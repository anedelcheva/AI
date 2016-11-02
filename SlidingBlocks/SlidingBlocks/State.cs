using System;

namespace SlidingBlocks
{
    class State : IComparable<State>
    {
        #region Fields
        private int[] currentState;
        private State previousState;
        private int blankIdx; // the index of 0 in the current state
        private int g; // cost
        private int h; // heuristics
        #endregion

        #region Properties
        public int[] CurrentState { get { return currentState; } }
        public State PreviousState { get { return previousState; } }
        public int BlankIdx { get { return blankIdx; } }
        public int G { get { return g; } }
        public int H { get { return h; } }
        #endregion

        #region Constructors
        public State(int[] state)
        {
            this.currentState = state;
            this.previousState = null;
            this.g = 0;
            this.blankIdx = Array.IndexOf(currentState, 0);
            this.h = ComputeHeuristics(this.currentState);
        }

        public State(State previousState, int blankIdx)
        {
            this.currentState = new int[previousState.currentState.Length];
            Array.Copy(previousState.currentState, this.currentState, this.currentState.Length);
            //this.currentState = previousState.currentState;
            this.currentState = this.currentState.Swap(previousState.blankIdx, blankIdx);
            this.blankIdx = blankIdx;
            this.g = previousState.g + 1;
            this.h = ComputeHeuristics(this.currentState);
            this.previousState = previousState;
        }
        #endregion

        #region Methods

        public int f()
        {
            return this.h + this.g;
        }

        public bool IsFinalState()
        {
            for (int i = 0; i < this.currentState.Length - 2; i++)
                if (this.currentState[i] > this.currentState[i + 1])
                    return false;
            return true;
        }

        private static int Inversions(int[] matrixInArray)
        {
            int inversions = 0;
            for (int i = 0; i < matrixInArray.Length - 1; i++)
            {
                for (int j = i + 1; j < matrixInArray.Length; j++)
                {
                    if (matrixInArray[i] > matrixInArray[j])
                    {
                        inversions++;
                    }
                }
            }
            // we remove number of inversions of elements prior to 0
            inversions -= Array.IndexOf(matrixInArray, 0);
            return inversions;
        }

        public bool IsSolvable()
        {
            int inversions = 0;
            int dim = (int)Math.Sqrt(this.currentState.Length);
            if (dim % 2 == 1) // if the matrix is 3x3, 5x5, ...
            {
                inversions = Inversions(this.currentState);
                // we remove the number of inversions where a certain number is > 0
                // because we don't want to count the blank square represented as 0
                // number of inversions prior to 0 = index of 0 in the array
                // number of inversions without 0 = all number of inversions - number of inversions of elements prior to 0
                return inversions % 2 == 0;
            }
            else // if the matrix is 2x2, 4x4, ...
            {
                int rowOf0 = this.blankIdx / dim; // we take the row where 0 is
                inversions = Inversions(this.currentState);
                //Console.WriteLine(rowOf0);
                //Console.WriteLine(inversions);
                return (inversions + rowOf0) % 2 == 1;
            }
        }

        // the method computes the manhattan distance of 
        // an element in the matrix to its final position
        private static int ComputeManhattanDistance(int index, int number, int dim)
        {
            // % gives us column, / gives us row
            int numberIdx = number - 1; // index where number should be
            int correctRow = index / dim; // row where number should be
            int numberRow = numberIdx / dim; // row where number is
            int correctColumn = index % dim; // column where number should be
            int numberColumn = numberIdx % dim; // column where number is 
            return Math.Abs(correctRow - numberRow) + Math.Abs(correctColumn - numberColumn);
        }

        private static int ComputeHeuristics(int[] state)
        {
            int h = 0;
            int dim = (int)Math.Sqrt(state.Length);
            for (int i = 0; i < state.Length; i++)
                if (state[i] != 0)
                    h += ComputeManhattanDistance(i, state[i], dim);
            return h;
        }

        public static void PrintState(int[] state)
        {
            for (int i = 0; i < state.Length; i++)
            {
                Console.WriteLine(state[i]);
            }
        }

        public int CompareTo(State other)
        {
            if (this.f() < other.f())
                return -1;
            else if (this.f() == other.f())
                return 0;
            else
                return 1;
        }
        #endregion

        /*public static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
            State state = new State(arr);
            State state2 = Move.Down(state);
            state2 = Move.Down(state2);
            PrintState(state2.CurrentState);
        }*/
    }
}
