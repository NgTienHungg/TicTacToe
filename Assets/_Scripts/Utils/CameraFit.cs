using UnityEngine;

public class CameraFit : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _rink;

    private void Start() {
        Camera.main.orthographicSize = _rink.bounds.size.x * Screen.height / Screen.width * 0.5f;
    }
}