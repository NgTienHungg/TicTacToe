using UnityEngine;
using Cysharp.Threading.Tasks;

public class AIControl : MonoBehaviour
{
    #region Singleton
    public static AIControl Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }
    #endregion

    private readonly int none = 0;
    private readonly int human = 1;
    private readonly int ai = 2;

    public int[,] board = new int[3, 3];

    public async void BestMove() {
        int bestScore = int.MinValue;
        Vector2Int move = Vector2Int.zero;

        // Nếu mode chơi là Easy thì sẽ cho AI đi random 
        if (GameControl.Instance.Difficult == EDifficult.Easy) {
            move = Board.Instance.GetListEmptyPos().Rand();
            goto Draw;
        }

        // AI to make its turn
        board = Board.Instance.ConvertBoard();
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                // Is the spot available?
                if (board[i, j] == none) {

                    // Đánh dấu là sẽ đi nước náy
                    board[i, j] = ai;

                    // Kiểm tra xem Mode chơi hiện tại đang ở mức nào để quyết định thuật toán sử dụng
                    int score = 0;
                    if (GameControl.Instance.Difficult == EDifficult.Medium)
                        score = Minimax(board, false);
                    else if (GameControl.Instance.Difficult == EDifficult.Hard)
                        score = Minimax(board, 0, false);

                    // reset coi như chưa đi, duyệt thử tiếp các nước khác
                    board[i, j] = none;

                    // Cập nhật điểm và nước đi tốt nhất
                    if (score > bestScore) {
                        bestScore = score;
                        move = new Vector2Int(i, j);
                    }
                }
            }
        }

        Debug.Log("best move : " + (move.x + 1) + " _ " + (move.y + 1) + " _ best score : " + bestScore);

    Draw: // Chờ 0.5s sau đó đi nước tốt nhất theo thuật toán
        await UniTask.Delay(500);
        Board.Instance.Draw(move.x, move.y, ESign.O);
        GameControl.Instance.HandleTurnAsync();
    }

    public enum EResult
    {
        Player = -10,
        AI = +10,
        Tie = 0,
        Null = -99
    }

    #region Minamax with depth
    public int Minimax(int[,] board, int depth, bool isMaximizing) {
        EResult result = GetWinner();
        if (result != EResult.Null) {
            // nếu đã tìm được người chiến thắng || hoà thì kết thúc đệ quy
            return (int)result - depth;
        }

        if (isMaximizing) {
            // duyệt với lượt chơi của AI
            int bestScore = int.MinValue;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (board[i, j] == none) {
                        board[i, j] = ai;
                        int score = Minimax(board, depth + 1, false);
                        board[i, j] = none;
                        bestScore = Mathf.Max(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
        else {
            // duyệt với lượt chơi của Human
            int bestScore = int.MaxValue;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (board[i, j] == none) {
                        board[i, j] = human;
                        int score = Minimax(board, depth + 1, true);
                        board[i, j] = none;
                        bestScore = Mathf.Min(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
    }
    #endregion

    #region Minamax without depth
    public int Minimax(int[,] board, bool isMaximizing) {
        EResult result = GetWinner();
        if (result != EResult.Null) {
            // nếu đã tìm được người chiến thắng || hoà thì kết thúc đệ quy
            return (int)result;
        }

        if (isMaximizing) {
            // duyệt với lượt chơi của AI
            int bestScore = int.MinValue;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (board[i, j] == none) {
                        board[i, j] = ai;
                        int score = Minimax(board, false);
                        board[i, j] = none;
                        bestScore = Mathf.Max(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
        else {
            // duyệt với lượt chơi của Human
            int bestScore = int.MaxValue;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (board[i, j] == none) {
                        board[i, j] = human;
                        int score = Minimax(board, true);
                        board[i, j] = none;
                        bestScore = Mathf.Min(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
    }
    #endregion

    private EResult GetWinner() {
        EResult winner = EResult.Null;
        #region check winner
        for (int i = 0; i < 3; i++) {
            if (board[i, 0] != none && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2]) {
                winner = board[i, 0] == human ? EResult.Player : EResult.AI;
            }
            if (board[0, i] != none && board[0, i] == board[1, i] && board[1, i] == board[2, i]) {
                winner = board[0, i] == human ? EResult.Player : EResult.AI;
            }
        }
        if (board[0, 0] != none && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) {
            winner = board[0, 0] == human ? EResult.Player : EResult.AI;
        }
        if (board[0, 2] != none && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]) {
            winner = board[0, 2] == human ? EResult.Player : EResult.AI;
        }
        #endregion

        int openSpots = 0;
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                if (board[i, j] == none) {
                    openSpots++;
                }
            }
        }

        if (winner == EResult.Null && openSpots == 0) {
            return EResult.Tie;
        }
        return winner;
    }
}