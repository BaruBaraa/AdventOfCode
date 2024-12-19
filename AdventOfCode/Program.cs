using AdventOfCode.AdventOfCode2024;

class MainTest
{
    static public void Main(String[] args)
    {
        // RunDayOneProblems();
        // RunDayTwoProblems();
        // RunDayThreeProblems();
        // RunDayFourProblems();
        // RunDayFiveProblems();
        // RunDaySixProblems();
        // RunDaySevenProblems();
        // RunDayEightProblems();
        // RunDayNineProblems();
        // RunDayTenProblems();
        // RunDayElevenProblems();
        // RunDayTwelveProblems();
        // RunDayThirteenProblems();
        // RunDayFourteenProblems();
        // RunDayFifteenProblems();
        // RunDay16Problems();
        // RunDay17Problems();
        // RunDay18Problems();
        RunDay19Problems();
        // RunDay20Problems();
        // RunDay21Problems();
        // RunDay22Problems();
        // RunDay23Problems();
        // RunDay24Problems();
        // RunDay25Problems();
    }

    private static void RunDayOneProblems()
    {
        Day1Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day1Input.txt");

        int totalDistance = problem.CalculateTotalDistanceBetweenLists();
        Console.WriteLine($"Day 1 - Problem 1: Total distance: {totalDistance}");

        int totalSimilarity = problem.CalculateSimilarityScoreBetweenLists();
        Console.WriteLine($"Day 1 - Problem 2: Total similarity: {totalSimilarity}");
    }

    private static void RunDayTwoProblems()
    {
        Day2Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day2Input.txt");

        int totalSafeReports = problem.CalculateNumberOfSafeReports();
        Console.WriteLine($"Day 2 - Problem 1: Sum of safe reports: {totalSafeReports}");

        int totalSafeReportsOneError = problem.CalculateNumberOfSafeReportsOneError();
        Console.WriteLine($"Day 2 - Problem 2: Sum of safe reports with one allowed error: {totalSafeReportsOneError}");
    }

    private static void RunDayThreeProblems()
    {
        Day3Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day3Input.txt");

        int totalSumOfValidMultiplactions = problem.CalculateValidMultiplications();
        Console.WriteLine($"Day 3 - Problem 1: Sum of valid multiplications: {totalSumOfValidMultiplactions}");

        int totalSumOfValidMultiplactionsDoDonts = problem.CalculateSumValidMultiplicationsWithDoDonts();
        Console.WriteLine($"Day 3 - Problem 2: Sum of valid multiplications with do & don't: {totalSumOfValidMultiplactionsDoDonts}");
    }

    private static void RunDayFourProblems()
    {
        Day4Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day4Input.txt");

        int totalSum = problem.CalculateNumberOfXmasWordsFound();
        Console.WriteLine($"Day 4 - Problem 1: Sum of valid multiplications: {totalSum}");

        int totalSum2 = problem.CalculateNumberOfXmasWordsFoundTwo();
        Console.WriteLine($"Day 4 - Problem 2: Sum of valid multiplications including do/don't: {totalSum2}");
    }

    private static void RunDayFiveProblems()
    {
        Day5Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day5Input.txt");

        int day5results = problem.CalculateSumOfValidMids();
        Console.WriteLine($"Day 5 - Problem 1: Sum of valid mids: {day5results}");

        int day5results2 = problem.CalculateSumOfFixedInvalidMids();
        Console.WriteLine($"Day 5 - Problem 2: Sum of fixed invalid mids: {day5results2}");
    }

    private static void RunDaySixProblems()
    {
        Day6Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day6Input.txt");

        int day6results = problem.CalculateGaurdDistinctPositions();
        Console.WriteLine($"Day 6 - Problem 1: {day6results}");

        int stackSize = Int32.MaxValue;
        Thread th  = new Thread( ()=>
        {
            int day6results2 = problem.CalculateNumberAddedObstructionLoops();
            Console.WriteLine($"Day 6 - Problem 2: {day6results2}");
        },
        stackSize);

        th.Start();
        th.Join();
    }

    private static void RunDaySevenProblems()
    {
        Day7Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day7Input.txt");

        double day7Results = problem.CalculateTotalValidCalibration();
        Console.WriteLine($"Day 7 - Problem 1: {day7Results}");

        double day7Results2 = problem.CalculateTotalValidCalibrationOrOperator();
        Console.WriteLine($"Day 7 - Problem 2: {day7Results2}");
    }

    private static void RunDayEightProblems()
    {
        Day8Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day8Input.txt");

        int day8results = problem.CalculateAllAntinodes();
        Console.WriteLine($"Day 8 - Problem 1: {day8results}");
    }

    private static void RunDayNineProblems()
    {
        Day9Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day9Input.txt");

        double day9results = problem.CalculateFinalChecksum();
        Console.WriteLine($"Day 9 - Problem 1: {day9results}");

        double day9results2 = problem.CalculateFinalChecksumTwo();
        Console.WriteLine($"Day 9 - Problem 2: {day9results2}");
    }

    private static void RunDayTenProblems()
    {
        Day10Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day10Input.txt");

        var watch = System.Diagnostics.Stopwatch.StartNew();
        double day10results = problem.Calculate();
        watch.Stop();
        Console.WriteLine($"Day 10 - Problem 1: {day10results}, elapsed ticks: {watch.ElapsedTicks}");

        watch.Reset();
        watch.Start();
        double day10resultsMemo = problem.CalculateMemo();
        watch.Stop();
        Console.WriteLine($"Day 10 - Problem 1: {day10resultsMemo}, elapsed ticks: {watch.ElapsedTicks}");

        // double day10results2 = problem.CalculateFinalChecksumTwo();
        // Console.WriteLine($"Day 10 - Problem 2: {day10results2}");
    }

