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

    private void Start() {
        _blackPanel.Fade(0f);
        _blackPanel.raycastTarget = false;

        _winPopup.Hide();
        _losePopup.Hide();
    }

    public void Show(bool isWin) {
        _blackPanel.raycastTarget = true;
        _blackPanel.DOKill();
        _blackPanel.DOFade(1f, 0.5f);

        if (isWin)
            _winPopup.Open();
        else
            _losePopup.Open();
    }

    public void Hide() {
        if (_winPopup.gameObject.activeInHierarchy)
            _winPopup.Hide();
        else
            _losePopup.Hide();
    }
}