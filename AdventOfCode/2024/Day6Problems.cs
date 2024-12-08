using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace AdventOfCode.AdventOfCode2024
{
    internal class Day6Problems
    {
        private string[] _input;
        private char[][] _space;
        private int _xStart;
        private int _yStart;
        public Day6Problems(string path)
        {
            _input = [];
            _space = [];
            ReadNumInputsFromFile(path);
            FindStartingPoint();
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);
            _space = new char[_input.Length][];

            for (int i = 0; i < _input.Length; i++) {
                _space[i] = new char[_input[i].Length];

                for(int j = 0; j < _input[i].Length; j++)
                    _space[i][j] = _input[i][j];
            }
        }

        public int CalculateGaurdDistinctPositions()
        {
            if(_space[_xStart][_yStart] == '^')
                TraverseSpace(_xStart, _yStart, "up");
            else if(_space[_xStart][_yStart] == '>')
                TraverseSpace(_xStart, _yStart, "right");
            else if(_space[_xStart][_yStart] == '<')
                TraverseSpace(_xStart, _yStart, "left");
            else if(_space[_xStart][_yStart] == 'v')
                TraverseSpace(_xStart, _yStart, "down");

            int sumOfValidPositions = 0;
            for(int x = 0; x < _space.Length; x++)
            {
                for(int y = 0; y < _space[x].Length; y++)
                    if(_space[x][y] == 'X') sumOfValidPositions++;
            }

            return sumOfValidPositions;
        }

        private void TraverseSpace(int x, int y, string direction)
        {
            if(x < 0 || y < 0 || x >= _space.Length || y >= _space[x].Length)
                return;

            _space[x][y] = 'X';

            if(direction == "up" && x - 1 >= 0)
            {
                if(_space[x - 1][y] != '#') TraverseSpace(x - 1, y, "up");
                else if(_space[x - 1][y] == '#') TraverseSpace(x, y + 1, "right");
            }
            else if(direction == "right" && y + 1 < _space[x].Length)
            {
                if(_space[x][y + 1] != '#') TraverseSpace(x, y + 1, "right");
                else if(_space[x][y + 1] == '#') TraverseSpace(x + 1, y, "down");
            }
            else if(direction == "down" && x + 1 < _space.Length)
            {
                if(_space[x + 1][y] != '#') TraverseSpace(x + 1, y, "down");
                else if(_space[x + 1][y] == '#') TraverseSpace(x, y - 1, "left");
            }
            else if(direction == "left" && y - 1 >= 0)
            {
                if(_space[x][y - 1] != '#') TraverseSpace(x, y - 1, "left");
                else if(_space[x][y - 1] == '#') TraverseSpace(x - 1, y, "up");
            }
        }

        public int CalculateNumberAddedObstructionLoops()
        {
            int totalLoopsCreated = 0;
            _space[_xStart][_yStart] = '^';

            for(int row = 0; row < _space.Length; row++)
            {
                for(int col = 0; col < _space[0].Length; col++)
                {
                    if(_space[row][col] == 'X') //I WANT TO CRY: && row != _xStart && col != _yStart
                    {
                        _space[row][col] = '#';
                        if(TraverseSpaceTwo(_xStart, _yStart, "up", new Dictionary<(int, int), HashSet<string>>()))
                            totalLoopsCreated++;
                        _space[row][col] = 'X';
                    }
                }
            }
            return totalLoopsCreated;
        }

        private bool TraverseSpaceTwo(int x, int y, string direction, Dictionary<(int, int), HashSet<string>> seenObstructions)
        {
            if(x < 0 || y < 0 || x >= _space.Length || y >= _space[x].Length)
                return false;

            bool isLoop;

            if(_space[x][y] == '#')
            {
                if(seenObstructions.ContainsKey((x, y)) && seenObstructions[(x,y)].Contains(direction))
                    return true;
            
                if(!seenObstructions.ContainsKey((x,y)))
                    seenObstructions.Add((x,y), []);
                seenObstructions[(x,y)].Add(direction);

                if(direction == "up")
                    isLoop = TraverseSpaceTwo(x + 1, y + 1, "right", seenObstructions);
                else if(direction == "right")
                    isLoop = TraverseSpaceTwo(x + 1, y - 1, "down", seenObstructions);
                else if(direction == "down")
                    isLoop = TraverseSpaceTwo(x - 1, y - 1, "left", seenObstructions);
                else
                    isLoop = TraverseSpaceTwo(x - 1, y + 1, "up", seenObstructions);
            }   
            else
            {
                if(direction == "up")
                    isLoop = TraverseSpaceTwo(x - 1, y, direction, seenObstructions);
                else if(direction == "right")
                    isLoop = TraverseSpaceTwo(x, y + 1, direction, seenObstructions);
                else if(direction == "down")
                    isLoop = TraverseSpaceTwo(x + 1, y, direction, seenObstructions);
                else
                    isLoop = TraverseSpaceTwo(x, y - 1, direction, seenObstructions);
            }

            return isLoop;
        }

        private void FindStartingPoint()
        {
            for(int x = 0; x < _space.Length; x++)
            {
                for(int y = 0; y < _space[0].Length; y++)
                {
                    if(_space[x][y] == '^')
                    {
                        _xStart = x;
                        _yStart = y;
                    }
                }
            }
        }
    }
}