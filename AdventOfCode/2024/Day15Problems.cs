using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;

namespace AdventOfCode.AdventOfCode2024
{
    internal class Day15Problems
    {
        private string[] _input = [];
        private char[][] _grid = [];
        private Queue<int[]> _moves = new();
        private int[] _botPos = [];

        public Day15Problems(string path)
        {
            ReadNumInputsFromFile(path);
        }

        public int CalculateTwo()
        {
            while(_moves.Any())
            {
                int[] currMove = _moves.Dequeue();
                int nRow = _botPos[0] + currMove[0];
                int nCol = _botPos[1] + currMove[1];
                if(_grid[nRow][nCol] == '#')
                    continue;
                else if(_grid[nRow][nCol] == '.')
                {
                    _grid[_botPos[0]][_botPos[1]] = '.';
                    _grid[nRow][nCol] = '@';
                    _botPos = [nRow, nCol];
                }
                else if(_grid[nRow][nCol] == '[' || _grid[nRow][nCol] == ']')
                {
                    DoPushes(currMove, nRow, nCol);
                }
                // PrintGrid(currMove);
            }
            int count = 0;

            for (int row = 0; row < _grid.Length; row++) 
            {
                for(int col = 0; col < _grid[0].Length; col++)
                {
                    if(_grid[row][col] == '[')
                        count += 100 * row + col;
                }
            }

            return count;
        }

        private void DoPushes(int[] currMove, int nRow, int nCol)
        {
            int nextR = nRow, nextC = nCol;
            int count = 0;
            if(currMove[1] == 1 || currMove[1] == -1)
            {
                while(_grid[nextR][nextC] != '#')
                {
                    if(_grid[nextR][nextC] == '.')
                    {
                        char prevBoxPiece = _grid[nRow][nCol];
                        nextR = nRow;
                        nextC = nCol;
                        while(count > 0)
                        {
                            nextC += currMove[1];
                            _grid[nextR][nextC] = prevBoxPiece;

                            if(prevBoxPiece == '[') prevBoxPiece = ']';
                            else prevBoxPiece = '[';

                            --count;
                        }
                        _grid[_botPos[0]][_botPos[1]] = '.';
                        _grid[nRow][nCol] = '@';
                        _botPos = [nRow, nCol];
                        return;
                    }
                    ++count;
                    nextC += currMove[1];
                }
            }
            else
            {
                BFSHelper(currMove, nRow, nCol);
            }
        }

        public class Coords
        {
            public int X1;
            public int Y1;
            public int X2;
            public int Y2;
            public Coords(int x1, int y1, int x2, int y2)
            {
                X1 = x1;
                Y1 = y1;
                X2 = x2;
                Y2 = y2;
            }
        }
        private void BFSHelper(int[] currMove, int nRow, int nCol)
        {
            Queue<Coords> queue = new();
            if(_grid[nRow][nCol] == '[')
                queue.Enqueue(new (nRow, nCol, nRow, nCol + 1));
            else if(_grid[nRow][nCol] == ']')
                queue.Enqueue(new (nRow, nCol - 1, nRow, nCol));

            Stack<Coords> toPush = new(); 
            while(queue.Any())
            {
                Coords curr = queue.Dequeue();
                toPush.Push(curr);

                int nextX = curr.X1 + currMove[0];
                if(_grid[nextX][curr.Y1] == '#' || _grid[nextX][curr.Y2] == '#')
                    return;
                
                if(_grid[nextX][curr.Y1] == '[' && _grid[nextX][curr.Y2] == ']')
                    queue.Enqueue(new (nextX, curr.Y1, nextX, curr.Y2));
                else
                {
                    if(_grid[nextX][curr.Y1] == ']')
                        queue.Enqueue(new (nextX, curr.Y1 - 1, nextX, curr.Y1));

                    if(_grid[nextX][curr.Y2] == '[')
                        queue.Enqueue(new (nextX, curr.Y2, nextX, curr.Y2 + 1));
                }
            }

            while(toPush.Any())
            {
                Coords curr = toPush.Pop();
                
                _grid[curr.X1 + currMove[0]][curr.Y1] = '[';
                _grid[curr.X2 + currMove[0]][curr.Y2] = ']';
                _grid[curr.X1][curr.Y1] = '.';
                _grid[curr.X2][curr.Y2] = '.';
            }
            _grid[_botPos[0]][_botPos[1]] = '.';
            _grid[_botPos[0] + currMove[0]][_botPos[1]] = '@';
            _botPos = [_botPos[0] + currMove[0], _botPos[1]];
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);

