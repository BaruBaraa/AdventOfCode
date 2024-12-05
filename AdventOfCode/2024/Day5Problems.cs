using System.ComponentModel.DataAnnotations;

namespace AdventOfCode.AdventOfCode2024
{
    internal class Day5Problems
    {
        private string[] _input;
        private Dictionary<int, HashSet<int>> _graph;
        private int[][] _nums;

        public Day5Problems(string path)
        {
            _input = [];
            _graph = new();
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);

            //Read and create graph
            int i;
            for (i = 0; i < _input.Length; i++) {
                if(_input[i].Length > 0)
                {
                    string[] line = _input[i].Split("|");
                    int num1 = int.Parse(line[0]);
                    int num2 = int.Parse(line[1]);

                    if(!_graph.ContainsKey(num1))
                        _graph.Add(num1, new HashSet<int>());

                    _graph[num1].Add(num2);
                }
                else
                    break;
            }

            i++;

            //Create list of nums to check validity
            _nums = new int[_input.Length - i][];
            int x = 0;
            for(i = i; i < _input.Length; i++)
            {
                string[] line = _input[i].Split(",");
                _nums[x] = new int[line.Length];

                for(int j = 0; j < line.Length; j++)
                    _nums[x][j] = int.Parse(line[j]);
                
                x++;
            }
        }

        public int CalculateSumOfValidMids()
        {
            int sumOfValidMids = 0;
            foreach(int[] nums in _nums)
            {
                bool isValid = true;
                int i;
                for(i = 0; i < nums.Length; i++)
                {
                    for(int j = i - 1; j >= 0; j--)
                    {
                        if(_graph[nums[i]].Contains(nums[j]))
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if(!isValid)
                        break;
                }
                if(isValid)
                    sumOfValidMids += nums[i/2];
            }
            return sumOfValidMids;
        }

        public int CalculateFixedInvalidMids()
        {
            int sumOfValidMids = 0;
            foreach(int[] nums in _nums)
            {
                bool isValid = true;
                int i;
                for(i = 0; i < nums.Length; i++)
                {
                    for(int j = i - 1; j >= 0; j--)
                    {
                        if(_graph[nums[i]].Contains(nums[j]))
                        {
                            isValid = false;
                            int temp = nums[i - 1];
                            nums[i - 1] = nums[i];
                            nums[i] = temp;
                            i = 0;
                            break;
                        }
                    }
                }
                if(!isValid)
                    sumOfValidMids += nums[i/2];
            }
            return sumOfValidMids;
        }
    }
}