using TMPro;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIResult : MonoBehaviour
{
    #region Singleton
    public static UIResult Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }
    #endregion

    [Space]
    [SerializeField] private Image _blackPanel;

    [Space]
    [SerializeField] private Popup _winPopup;
    [SerializeField] private Popup _losePopup;
    [SerializeField] private Popup _drawPopup;

    [Space]
    [SerializeField] private TextMeshProUGUI _winTitle;
    [SerializeField] private TextMeshProUGUI _loseTitle;
    [SerializeField] private TextMeshProUGUI _drawTitle;

    private void Start() {
        GetComponent<CanvasGroup>().alpha = 1f;

        _blackPanel.Fade(0f);
        _blackPanel.raycastTarget = false;

        _winPopup.Hide();
        _losePopup.Hide();
        _drawPopup.Hide();
    }

    public void Prepare() {
        switch (GameControl.Instance.Mode) {
            case EMode.PvP:
                _winTitle.text = "Player 1 win!";
                _loseTitle.text = "Player 1 lose!";
                _drawTitle.text = "You draw!";
                break;
            case EMode.PvE:
                _winTitle.text = "You win!";
                _loseTitle.text = "You lose!";
                _drawTitle.text = "You draw!";
                break;
        }
    }

    public void ShowDraw() {
        _blackPanel.raycastTarget = true;
        _blackPanel.DOKill();
        _blackPanel.DOFade(1f, 0.5f);

        _drawPopup.Open();
    }

    public void ShowResult(bool isWin) {
        _blackPanel.raycastTarget = true;
        _blackPanel.DOKill();
        _blackPanel.DOFade(1f, 0.5f);

        if (isWin)
            _winPopup.Open();
        else
            _losePopup.Open();
    }

    public void Close() {
        _blackPanel.DOKill();
        _blackPanel.DOFade(0f, 0.5f).OnComplete(() => {
            _blackPanel.raycastTarget = false;
        });

        if (_winPopup.gameObject.activeInHierarchy)
            _winPopup.Close();
        if (_losePopup.gameObject.activeInHierarchy)
            _losePopup.Close();
        if (_drawPopup.gameObject.activeInHierarchy)
            _drawPopup.Close();
    }

    public void OnReplayButton() {
        //GameControl.Instance.ReloadScene();
        this.Close();
        GameControl.Instance.RestartGame();
    }

    public void OnHomeButton() {
        GameControl.Instance.ReloadScene();
    }
}