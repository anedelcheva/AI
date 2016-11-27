using System;
using System.Linq;

namespace TicTacToe
{
    static class TicTacToe
    {
        public static char[] Xwins = { 'X', 'X', 'X' };
        public static char[] Owins = { 'O', 'O', 'O' };

        #region ValuesForLeafNodes

        private const int VICTORY = 100;
        private const int LOSS = -100;
        private const int DRAW = 0; 

        #endregion

        private const char YOU_PLAYER = 'X';
        private const char COMPUTER_PLAYER = 'O';
        private const char EMPTY_CELL = '_';
        private const char EQUAL = '=';

        /// <summary>
        /// Checks whether a certain board is in terminal state
        /// </summary>
        /// <param name="board">char matrix</param>
        /// <returns>
        /// -> YOU_PLAYER if you win
        /// -> COMPUTER_PLAYER if computer wins
        /// -> EMPTY_CELL if the state is not terminal
        /// -> EQUAL if it is a draw and nobody wins
        /// </returns>
        private static char CheckForGameOver(this char[,] board)
        {
            char[,] boardTransposed = board.TransposeBoard();
            for (int rowNumber = 0; rowNumber < board.GetLength(0); rowNumber++)
            {
                // check horizontals
                if (board.TakeRow(rowNumber).SequenceEqual(Xwins) ||
                    boardTransposed.TakeRow(rowNumber).SequenceEqual(Xwins))
                    return YOU_PLAYER;

                // check verticals
                if (board.TakeRow(rowNumber).SequenceEqual(Owins) ||
                    boardTransposed.TakeRow(rowNumber).SequenceEqual(Owins))
                    return COMPUTER_PLAYER;
            }

            // check if you win in main diagonal
            if (board.IsWinnerInMainDiagonal(YOU_PLAYER))
                return YOU_PLAYER;

            // check if computer wins in main diagonal
            if (board.IsWinnerInMainDiagonal(COMPUTER_PLAYER))
                return COMPUTER_PLAYER;

            // check if you win in secondary diagonal
            if (board.IsWinnerInSecondaryDiagonal(YOU_PLAYER))
                return YOU_PLAYER;

            // check if computer wins in secondary diagonal
            if (board.IsWinnerInSecondaryDiagonal(COMPUTER_PLAYER))
                return COMPUTER_PLAYER;

            // check whether state is not terminal
            char[] boardInArray = board.Cast<char>().ToArray();
            for (int i = 0; i < board.Length; i++)
                if (boardInArray[i] == EMPTY_CELL)
                    return EMPTY_CELL;

            // it's a draw
            return EQUAL;
        }

        // You move by entering a position in the format row col 
        public static char[,] PlayerMoves(this char[,] board)
        {
            Tuple<int, int> xy = board.EnterAMove();
            int x = xy.Item1;
            int y = xy.Item2;
            while (x < 0 || y < 0 || y >= board.GetLength(1) || x >= board.GetLength(0) ||
                   board[x, y] == YOU_PLAYER || board[x, y] == COMPUTER_PLAYER)
            {
                xy = board.EnterAMove();
                x = xy.Item1;
                y = xy.Item2;
            }
            board[x, y] = YOU_PLAYER;
            return board;
        }

        // Minimax with alpha-beta pruning algorithm used by computer to predict its moves
        public static int MinimaxWithAlphaBetaPruning(this char[,] board, char player, int alpha, int beta)
        {
            char terminalState = board.CheckForGameOver();
            if (terminalState != EMPTY_CELL) // board[,] is a leaf, we are in a terminal state
            {
                if (terminalState == EQUAL)
                    return DRAW;
                else
                    if (terminalState == YOU_PLAYER) // if you win
                    return VICTORY;
                else // if computer wins
                    return LOSS;
            }
            else // board[,] is NOT a leaf, the state is not terminal
            {
                char nextPlayer;
                if (player == YOU_PLAYER)
                    nextPlayer = COMPUTER_PLAYER;
                else
                    nextPlayer = YOU_PLAYER;

                int newAlpha = alpha, newBeta = beta;
                int value;

                if (player == COMPUTER_PLAYER) // board[,] is a node for minimizing your score
                {
                    for (int x = 0; x < 3; x++)
                        for (int y = 0; y < 3; y++)
                            if (board[x, y] == EMPTY_CELL)
                            {
                                board[x, y] = COMPUTER_PLAYER;
                                value = board.MinimaxWithAlphaBetaPruning(nextPlayer, newAlpha, newBeta);
                                board[x, y] = EMPTY_CELL;
                                newBeta = Math.Min(newBeta, value); 
                                // beta pruning
                                if (newBeta <= newAlpha)
                                    break;
                            }
                    return newBeta;
                }
                else // You are the player and board[,] is a node for maximizing
                {
                    for (int x = 0; x < 3; x++)
                        for (int y = 0; y < 3; y++)
                            if (board[x, y] == EMPTY_CELL)
                            {
                                board[x, y] = YOU_PLAYER;
                                value = board.MinimaxWithAlphaBetaPruning(nextPlayer, newAlpha, newBeta);
                                board[x, y] = EMPTY_CELL;
                                newAlpha = Math.Max(newAlpha, value); 
                                // alpha pruning
                                if (newAlpha >= newBeta)
                                    break;
                            }
                    return newAlpha;
                }
            }
        }

