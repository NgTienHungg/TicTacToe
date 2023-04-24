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
    public static readonly int LINE = 3;

    [Header("Cells")]
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private Transform _cellHolder;
    [SerializeField] private float _cellSize = 3.2f;

    private Cell[,] _cellMatrix;

    private void Start() {
        this.InitCells();
    }

    private void InitCells() {
        _cellMatrix = new Cell[3, 3];

        for (int r = 0; r < SIZE; r++) {
            for (int c = 0; c < SIZE; c++) {
                _cellMatrix[r, c] = Instantiate(_cellPrefab, _cellHolder).GetComponent<Cell>();
                _cellMatrix[r, c].gameObject.name = $"Cell row {r + 1} - col {c + 1}";
                _cellMatrix[r, c].SetPosInBoard(_cellSize, r, c);
            }
        }
    }

    public bool IsEndGame() {
        ESign currentSign = Sign.SignOfTurn(TurnBasedControl.Instance.CurrentTurn);
        if (HasHorizontalLine(currentSign) || HasVerticalLine(currentSign) || HasDiagonalLine(currentSign)) {
            return true;
        }
        return false;
    }

    #region Check line in board
    private bool HasHorizontalLine(ESign sign) {
        for (int r = 0; r < SIZE; r++) {
            int count = 0;
            for (int c = 0; c < SIZE; c++) {
                if (_cellMatrix[r, c].HasSign && _cellMatrix[r, c].Sign.Type == sign) {
                    count++;
                }
            }
            Debug.Log("hang " + (r + 1) + " co " + count);
            if (count == LINE) {
                Debug.Log($"<color=lime> Has horizontal line in row {r + 1}</color>");
                return true;
            }
        }
        return false;
    }

    private bool HasVerticalLine(ESign sign) {
        for (int c = 0; c < SIZE; c++) {
            int count = 0;
            for (int r = 0; r < SIZE; r++) {
                if (_cellMatrix[r, c].HasSign && _cellMatrix[r, c].Sign.Type == sign) {
                    count++;
                }
            }
            if (count == LINE) {
                Debug.Log($"<color=lime> Has vertical line in col {c + 1}</color>");
                return true;
            }
        }
        return false;
    }

    private bool HasDiagonalLine(ESign sign) {
        int cheoXuoi = 0, cheoNguoc = 0;
        for (int i = 0; i < 3; i++) {
            if (_cellMatrix[i, i].HasSign && _cellMatrix[i, i].Sign.Type == sign) {
                cheoXuoi++;
            }
            if (_cellMatrix[i, 2 - i].HasSign && _cellMatrix[i, 2 - i].Sign.Type == sign) {
                cheoNguoc++;
            }
        }
        if (cheoXuoi == LINE || cheoNguoc == LINE) {
            Debug.Log($"<color=lime> Has diagonal line </color>");
            return true;
        }
        return false;
    }
    #endregion
}