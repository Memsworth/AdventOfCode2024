using AoCHelper;

namespace AoC2024;

public class Day02 : BaseDay
{
    private readonly string[] _input;
    public Day02()
    {
        _input = File.ReadAllLines(InputFilePath);
    }
    public override ValueTask<string> Solve_1() => 
        new($"{SolvingOne()}");

    public override ValueTask<string> Solve_2() => 
        new($"{SolvingTwo()}");


    private int SolvingOne()
    {
        var safe = 0;
        foreach (var line in _input)
        {
            var numbersOnEachLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            var numbers = numbersOnEachLine.Select(n => int.Parse(n.ToString())).ToList();
            if (IsSafe(numbersOnEachLine))
            {
                safe++;
            }
        }
        return safe;
    }
    
    private int SolvingTwo()
    {
        var safe = 0;
        foreach (var line in _input)
        {
            var numbersOnEachLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            var numbers = numbersOnEachLine.Select(n => int.Parse(n.ToString())).ToList();
            if (IsSafe(numbersOnEachLine))
            {
                safe++;
            }
            else
            {
                for (int i = 0; i < numbersOnEachLine.Count; i++)
                {
                    var copy = numbersOnEachLine.ToList();
                    copy.RemoveAt(i);
                    if (IsSafe(copy))
                    {
                        safe++;
                        break;
                    }
                }
            }
        }
        return safe;
    }

    private bool IsSafe(List<int> numbers)
    {
        var firstDiff = numbers[1] - numbers[0];

        if (Math.Abs(firstDiff) > 3 || firstDiff == 0)
        {
            return false;
        }

        var sign = firstDiff / Math.Abs(firstDiff);
        for (int i = 1; i < numbers.Count-1; i++)
        {
            var difference = numbers[i+1] - numbers[i];
            if (difference == 0 || Math.Abs(difference) > 3)
            {
                return false;
            }
            var currentStatus = difference / Math.Abs(difference) ;

            if (sign != currentStatus)
            {
                return false;
            }
        }
        return true;
    }
}