        public static void PrintBoard(this char[,] board)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                    Console.Write("{0} ", board[x, y]);
                Console.WriteLine();
            }
        }

        public static void PlayGame(this char[,] board)
        {
            board.FillWithEmptyCells();
            board.PrintBoard();
            bool isGameOver = false;
            int xForO = 0, yForO = 0;
            while (!isGameOver)
            {
                board.PlayerMoves();
                int minResult = int.MaxValue;
                int result;
                for (int x = 0; x < 3; x++)
                    for (int y = 0; y < 3; y++)
                        if (board[x, y] == EMPTY_CELL)
                        {
                            board[x, y] = COMPUTER_PLAYER;
                            result = board.MinimaxWithAlphaBetaPruning(YOU_PLAYER, int.MinValue, int.MaxValue);
                            if (result < minResult)
                            {
                                minResult = result;
                                xForO = x;
                                yForO = y;
                            }
                            board[x, y] = EMPTY_CELL;
                        }
                board[xForO, yForO] = COMPUTER_PLAYER;

                Console.Clear();
                board.PrintBoard();

                char terminalState = board.CheckForGameOver();
                if (terminalState != EMPTY_CELL)
                {
                    if (terminalState == YOU_PLAYER)
                        Console.WriteLine("You win!");
                    else if (terminalState == COMPUTER_PLAYER)
                        Console.WriteLine("Computer wins!");
                    else
                        Console.WriteLine("It's a draw!");
                    isGameOver = true;
                }
            }
        }

        #region HelperMethods

        public static void FillWithEmptyCells(this char[,] board)
        {
            for (int x = 0; x < board.GetLength(0); x++)
                for (int y = 0; y < board.GetLength(1); y++)
                    board[x, y] = EMPTY_CELL;
        }

        private static char[] TakeRow(this char[,] board, int rowNumber)
        {
            return board.Cast<char>().Skip(rowNumber * 3).Take(3).ToArray();
        }

        private static bool IsWinnerInMainDiagonal(this char[,] board, char XorO)
        {
            for (int i = 0; i < board.GetLength(0); i++)
                if (board[i, i] != XorO)
                    return false;
            return true;
        }

        private static bool IsWinnerInSecondaryDiagonal(this char[,] board, char XorO)
        {
            if (board[0, 2] == XorO &&
                board[1, 1] == XorO &&
                board[2, 0] == XorO)
                return true;
            else
                return false;
        }

        private static char[,] TransposeBoard(this char[,] board)
        {
            int rowsNum = board.GetLength(0);
            int colsNum = board.GetLength(1);
            char[,] boardTransposed = new char[rowsNum, colsNum];
            for (int col = 0; col < colsNum; col++)
                for (int row = 0; row < rowsNum; row++)
                    boardTransposed[row, col] = board[col, row];
            return boardTransposed;
        }

        // Position is in the format row col where row, col = 1, 2, 3
        private static Tuple<int, int> EnterAMove(this char[,] board)
        {
            Console.Write("Enter a position: ");
            int[] move = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int x = move[0] - 1;
            int y = move[1] - 1;
            return Tuple.Create(x, y);
        }

        #endregion

        static void Main(string[] args)
        {
            char[,] board = new char[3, 3];
            board.PlayGame();
        }
    }
}