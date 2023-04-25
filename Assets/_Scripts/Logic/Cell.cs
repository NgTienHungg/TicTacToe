using UnityEngine;

public class Cell : MonoBehaviour
{
    private BoxCollider2D _collider;
    public bool HasSign { get; private set; }
    public Sign Sign { get; private set; }

    private void Awake() {
        _collider = GetComponent<BoxCollider2D>();
        this.Sign = GetComponentInChildren<Sign>();
    }

    private void Start() {
        this.Reset();
    }

    public void Reset() {
        _collider.enabled = true;
        this.HasSign = false;
        this.Sign.Hide();
    }

    public void SetPosInBoard(float cellSize, int row, int col) {
        float localX = ((col + 0.5f) - Board.SIZE / 2f) * cellSize;
        float localY = (Board.SIZE / 2f - (row + 0.5f)) * cellSize;
        transform.localPosition = new Vector3(localX, localY);
    }

    private void OnMouseDown() {
        if (!GameControl.Instance.CanDraw)
            return;

        if (GameControl.Instance.Mode == EMode.PvE && TurnBasedControl.Instance.CurrentTurn == ETurn.Opponent)
            return;

        // Player draw
        this.Draw(Sign.SignOfTurn(TurnBasedControl.Instance.CurrentTurn));

        // handle turn
        GameControl.Instance.HandleTurnAsync();
    }

    public void Draw(ESign sign) {
        // disable collider to can't click on this cell again
        _collider.enabled = false;

        // draw sign follow current turn
        this.Sign.Draw(sign);
        this.HasSign = true;
    }
}