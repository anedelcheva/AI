using System;

namespace SlidingBlocks
{
    public static class ExtensionMethods
    {
        public static int[] Swap(this int[] state, int idx1, int idx2)
        {
            int temp = state[idx1];
            state[idx1] = state[idx2];
            state[idx2] = temp;
            return state;
        }

        public static void PrintPath(this State state)
        {
            if (state.PreviousState != null)
            {
                state.PreviousState.PrintPath();
                PrintMoves(state, state.PreviousState);
            }
        }

        public static void PrintMoves(State state1, State state2)
        {
            if (IsMovementUp(state1, state2))
                Console.WriteLine("up");
            else if (IsMovementDown(state1, state2))
                Console.WriteLine("down");
            else if (IsMovementLeft(state1, state2))
                Console.WriteLine("left");
            else if (IsMovementRight(state1, state2))
                Console.WriteLine("right");
        }

        public static bool IsMovementRight(State state1, State state2)
        {
            if (state2.BlankIdx - state1.BlankIdx == 1)
                return true;
            return false;
        }

        public static bool IsMovementLeft(State state1, State state2)
        {
            if (state2.BlankIdx - state1.BlankIdx == -1)
                return true;
            return false;
        }

        public static bool IsMovementDown(State state1, State state2)
        {
            int dim = (int)Math.Sqrt(state1.CurrentState.Length);
            if (state2.BlankIdx - state1.BlankIdx == dim)
                return true;
            return false;
        }

        public static bool IsMovementUp(State state1, State state2)
        {
            int dim = (int)Math.Sqrt(state1.CurrentState.Length);
            if (state2.BlankIdx - state1.BlankIdx == -dim)
                return true;
            return false;
        }

    }
}
