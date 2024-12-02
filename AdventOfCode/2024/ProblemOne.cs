using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.AdventOfCode2024
{
    internal class ProblemOne
    {
        private int[] _arr1;
        private int[] _arr2;

        public ProblemOne(string path)
        {
            _arr1 = [];
            _arr2 = [];
            ReadNumInputsFromFile(path);
        }

        private void ReadNumInputsFromFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            _arr1 = new int[lines.Length];
            _arr2 = new int[lines.Length];

            for (var i = 0; i < lines.Length; i += 1) {
                string[] line = lines[i].Split("   ");
                _arr1[i] = int.Parse(line[0]);
                _arr2[i] = int.Parse(line[1]);
            }
        }

        public int CalculateTotalDistanceBetweenLists()
        {
            PriorityQueue<int, int> pQueueFirstList = new();
            PriorityQueue<int, int> pQueueSecondList = new();
            Dictionary<int, int> firstListDict = new();
            Dictionary<int, int> secondListDict = new();

            PopulateQueueAndDictFromLists(pQueueFirstList, firstListDict, _arr1);
            PopulateQueueAndDictFromLists(pQueueSecondList, secondListDict, _arr2);

            int totalDistance = 0;

            while(pQueueFirstList.TryPeek(out int element, out int priority))
            {
                int first = element;
                int second = pQueueSecondList.Peek();

                totalDistance += Math.Abs(first - second);

                if(--firstListDict[first] == 0)
                    pQueueFirstList.Dequeue();

                if(--secondListDict[second] == 0)
                    pQueueSecondList.Dequeue();
            }
            
            return totalDistance;
        }

        private void PopulateQueueAndDictFromLists(PriorityQueue<int, int> pQueue, Dictionary<int, int> listDict, int[] nums)
        {
            foreach(int num in nums)
            {
                if(listDict.ContainsKey(num))
                    listDict[num]++;
                else
                {
                    listDict.Add(num, 1);
                    pQueue.Enqueue(num, num);
                }
            }
        }

        public int CalculateSimilarityScoreBetweenLists()
        {
            Dictionary<int, int> secondListDict = new();

            for(int i=0; i < _arr2.Length; i++)
            {
                if(!secondListDict.ContainsKey(_arr2[i]))
                    secondListDict.Add(_arr2[i], 0);

                secondListDict[_arr2[i]]++;
            }

            int totalSimilarity = 0;

            foreach(int num in _arr1)
            {
                if(secondListDict.ContainsKey(num))
                    totalSimilarity += num * secondListDict[num];
            }
            
            return totalSimilarity;
        }
    }
}