using AoCHelper;

namespace AoC2024
{
    public class Day01 : BaseDay
    {
        private readonly string[] _input;

        public Day01()
        {
            _input = File.ReadAllLines(InputFilePath);
        }
        public override ValueTask<string> Solve_1() =>
            new($"{SolvingOne().ToString()}");

        public override ValueTask<string> Solve_2() =>
            new($"{SolvingTwo()}");

        private int SolvingOne()
        {
            var leftList = new List<int>();
            var rightList = new List<int>();

            foreach (var line in _input)
            {
                var item = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                leftList.Add(int.Parse(item[0]));
                rightList.Add(int.Parse(item[1]));
            }
            
            leftList.Sort();
            rightList.Sort();
            
            var result = leftList.Zip(rightList, (l, r) => Math.Abs(l - r)).ToList();
            var total = result.Sum();
            return total;
        }

        private int SolvingTwo()
        {
            var leftList = new List<int>();
            var rightList = new List<int>();

            foreach (var line in _input)
            {
                var item = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                leftList.Add(int.Parse(item[0]));
                rightList.Add(int.Parse(item[1]));
            }

            var noDuplicates = leftList.Distinct().ToList();
            var dictionary = noDuplicates.ToDictionary(k => k, k => 0);

            foreach (var number in rightList.Where(number => dictionary.ContainsKey(number)))
            {
                dictionary[number]++;
            }

            var total = leftList.Sum(number => (number * dictionary[number]));
            
            return total;
        }
    }
}
