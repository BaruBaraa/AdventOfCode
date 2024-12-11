using System.Globalization;
using System.Transactions;

namespace AdventOfCode.AdventOfCode2024
{
    internal class Day10Problems
    {
        private string[] _input = [];
        private int[][] _graph = [];

        public Day10Problems(string path)
        {
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);
            _graph = new int[_input.Length][];

            for (int i = 0; i < _input.Length; i++) 
            {
                 _graph[i] = new int[_input[i].Length];

                for(int j = 0; j < _input[0].Length; j++)
                    _graph[i][j] = _input[i][j] - '0';
            }
        }

        public int Calculate()
        {
            int results = 0;
            for(int row = 0; row < _graph.Length; row++)
            {
                for(int col = 0; col < _graph[0].Length; col++)
                {
                    if(_graph[row][col] == 0)
                        results += DFSHelper(row, col, _graph, 0, []);
                }
            }
            return results;
        }

        private int DFSHelper(int row, int col, int[][] _graph, int currHeight, HashSet<(int, int)> visited)
        {
            if(row >= _graph.Length || row < 0 || col >= _graph[0].Length || col < 0 || _graph[row][col] != currHeight)
                return 0;
            
            // visited.Add((row, col));

            if(_graph[row][col] == 9)
                return 1;
            
            int count = 0;

            count += DFSHelper(row + 1, col, _graph, currHeight + 1, visited);
            count += DFSHelper(row, col + 1, _graph, currHeight + 1, visited);
            count += DFSHelper(row - 1, col, _graph, currHeight + 1, visited);
            count += DFSHelper(row, col - 1, _graph, currHeight + 1, visited);

            return count;
        }

        public int CalculateMemo()
        {
            int results = 0;
            int[][] memo = new int[_graph.Length][];
            for(int row = 0; row < _graph.Length; row++)
            {
                memo[row] = new int[_graph[row].Length];
                for(int col = 0; col < _graph[0].Length; col++)
                    memo[row][col] = -1;
            }

            for(int row = 0; row < _graph.Length; row++)
            {
                for(int col = 0; col < _graph[0].Length; col++)
                {
                    if(_graph[row][col] == 0)
                        results += DFSHelperMemo(row, col, _graph, 0, [], memo);
                }
            }
            return results;
        }

        private int DFSHelperMemo(int row, int col, int[][] _graph, int currHeight, HashSet<(int, int)> visited, int[][] memo)
        {
            if(row >= _graph.Length || row < 0 || col >= _graph[0].Length || col < 0 || _graph[row][col] != currHeight)
                return 0;
            
            
            if(memo[row][col] != -1)
                return memo[row][col];

            if(_graph[row][col] == 9)
                return 1;
            
            int count = 0;

            count += DFSHelper(row + 1, col, _graph, currHeight + 1, visited);
            count += DFSHelper(row, col + 1, _graph, currHeight + 1, visited);
            count += DFSHelper(row - 1, col, _graph, currHeight + 1, visited);
            count += DFSHelper(row, col - 1, _graph, currHeight + 1, visited);

            return memo[row][col] = count;
        }
    }
}