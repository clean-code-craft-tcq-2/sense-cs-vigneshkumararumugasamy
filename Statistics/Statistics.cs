using System;
using System.Collections;
using System.Collections.Generic;

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

    public class Stats
    {
        public double average { get; set; }
        public double min { get; set; }
        public double max { get; set; }
    }

    public class EmailAlert
    {
        public bool emailSent { get; set; }

        public EmailAlert()
        {
            this.emailSent = false;
        }
    }

    public class LedAlert
    {
        public bool ledGlows { get; set; }

        public LedAlert()
        {
            this.ledGlows = false;
        }
    }

    public class StatsAlerter
    {
        public float maxThreshold { get; set; }
        public ArrayList alert { get; set; }

        public StatsAlerter(float maxThreshold, ArrayList alert)
        {
            this.maxThreshold = maxThreshold;
            this.alert = alert;
        }

        public virtual void checkAndAlert(List<float> values)
        {
            StatsComputer statsComputer = new StatsComputer();
            var stats = statsComputer.CalculateStatistics(values);

            if(stats != null && !double.IsNaN(stats.max))
            {
                if (stats.max >= this.maxThreshold)
                {
                    var email = (EmailAlert)this.alert[0];
                    email.emailSent = true;

                    var led = (LedAlert)this.alert[1];
                    led.ledGlows = true;
                }
            }
        }
    }
}