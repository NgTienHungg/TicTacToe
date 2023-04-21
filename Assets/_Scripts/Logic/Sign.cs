using UnityEngine;

public enum SignType
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

    private void Awake() {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void Draw(SignType type) {
        switch (type) {
            case SignType.X:
                _renderer.sprite = _xSprite;
                break;
            case SignType.O:
                _renderer.sprite = _oSprite;
                break;
        }
    }
}