using AdventOfCode.AdventOfCode2024;

class MainTest
{
    static public void Main(String[] args)
    {
        //RunDayOneProblems();
        //RunDayTwoProblems();
        //RunDayThreeProblems();
        //RunDayFourProblems();
        //RunDayFiveProblems();
        //RunDaySixProblems();
        //RunDaySevenProblems();
        RunDayEightProblems();
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

    private static void RunDaySixProblems()
    {
        Day6Problems problemSix = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day6Input.txt");

        int day6results = problemSix.CalculateGaurdDistinctPositions();
        Console.WriteLine($"Day 6 - Problem 1: {day6results}");

        int stackSize = Int32.MaxValue;
        Thread th  = new Thread( ()=>
        {
            int day6results2 = problemSix.CalculateNumberAddedObstructionLoops();
            Console.WriteLine($"Day 6 - Problem 2: {day6results2}");
        },
        stackSize);

        th.Start();
        th.Join();
    }

    private static void RunDaySevenProblems()
    {
        Day7Problems problemSeven = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day7Input.txt");

        double day7Results = problemSeven.CalculateTotalValidCalibration();
        Console.WriteLine($"Day 7 - Problem 1: {day7Results}");

        double day7Results2 = problemSeven.CalculateTotalValidCalibrationOrOperator();
        Console.WriteLine($"Day 7 - Problem 2: {day7Results2}");
    }

    private static void RunDayEightProblems()
    {
        Day8Problems problemEight = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day8Input.txt");

        int day8results = problemEight.CalculateAllAntinodes();
        Console.WriteLine($"Day 8 - Problem 1: {day8results}");

        // int day8results2 = problemSix.CalculateNumberAddedObstructionLoops();
        // Console.WriteLine($"Day 8 - Problem 2: {day8results2}");
    }
}