            int rowNum = 0;
            while(_input[rowNum] != "") rowNum++;

            _grid = new char[rowNum][];

            for (int i = 0; i < _input.Length; i++) 
            {
                if(_input[i] == "") continue;
                
                if(_input[i][0] == '#')
                {
                    _grid[i] = new char[_input[i].Length];

                    for(int j = 0; j < _input[0].Length; j++)
                    {
                        _grid[i][j] = _input[i][j];
                        if(_grid[i][j] == '@') _botPos = [i, j];
                    }
                }
                else
                {
                    for(int j = 0; j < _input[i].Length; j++)
                    {
                        if(_input[i][j] == '^') _moves.Enqueue([-1, 0]);
                        else if(_input[i][j] == '>') _moves.Enqueue([0, 1]);
                        else if(_input[i][j] == 'v') _moves.Enqueue([1, 0]);
                        else if(_input[i][j] == '<') _moves.Enqueue([0, -1]);
                    }
                }
            }
        }

        public int Calculate()
        {
            while(_moves.Any())
            {
                int[] currMove = _moves.Dequeue();
                int nRow = _botPos[0] + currMove[0];
                int nCol = _botPos[1] + currMove[1];
                if(_grid[nRow][nCol] == '#')
                    continue;
                else if(_grid[nRow][nCol] == '.')
                {
                    _grid[_botPos[0]][_botPos[1]] = '.';
                    _grid[nRow][nCol] = '@';
                    _botPos = [nRow, nCol];
                }
                else if(_grid[nRow][nCol] == 'O')
                {
                    int numOfPushes = GetNumberOfPushes(currMove, nRow, nCol);
                    if(numOfPushes > 0)
                    {
                        _grid[_botPos[0]][_botPos[1]] = '.';
                        _grid[nRow][nCol] = '@';
                        _botPos = [nRow, nCol];
                        int nextR = nRow, nextC = nCol;
                        for(int i = 0; i < numOfPushes; i++)
                        {
                            nextR += currMove[0];
                            nextC += currMove[1];
                            _grid[nextR][nextC] = 'O';
                        }
                    }
                }
                
            // PrintGrid(currMove);
            }

            int count = 0;

            for (int row = 0; row < _grid.Length; row++) 
            {
                for(int col = 0; col < _grid[0].Length; col++)
                {
                    if(_grid[row][col] == 'O')
                        count += 100 * row + col;
                }
            }

            return count;
        }

        private int GetNumberOfPushes(int[] currMove, int nRow, int nCol)
        {
            int count = 0;
            int nextR = nRow, nextC = nCol;
            while(_grid[nextR][nextC] != '#')
            {
                if(_grid[nextR][nextC] == '.')
                    return count;
                
                count++;
                nextR += currMove[0];
                nextC += currMove[1];
            }

            return 0;
        }

        private void PrintGrid(int[] currMove)
        {
            StringBuilder sb = new();
            string move = "";
            if(currMove[0] == -1) move = "Move ^:";
            else if(currMove[0] == 1) move = "Move v:";
            else if(currMove[1] == -1) move = "Move <:";
            else if(currMove[1] == 1) move = "Move >:";

            sb.AppendFormat(move, Environment.NewLine);

            for (int row = 0; row < _grid.Length; row++) 
            {
                sb.Append(Environment.NewLine);
                for(int col = 0; col < _grid[0].Length; col++)
                    sb.Append(_grid[row][col]);
            }

            Console.WriteLine(sb);
        }
    }
}