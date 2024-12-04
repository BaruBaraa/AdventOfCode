namespace AdventOfCode.AdventOfCode2024
{
    internal class Day3Problems
    {
        private string[] _input;

        public Day3Problems(string path)
        {
            _input = [];
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);
        }

        public int CalculateValidMultiplications()
        {
            int totalMultiplications = 0;
            foreach(string line in _input)
            {
                for(int i = 0; i < line.Length; i++)
                {
                    if(i + 7 < line.Length && line.Substring(i, 4) == "mul(")
                    {
                        i += 4;
                        int first = 0, second = 0;
                        bool isValidNum = true;

                        while(isValidNum && line[i] != ',')
                        {
                            if(line[i] - '0' >= 0 && line[i] - '0' <= 9)
                            {
                                if(first == 0 && line[i] - '0' == 0)
                                {
                                    isValidNum = false;
                                    break;
                                }
                                first *= 10;
                                first += line[i] - '0';
                                i++;
                            }
                            else
                                isValidNum = false;
                        }
                        if(isValidNum == false)
                            continue;

                        i++;
                        while(isValidNum && line[i] != ')')
                        {
                            if(line[i] - '0' >= 0 && line[i] - '0' <= 9)
                            {
                                if(second == 0 && line[i] - '0' == 0)
                                {
                                    isValidNum = false;
                                    break;
                                }
                                second *= 10;
                                second += line[i] - '0';
                                i++;
                            }
                            else
                                isValidNum = false;
                        }

                        if(isValidNum == false)
                            continue;

                        totalMultiplications += first * second;
                    }
                }
            }

            return totalMultiplications;
        }

        public int CalculateSumValidMultiplicationsWithDoDonts()
        {
            int totalMultiplications = 0;
            bool doMultiplication = true;
            foreach(string line in _input)
            {
                for(int i = 0; i < line.Length; i++)
                {

                    if(i + 6 < line.Length && line.Substring(i, 7) == "don't()")
                        doMultiplication = false;
                    else if(i + 3 < line.Length && line.Substring(i, 4) == "do()")
                        doMultiplication = true;

                    if(doMultiplication && i + 7 < line.Length && line.Substring(i, 4) == "mul(")
                    {
                        i += 4;
                        int first = 0, second = 0;
                        bool isValidNum = true;

                        while(isValidNum && line[i] != ',')
                        {
                            if(line[i] - '0' >= 0 && line[i] - '0' <= 9)
                            {
                                if(first == 0 && line[i] - '0' == 0)
                                {
                                    isValidNum = false;
                                    break;
                                }
                                first *= 10;
                                first += line[i] - '0';
                                i++;
                            }
                            else
                                isValidNum = false;
                        }
                        if(isValidNum == false)
                            continue;

                        i++;
                        while(isValidNum && line[i] != ')')
                        {
                            if(line[i] - '0' >= 0 && line[i] - '0' <= 9)
                            {
                                if(second == 0 && line[i] - '0' == 0)
                                {
                                    isValidNum = false;
                                    break;
                                }
                                second *= 10;
                                second += line[i] - '0';
                                i++;
                            }
                            else
                                isValidNum = false;
                        }

                        if(isValidNum == false)
                            continue;

                        totalMultiplications += first * second;
                    }
                }
            }

            return totalMultiplications;
        }
    }
}