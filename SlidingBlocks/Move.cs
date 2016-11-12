using System;

namespace SlidingBlocks
{
    static class Move
    {
        #region Methods

        public static State Up(State state)
        {
            int dim = (int)Math.Sqrt(state.CurrentState.Length);
            if (state.BlankIdx < dim * 2)
                return new State(state, state.BlankIdx + dim);
            return null;
        }

        public static State Down(State state)
        {
            int dim = (int)Math.Sqrt(state.CurrentState.Length);
            if (state.BlankIdx > dim - 1)
                return new State(state, state.BlankIdx - dim);
            return null;
        }

        public static State Left(State state)
        {
            int dim = (int)Math.Sqrt(state.CurrentState.Length);
            if (state.BlankIdx % dim < dim - 1)
                return new State(state, state.BlankIdx + 1);
            return null;
        }

        public static State Right(State state)
        {
            int dim = (int)Math.Sqrt(state.CurrentState.Length);
            if (state.BlankIdx % dim > 0)
                return new State(state, state.BlankIdx - 1);
            return null;
        }

        #endregion
    }
}
