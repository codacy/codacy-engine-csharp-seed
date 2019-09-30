using System;

namespace Codacy.Engine.Seed
{
    /// <summary>
    ///     TimeSpan helper.
    ///     This parse a given string to a TimeSpan.
    /// </summary>
    public static class TimeSpanHelper
    {
        /// <summary>
        ///     Parse a TimeSpan from a string formatted with ('number.time_scale' or 'number time_scale')
        ///     Available time scales:
        ///       - second(s)
        ///       - minute(s)
        ///       - hour(s)
        ///
        ///     e.g.: '1 hour', '2 hours', '30.minutes'
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        public static TimeSpan Parse(string value)
        {
            var timeSplitted = value.Replace('.', ' ').Split(' ');
            int timeFactor;

            if (timeSplitted.Length > 1)
            {
                switch (timeSplitted[1])
                {
                    case "second":
                    case "seconds":
                        timeFactor = 1;
                        break;

                    case "minute":
                    case "minutes":
                        timeFactor = 60;
                        break;

                    case "hour":
                    case "hours":
                        timeFactor = 3600;
                        break;

                    default:
                        throw new FormatException();
                }
            }
            else
            {
                timeFactor = 1;
            }

            return TimeSpan.FromSeconds(int.Parse(timeSplitted[0]) * timeFactor);
        }
    }
}
