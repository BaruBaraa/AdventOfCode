using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;

namespace AdventOfCode.AdventOfCode2024
{
    internal class Day24Problems
    {
        private string[] _input = [];

        public Day24Problems(string path)
        {
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            _input = File.ReadAllLines(path);
        }

        public int Calculate()
        {
            int count = 0;

            return count;
        }
    }
}