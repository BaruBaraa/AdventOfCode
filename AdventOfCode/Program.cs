using AdventOfCode.AdventOfCode2024;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

class MainTest
{
    static public void Main(String[] args)
    {
        #region adventofcode2024
        ProblemOne problemOne = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\ProblemOneInput.txt");

        int totalDistance = problemOne.CalculateTotalDistanceBetweenLists();
        Console.WriteLine($"Total Distance: {totalDistance}");

        int totalSimilarity = problemOne.CalculateSimilarityScoreBetweenLists();
        Console.WriteLine($"Total Similarity: {totalSimilarity}");        
        #endregion
    }
}