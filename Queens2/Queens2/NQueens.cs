using System;

namespace Queens2
{
    class NQueens
    {
        static void Main(string[] args)
        {
            // N -> dimension of board or number of queens on board
            // problem constraint -> our code should work for N=10000
            int N = int.Parse(Console.ReadLine());

            /* If we represent our board as a char matrix our program 
             * will work for 10000*10000*sizeof(char) = 200000000B
             * which is approximately 200MB.
             * We will keep our board in an array which will hold
             * the same info but will use up 10000*sizeof(int) = 40000B
             * which is 40KB of RAM memory.
             */

            // represents a chess board; 0th row and col are unused
            int[] board = new int[N + 1];
            /*
            -> an index in board represents a column number
            -> 0 represents a blank space (there is no queen there)
            -> board[some index] gives us the row where our queen is situated
            -> Columns and rows can get values in the range (1, N)
            -> board[col]=row represents there's a queen in position (row, col)
            */

            // prints a board with N number of queens where no 2 of them are in a conflict
            board.NQueens(10000);
        }
    }
}
