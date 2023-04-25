using TMPro;
using UnityEngine;

public class UIPlay : MonoBehaviour
{
    #region Singleton
    public static UIPlay Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }
    #endregion

    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _namePlayer;
    [SerializeField] private TextMeshProUGUI _nameOpponent;

    public void Prepare() {
        switch (GameControl.Instance.Difficult) {
            case EDifficult.Easy:
                _title.text = "EASY";
                break;
            case EDifficult.Medium:
                _title.text = "MEDIUM";
                break;
            case EDifficult.Hard:
                _title.text = "HARD";
                break;
        }

        switch (GameControl.Instance.Mode) {
            case EMode.PvP:
                _namePlayer.text = "Player 1";
                _nameOpponent.text = "Player 2";
                break;
            case EMode.PvE:
                _namePlayer.text = "You";
                _nameOpponent.text = "AI";
                break;
        }
    }

    public void OnPauseButton() {
        UIPause.Instance.Open();
    }
}