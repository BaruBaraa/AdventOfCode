namespace AdventOfCode.AdventOfCode2024
{
    internal class Day2Problems
    {
        private int[][] _nums;

        public Day2Problems(string path)
        {
            _nums = [];
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            _nums = new int[lines.Length][];

            for (int i = 0; i < lines.Length; i++) {
                string[] line = lines[i].Split(" ");
                _nums[i] = new int[line.Length];

                for(int j = 0; j < line.Length; j++)
                    _nums[i][j] = int.Parse(line[j]);
            }
        }

        public int CalculateNumberOfSafeReports()
        {
            int numOfSafeReports = 0;

            foreach(int[] numSubset in _nums)
            {
                bool isIncreasing = numSubset[1] - numSubset[0] > 0;
                bool isSafe = true;
                for(int i = 1; i < numSubset.Length; i++)
                {
                    int curr = numSubset[i] - numSubset[i - 1];
                    
                    if((isIncreasing && (curr <=0 || curr > 3)) || (!isIncreasing && (curr >= 0 || curr < -3)))
                    {
                        isSafe = false;
                        break;
                    }
                }

                if(isSafe)
                    numOfSafeReports++;
            }
            return numOfSafeReports;
        }

        public int CalculateNumberOfSafeReportsOneError()
        {
            int numOfSafeReports = 0;

            foreach(int[] numSubset in _nums)
            {
                bool isIncreasing = numSubset[1] - numSubset[0] > 0;
                bool isSafe = true;
                bool errorAllowedUsed = false;

                for(int i = 1; i < numSubset.Length; i++)
                {
                    int curr = numSubset[i] - numSubset[i - 1];
                    
                    if((isIncreasing && (curr <=0 || curr > 3)) || (!isIncreasing && (curr >= 0 || curr < -3)))
                    {
                        if(errorAllowedUsed)
                        {
                            isSafe = false;
                            break;
                        }
                        errorAllowedUsed = true;
                    }
                }

                if(isSafe)
                    numOfSafeReports++;
            }
            return numOfSafeReports;
        }
    }
}