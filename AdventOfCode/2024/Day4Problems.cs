using System.ComponentModel.DataAnnotations;

namespace AdventOfCode.AdventOfCode2024
{
    internal class Day4Problems
    {
        private string[] _input;

        public Day4Problems(string path)
        {
            _input = [];
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);

        }

        public int CalculateNumberOfXmasWordsFound()
        {
            int wordsFound = 0;

            for(int x = 0; x < _input.Length; x++)
            {
                for(int y = 0; y < _input[x].Length; y++)
                {
                    if(_input[x][y] == 'X')
                        wordsFound += NumOfValidXmas(x, y, _input);
                }
            }

            return wordsFound;
        }

        private static int NumOfValidXmas(int x, int y, string[] _input)
        {
            int allFound = 0;

            if(x + 3 < _input.Length && _input[x + 1][y] == 'M' && _input[x + 2][y] == 'A' && _input[x + 3][y] == 'S')
                allFound++;

            if(y + 3 < _input[x].Length && _input[x][y + 1] == 'M' && _input[x][y + 2] == 'A' && _input[x][y + 3] == 'S')
                allFound++;

            if(x - 3 >= 0 && _input[x - 1][y] == 'M' && _input[x - 2][y] == 'A' && _input[x - 3][y] == 'S')
                allFound++;

            if(y - 3 >= 0 && _input[x][y - 1] == 'M' && _input[x][y - 2] == 'A' && _input[x][y - 3] == 'S')
                allFound++;

            if(x + 3 < _input.Length && y + 3 < _input[x].Length && _input[x + 1][y + 1] == 'M' && _input[x + 2][y + 2] == 'A' && _input[x + 3][y + 3] == 'S')
                allFound++;

            if(x + 3 < _input.Length && y - 3 >= 0 && _input[x + 1][y - 1] == 'M' && _input[x + 2][y - 2] == 'A' && _input[x + 3][y - 3] == 'S')
                allFound++;

            if(x - 3 >= 0 && y + 3 < _input[x].Length && _input[x - 1][y + 1] == 'M' && _input[x - 2][y + 2] == 'A' && _input[x - 3][y + 3] == 'S')
                allFound++;

            if(x - 3 >= 0 && y - 3 >= 0 && _input[x - 1][y - 1] == 'M' && _input[x - 2][y - 2] == 'A' && _input[x - 3][y - 3] == 'S')
                allFound++;

            return allFound;
        }

        public int CalculateNumberOfXmasWordsFoundTwo()
        {
            int wordsFound = 0;

            for(int x = 0; x < _input.Length; x++)
            {
                for(int y = 0; y < _input[x].Length; y++)
                {
                    if(_input[x][y] == 'A')
                        wordsFound += NumOfValidXmasTwo(x, y, _input);
                }
            }

            return wordsFound;
        }

        private static int NumOfValidXmasTwo(int x, int y, string[] _input)
        {
            if(x + 1 >= _input.Length || y + 1 >= _input[x].Length || x - 1 < 0 || y - 1 < 0)
                return 0;

            if(((_input[x + 1][y + 1] == 'M' && _input[x - 1][y - 1] == 'S') || 
                (_input[x + 1][y + 1] == 'S' && _input[x - 1][y - 1] == 'M')) && 
                ((_input[x - 1][y + 1] == 'M' && _input[x + 1][y - 1] == 'S') || 
                (_input[x - 1][y + 1] == 'S' && _input[x + 1][y - 1] == 'M')))
            {
                return 1;
            }

            return 0;
        }
    }
}