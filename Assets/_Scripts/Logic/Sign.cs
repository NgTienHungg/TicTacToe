using DG.Tweening;
using UnityEngine;

public enum ESign
{
    X,
    O
}

public class Sign : MonoBehaviour
{
    [Header("Assets")]
    [SerializeField] private Sprite _xSprite;
    [SerializeField] private Sprite _oSprite;

    private SpriteRenderer _renderer;
    public ESign Type { get; private set; }

    private void Awake() {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void Draw(ESign type) {
        Type = type;

        switch (type) {
            case ESign.X:
                _renderer.sprite = _xSprite;
                break;
            case ESign.O:
                _renderer.sprite = _oSprite;
                break;
        }

        this.Appear();
    }

    public void Hide() {
        _renderer.Fade(0f);
        transform.localScale = Vector3.zero;
    }

    public void Appear() {
        _renderer.DOFade(1f, 0.3f);
        transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack);
    }

    public static ESign SignOfTurn(ETurn turn) {
        if (turn == ETurn.Player)
            return ESign.X;
        else if (turn == ETurn.Opponent)
            return ESign.O;

        Debug.LogWarning("Turn.None => No Sign");
        return ESign.O;
    }
}