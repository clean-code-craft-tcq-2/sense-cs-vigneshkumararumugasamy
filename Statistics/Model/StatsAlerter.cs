using System.Collections;
using System.Collections.Generic;

namespace Statistics.Model
{
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

            if (stats != null && !double.IsNaN(stats.max) && stats.max >= this.maxThreshold)
            {
                var email = (EmailAlert)this.alert[0];
                email.emailSent = true;

                var led = (LedAlert)this.alert[1];
                led.ledGlows = true;
            }
        }
    }
}