    private static void RunDayElevenProblems()
    {
        Day11Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day11Input.txt");

        ulong day11results = problem.CalculateMemo();
        Console.WriteLine($"Day 11 - Problem 1: {day11results}");

        // double day11results2 = problem.Calculate();
        // Console.WriteLine($"Day 11 - Problem 2: {day11results2}");
    }

    private static void RunDayTwelveProblems()
    {
        Day12Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day12Input.txt");

        // int day12results = problem.CalculateTotalFencingCost();
        // Console.WriteLine($"Day 12 - Problem 1: {day12results}");

        int day12results2 = problem.CalculateTotalFencingCostTwo();
        Console.WriteLine($"Day 12 - Problem 2: {day12results2}");
    }

    private static void RunDayThirteenProblems()
    {
        Day13Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day13Input.txt");

        // int day13results = problem.Calculate();
        // Console.WriteLine($"Day 13 - Problem 1: {day13results}");

        Int64 day13resultsMod = problem.CalculateMod();
        Console.WriteLine($"Day 13 - Problem 2: {day13resultsMod}");

        // ulong day13results2 = problem.CalculateTwo();
        // Console.WriteLine($"Day 13 - Problem 2: {day13results2}");
    }

    private static void RunDayFourteenProblems()
    {
        Day14Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day14Input.txt");

        // int day14results = problem.Calculate();
        // Console.WriteLine($"Day 14 - Problem 1: {day14results}");

        problem.DrawChristmasTree();
    }

    private static void RunDayFifteenProblems()
    {
        Day15Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day15Input.txt");
        
        int day15results = problem.CalculateTwo();
        Console.WriteLine($"Day 15 - Problem 1: {day15results}");

        int day15results2 = problem.CalculateTwo();
        Console.WriteLine($"Day 15 - Problem 2: {day15results}");
    }

    private static void RunDay16Problems()
    {
        Day16Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day16Input.txt");
        
        int dayresults = problem.Calculate(false);
        Console.WriteLine($"Problem 1: {dayresults}");

        problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day16Input.txt");
        int dayresults2 = problem.Calculate(true);
        Console.WriteLine($"Problem 2: {dayresults2}");
    }

    private static void RunDay17Problems()
    {
        Day17Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day17Input.txt");
        
        // string dayresults = problem.Calculate();
        // Console.WriteLine($"Problem 1: {dayresults}");

        long dayresults2 = problem.CalculateTwo();
        Console.WriteLine($"Problem 2: {dayresults2}");
    }

    private static void RunDay18Problems()
    {
        Day18Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day18Input.txt");
        
        // int dayresults = problem.Calculate();
        // Console.WriteLine($"Problem 1: {dayresults}");

        (int x, int y) dayresults2 = problem.CalculateTwo();
        Console.WriteLine($"Problem 2: ({dayresults2.x},{dayresults2.y})");
    }

    private static void RunDay19Problems()
    {
        Day19Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day19Input.txt");
        
        long dayresults = problem.Calculate();
        Console.WriteLine($"Problem 1: {dayresults}");

        // int dayresults2 = problem.Calculate();
        // Console.WriteLine($"Problem 2: {dayresults2}");
    }

    private static void RunDay20Problems()
    {
        Day20Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day20Input.txt");
        
        int dayresults = problem.Calculate();
        Console.WriteLine($"Problem 1: {dayresults}");

        // int dayresults2 = problem.Calculate();
        // Console.WriteLine($"Problem 2: {dayresults2}");
    }

    private static void RunDay21Problems()
    {
        Day21Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day21Input.txt");
        
        int dayresults = problem.Calculate();
        Console.WriteLine($"Problem 1: {dayresults}");

        // int dayresults2 = problem.Calculate();
        // Console.WriteLine($"Problem 2: {dayresults2}");
    }

    private static void RunDay22Problems()
    {
        Day22Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day22Input.txt");
        
        int dayresults = problem.Calculate();
        Console.WriteLine($"Problem 1: {dayresults}");

        // int dayresults2 = problem.Calculate();
        // Console.WriteLine($"Problem 2: {dayresults2}");
    }

    private static void RunDay23Problems()
    {
        Day23Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day23Input.txt");
        
        int dayresults = problem.Calculate();
        Console.WriteLine($"Problem 1: {dayresults}");

        // int dayresults2 = problem.Calculate();
        // Console.WriteLine($"Problem 2: {dayresults2}");
    }

    private static void RunDay24Problems()
    {
        Day24Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day24Input.txt");
        
        int dayresults = problem.Calculate();
        Console.WriteLine($"Problem 1: {dayresults}");

        // int dayresults2 = problem.Calculate();
        // Console.WriteLine($"Problem 2: {dayresults2}");
    }

    private static void RunDay25Problems()
    {
        Day25Problems problem = new("C:\\Source\\AdventOfCode\\AdventOfCode\\2024\\Day25Input.txt");
        
        int dayresults = problem.Calculate();
        Console.WriteLine($"Problem 1: {dayresults}");

        // int dayresults2 = problem.Calculate();
        // Console.WriteLine($"Problem 2: {dayresults2}");
    }
}