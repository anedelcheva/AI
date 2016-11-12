using System;
using System.Linq;

namespace Queens2
{
    static class ExtensionMethods
    {
        #region MethodsForConflicts

        #region MethodsForConflictsInDirections

        private static int HorizontalConflicts(this int[] board, int column, int row)
        {
            int conflicts = 0;
            //int row = board[column];
            for (int col = 1; col < board.Length; col++)
            {
                if (col == column)
                    continue;
                if (board[col] == row)
                    conflicts++;
            }
            return conflicts;
        }

        private static int FirstDiagonalConflicts(this int[] board, int column, int row)
        {
            int conflicts = 0;
            int beginRow = row;
            int beginCol = column;
            while (beginRow > 1 && beginCol > 1)
            {
                beginRow--;
                beginCol--;
            }
            for (int col = beginCol; col < board.Length; col++)
            {
                if (col == column)
                {
                    beginRow++;
                    continue;
                }
                if (board[col] == beginRow)
                    conflicts++;
                beginRow++;
            }
            return conflicts;
        }

        private static int SecondaryDiagonalConflicts(this int[] board, int column, int row)
        {
            int conflicts = 0;
            int beginRow = row;
            int beginCol = column;
            while (beginRow > 1 && beginCol < board.Length - 1)
            {
                beginRow--;
                beginCol++;
            }
            for (int col = beginCol; col >= 1; col--)
            {
                if (col == column)
                {
                    beginRow++;
                    continue;
                }
                if (board[col] == beginRow)
                    conflicts++;
                beginRow++;
            }
            return conflicts;
        }

        #endregion

        /// <summary>
        /// Returns all conflicts of queen in its current position
        /// </summary>
        /// <param name="board">board we compute conflicts for</param>
        /// <param name="column">column of queen</param>
        /// <param name="row">row of queen</param>
        /// <returns>an array with conflicts in every row
        /// where an index represents the row</returns>
        private static int AllConflictsOfQueen(this int[] board, int column, int row)
        {
            int conflicts = board.HorizontalConflicts(column, row);
            conflicts += board.FirstDiagonalConflicts(column, row);
            conflicts += board.SecondaryDiagonalConflicts(column, row);
            return conflicts;
        }

        /// <summary>
        /// Computes conflicts in all rows in a given column
        /// </summary>
        /// <param name="board">board where queens are located index=column, board[column]=row</param>
        /// <param name="column">column where queen is located</param>
        /// <param name="row">row where queen is located</param>
        /// <returns>an array with number of conflicts in every row 
        /// where index is the number of conflicts in row</returns>
        private static int[] ConflictsInAllRows(this int[] board, int column, int row)
        {
            int[] conflicts = new int[board.Length];
            for (int curRow = 1; curRow < board.Length; curRow++)
                conflicts[curRow] = board.AllConflictsOfQueen(column, curRow);
            return conflicts;
        }

        /// <summary>
        /// Finds all rows with min conflicts in a column
        /// </summary>
        /// <param name="board">board where queens are located index=column, board[column]=row</param>
        /// <param name="column">column where queen is located</param>
        /// <param name="row">row where queen is located</param>
        /// <returns>an array with rows with min conflicts</returns>
        private static int[] MinConflicts(this int[] board, int column, int row)
        {
            int[] conflicts = board.ConflictsInAllRows(column, row);
            conflicts[0] = int.MaxValue;
            int min = Array.IndexOf(conflicts, conflicts.Min());
            // finds the rows with min conflicts
            int[] minConflicts = Enumerable.Range(1, conflicts.Length - 1)
                                        .Where(everyRow => conflicts[everyRow] == conflicts.Min())
                                        .ToArray();
            return minConflicts;
        }

        #endregion

        #region MethodsForBoardPrinting

