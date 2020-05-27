using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_social_networking
{
    public static class TimeFormatter
    {
        private static int numberTimeUnits = 0;

        public static string TimeAgo(DateTime timestamp)
        {
            TimeSpan timeDiff = DateTime.UtcNow - timestamp;
            string timeUnit = timeUnitSetter(timeDiff);
            return $"({numberTimeUnits} {timeUnit} ago)";
        }

        private static string timeUnitSetter(TimeSpan timeSpan)
        {
            string result = "";
            switch (timeSpan.Days)
            {
                case 1:
                    numberTimeUnits = 1;
                    result = "day";
                    break;
                case 0:
                    result = checkHoursAgo(timeSpan);
                    break;
                default:
                    numberTimeUnits = timeSpan.Days;
                    result = "days";
                    break;
            }

            return result;
        }

        private static string checkHoursAgo (TimeSpan timeSpan)
        {
            string result = "";
            switch (timeSpan.Hours)
            {
                case 1:
                    numberTimeUnits = 1;
                    result = "hour";
                    break;
                case 0:
                    result = checkMinutesAgo(timeSpan);
                    break;
                default:
                    numberTimeUnits = timeSpan.Hours;
                    result = "hours";
                    break;
            }
            return result;
        }

        private static string checkMinutesAgo(TimeSpan timeSpan)
        {
            string result = "";
            switch (timeSpan.Minutes)
            {
                case 1:
                    numberTimeUnits = 1;
                    result = "minute";
                    break;
                case 0:
                    result = checkSecondsAgo(timeSpan);
                    break;
                default:
                    numberTimeUnits = timeSpan.Minutes;
                    result = "minutes";
                    break;
            }
            return result;
        }

        private static string checkSecondsAgo(TimeSpan timeSpan)
        {
            string result = "";
            switch (timeSpan.Seconds)
            {
                case 1:
                    numberTimeUnits = 1;
                    result = "second";
                    break;
                default:
                    numberTimeUnits = timeSpan.Seconds;
                    result = "seconds";
                    break;
            }
            return result;
        }
    }
}
