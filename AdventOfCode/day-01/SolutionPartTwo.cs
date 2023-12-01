using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode;

public class SolutionPartTwo
{
    public void Solve()
    {
        var lines = File.ReadAllLines("C:\\Users\\User\\source\\repos\\AdventOfCode\\AdventOfCode\\input.txt");
        
        int sum = lines.Sum(x => ParseNum(x));
        Console.WriteLine(sum);
    }

    private int ParseNum(string s)
    {
        Dictionary<string, int> nums = new Dictionary<string, int>()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },
            { "1", 1 },
            { "2", 2 },
            { "3", 3 },
            { "4", 4 },
            { "5", 5 },
            { "6", 6 },
            { "7", 7 },
            { "8", 8 },
            { "9", 9 },
        };

        int min = int.MaxValue;
        string min_key = string.Empty;

        int max = int.MinValue;
        string max_key = string.Empty;

        foreach (var key in nums.Keys)
        {
            int first = s.IndexOf(key);
            if (first == -1)
            {
                continue;
            }

            int last = s.LastIndexOf(key);

            if (first < min)
            {
                min = first; 
                min_key = key;
            }

            if (last > max)
            {
                max = last;
                max_key = key;
            }
        }
        Console.WriteLine($"ParseNum: {min_key}{max_key}");
        return nums[min_key] * 10 + nums[max_key];
    }
}