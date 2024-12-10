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
    }
}