using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;

namespace AdventOfCode.AdventOfCode2024
{
    internal class Day17Problems
    {
        private string[] _input = [];
        private long _regA = 0, _regB = 0, _regC = 0;
        private long[] _programs = [];

        public Day17Problems(string path)
        {
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);
            _regA = int.Parse(_input[0].Substring(12));
            _regB = int.Parse(_input[1].Substring(12));
            _regC = int.Parse(_input[2].Substring(12));
            _programs = Array.ConvertAll(_input[4].Substring(9).Split(','), long.Parse);
        }

        public long CalculateTwo()
        {
            return 1;
        }

        public long Calculate()
        {
            StringBuilder sb = new();

            for(int i = 0; i < _programs.Length; i+=2)
            {
                switch(_programs[i])
                {
                    case 0:
                        CalculateAdv(0, GetCombo(i));
                        break;
                    case 1:
                        _regB ^= _programs[i + 1];
                        break;
                    case 2:
                        _regB = GetCombo(i) % 8;
                        break;
                    case 3:
                        if(_regA == 0) break;
                        i = (int)_programs[i + 1] - 2;
                        break;
                    case 4:
                        _regB ^= _regC;
                        break;
                    case 5:
                        sb.Append(sb.Length > 0 ? "," : "");
                        sb.Append(GetCombo(i) % 8);
                        break;
                    case 6:
                        CalculateAdv(6, GetCombo(i));
                        break;
                    case 7:
                        CalculateAdv(7, GetCombo(i));
                        break;
                }
                if(sb.Length == _input.Length && sb.ToString() == _input[4])
                    return _regA;

                if(sb.Length > _input[4].Length)
                    return -1;
            }

            // return sb.ToString();
            return -1;
        }

        private void CalculateAdv(int caseVal, long combo)
        {
            if(caseVal == 0) _regA = (long)(_regA / Math.Pow(2, combo));
            else if(caseVal == 6) _regB = (long)(_regA / Math.Pow(2, combo));
            else if(caseVal == 7) _regC = (long)(_regA / Math.Pow(2, combo));
        }

        private long GetCombo(int i)
        {
            long combo = (_programs[i + 1]) switch
            {
                0 => 0,
                1 => 1,
                2 => 2,
                3 => 3,
                4 => _regA,
                5 => _regB,
                6 => _regC,
                _ => throw new ArgumentOutOfRangeException()
            };

            return combo;
        }
    }
}