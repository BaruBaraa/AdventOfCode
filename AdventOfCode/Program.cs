using AdventOfCode.AdventOfCode2024;

class MainTest
{
    static public void Main(String[] args)
    {
        #region day1
        Day1Problems problemOne = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day1Input.txt");

        int totalDistance = problemOne.CalculateTotalDistanceBetweenLists();
        Console.WriteLine($"Day 1 - Problem 1: Total distance: {totalDistance}");

        int totalSimilarity = problemOne.CalculateSimilarityScoreBetweenLists();
        Console.WriteLine($"Day 1 - Problem 2: Total similarity: {totalSimilarity}");
        #endregion

        #region day2
        Day2Problems problemTwo = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day2Input.txt");

        int totalSafeReports = problemTwo.CalculateNumberOfSafeReports();
        Console.WriteLine($"Day 2 - Problem 1: Total safe reports: {totalSafeReports}");

        int totalSafeReportsOneError = problemTwo.CalculateNumberOfSafeReportsOneError();
        Console.WriteLine($"Day 2 - Problem 2: Total safe reports with one allowed error: {totalSafeReportsOneError}");
        #endregion
    }
}