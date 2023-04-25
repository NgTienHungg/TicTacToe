using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIDifficulty : MonoBehaviour
{
    #region Singleton
    public static UIDifficulty Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }
    #endregion

    [SerializeField] private Image _blackBG;
    [SerializeField] private Popup _popup;
    [SerializeField] private Button _closeButton;

    private void Start() {
        GetComponent<CanvasGroup>().alpha = 1f;

        _blackBG.Fade(0f);

        _popup.Hide();

        _closeButton.gameObject.SetActive(false);
    }

    public void Open() {
        _blackBG.DOKill();
        _blackBG.DOFade(1f, 0.5f);

        _popup.Open();

        _closeButton.gameObject.SetActive(true);
    }

    public void Close() {
        _blackBG.DOKill();
        _blackBG.DOFade(0f, 0.3f).OnComplete(() => {
            _blackBG.raycastTarget = false;
        });

        _popup.Close();

        _closeButton.gameObject.SetActive(false);
    }

    public void OnEasyMode() {
        GameControl.Instance.SetDifficult(EDifficult.Easy);
        StartPlayGame();
    }

    public void OnMediumMode() {
        GameControl.Instance.SetDifficult(EDifficult.Medium);
        StartPlayGame();
    }

    public void OnHardMode() {
        GameControl.Instance.SetDifficult(EDifficult.Hard);
        StartPlayGame();
    }

    private void StartPlayGame() {
        this.Close();
        UIHome.Instance.Close();
        UIPlay.Instance.Prepare();
        UIResult.Instance.Prepare();
        GameControl.Instance.StartGame();
    }

    public void OnCloseButton() {
        this.Close();
    }
}