using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    #region  Singleton
    public static GameControl Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }
    #endregion

    public bool CanDraw { get; private set; }

    private async void Start() {
        Debug.Log("<color=orange> Init game </color>");
        await UniTask.DelayFrame(5);
        Debug.Log("<color=yellow> Start game </color>");

        this.CanDraw = true;
        TurnBasedControl.Instance.StartWithPlayerTurn();
    }

    public async void HandleTurnAsync() {
        Debug.Log("handle");

        // lock để không click được vào các cell khác
        this.CanDraw = false;

        // check xem có hàng nào được ăn không
        bool endGame = Board.Instance.IsEndGame();
        if (endGame) {
            bool isWin = TurnBasedControl.Instance.CurrentTurn == ETurn.Player;
            UIResult.Instance.Show(isWin);
            return;
        }

        // wait switch turn => can draw
        await TurnBasedControl.Instance.SwitchTurnAsync();
        this.CanDraw = true;
    }

    public void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}