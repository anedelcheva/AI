using System.Collections.Generic;

namespace SlidingBlocks
{
    class BoardComparer : IEqualityComparer<State>
    {
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
            int hash = 57;

            for (int i = 0; i < obj.CurrentState.Length; i++)
                hash = (hash * 23) + obj.CurrentState[i];

            return hash;
        }
    }
}
