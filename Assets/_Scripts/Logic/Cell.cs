using UnityEngine;

public class Cell : MonoBehaviour
{
    private BoxCollider2D _collider;
    private Sign _sign;

    private void Awake() {
        TryGetComponent(out _collider);
        TryGetComponent(out _sign);
    }

    private void Reset() {
        _collider.enabled = true;
    }

    public void SetupCell(float cellSize, int row, int col) {

    }

    private void OnMouseDown() {
        Debug.Log("Click");
        _collider.enabled = false;
        _sign.Draw(SignType.X);
    }
}