using AdventOfCode.AdventOfCode2024;

class MainTest
{
    static public void Main(String[] args)
    {
        #region day1
        // Day1Problems problemOne = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day1Input.txt");

        // int totalDistance = problemOne.CalculateTotalDistanceBetweenLists();
        // Console.WriteLine($"Day 1 - Problem 1: Total distance: {totalDistance}");

        // int totalSimilarity = problemOne.CalculateSimilarityScoreBetweenLists();
        // Console.WriteLine($"Day 1 - Problem 2: Total similarity: {totalSimilarity}");
        #endregion

        #region day2
        // Day2Problems problemTwo = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day2Input.txt");

        // int totalSafeReports = problemTwo.CalculateNumberOfSafeReports();
        // Console.WriteLine($"Day 2 - Problem 1: Total safe reports: {totalSafeReports}");

        // int totalSafeReportsOneError = problemTwo.CalculateNumberOfSafeReportsOneError();
        // Console.WriteLine($"Day 2 - Problem 2: Total safe reports with one allowed error: {totalSafeReportsOneError}");
        #endregion

        #region day3
        // Day3Problems problemThree = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day3Input.txt");

        // int totalSumOfValidMultiplactions = problemThree.CalculateValidMultiplications();
        // Console.WriteLine($"Day 3 - Problem 1: Total sum of valid multiplications: {totalSumOfValidMultiplactions}");

        // int totalSumOfValidMultiplactionsDoDonts = problemThree.CalculateSumValidMultiplicationsWithDoDonts();
        // Console.WriteLine($"Day 3 - Problem 1: Total sum of valid multiplications with do & don't: {totalSumOfValidMultiplactionsDoDonts}");
        #endregion

        #region day4
        Day4Problems problemFour = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day4Input.txt");

        int totalSum = problemFour.CalculateNumberOfXmasWordsFound();
        Console.WriteLine($"Day 3 - Problem 1: Total sum of valid multiplications: {totalSum}");

        int totalSum2 = problemFour.CalculateNumberOfXmasWordsFoundTwo();
        Console.WriteLine($"Day 3 - Problem 1: Total sum of valid multiplications with do & don't: {totalSum2}");
        #endregion
    }
}