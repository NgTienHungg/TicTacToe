using DG.Tweening;
using UnityEngine;

public class TurnLabelControl : MonoBehaviour
{
    [Space]
    [SerializeField] private CanvasGroup _playerCanvas;
    [SerializeField] private CanvasGroup _opponentCanvas;

    [Space]
    [SerializeField] private float _highlightAlpha = 1f;
    [SerializeField] private float _unhighlightAlpha = 0.5f;

    [Space]
    [SerializeField] private float _highlightScale = 1.2f;
    [SerializeField] private float _unhighlightScale = 1f;

    [Space]
    [SerializeField] private float _duration = 0.5f;

    public void HighlightLabel(ETurn turn) {
        if (turn == ETurn.Player) {
            // fade
            _playerCanvas.DOKill();
            _playerCanvas.DOFade(_highlightAlpha, _duration);

            // scale
            _playerCanvas.transform.DOKill();
            _playerCanvas.transform.DOScale(_highlightScale, _duration).SetEase(Ease.OutQuart);
        }
        else {
            _opponentCanvas.DOKill();
            _opponentCanvas.DOFade(_highlightAlpha, _duration);

            _opponentCanvas.transform.DOKill();
            _opponentCanvas.transform.DOScale(_highlightScale, _duration).SetEase(Ease.OutQuart);
        }
    }

    public void UnhighlighLabel(ETurn turn) {
        if (turn == ETurn.Player) {
            _playerCanvas.DOKill();
            _playerCanvas.DOFade(_unhighlightAlpha, _duration);

            _playerCanvas.transform.DOKill();
            _playerCanvas.transform.DOScale(_unhighlightScale, _duration).SetEase(Ease.InQuart);
        }
        else {
            _opponentCanvas.DOKill();
            _opponentCanvas.DOFade(_unhighlightAlpha, _duration);

            _opponentCanvas.transform.DOKill();
            _opponentCanvas.transform.DOScale(_unhighlightScale, _duration).SetEase(Ease.InQuart);
        }
    }
}