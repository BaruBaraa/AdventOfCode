using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;

namespace AdventOfCode.AdventOfCode2024
{
    internal class Day13Problems
    {
        private string[] _input = [];
        private List<ClawSettings> _allClawSettings;

        public class ClawSettings
        {
            public int Ax;
            public int Ay;
            public int Bx;
            public int By;
            public int Px;
            public int Py;

            public ClawSettings(int aX, int aY, int bX, int bY, int pX, int pY)
            {
                Ax = aX;
                Ay = aY;
                Bx = bX;
                By = bY;
                Px = pX;
                Py = pY;
            }
        }

        public Day13Problems(string path)
        {
            _input = [];
            _allClawSettings = [];
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);

            for(int i = 2; i < _input.Length; i += 4)
            {
                int aX = int.Parse(_input[i-2].Substring(12, 2));
                int aY = int.Parse(_input[i-2].Substring(18, 2));
                int bX = int.Parse(_input[i-1].Substring(12, 2));
                int bY = int.Parse(_input[i-1].Substring(18, 2));
                int pX = int.Parse(_input[i].Substring(9, _input[i].IndexOf(',') - 9));
                int pY = int.Parse(_input[i].Substring(_input[i].IndexOf(',') + 4));

                ClawSettings newSetting = new(aX, aY, bX, bY, pX, pY);

                _allClawSettings.Add(newSetting);
            }
        }

        public int Calculate()
        {
            int count = 0;
            foreach(ClawSettings s in _allClawSettings)
            {
                int currX = s.Px;
                int currY = s.Py;

                int[][] memo = new int[currX + 1][];
                for(int i = 0; i < currX + 1; i++)
                {
                    memo[i] = new int[currY + 1];
                    for(int j = 0; j < currY + 1; j++)
                        memo[i][j] = Int32.MaxValue;
                }

                DFSHelper(currX, currY, 0, 0, s, memo);

                Console.WriteLine(memo[0][0] != Int32.MaxValue ? memo[0][0] : "No Prize Win");
                count += memo[0][0] != Int32.MaxValue ? memo[0][0] : 0;
            }

            return count;
        }

        public void DFSHelper(int x, int y, int a, int b, ClawSettings s, int[][] memo)
        {
            if(a > 100 && b > 100)
                return;

            if(x == 0 && y == 0)
                memo[x][y] = Math.Min(memo[x][y], a * 3 + b);

            int nextAx = x - s.Ax, nextBx = x - s.Bx, nextAy = y - s.Ay, nextBy = y - s.By;
            int nextACost = (a + 1) * 3 + b, nextBCost = a * 3 + b + 1;

            if(nextACost < memo[0][0])
            {
                if(nextAx >= 0 && nextACost < memo[nextAx][y])
                {
                    memo[nextAx][y] = nextACost;
                    DFSHelper(nextAx, y, a + 1, b, s, memo);
                }
                
                if(nextAy >= 0 && nextACost < memo[x][nextAy])
                {
                    memo[x][nextAy] = nextACost;
                    DFSHelper(x, nextAy, a + 1, b, s, memo);
                }
            }
            if(nextBCost < memo[0][0])
            {
                if(nextBx >= 0 && nextBCost < memo[nextBx][y])
                {
                    memo[nextBx][y] = nextBCost;
                    DFSHelper(nextBx, y, a, b + 1, s, memo);
                }
                
                if(nextBy >= 0 && nextBCost < memo[x][nextBy])
                {
                    memo[x][nextBy] = nextBCost;
                    DFSHelper(x, nextBy, a, b + 1, s, memo);
                }
            }
        }

        public class QueueObject
        {
            public int X;
            public int Y;
            public int A;
            public int B;

            public QueueObject(int x, int y, int a, int b)
            {
                X = x;
                Y = y;
                A = a;
                B = b;
            }
        }

        public int CalculateTwo()
        {
            int count = 0;
            
            foreach(ClawSettings s in _allClawSettings)
            {
                int currCount = Int32.MaxValue;
                int currX = s.Px;
                int currY = s.Py;

                int[][] memo = new int[currX + 1][];
                for(int i = 0; i < currX + 1; i++)
                {
                    memo[i] = new int[currY + 1];
                    for(int j = 0; j < currY + 1; j++)
                        memo[i][j] = Int32.MaxValue;
                }

                Queue<QueueObject> queue = new();
                queue.Enqueue(new (currX, currY, 0, 0));

                while(queue.Any())
                {
                    QueueObject curr = queue.Dequeue();

                    if(curr.X == 0 && curr.Y == 0)
                        currCount = Math.Min(currCount, curr.A * 3 + curr.B);
                    else
                    {
                        int nextAx = curr.X - s.Ax, nextBx = curr.X - s.Bx, nextAy = curr.Y - s.Ay, nextBy = curr.Y - s.By;
                        int nextACost = (curr.A + 1) * 3 + curr.B, nextBCost = curr.A * 3 + curr.B + 1;

                        if(nextACost < currCount)
                        {
                            if(nextAx >= 0 && nextACost < memo[nextAx][curr.Y])
                            {
                                memo[nextAx][curr.Y] = nextACost;
                                queue.Enqueue(new (nextAx, curr.Y, curr.A + 1, curr.B));
                            }
                            
                            if(nextAy >= 0 && nextACost < memo[curr.X][nextAy])
                            {
                                memo[curr.X][nextAy] = nextACost;
                                queue.Enqueue(new (curr.X, nextAy, curr.A + 1, curr.B));
                            }
                        }
                        if(nextBCost < currCount)
                        {
                            if(nextBx >= 0 && nextBCost < memo[nextBx][curr.Y])
                            {
                                memo[nextBx][curr.Y] = nextBCost;
                                queue.Enqueue(new (nextBx, curr.Y, curr.A, curr.B + 1));
                            }
                            
                            if(nextBy >= 0 && nextBCost < memo[curr.X][nextBy])
                            {
                                memo[curr.X][nextBy] = nextBCost;
                                queue.Enqueue(new (curr.X, nextBy, curr.A, curr.B + 1));
                            }
                        }
                    }
                }
                Console.WriteLine(currCount);
                count += currCount != Int32.MaxValue ? currCount : 0;
            }

            return count;
        }
    }
}