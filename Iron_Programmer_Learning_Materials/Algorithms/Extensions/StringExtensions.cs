namespace Algorithms
{
    internal static class StringExtensions
    {
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
