using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;

namespace AdventOfCode.AdventOfCode2024
{
    internal class Day19Problems
    {
        private string[] _input = [];
        private HashSet<string> _possibleTowel = [];
        private List<string> _combinations = [];

        public Day19Problems(string path)
        {
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);
            string[] towels = _input[0].Split(", ");

            foreach(string t in towels)
                _possibleTowel.Add(t);

            for(int i = 2; i < _input.Length; i++)
            {
                _combinations.Add(_input[i]);
            }
        }

        public long Calculate()
        {
            long count = 0;

            foreach(string c in _combinations)
            {
                long[] memo = new long[c.Length];
                for(int i = 0; i < memo.Length; i++)
                    memo[i] = -1;
                count += DFSHelper(c, 0, memo);
            }

            return count;
        }

        private long DFSHelper(string c, int currIndex, long[] memo)
        {
            if(currIndex == c.Length) return 1;
            if(memo[currIndex] != -1) return memo[currIndex];
                
            long count = 0;

            for(int i = currIndex + 1; i <= c.Length; i++)
            {
                if(_possibleTowel.Contains(c.Substring(currIndex, i - currIndex)))
                    count += DFSHelper(c, i, memo);
            }

            memo[currIndex] = count;
            return count;
        }
    }
}