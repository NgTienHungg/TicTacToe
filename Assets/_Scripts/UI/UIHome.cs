using DG.Tweening;
using UnityEngine;

public class UIHome : MonoBehaviour
{
    #region Singleton
    public static UIHome Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }
    #endregion

    [SerializeField] private CanvasGroup _canvasGroup;

    private void Start() {
        GetComponent<CanvasGroup>().alpha = 1f;
    }

    public void Close() {
        gameObject.SetActive(false);
        _canvasGroup.DOFade(0f, 0.3f).OnComplete(() => {
            _canvasGroup.interactable = false;
        });
    }

    public void OnPvE() {
        GameControl.Instance.SetMode(EMode.PvE);
        UIDifficulty.Instance.Open();
    }

    public void OnPvP() {
        GameControl.Instance.SetMode(EMode.PvP);
        this.Close();
        GameControl.Instance.StartGame();
    }
}