        /// <summary>
        /// Prints * if there's a queen, _ if there's a blank space
        /// We can't visualize a board of dimension > 43
        /// </summary>
        /// <param name="board">an array representing a board</param>
        private static void PrintBoard(this int[] board)
        {
            for (int row = 1; row < board.Length; row++)
            {
                for (int col = 1; col < board.Length; col++)
                    if (board[col] == row)
                        Console.Write("* ");
                    else
                        Console.Write("_ ");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prints queens' coordinates separated with ;
        /// Used when queens number > 43
        /// </summary>
        /// <param name="board">an array representing a board</param>
        private static void PrintQueensCoordinates(this int[] board)
        {
            string[] allCoordinates = board.PutQueensCoordinates();
            Console.WriteLine(String.Join("; ", allCoordinates));
        } 

        #endregion

        /// <summary>
        /// Situating N number of queens so that there're no conflicts
        /// between any 2 of them using the MinConflicts algorithm
        /// </summary>
        /// <param name="board">an array representing a board</param>
        /// <param name="max_iter">the number of steps allowed before giving up</param>
        public static void NQueens(this int[] board, int max_iter)
        {
            while (!board.IsSolution())
            {
                board.PutQueensInDiagonal();
                int i = 0;
                int[] minConflicts;
                int randomRow;
                while (i++ < max_iter)
                {
                    for (int col = 1; col < board.Length; col++)
                    {
                        minConflicts = board.MinConflicts(col, board[col]);
                        randomRow = board.ChooseRandomRowFrom(minConflicts);
                        board.MoveQueen(col, randomRow);
                    }
                    if (board.IsSolution())
                    {
                        if (board.Length - 1 <= 43)
                            board.PrintBoard();
                        else
                            board.PrintQueensCoordinates();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Finds whether there are no conflicts on board
        /// </summary>
        /// <param name="board">an array representing a board</param>
        /// <returns>true if there are no conflicts, false-otherwise</returns>
        private static bool IsSolution(this int[] board)
        {
            for (int col = 1; col < board.Length; col++)
                if (board.AllConflictsOfQueen(col, board[col]) != 0)
                    return false;
            return true;
        }

        /// <summary>
        /// Puts board.Length - 1 number of queens on board
        /// </summary>
        /// <param name="board">an array whose indices=columns 
        /// and its values=rows of a queen on board</param>
        /// <returns>an array representing the board</returns>
        private static int[] PutQueensInDiagonal(this int[] board)
        {
            for (int col = 1; col < board.Length; col++)
                board[col] = col;
            return board;
        }

        /// <summary>
        /// Puts a queen to a new row by assigning a new value to board[column]
        /// </summary>
        /// <param name="board">an array representing a board</param>
        /// <param name="column">the column where of the queen</param>
        /// <param name="newRow">the new row where the queen will be</param>
        private static void MoveQueen(this int[] board, int column, int newRow)
        {
            board[column] = newRow;
        }

        /// <summary>
        /// Chooses a random row from rows where there 
        /// are min conflicts in a certain column
        /// </summary>
        /// <param name="board">an array representing a board</param>
        /// <param name="minConflicts">an array representing rows with min conflicts</param>
        /// <returns>a random row from minConflicts where the queen will be</returns>
        private static int ChooseRandomRowFrom(this int[] board, int[] minConflicts)
        {
            Random generator = new Random();
            int rowIndex = generator.Next(0, minConflicts.Length);
            return minConflicts[rowIndex];
        }

        /// <summary>
        /// Puts a particular queen's coordinates to a string
        /// </summary>
        /// <param name="board">an array representing a board</param>
        /// <param name="column">the column of the queen</param>
        /// <returns>a string in the format (row,column)</returns>
        private static string PutQueenCoordinatesToString(this int[] board, int column)
        {
            string coordinates = String.Format("({0},{1})", board[column], column);
            return coordinates;
        }

        /// <summary>
        /// Puts all queens' coordinates to a string array
        /// </summary>
        /// <param name="board">an array representing a board</param>
        /// <returns>a string array with all coordinates of queens</returns>
        private static string[] PutQueensCoordinates(this int[] board)
        {
            string[] allCoordinates = new string[board.Length - 1];
            for (int col = 0; col < allCoordinates.Length; col++)
                allCoordinates[col] = board.PutQueenCoordinatesToString(col + 1);
            return allCoordinates;
        }
    }
}
