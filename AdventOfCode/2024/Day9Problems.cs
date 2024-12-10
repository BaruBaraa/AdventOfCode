using System.Globalization;
using System.Transactions;

namespace AdventOfCode.AdventOfCode2024
{
    internal class Day9Problems
    {
        private string[] _input = [];

        public Day9Problems(string path)
        {
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);
        }

        public double CalculateFinalChecksum()
        {
            Queue<(int, int)> queueFileBlocksFreeSpaces = new();
            Stack<int> stackFileBlocks = new();
            Dictionary<int, int> countOfFileIds = new();

            int numCount = CreateIdNumsAndFreeSpaces(queueFileBlocksFreeSpaces, stackFileBlocks, countOfFileIds);
            Console.WriteLine($"Num Count: {numCount}");
            double results = MoveToLeftAndCalcCheckSum(queueFileBlocksFreeSpaces, stackFileBlocks, countOfFileIds, numCount);

            return results;
        }

        private int CreateIdNumsAndFreeSpaces(Queue<(int, int)> queueFileBlocksFreeSpaces, Stack<int> stackFileBlocks, Dictionary<int, int> countOfFileIds)
        {
            int curr = 0;
            int numCount = 0;
            for(int i = 0; i < _input[0].Length; i++)
            {
                numCount += _input[0][i] - '0';
                queueFileBlocksFreeSpaces.Enqueue((curr, _input[0][i] - '0'));
                countOfFileIds.TryAdd(curr, _input[0][i] - '0');
                stackFileBlocks.Push(curr);
                if(i + 1 < _input[0].Length && _input[0][i + 1] != '0')
                    queueFileBlocksFreeSpaces.Enqueue((-1, _input[0][i + 1] - '0'));
                i++;
                curr++;
            }
            return numCount;
        }

        private double MoveToLeftAndCalcCheckSum(Queue<(int, int)> queueFileBlocksFreeSpaces, Stack<int> stackFileBlocks, Dictionary<int, int> countOfFileIds, int numCount)
        {
            //I HATE MYSELF, was using an int instead of a double, but didn't know to use a double because I was still getting a positive value back, the second to last variable was overflowing (into negative)
            //but the last multiplication was large enough that when adding to the overflow it was turning it back to a positive.
            double checkSum = 0;
            int currPos = 0;
            int leftOver = 0;
            while(queueFileBlocksFreeSpaces.Any() && currPos < numCount)
            {
                (int, int) curr = queueFileBlocksFreeSpaces.Peek();
                if(leftOver > 0 || curr.Item1 == -1) //free spaces found
                {
                    if(currPos == numCount)
                        return checkSum;
                    
                    leftOver = leftOver > 0 ? leftOver : curr.Item2;
                    int currStack = stackFileBlocks.Pop();
                    int leftOverStack = countOfFileIds[currStack];

                    if(leftOver == leftOverStack)
                    {
                        queueFileBlocksFreeSpaces.Dequeue();
                        for(int i = 0; i < leftOver; i++)
                        {
                            if(--countOfFileIds[currStack] == 0)
                                countOfFileIds.Remove(currStack);
                            checkSum += currPos * currStack;
                            currPos++;
                            if(currPos == numCount)
                            {
                                return checkSum;
                            }
                        }
                        leftOver = 0;
                    }
                    else if(leftOver < leftOverStack)
                    {
                        queueFileBlocksFreeSpaces.Dequeue();
                        for(int i = 0; i < leftOver; i++)
                        {
                            countOfFileIds[currStack]--;
                            checkSum += currPos * currStack;
                            currPos++;
                            if(currPos == numCount)
                            {
                                return checkSum;
                            }
                        }
                        leftOver = 0;
                        stackFileBlocks.Push(currStack);
                    }
                    else if(leftOver > leftOverStack && leftOverStack > 0)
                    {
                        for(int i = 0; i < leftOverStack; i++)
                        {
                            countOfFileIds[currStack]--;
                            checkSum += currPos * currStack;
                            currPos++;
                            if(currPos == numCount)
                            {
                                return checkSum;
                            }
                        }
                        leftOver -= leftOverStack;
                    }
                }
                else
                {
                    (int, int) currRemove = queueFileBlocksFreeSpaces.Dequeue();
                    if(countOfFileIds[currRemove.Item1] > 0)
                    {
                        for(int i = 0; i < currRemove.Item2; i++)
                        {
                            if(countOfFileIds[currRemove.Item1] > 0)
                            {
                                countOfFileIds[currRemove.Item1]--;
                                checkSum += currPos * currRemove.Item1;
                                currPos++;
                                if(currPos == numCount)
                                {
                                    return checkSum;
                                }
                            }
                        }
                    }
                }
            }
            return checkSum;
        }

