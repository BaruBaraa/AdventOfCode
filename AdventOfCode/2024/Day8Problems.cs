using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode.AdventOfCode2024
{
    internal class Day8Problems
    {
        private string[] _input = [];
        private char[][] _antinode = [];

        public Day8Problems(string path)
        {
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);
            _antinode = _input.Select(s => s.ToArray()).ToArray();
        }

        public int CalculateAllAntinodes()
        {
            Dictionary<char, List<(int, int)>> antennaLookUp = new();
            int sumOfAntinodes = 0;
            for(int row = 0; row < _input.Length; row++)
            {
                for(int col = 0; col < _input[0].Length; col++)
                {
                    if(_input[row][col] != '.')
                    {
                        if(!antennaLookUp.ContainsKey(_input[row][col]))
                            antennaLookUp.Add(_input[row][col], new List<(int, int)>());
                        else
                        {
                            foreach((int,int) antenna in antennaLookUp[_input[row][col]])
                            {
                                int xDist = Math.Abs(row - antenna.Item1);
                                int yDist = Math.Abs(col - antenna.Item2);
                                int negXDist = xDist * -1;
                                int negYDist = yDist * -1;

                                if(row > antenna.Item1 && col <= antenna.Item2)
                                    AddAllAntinodes(row, col, antenna.Item1, antenna.Item2, xDist, negYDist, negXDist, yDist);
                                else if(row > antenna.Item1 && col > antenna.Item2)
                                    AddAllAntinodes(row, col, antenna.Item1, antenna.Item2, xDist, yDist, negXDist, negYDist);
                                else if(row < antenna.Item1 && col < antenna.Item2)
                                    AddAllAntinodes(row, col, antenna.Item1, antenna.Item2, negXDist, negYDist, xDist, yDist);
                                else
                                    AddAllAntinodes(row, col, antenna.Item1, antenna.Item2, negXDist, yDist, xDist, negYDist);
                            }
                        }
                        // PrintCurrAntinodes();
                        antennaLookUp[_input[row][col]].Add((row, col));
                    }
                }
            }
            

            for(int row = 0; row < _antinode.Length; row++)
            {
                for(int col = 0; col < _antinode[0].Length; col++)
                {
                    if(_antinode[row][col] == '#')
                        sumOfAntinodes++;
                }
            }

            return sumOfAntinodes;
        }

        private void AddAllAntinodes(int firstX, int firstY, int secondX, int secondY, int firstXDist, int firstYDist, int secondXDist, int secondYDist)
        {
            while(firstX < _input.Length && firstY < _input[0].Length && firstX >= 0 && firstY >= 0)
            {
                _antinode[firstX][firstY] = '#';
                firstX += firstXDist;
                firstY += firstYDist;
            }
            while(secondX < _input.Length && secondY < _input[0].Length && secondX >= 0 && secondY >= 0)
            {
                _antinode[secondX][secondY] = '#';
                secondX += secondXDist;
                secondY += secondYDist;
            }
        }

        private void PrintCurrAntinodes()
        {
            Console.WriteLine("------------NEXT------------");
            for(int row = 0; row < _antinode.Length; row++)
            {
                string curr = "";

                for(int col = 0; col < _antinode[0].Length; col++)
                    curr += _antinode[row][col];

                Console.WriteLine(curr);
            }
        }
    }
}