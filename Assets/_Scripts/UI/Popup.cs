using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Popup : MonoBehaviour
{
    [SerializeField] private float _openDuration = 0.5f;
    [SerializeField] private float _closeDuration = 0.3f;

    private CanvasGroup _canvasGroup;

    private void Awake() {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Hide() {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        transform.localScale = Vector3.one * 0.5f;
        gameObject.SetActive(false);
    }

    public void Open() {
        gameObject.SetActive(true);

        _canvasGroup.DOKill();
        _canvasGroup.DOFade(1f, _openDuration).OnComplete(() => {
            _canvasGroup.interactable = true;
        });

        transform.DOKill();
        transform.DOScale(1f, _openDuration).SetEase(Ease.OutBack);
    }

    public void Close() {
        _canvasGroup.interactable = false;
        _canvasGroup.DOKill();
        _canvasGroup.DOFade(0f, _closeDuration).OnComplete(() => {
            gameObject.SetActive(false);
        });

        transform.DOKill();
        transform.DOScale(0.5f, _closeDuration).SetEase(Ease.InBack);
    }
}