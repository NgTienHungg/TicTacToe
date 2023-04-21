using UnityEngine;

public class CellManager : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private float _cellSize = 3f;

    private Cell[,] _cellMatrix;

    private void Awake() {
        this.InitCells();
    }

    private void InitCells() {
        _cellMatrix = new Cell[Board.SIZE, Board.SIZE];

        for (int r = 0; r < 3; r++) {
            for (int c = 0; c < 3; c++) {
                _cellMatrix[r, c] = Instantiate(_cellPrefab).GetComponent<Cell>();
            }
        }
    }
}