using System.Globalization;
using System.Text;
using System.Transactions;

namespace AdventOfCode.AdventOfCode2024
{
    internal class Day11Problems
    {
        private string[] _input = [];
        private ulong[] _nums = [];

        public class LinkedNode
        {
            public LinkedNode Left = null;
            public LinkedNode Right = null;
            public string Value = "";

            public LinkedNode() {}

            public LinkedNode(LinkedNode left, LinkedNode right, string value)
            {
                Left = left;
                Right = right;
                Value = value;
            }
        }
        public class LinkedList
        {
            public LinkedNode Root = null;
            public int Count = 0;
        }

        public Day11Problems(string path)
        {
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);
            _nums = [0, 7, 6618216, 26481, 885, 42, 202642, 8791];
        }

        public ulong CalculateMemo()
        {
            Dictionary<(ulong, int), ulong> memo = new();
            ulong count = 0;
            for(int i = 0; i < _nums.Length; i++)
            {
                count += DFSHelper(_nums[i], 0, memo);
            }

            return count + 8;
        }

        private ulong DFSHelper(ulong curr, int depth, Dictionary<(ulong, int), ulong> memo)
        {
            if(depth > 74)
                return 0;

            if(memo.ContainsKey((curr, depth)))
                return memo[(curr, depth)];
            
            ulong count = 0;

            string currVal = $"{curr}";

            if(curr == 0)
                count += DFSHelper(1, depth + 1, memo);
            else if(currVal.Length % 2 == 0)
            {
                string firstHalf = currVal.Substring(0, currVal.Length/2);
                string secondHalf = currVal.Substring(currVal.Length/2, currVal.Length - currVal.Length/2);

                ulong firstNum = ulong.Parse(firstHalf);
                ulong secondNum = ulong.Parse(secondHalf);

                count++;
                count += DFSHelper(firstNum, depth + 1, memo);
                count += DFSHelper(secondNum, depth + 1, memo);
            }
            else
                count += DFSHelper(curr * 2024, depth + 1, memo);
            
            memo.Add((curr, depth), count);
            return count;
        }

        /* old solutions */
        // public int Calculate()
        // {
        //     LinkedList stones = new();
        //     LinkedNode curr = null;
        //     for(int i = 0; i < _nums.Length; i++)
        //     {
        //         if(stones.Root == null)
        //         {
        //             LinkedNode rootStone = new (null, null, $"{_nums[i]}");
        //             stones.Root = rootStone;
        //             curr = stones.Root;
        //             stones.Count++;
        //         }
        //         else
        //         {
        //             LinkedNode nextStone = new (curr, null, $"{_nums[i]}");
        //             curr.Right = nextStone;
        //             curr = curr.Right;
        //             stones.Count++;
        //         }
        //     }


        //     int blinkCount = 75;

        //     while(blinkCount > 0)
        //     {
        //         curr = stones.Root;
        //         while(curr != null)
        //         {
        //             if(curr.Value == "0")
        //                 curr.Value = "1";
        //             else if(curr.Value.Length % 2 == 0)
        //             {
        //                 string firstHalf = curr.Value.Substring(0, curr.Value.Length/2);
        //                 string secondHalf = curr.Value.Substring(curr.Value.Length/2, curr.Value.Length - curr.Value.Length/2);

        //                 ulong firstNum = ulong.Parse(firstHalf);
        //                 ulong secondNum = ulong.Parse(secondHalf);

        //                 LinkedNode prev = curr.Left;
        //                 if(prev == null)
        //                 {
        //                     LinkedNode newLeft = new(null, curr, $"{firstNum}");
        //                     curr.Left = newLeft;
        //                     stones.Root = newLeft;
        //                 }
        //                 else
        //                 {
        //                     LinkedNode newLeft = new(prev, curr, $"{firstNum}");
        //                     prev.Right = newLeft;
        //                     curr.Left = newLeft;
        //                 }
        //                 curr.Value = $"{secondNum}";
        //                 stones.Count++;
        //             }
        //             else
        //             {
        //                 ulong firstNum = ulong.Parse(curr.Value);
        //                 curr.Value = $"{firstNum * 2024}";
        //             }
        //             curr = curr.Right;
        //         }
        //         Console.WriteLine($"Iter: {blinkCount}: Stones Count: {stones.Count}");
        //         blinkCount--;
        //     }

        //     Console.WriteLine($"Stones Count: {stones.Count}");
        //     return stones.Count;
        // }

        // public ulong CalculateTwo()
        // {
        //     ulong count = 8;
        //     string nums = "0,7,6618216,26481,885,42,202642,8791";

        //     int blink = 75;
        //     while(blink > 0)
        //     {
        //         StringBuilder sb = new();
        //         StringBuilder currNum = new();
        //         for(int i = 0; i < nums.Length; i++)
        //         {
        //             if(nums[i] == ',')
        //             {
        //                 string currString = currNum.ToString();
        //                 ulong num = ulong.Parse(currNum.ToString());

        //                 if(num == 0)
        //                 {
        //                     num = 1;
        //                     sb.Append(num);
        //                 }
        //                 else if(currString.Length % 2 == 0)
        //                 {
        //                     string firstHalf = currString.Substring(0, currString.Length/2);
        //                     string secondHalf = currString.Substring(currString.Length/2, currString.Length - currString.Length/2);

        //                     ulong firstNum = ulong.Parse(firstHalf);
        //                     ulong secondNum = ulong.Parse(secondHalf);
        //                     sb.Append(firstNum);
        //                     sb.Append(',');
        //                     sb.Append(secondNum);
        //                     count++;
        //                 }
        //                 else
        //                 {
        //                     num *= 2024;
        //                     sb.Append(num);
        //                 }
        //                 sb.Append(',');
        //                 currNum = new();
        //             }
        //             else
        //             {
        //                 currNum.Append(nums[i]);
        //             }
        //         }
        //         string finalString = currNum.ToString();
        //         ulong finalNum = ulong.Parse(finalString);

        //         if(finalNum == 0)
        //         {
        //             finalNum = 1;
        //             sb.Append(finalNum);
        //         }
        //         else if(finalString.Length % 2 == 0)
        //         {
        //             string firstHalf = currNum.ToString().Substring(0, finalString.Length/2);
        //             string secondHalf = finalString.Substring(finalString.Length/2, finalString.Length - finalString.Length/2);

        //             ulong firstNum = ulong.Parse(firstHalf);
        //             ulong secondNum = ulong.Parse(secondHalf);
        //             sb.Append(firstNum);
        //             sb.Append(',');
        //             sb.Append(secondNum);
        //             count++;
        //         }
        //         else
        //         {
        //             finalNum *= 2024;
        //             sb.Append(finalNum);
        //         }

        //         nums = sb.ToString();
        //         Console.WriteLine($"Iter: {blink}, Count: {count}");
        //         blink--;
        //     }
            
        //     return count;
        // }
    }
}