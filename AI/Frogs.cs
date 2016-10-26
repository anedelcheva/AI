using System;
using System.Collections.Generic;

namespace AI
{
    class Frogs
    {
        public static bool found = false;
        public static Stack<string> st = new Stack<string>();

        // generates initial or final state
        public static string GenerateState(int N, char left, char right)
        {
            char[] state = new char[2 * N + 1];
            for (int i = 0; i < N; i++)
            {
                state[i] = left;
            }
            state[N] = '_';
            for (int i = N + 1; i < 2 * N + 1; i++)
            {
                state[i] = right;
            }
            return new string(state);
        }

        // method jump is like method swap-it swaps the places of the elements on positions idx1 and idx2
        private static string jump(string state, int idx1, int idx2)
        {
            char[] newState = state.ToCharArray();
            char temp = newState[idx1];
            newState[idx1] = newState[idx2];
            newState[idx2] = temp;
            return new string(newState);
        }

        // HelpFrogMoveRight moves a left frog > right to a particular index called frogIdx if the "if" condition is true
        private static List<string> HelpFrogMoveRight(List<string> states, string state, int frogIdx)
        {
            int leftBound = 0;
            int stoneIdx = state.IndexOf('_');
            if (frogIdx >= leftBound && state[frogIdx] == '>')
            {
                states.Add(jump(state, frogIdx, stoneIdx));
            }
            return states;
        }

        // HelpFrogMoveLeft moves a right frog < left to a particular index called frogIdx if the "if" condition is true
        private static List<string> HelpFrogMoveLeft(List<string> states, string state, int frogIdx)
        {
            int rightBound = state.Length - 1;
            int stoneIdx = state.IndexOf('_');
            if (frogIdx <= rightBound && state[frogIdx] == '<')
            {
                states.Add(jump(state, frogIdx, stoneIdx));
            }
            return states;
        }

        public static List<string> GenerateNextStates(string state)
        {
            int stoneIdx = state.IndexOf("_");
            int fstLeft = stoneIdx - 1; // first left index of stone
            int sndLeft = stoneIdx - 2; // second left index of stone
            int fstRight = stoneIdx + 1; // first right index of stone
            int sndRight = stoneIdx + 2; // second right index of stone
            List<string> nextStates = new List<string>();
            nextStates = HelpFrogMoveRight(nextStates, state, fstLeft);
            nextStates = HelpFrogMoveRight(nextStates, state, sndLeft);
            nextStates = HelpFrogMoveLeft(nextStates, state, fstRight);
            nextStates = HelpFrogMoveLeft(nextStates, state, sndRight);
            return nextStates;
        }

        public static void Generate(int N, string initialState)
        {
            st.Push(initialState);
            if (initialState == GenerateState(N, '<', '>'))
            {
                found = true;
            }
            List<string> nextstates = GenerateNextStates(initialState);
            foreach (var state in nextstates)
            {
                Generate(N, state);
                if (!found)
                {
                    st.Pop();
                }
                else
                {
                    return;
                }
            }
        }

        public static Stack<string> Reverse(Stack<string> st)
        {
            Stack<string> reversed = new Stack<string>();
            while (st.Count > 0)
            {
                reversed.Push(st.Pop());
            }
            return reversed;
        }

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string initialState = GenerateState(N, '>', '<');
            Generate(N, initialState);
            st = Reverse(st);
            while (st.Count > 0)
            {
                Console.WriteLine(st.Pop());
            }
        }
    }
}