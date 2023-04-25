using UnityEngine;
using Cysharp.Threading.Tasks;

public enum ETurn
{
    Player,
    Opponent
}

public class TurnBasedControl : MonoBehaviour
{
    #region  Singleton
    public static TurnBasedControl Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }
    #endregion

    [SerializeField] private TurnLabelControl _labelControl;

    public ETurn CurrentTurn { get; private set; }

    public void StartWithPlayerTurn() {
        _labelControl.HighlightLabel(ETurn.Player);
        _labelControl.UnhighlighLabel(ETurn.Opponent);

        this.CurrentTurn = ETurn.Player;
    }

    public async UniTask SwitchTurnAsync() {
        _labelControl.UnhighlighLabel(CurrentTurn);

        // wait 0.3s: can't draw sign
        await UniTask.Delay(300);

        // change turn
        this.CurrentTurn = (CurrentTurn == ETurn.Player) ? ETurn.Opponent : ETurn.Player;

        _labelControl.HighlightLabel(CurrentTurn);

        if (GameControl.Instance.Mode == EMode.PvE && this.CurrentTurn == ETurn.Opponent) {
            AIControl.Instance.BestMove();
        }
    }
}