        public double CalculateFinalChecksumTwo()
        {
            List<int> fileBlocksFreeSpaces = new();
            Dictionary<int, int> countOfFileIds = new();
            Dictionary<int, int> freeSpaceSizes = new();

            int numCount = CreateIdNumsAndFreeSpacesTwo(fileBlocksFreeSpaces, countOfFileIds, freeSpaceSizes);
            double results = MoveToLeftAndCalcCheckSumTwo(fileBlocksFreeSpaces, countOfFileIds, freeSpaceSizes, numCount);

            return results;
        }

        private int CreateIdNumsAndFreeSpacesTwo(List<int> fileBlocksFreeSpaces, Dictionary<int, int> countOfFileIds, Dictionary<int, int> freeSpaceSizes)
        {
            int curr = 0;
            int numCount = 0;
            int freeSpaceEncountered = 0;
            for(int i = 0; i < _input[0].Length; i++)
            {
                int currCount = _input[0][i] - '0';
                for(int j = 0; j < currCount; j++)
                    fileBlocksFreeSpaces.Add(curr);
                
                countOfFileIds.TryAdd(curr, currCount);

                if(i + 1 < _input[0].Length && _input[0][i + 1] != '0')
                {
                    int freeCount = _input[0][i + 1] - '0';
                    freeSpaceSizes.Add(freeSpaceEncountered, freeCount);
                    for(int j = 0; j < freeCount; j++)
                        fileBlocksFreeSpaces.Add(-1);

                    freeSpaceEncountered++;
                }
                i++;
                curr++;
            }
            return numCount;
        }

        private double MoveToLeftAndCalcCheckSumTwo(List<int> fileBlocksFreeSpaces, Dictionary<int, int> countOfFileIds, Dictionary<int, int> freeSpaceSizes, int numCount)
        {
            double checkSum = 0;
            for(int i = 0; i < fileBlocksFreeSpaces.Count; i++)
            {
                if(fileBlocksFreeSpaces[i] == -1)
                {
                    int j = i;
                    int k = fileBlocksFreeSpaces.Count - 1;
                    int count = 0;
                    while(i < fileBlocksFreeSpaces.Count && fileBlocksFreeSpaces[i] == -1)
                    {
                        count++;
                        i++;
                    }
                    while(count > 0 && k > i)
                    {
                        if(fileBlocksFreeSpaces[k] != -1 && fileBlocksFreeSpaces[k] != -2 && countOfFileIds.ContainsKey(fileBlocksFreeSpaces[k]) && countOfFileIds[fileBlocksFreeSpaces[k]] <= count)
                        {
                            int currFileIdCount = countOfFileIds[fileBlocksFreeSpaces[k]];
                            for(int l = currFileIdCount; l > 0; l--)
                            {
                                fileBlocksFreeSpaces[j] = fileBlocksFreeSpaces[k];
                                if(--countOfFileIds[fileBlocksFreeSpaces[j]] == 0)
                                    countOfFileIds.Remove(fileBlocksFreeSpaces[j]);
                                fileBlocksFreeSpaces[k] = -2;
                                j++;
                                k--;
                                count--;
                            }
                        }
                        k--;
                    }
                }
            }

            for(int i = 0; i < fileBlocksFreeSpaces.Count; i++)
            {
                if(fileBlocksFreeSpaces[i] != -1 && fileBlocksFreeSpaces[i] != -2)
                    checkSum += fileBlocksFreeSpaces[i] * i;
            }

            return checkSum;
        }
    }
}