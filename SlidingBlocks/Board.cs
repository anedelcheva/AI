using System;
using System.Collections.Generic;
using Wintellect.PowerCollections; // for OrderedBag used as a priority queue

namespace SlidingBlocks
{
    class Board
    {
        #region Fields
        private State initialState;
        private State currentState;
        private static OrderedBag<State> priorityQueue = new OrderedBag<State>();
        private static HashSet<State> visited = new HashSet<State>(new BoardComparer());
        #endregion

        #region Property
        public State InitialState { get { return initialState; } } 
        #endregion

        #region Constructor
        public Board(int[] initialBoard)
        {
            this.initialState = new State(initialBoard);
            this.currentState = this.initialState;
        }
        #endregion

        #region Methods

        // adds a state to the priority queue if it is not null and is not present in the HashSet
        private void AddToQueue(State nextState)
        {
            if (nextState != null && !visited.Contains(nextState))
                priorityQueue.Add(nextState);
        }

        // Algorithm A* for finding path from initial state to final state of a board
        public State AStarSolve()
        {
            priorityQueue.Clear();
            priorityQueue.Add(this.initialState);
            while (priorityQueue.Count > 0)
            {
                this.currentState = priorityQueue.RemoveFirst();

                if (this.currentState.IsFinalState())
                    return this.currentState;

                if (!visited.Contains(this.currentState))
                    visited.Add(this.currentState);
                
                State movementUp = Move.Up(this.currentState);
                State movementDown = Move.Down(this.currentState);
                State movementLeft = Move.Left(this.currentState);
                State movementRight = Move.Right(this.currentState);
                this.AddToQueue(movementUp);
                this.AddToQueue(movementDown);
                this.AddToQueue(movementLeft);
                this.AddToQueue(movementRight);
            }
            return null;
        }

        // Reads in an array a board with numbers
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
        #endregion

        public static void Main()
        {
            int N = int.Parse(Console.ReadLine()); // the number of elements in the matrix
            // dimension of a matrix with N+1 number of elements, +1 because of the blank 
            int dim = (int)Math.Sqrt((double)N + 1);
            int[] initialBoard = ReadInArray(dim);
            Board board = new Board(initialBoard);
            if (!board.InitialState.IsSolvable())
                Console.WriteLine("The board is not solvable!");
            else
            {
                var result = board.AStarSolve();
                Console.WriteLine(result.Cost);
                result.PrintPath();
            }
        }
    }
}
