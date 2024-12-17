using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;

namespace AdventOfCode.AdventOfCode2024
{
    internal class Day14Problems
    {

        public class Robot
        {
            public int Row {get; set;}
            public int Col {get; set;}
            public int RowV {get; set;}
            public int ColV {get; set;}
        }
        private string[] _input = [];
        private List<Robot> _robots;

        public Day14Problems(string path)
        {
            _input = [];
            _robots = new();
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);

            for(int row=0; row < _input.Length; row++)
            {
                Robot robToAdd = new();
                int firstCommaIndex = _input[row].IndexOf(',');
                int lastCommaIndex = _input[row].LastIndexOf(',');
                robToAdd.Col = int.Parse(_input[row].Substring(2, firstCommaIndex - 2));
                robToAdd.Row = int.Parse(_input[row].Substring(firstCommaIndex + 1, _input[row].IndexOf(' ') - (firstCommaIndex + 1)));
                robToAdd.ColV = int.Parse(_input[row].Substring(_input[row].LastIndexOf('=') + 1, lastCommaIndex - (_input[row].LastIndexOf('=') + 1)));
                robToAdd.RowV = int.Parse(_input[row].Substring(lastCommaIndex + 1));
                _robots.Add(robToAdd);
            }
        }

        public int Calculate()
        {
            int quadrant1 = 0, quadrant2 = 0, quadrant3 = 0, quadrant4 = 0;

            foreach(Robot r in _robots)
            {
                int currRow = r.Row; // + r.RowV * 100) % 7);
                int currCol = r.Col; //+ r.ColV * 100) % 11);

                for(int i = 0; i < 100; i++)
                {
                    currRow += r.RowV;
                    currCol += r.ColV;

                    if(currRow < 0)
                        currRow = 103 + currRow;

                    if(currCol < 0)
                        currCol = 101 + currCol;

                    if(currRow > 102)
                        currRow -= 103;
                    
                    if(currCol > 100)
                        currCol -= 101;
                }

                if(currRow <= 50 && currCol <= 49 )
                    quadrant1++;
                else if(currRow <= 50 && currCol >= 51)
                    quadrant2++;
                else if(currRow >= 52 && currCol <= 49)
                    quadrant3++;
                else if(currRow >= 52 && currCol >= 51)
                    quadrant4++;
            }

            return quadrant1 * quadrant2 * quadrant3 * quadrant4;
        }

        public void DrawChristmasTree()
        {
            char[][] grid = new char[103][];
            for(int row = 0; row < 103; row++)
            {
                grid[row] = new char[101];
                for(int col = 0; col < 101; col++)
                    grid[row][col] = '-';
            }

            bool firstFound = false, secondFound = false;
            int firstIter = 0, secondIter = 0;

            for(int i = 0; i < 100000; i++)
            {
               
                if(firstFound) firstIter++;
                if(secondFound) secondIter++;
                
                foreach(Robot r in _robots)
                {
                    r.Row += r.RowV;
                    r.Col += r.ColV;

                    if(r.Row < 0) r.Row = 103 + r.Row;
                    if(r.Col < 0) r.Col = 101 + r.Col;
                    if(r.Row > 102) r.Row -= 103;
                    if(r.Col > 100) r.Col -= 101;

                    grid[r.Row][r.Col] = '|';
                }

                if((firstFound && firstIter % 103 == 0) || (secondFound && secondIter % 101 == 0))
                    DrawGrid(grid, i);

                // if(i == 8167) DrawGrid(grid, i); TREE LOCATION
                
                ResetGrid(grid);
            }

        }

        private void DrawGrid(char[][] grid, int iteration)
        {
            StringBuilder sb = new();
            sb.Append(Environment.NewLine);
            sb.Append(iteration);
            sb.Append(Environment.NewLine);
            for(int row = 0; row < 103; row++)
            {
                for(int col = 0; col < 101; col++)
                {
                    sb.Append(grid[row][col]);
                }
                sb.Append(Environment.NewLine);
            }

            using (System.IO.StreamWriter file = File.AppendText(@"C:\Users\uknow\Documents\christmasTree.txt"))
            {
                file.WriteLine(sb.ToString()); // "sb" is the StringBuilder
            }
        }

        private void ResetGrid(char[][] grid)
        {
            for(int row = 0; row < 103; row++)
            {
                for(int col = 0; col < 101; col++)
                    grid[row][col] = '.';
            }
        }

        public int CalculateOptimization()
        {
            int quadrant1 = 0, quadrant2 = 0, quadrant3 = 0, quadrant4 = 0;

            foreach(Robot r in _robots)
            {
                int currRow = Math.Abs((r.Row + r.RowV * 100) % 7);
                int currCol = Math.Abs((r.Col + r.ColV * 100) % 11);

                Console.WriteLine($"{currCol},{currRow}");

                if(currRow <= 2 && currCol <= 4 )
                    quadrant1++;
                else if(currRow <= 2 && currCol >= 6)
                    quadrant2++;
                else if(currRow >= 4 && currCol <= 4)
                    quadrant3++;
                else if(currRow >= 4 && currCol >= 6)
                    quadrant4++;
            }

            return quadrant1 * quadrant2 * quadrant3 * quadrant4;
        }
    }
}