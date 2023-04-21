using UnityEngine;

public class Board : MonoBehaviour
{
    #region Singleton
    public static Board Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }
    #endregion

    public static readonly int SIZE = 3;

    [Header("Cells")]
    [SerializeField] private GameObject _cellPrefab;
    public Cell[,] _cellMatrix;

    private void Start() {
        this.InitCells();
    }

    private void InitCells() {
        _cellMatrix = new Cell[SIZE, SIZE];

        for (int r = 0; r < 3; r++) {
            for (int c = 0; c < 3; c++) {
                _cellMatrix[r, c] = Instantiate(_cellPrefab).GetComponent<Cell>();
            }
        }
    }
}