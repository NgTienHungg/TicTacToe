using System.Collections.Generic;
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

    public bool IsFull() {
        for (int i = 0; i < SIZE; i++) {
            for (int j = 0; j < SIZE; j++) {
                if (!_cellMatrix[i, j].HasSign) {
                    return false;
                }
            }
        }
        return true;
    }

    public bool HasWinner() {
        ESign currentSign = Sign.SignOfTurn(TurnBasedControl.Instance.CurrentTurn);
        Vector3 _linePos;
        if (HasHorizontalLine(currentSign, out _linePos)) {
            WinLine.Instance.Prepare(ELine.Horizontal, _linePos);
            return true;
        }
        else if (HasVerticalLine(currentSign, out _linePos)) {
            WinLine.Instance.Prepare(ELine.Vertical, _linePos);
            return true;
        }
        else if (HasCrossLine1(currentSign)) {
            WinLine.Instance.Prepare(ELine.Cross1, _cellMatrix[1, 1].transform.position);
            return true;
        }
        else if (HasCrossLine2(currentSign)) {
            WinLine.Instance.Prepare(ELine.Cross2, _cellMatrix[1, 1].transform.position);
            return true;
        }
        return false;
    }

    #region Check line in board
    private bool HasHorizontalLine(ESign sign, out Vector3 linePos) {
        for (int r = 0; r < SIZE; r++) {
            int count = 0;
            for (int c = 0; c < SIZE; c++) {
                if (_cellMatrix[r, c].HasSign && _cellMatrix[r, c].Sign.Type == sign) {
                    count++;
                }
            }
            if (count == LINE) {
                Debug.Log($"<color=lime> An hang ngang tai hang: {r + 1}</color>");
                linePos = _cellMatrix[r, SIZE / 2].transform.position; //!
                return true;
            }
        }
        linePos = Vector3.zero;
        return false;
    }

    private bool HasVerticalLine(ESign sign, out Vector3 linePos) {
        for (int c = 0; c < SIZE; c++) {
            int count = 0;
            for (int r = 0; r < SIZE; r++) {
                if (_cellMatrix[r, c].HasSign && _cellMatrix[r, c].Sign.Type == sign) {
                    count++;
                }
            }
            if (count == LINE) {
                Debug.Log($"<color=lime> An hang doc tai cot: {c + 1}</color>");
                linePos = _cellMatrix[SIZE / 2, c].transform.position; //!
                return true;
            }
        }
        linePos = Vector3.zero;
        return false;
    }

    private bool HasCrossLine1(ESign sign) {
        int count = 0;
        for (int i = 0; i < 3; i++) {
            if (_cellMatrix[i, i].HasSign && _cellMatrix[i, i].Sign.Type == sign) {
                count++;
            }
        }
        if (count == LINE) {
            Debug.Log("<color=lime> An hang cheo xuoi </color>");
            return true;
        }
        return false;
    }

    public bool HasCrossLine2(ESign sign) {
        int count = 0;
        for (int i = 0; i < 3; i++) {
            if (_cellMatrix[i, SIZE - 1 - i].HasSign && _cellMatrix[i, SIZE - 1 - i].Sign.Type == sign) {
                count++;
            }
        }
        if (count == LINE) {
            Debug.Log("<color=lime> An hang cheo nguoc </color>");
            return true;
        }
        return false;
    }
    #endregion

    //---------- AI

    public int[,] ConvertBoard() {
        int[,] board = new int[3, 3];
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                if (_cellMatrix[i, j].HasSign) {
                    board[i, j] = _cellMatrix[i, j].Sign.Type == ESign.X ? 1 : 2;
                }
                else {
                    board[i, j] = 0;
                }
            }
        }
        return board;
    }

    public void Draw(int row, int col, ESign sign) {
        _cellMatrix[row, col].Draw(sign);
    }

    public List<Vector2Int> GetListEmptyPos() {
        List<Vector2Int> listPos = new List<Vector2Int>();
        for (int i = 0; i < SIZE; i++) {
            for (int j = 0; j < SIZE; j++) {
                if (!_cellMatrix[i, j].HasSign) {
                    listPos.Add(new Vector2Int(i, j));
                }
            }
        }
        return listPos;
    }
}