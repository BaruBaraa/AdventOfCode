using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;

namespace AdventOfCode.AdventOfCode2024
{
    internal class Day12Problems
    {
        private string[] _input = [];
        private char[][] _graph = [];

        public Day12Problems(string path)
        {
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);
            _graph = new char[_input.Length][];

            for (int i = 0; i < _input.Length; i++) 
            {
                 _graph[i] = new char[_input[i].Length];

                for(int j = 0; j < _input[0].Length; j++)
                    _graph[i][j] = _input[i][j];
            }
        }

        public int CalculateTotalFencingCost()
        {
            int count = 0;
            HashSet<(int, int)> visited = new();
            for(int row = 0; row < _graph.Length; row++)
            {
                for(int col = 0; col < _graph[0].Length; col++)
                {
                    if(!visited.Contains((row, col)))
                    {
                        (int, int) currCount = DFSHelper(row, col, _graph[row][col], visited);
                        count += currCount.Item1 * currCount.Item2;
                    }
                }
            }

            return count;
        }

        private (int, int) DFSHelper(int row, int col, char curr, HashSet<(int, int)> visited)
        {
            if(row < 0 || col < 0 || row >= _graph.Length || col >= _graph[0].Length || visited.Contains((row, col)) || curr != _graph[row][col])
                return (0, 0);
            
            visited.Add((row, col));

            (int, int) currCount = (1, 0);

            if(row - 1 < 0 || (row - 1 >= 0 && _graph[row - 1][col] != curr)) ++currCount.Item2;
            if(col - 1 < 0 || (col - 1 >= 0 && _graph[row][col - 1] != curr)) ++currCount.Item2;
            if(row + 1 >= _graph.Length || (row + 1 < _graph.Length && _graph[row + 1][col] != curr)) ++currCount.Item2;
            if(col + 1 >= _graph[0].Length || (col + 1 < _graph[0].Length && _graph[row][col + 1] != curr)) ++currCount.Item2;

            (int, int) next = DFSHelper(row - 1, col, curr, visited);
            (int, int) next1 = DFSHelper(row + 1, col, curr, visited);
            (int, int) next2 = DFSHelper(row, col - 1, curr, visited);
            (int, int) next3 = DFSHelper(row, col + 1, curr, visited);

            currCount.Item1 += next.Item1 + next1.Item1 + next2.Item1 + next3.Item1;
            currCount.Item2 += next.Item2 + next1.Item2 + next2.Item2 + next3.Item2;

            return currCount;
        }

        public int CalculateTotalFencingCostTwo()
        {
            int count = 0;
            HashSet<(int, int)> visited = [];

            for(int row = 0; row < _graph.Length; row++)
            {
                for(int col = 0; col < _graph[0].Length; col++)
                {
                    if(!visited.Contains((row, col)))
                    {
                        (int, int) currCount = DFSHelperTwo(row, col, _graph[row][col], visited);
                        count += currCount.Item1 * currCount.Item2;
                    }
                }
            }

            return count;
        }

        private (int, int) DFSHelperTwo(int row, int col, char curr, HashSet<(int, int)> visited)
        {
            if(row < 0 || col < 0 || row >= _graph.Length || col >= _graph[0].Length || visited.Contains((row, col)) || curr != _graph[row][col])
                return (0, 0);
            
            visited.Add((row, col));

            (int, int) currCount = (1, 0);

            if((row - 1 >= 0 && col - 1 >= 0 && _graph[row - 1][col] != curr && _graph[row][col - 1] != curr) ||
                (row - 1 < 0 && col - 1 >= 0 && _graph[row][col - 1] != curr) || 
                (col - 1 < 0 && row - 1 >= 0 && _graph[row - 1][col] != curr) ||
                (row - 1 < 0 && col - 1 < 0))
                ++currCount.Item2;

            if((row - 1 >= 0 && col + 1 < _graph[0].Length && _graph[row - 1][col] != curr && _graph[row][col + 1] != curr) ||
                (row - 1 < 0 && col + 1 < _graph[0].Length && _graph[row][col + 1] != curr) || 
                (col + 1 >= _graph[0].Length && row - 1 >= 0 && _graph[row - 1][col] != curr) ||
                (row - 1 < 0 && col + 1 >= _graph[0].Length))
                ++currCount.Item2;
            
            if((row + 1 < _graph.Length && col - 1 >= 0 && _graph[row + 1][col] != curr && _graph[row][col - 1] != curr) ||
                (row + 1 >= _graph.Length && col - 1 >= 0 && _graph[row][col - 1] != curr) || 
                (col - 1 < 0 && row + 1 < _graph.Length && _graph[row + 1][col] != curr) ||
                (row + 1 >= _graph.Length && col - 1 < 0))
                ++currCount.Item2;

            if((row + 1 < _graph.Length && col + 1 < _graph[0].Length && _graph[row + 1][col] != curr && _graph[row][col + 1] != curr) ||
                (row + 1 >= _graph.Length && col + 1 < _graph[0].Length && _graph[row][col + 1] != curr) || 
                (col + 1 >= _graph[0].Length && row + 1 < _graph.Length && _graph[row + 1][col] != curr) ||
                (row + 1 >= _graph.Length && col + 1 >= _graph[0].Length))
                ++currCount.Item2;

            if(row - 1 >= 0 && col - 1 >= 0 && _graph[row - 1][col - 1] != curr && _graph[row][col - 1] == curr && _graph[row - 1][col] == curr)
                ++currCount.Item2;
            if(row + 1 < _graph.Length && col + 1 < _graph[0].Length && _graph[row + 1][col + 1] != curr && _graph[row][col + 1] == curr && _graph[row + 1][col] == curr)
                ++currCount.Item2;
            if(row - 1 >= 0 && col + 1 < _graph[0].Length && _graph[row - 1][col + 1] != curr && _graph[row][col + 1] == curr && _graph[row - 1][col] == curr)
                ++currCount.Item2;
            if(row + 1 < _graph.Length && col - 1 >= 0 && _graph[row + 1][col - 1] != curr && _graph[row][col - 1] == curr && _graph[row + 1][col] == curr)
                ++currCount.Item2;

            (int, int) next = DFSHelperTwo(row - 1, col, curr, visited);
            (int, int) next1 = DFSHelperTwo(row + 1, col, curr, visited);
            (int, int) next2 = DFSHelperTwo(row, col - 1, curr, visited);
            (int, int) next3 = DFSHelperTwo(row, col + 1, curr, visited);

            currCount.Item1 += next.Item1 + next1.Item1 + next2.Item1 + next3.Item1;
            currCount.Item2 += next.Item2 + next1.Item2 + next2.Item2 + next3.Item2;

            return currCount;
        }
    }
}