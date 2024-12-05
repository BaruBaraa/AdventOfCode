using AdventOfCode.AdventOfCode2024;

class MainTest
{
    static public void Main(String[] args)
    {
        RunDayOneProblems();
        RunDayTwoProblems();
        RunDayThreeProblems();
        RunDayFourProblems();
        RunDayFiveProblems();
    }

    private static void RunDayOneProblems()
    {
        Day1Problems problemOne = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day1Input.txt");

        int totalDistance = problemOne.CalculateTotalDistanceBetweenLists();
        Console.WriteLine($"Day 1 - Problem 1: Total distance: {totalDistance}");

        int totalSimilarity = problemOne.CalculateSimilarityScoreBetweenLists();
        Console.WriteLine($"Day 1 - Problem 2: Total similarity: {totalSimilarity}");
    }

    private static void RunDayTwoProblems()
    {
        Day2Problems problemTwo = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day2Input.txt");

        int totalSafeReports = problemTwo.CalculateNumberOfSafeReports();
        Console.WriteLine($"Day 2 - Problem 1: Sum of safe reports: {totalSafeReports}");

        int totalSafeReportsOneError = problemTwo.CalculateNumberOfSafeReportsOneError();
        Console.WriteLine($"Day 2 - Problem 2: Sum of safe reports with one allowed error: {totalSafeReportsOneError}");
    }

    private static void RunDayThreeProblems()
    {
        Day3Problems problemThree = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day3Input.txt");

        int totalSumOfValidMultiplactions = problemThree.CalculateValidMultiplications();
        Console.WriteLine($"Day 3 - Problem 1: Sum of valid multiplications: {totalSumOfValidMultiplactions}");

        int totalSumOfValidMultiplactionsDoDonts = problemThree.CalculateSumValidMultiplicationsWithDoDonts();
        Console.WriteLine($"Day 3 - Problem 2: Sum of valid multiplications with do & don't: {totalSumOfValidMultiplactionsDoDonts}");
    }

    private static void RunDayFourProblems()
    {
        Day4Problems problemFour = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day4Input.txt");

        int totalSum = problemFour.CalculateNumberOfXmasWordsFound();
        Console.WriteLine($"Day 4 - Problem 1: Sum of valid multiplications: {totalSum}");

        int totalSum2 = problemFour.CalculateNumberOfXmasWordsFoundTwo();
        Console.WriteLine($"Day 4 - Problem 2: Sum of valid multiplications including do/don't: {totalSum2}");
    }

    private static void RunDayFiveProblems()
    {
        Day5Problems problemFive = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day5Input.txt");

        int day5results = problemFive.CalculateSumOfValidMids();
        Console.WriteLine($"Day 5 - Problem 1: Sum of valid mids: {day5results}");

        int day5results2 = problemFive.CalculateSumOfFixedInvalidMids();
        Console.WriteLine($"Day 5 - Problem 2: Sum of fixed invalid mids: {day5results2}");
    }
}