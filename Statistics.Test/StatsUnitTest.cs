using Statistics.Model;
using System;
using System.Collections.Generic;
using System.Collections;
using Xunit;

namespace Statistics.Test
{
    public class StatsUnitTest
    {
        [Fact]
        public void ReportsAverageMinMax()
        {
            StatsComputer statsComputer = new StatsComputer();
            var computedStats = statsComputer.CalculateStatistics( new List<float>{1.5F, 8.9F, 3.2F, 4.5F });
            float epsilon = 0.001F;
            Assert.True(Math.Abs(computedStats.average - 4.525) <= epsilon);
            Assert.True(Math.Abs(computedStats.max - 8.9) <= epsilon);
            Assert.True(Math.Abs(computedStats.min - 1.5) <= epsilon);
        }
        [Fact]
        public void ReportsNaNForEmptyInput()
        {
            var statsComputer = new StatsComputer();
            var computedStats = statsComputer.CalculateStatistics(new List<float>{ });
            //All fields of computedStats (average, max, min) must be
            //Double.NaN (not-a-number), as described in
            //https://docs.microsoft.com/en-us/dotnet/api/system.double.nan?view=netcore-3.1

            Assert.True(double.IsNaN(computedStats.average));
            Assert.True(double.IsNaN(computedStats.max));
            Assert.True(double.IsNaN(computedStats.min));
        }
        [Fact]
        public void RaisesAlertsIfMaxIsMoreThanThreshold()
        {
            EmailAlert emailAlert = new EmailAlert();
            LedAlert ledAlert = new LedAlert();
            ArrayList alerters = new ArrayList { emailAlert, ledAlert };

            const float maxThreshold = 10.2F;
            var statsAlerter = new StatsAlerter(maxThreshold, alerters);
            statsAlerter.checkAndAlert(new List<float>{0.2F, 11.9F, 4.3F, 8.5F});

            Assert.True(emailAlert.emailSent);
            Assert.True(ledAlert.ledGlows);
        }
    }
}
