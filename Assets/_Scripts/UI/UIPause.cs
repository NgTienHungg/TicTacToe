using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIPause : MonoBehaviour
{
    #region Singleton
    public static UIPause Instance { get; private set; }

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
    }

    public void Open() {
        gameObject.SetActive(true);

        _blackBG.DOKill();
        _blackBG.DOFade(1f, 0.5f);

        _popup.Open();

        _closeButton.interactable = true;
    }

    public void Close() {
        _blackBG.DOKill();
        _blackBG.DOFade(0f, 0.3f).OnComplete(() => {
            _blackBG.raycastTarget = false;
            gameObject.SetActive(false);
        });

        _popup.Close();

        _closeButton.interactable = false;
    }

    public void OnReplayButton() {
        GameControl.Instance.ReloadScene();
    }

    public void OnHomeButton() {
        GameControl.Instance.ReloadScene();
    }

    public void OnCloseButton() {
        this.Close();
    }
}