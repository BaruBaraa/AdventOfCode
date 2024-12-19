using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;

namespace AdventOfCode.AdventOfCode2024
{
    internal class Day18Problems
    {
        private string[] _input = [];
        private int[][] _prevCosts = [];
        Dictionary<int, HashSet<(int x, int y)>> _bytes = new();
        private int rowSize = 71;
        private int colSize = 71;

        public Day18Problems(string path)
        {
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);
            int count = 1;
            HashSet<(int x, int y)> curr = new();
            _bytes.Add(0, []);
            foreach(string fall in _input)
            {
                string[] split = fall.Split(',');
                curr.Add((int.Parse(split[0]), int.Parse(split[1])));
                _bytes.Add(count++, curr);
                HashSet<(int x, int y)> next = new (curr);
                curr = next;
            }

            _prevCosts = new int[rowSize][];
            for (int i = 0; i < rowSize; i++) 
            {
                _prevCosts[i] = new int[colSize];
                for(int j = 0; j < colSize; j++) _prevCosts[i][j] = -1;
            }
        }


        public (int, int) CalculateTwo()
        {
            (int, int) firstToBlock;

            int i;
            for(i = 0; i < _input.Length; i++)
            {
                if(Calculate(i) == -1)
                    break;
                _prevCosts = new int[rowSize][];
                for (int j = 0; j < rowSize; j++) 
                {
                    _prevCosts[j] = new int[colSize];
                    for(int c = 0; c < colSize; c++) _prevCosts[j][c] = -1;
                }
            }

            string[] split = _input[i - 1].Split(',');

            return (int.Parse(split[0]), int.Parse(split[1]));
        }

        public int Calculate(int currGrid)
        {
            PriorityQueue<(int x, int y), int> pQueue = new();
            pQueue.Enqueue((0, 0), 0);

            while(pQueue.TryDequeue(out (int x, int y) curr, out int prevCost))
            {
                
                if(curr.x == rowSize - 1 && curr.y == colSize - 1)
                    return prevCost;

                AddToQueue(curr.x + 1, curr.y, currGrid, prevCost + 1, pQueue);
                AddToQueue(curr.x - 1, curr.y, currGrid, prevCost + 1, pQueue);
                AddToQueue(curr.x, curr.y + 1, currGrid, prevCost + 1, pQueue);
                AddToQueue(curr.x, curr.y - 1, currGrid, prevCost + 1, pQueue);
            }

            void AddToQueue(int x, int y, int currGrid, int nextCost, PriorityQueue<(int x, int y), int> pQueue)
            {
                if(x >= 0 && x < rowSize && y >= 0 && y < rowSize && (!_bytes[currGrid].Contains((x,y))) && (_prevCosts[x][y] == -1 || nextCost < _prevCosts[x][y]))
                {
                    _prevCosts[x][y] = nextCost;
                    pQueue.Enqueue((x, y), nextCost);
                }
            }

            return -1;
        }
    }
}