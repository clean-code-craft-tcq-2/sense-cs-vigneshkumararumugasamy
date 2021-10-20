using System.Collections.Generic;
using Statistics.Model;

namespace Statistics
{
    public class StatsComputer
    {
        public Stats CalculateStatistics(List<float> numbers) {

            //Implement statistics here
            Stats stats = new Stats();

            if (numbers != null && numbers.Count > 0)
            {
                numbers.Sort();
                stats.min = numbers[0];
                stats.max = numbers[numbers.Count - 1];
                stats.average = Sum(numbers) / numbers.Count;
            }
            else
            {
                stats.min = float.NaN;
                stats.max = float.NaN;
                stats.average = float.NaN;
            }

            return stats;
        }
        public float Sum(IEnumerable<float> source)
        {
            double sum = 0;
            foreach (float v in source) sum += v;
            return (float)sum;
        }
    }    
}