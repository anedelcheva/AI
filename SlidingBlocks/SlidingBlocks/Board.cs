using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace SlidingBlocks
{
    class Board : IEqualityComparer<State>
    {
        #region Fields
        private State initialState;
        private State currentState;
        private static OrderedBag<State> priorityQueue = new OrderedBag<State>();
        private static HashSet<State> visited = new HashSet<State>();
        public static Queue<State> moves = new Queue<State>();
        public static int movesNumber = -1;
        #endregion

        public State InitialState { get { return initialState; } }

        #region Constructor
        public Board(int[] initialBoard)
        {
            this.initialState = new State(initialBoard);
            this.currentState = this.initialState;
        }
        #endregion

        #region Methods

        private void AddToQueue(State nextState)
        {
            if (nextState != null && !visited.Contains(nextState))
                priorityQueue.Add(nextState);
        }

        public void AStarSolve()
        {
            priorityQueue.Clear();
            priorityQueue.Add(this.initialState);
            while (priorityQueue.Count > 0)
            {
                this.currentState = priorityQueue.RemoveFirst();
                movesNumber++;
                moves.Enqueue(this.currentState);
                //PrintMatrix(ConvertArrayToMatrix(this.currentState.CurrentState));
                //PrintArray(this.currentState.CurrentState);
                if (this.currentState.IsFinalState())
                {
                    return;
                }
                visited.Add(this.currentState);
                State movementUp = Move.Up(this.currentState);
                State movementDown = Move.Down(this.currentState);
                State movementLeft = Move.Left(this.currentState);
                State movementRight = Move.Right(this.currentState);
                if (movementUp != null)
                    this.AddToQueue(movementUp);
                if (movementDown != null)
                    this.AddToQueue(movementDown);
                if (movementLeft != null)
                    this.AddToQueue(movementLeft);
                if (movementRight != null)
                    this.AddToQueue(movementRight);
            }
        }

        public static int[,] ConvertArrayToMatrix(int[] state)
        {
            int dim = (int)Math.Sqrt(state.Length);
            int[,] board = new int[dim, dim];
            int row = 0;
            int col = 0;
            for (int i = 0; i < state.Length; i++)
            {
                row = i / dim % dim;
                if (i % dim == 0)
                    col = 0;
                board[row, col] = state[i];
                col++;
            }
            return board;
        }

        public static int[] ComputeGoalBoard(int dim)
        {
            int[] boardInArray = new int[dim * dim];
            for (int i = 0; i < boardInArray.Length - 1; i++)
                boardInArray[i] = i + 1;
            boardInArray[boardInArray.Length - 1] = 0;
            //int[,] goalBoard = ConvertArrayToMatrix(boardInArray);
            return boardInArray;
        }

        public static bool IsMovementLeft(State state1, State state2)
        {
            if (state2.BlankIdx - state1.BlankIdx == 1)
                return true;
            return false;
        }

        public static bool IsMovementRight(State state1, State state2)
        {
            if (state2.BlankIdx - state1.BlankIdx == -1)
                return true;
            return false;
        }

        public static bool IsMovementUp(State state1, State state2)
        {
            int dim = (int)Math.Sqrt(state1.CurrentState.Length);
            if (state2.BlankIdx - state1.BlankIdx == dim)
                return true;
            return false;
        }

        public static bool IsMovementDown(State state1, State state2)
        {
            int dim = (int)Math.Sqrt(state1.CurrentState.Length);
            if (state2.BlankIdx - state1.BlankIdx == -dim)
                return true;
            return false;
        }

        public bool Equals(State x, State y)
        {
            int length = x.CurrentState.Length;
            for (int i = 0; i < length; i++)
                if (x.CurrentState[i] != y.CurrentState[i])
                    return false;
            return true;
        }

        public int GetHashCode(State obj)
        {
            throw new NotImplementedException();
        }

        public static int[] ReadInArray(int dim)
        {
            int counter = 0;
            int[] array = new int[dim * dim];
            int[] row;
            for (int i = 0; i < dim; i++)
            {
                row = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                for (int j = 0; j < dim; j++)
                    array[counter++] = row[j];
            }
            return array;
        }


        public static void PrintMoves(State state1, State state2)
        {
            if (IsMovementUp(state1, state2))
            {
                Console.WriteLine("up");
            }
            else if (IsMovementDown(state1, state2))
            {
                Console.WriteLine("down");
            }
            else if (IsMovementLeft(state1, state2))
            {
                Console.WriteLine("left");
            }
            else if (IsMovementRight(state1, state2))
            {
                Console.WriteLine("right");
            }
        }

        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        #endregion

        public static void Main()
        {

            /*State state1 = new State(new int[] { 1, 2, 3, 0, 5, 6, 4, 7, 8 });
            State state2 = new State(new int[] { 2, 3, 6, 5, 0, 6, 4, 7, 8 });

            Console.WriteLine(IsMovementDown(state1, state2));
            Console.WriteLine(IsMovementUp(state1, state2));
            Console.WriteLine(IsMovementLeft(state1, state2));
            Console.WriteLine(IsMovementRight(state1, state2));*/
            int N = int.Parse(Console.ReadLine()); // the number of elements in the matrix
            // dimension of a matrix with N+1 number of elements, +1 because of the blank 
            int dim = (int)Math.Sqrt((double)N + 1);
            int[] initialBoard = ReadInArray(dim);
            Board board = new Board(initialBoard);
            if (!board.InitialState.IsSolvable())
            {
                Console.WriteLine("The board is not solvable!");
            }
            else
            {
                board.AStarSolve();
                Console.WriteLine(movesNumber);
                State state1 = moves.Dequeue();
                State state2 = moves.Dequeue();
                while (moves.Count > 0)
                {
                    PrintMoves(state1, state2);
                    state1 = state2;
                    state2 = moves.Dequeue();
                    //PrintMatrix(ConvertArrayToMatrix(moves.Dequeue().CurrentState));
                }
            }
        }
    }
}
