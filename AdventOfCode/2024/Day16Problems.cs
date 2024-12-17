using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;
using Microsoft.VisualBasic;

namespace AdventOfCode.AdventOfCode2024
{
    internal class Day16Problems
    {
        private string[] _input = [];
        private char[][] _grid = [];
        private int rowSize = -1;
        private int colSize = -1;
        private int[] _start = [];
        private int _count = int.MaxValue;

        public Day16Problems(string path)
        {
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);
            _grid = new char[_input.Length][];
            rowSize = _input.Length;
            colSize = _input[0].Length;
            for (int i = 0; i < _input.Length; i++) 
            {
                _grid[i] = new char[_input[i].Length];

                for(int j = 0; j < _input[0].Length; j++)
                {
                    if(_input[i][j] == 'S') _start = [i, j];
                    _grid[i][j] = _input[i][j];
                }
            }
        }

        public class Node(int x, int y, char dir, int count, HashSet<(int x, int y)> path)
        {
            public int X = x;
            public int Y = y;
            public char Dir = dir;
            public int Count = count;
            public HashSet<(int x, int y)> Path = path;
        }

        public int Calculate(bool second)
        {
            
            Queue<Node> queue = new();
            queue.Enqueue(new(_start[0], _start[1], 'E', 0, [(_start[0], _start[1])]));
            Dictionary<(int x, int y, char d), int> visited = new (){{(_start[0], _start[1], 'E'), 0}};

            HashSet<(int, int)> finalPaths = [];
            while (queue.TryDequeue(out Node? curr))
            {
                if(_grid[curr.X][curr.Y] == 'E')
                {
                    if(curr.Count < _count)
                    {
                        finalPaths = [(_start[0], _start[1])];
                        _count = curr.Count;
                    }

                    foreach((int x, int y) in curr.Path)
                        finalPaths.Add((x,y));
                }

                var (firstX, firstY, firstCount, firstDir, clockX, clockY, clockCount, secondDir, counterX, counterY, counterCount, thirdDir) = curr.Dir switch
                {
                    'E' => (0, +1, +1, 'E', +1, 0, +1001, 'S', -1, 0, +1001, 'N'),
                    'S' => (+1, 0, +1, 'S', 0, -1, +1001, 'W', 0, +1, +1001, 'E'),
                    'W' => (0, -1, +1, 'W', +1, 0, +1001, 'S', -1, 0, +1001, 'N'),
                    'N' or _ => (-1, 0, +1, 'N', 0, +1, +1001, 'E', 0, -1, +1001, 'W')
                };

                AddToQueue(curr.X + firstX, curr.Y + firstY, curr.Count + firstCount, firstDir);
                AddToQueue(curr.X + clockX, curr.Y + clockY, curr.Count + clockCount, secondDir);
                AddToQueue(curr.X + counterX, curr.Y + counterY, curr.Count + counterCount, thirdDir);

                void AddToQueue(int x, int y, int c, char d)
                {
                    if(x < rowSize && x >= 0 && y < colSize && y >= 0 && _grid[x][y] != '#' && 
                       !curr.Path.Contains((x, y)) && (!visited.TryGetValue((x, y, d), out int pC) || c <= pC))
                    {
                        HashSet<(int x, int y)> newPath = [.. curr.Path, (x, y)];
                        visited[(x, y, d)] = c;
                        queue.Enqueue(new(x, y, d, c, newPath));
                    }
                }
            }

            return second ? finalPaths.Count : _count;
        }
    }
}