using System;
using System.Net;

namespace Algorithms
{
    internal static class StringExtensions
    {
        private delegate bool TryParseDelegate<T>(string s, out T result);

        private static T To<T>(string value, TryParseDelegate<T> parse)
            => parse(value, out T result) ? result : default;

        public static int ToInt32(this string value)
            => To<int>(value, int.TryParse);

        public static DateTime ToDateTime(this string value)
            => To<DateTime>(value, DateTime.TryParse);

        public static IPAddress ToIPAddress(this string value)
            => To<IPAddress>(value, IPAddress.TryParse);

        public static TimeSpan ToTimeSpan(this string value)
            => To<TimeSpan>(value, TimeSpan.TryParse);

        internal static bool Exist(this string data, char item)
        {
            foreach (var _char in data)
            {
                if (_char == item)
                    return true;
            }
            return false;
        }

        internal static int Count(this string data, char item)
        {
            var countSameChars = 0;
            foreach (var _char in data)
            {
                if (_char == item)
                    countSameChars++;
            }
            return countSameChars;
        }
    }
}
