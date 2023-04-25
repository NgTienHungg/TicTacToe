using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public enum EDifficult
{
    Easy,
    Medium,
    Hard
}

public enum EMode
{
    PvP,
    PvE
}

public class GameControl : MonoBehaviour
{
    #region  Singleton
    public static GameControl Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }
    #endregion

    public EMode Mode { get; private set; }

    public void SetMode(EMode mode) {
        this.Mode = mode;
    }

    public EDifficult Difficult { get; private set; }

    public void SetDifficult(EDifficult mode) {
        this.Difficult = mode;
    }

    public bool CanDraw { get; set; }

    public void RestartGame() {
        Board.Instance.Reset();
        WinLine.Instance.Reset();
        this.CanDraw = true;
        TurnBasedControl.Instance.StartWithPlayerTurn();
    }

    public void StartGame() {
        this.CanDraw = true;
        TurnBasedControl.Instance.StartWithPlayerTurn();
    }

    public async void HandleTurnAsync() {
        // lock để không click được vào các cell khác
        this.CanDraw = false;

        if (Board.Instance.HasWinner()) {
            bool isWin = TurnBasedControl.Instance.CurrentTurn == ETurn.Player;
            await UniTask.Delay(500);
            // chờ vẽ xong mới hiện pop up kết quả
            await WinLine.Instance.Draw();
            UIResult.Instance.ShowResult(isWin);
            return;
        }
        else if (Board.Instance.IsFull()) {
            await UniTask.Delay(800);
            UIResult.Instance.ShowDraw();
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