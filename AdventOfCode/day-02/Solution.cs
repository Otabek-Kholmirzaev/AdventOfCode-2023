namespace AdventOfCode.day_02
{
    public class Solution
    {
        int red_count = 12, green_count = 13, blue_count = 14;
        public void Solve()
        {
            var lines = File.ReadAllLines("C:\\Users\\User\\source\\repos\\AdventOfCode\\AdventOfCode\\day-02\\input.txt");

            int ans = 0;
            foreach (var line in lines)
            {
                string game = line.Split(':')[0];
                string sets = line.Split(":")[1].Trim();
                /*if (IsSetsValid(sets))
                {
                    ans += int.Parse(game.Split()[1]);
                }*/

                ans += Power(sets);
            }

            Console.WriteLine(ans);
        }

        private bool IsSetsValid(string sets)
        {
            string[] sets_array = sets.Split(";").Select(x => x.Trim()).ToArray();
            foreach (var set in sets_array)
            {
                int red = set.Split(',').Select(x => x.Trim()).Where(x => x.Split()[1] == "red").Sum(x => int.Parse(x.Split()[0]));
                int green = set.Split(',').Select(x => x.Trim()).Where(x => x.Split()[1] == "green").Sum(x => int.Parse(x.Split()[0]));
                int blue = set.Split(',').Select(x => x.Trim()).Where(x => x.Split()[1] == "blue").Sum(x => int.Parse(x.Split()[0]));
                if (red > red_count || green > green_count || blue > blue_count)
                {
                    return false;
                }
            }
            return true;
        }

        private int Power(string sets)
        {
            Dictionary<string, int> dict = new()
            {
                { "green", 0 },
                { "blue", 0 },
                { "red", 0 }
            };

            string[] sets_array = sets.Split(";").Select(x => x.Trim()).ToArray();
            foreach (var set in sets_array)
            {
                string[] cubs = set.Split(',').Select(x => x.Trim()).ToArray();

                foreach (var cub in cubs)
                {
                    int number = int.Parse(cub.Split()[0]);
                    string color = cub.Split()[1];
                    dict[color] = Math.Max(dict[color], number);
                }
            }

            return dict["red"] * dict["green"] * dict["blue"];
        }
    }
}
