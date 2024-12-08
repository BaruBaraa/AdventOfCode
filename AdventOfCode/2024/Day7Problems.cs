using System.ComponentModel.DataAnnotations;

namespace AdventOfCode.AdventOfCode2024
{
    internal class Day7Problems
    {
        private string[] _input;
        private double[] _solutions;
        private int[][] _nums;
        // private List<int, List<int>> _nums;

        public Day7Problems(string path)
        {
            _input = [];
            _solutions = [];
            _nums = [];
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);
            _solutions = new double[_input.Length];
            _nums = new int[_input.Length][];

            for (int i = 0; i < _input.Length; i++) {
                string[] line = _input[i].Split(":");
                
                _solutions[i] = double.Parse(line[0]);

                string[] lineTwo = line[1].Split(" ");

                _nums[i] = new int[lineTwo.Length - 1];

                for(int j = 0; j < _nums[i].Length; j++)
                    _nums[i][j] = int.Parse(lineTwo[j + 1]);
            }
        }

        public double CalculateTotalValidCalibration()
        {
            double sumOfValid = 0;
            for(int i = 0; i < _solutions.Length; i++)
            {
                if(DFSHelper(i, 1, _nums[i][0]))
                    sumOfValid += _solutions[i];
            }
            return sumOfValid;
        }

        public double CalculateTotalValidCalibrationOrOperator()
        {
            double sumOfValid = 0;
            for(int i = 0; i < _solutions.Length; i++)
            {
                if(DFSHelperTwo(i, 1, _nums[i][0]))
                    sumOfValid += _solutions[i];
            }
            return sumOfValid;
        }

        private bool DFSHelper(int currAnswerIndex, int currIndex, double currTotal)
        {
        
            if(currTotal == _solutions[currAnswerIndex] && currIndex == _nums[currAnswerIndex].Length)
                return true;
            
            if(currTotal > _solutions[currAnswerIndex] || currIndex >= _nums[currAnswerIndex].Length)
                return false;

            double temp = currTotal + _nums[currAnswerIndex][currIndex];
            if(DFSHelper(currAnswerIndex, currIndex + 1, temp))
                return true;

            double temp2 = currTotal * _nums[currAnswerIndex][currIndex];
            if(DFSHelper(currAnswerIndex, currIndex + 1, temp2))
                return true;

            return false;
        }

        private bool DFSHelperTwo(int currAnswerIndex, int currIndex, double currTotal)
        {
        
            if(currTotal == _solutions[currAnswerIndex] && currIndex == _nums[currAnswerIndex].Length)
                return true;
            
            if(currTotal > _solutions[currAnswerIndex] || currIndex >= _nums[currAnswerIndex].Length)
                return false;

            double temp = currTotal + _nums[currAnswerIndex][currIndex];
            if(DFSHelperTwo(currAnswerIndex, currIndex + 1, temp))
                return true;

            double temp2 = currTotal * _nums[currAnswerIndex][currIndex];
            if(DFSHelperTwo(currAnswerIndex, currIndex + 1, temp2))
                return true;

            int length = _nums[currAnswerIndex][currIndex].ToString().Length;
            for(int i = 0; i < length; i++)
                currTotal *= 10;
            
            double temp3 =  currTotal + _nums[currAnswerIndex][currIndex];
            if(DFSHelperTwo(currAnswerIndex, currIndex + 1, temp3))
                return true;

            return false;
        }
    }
}