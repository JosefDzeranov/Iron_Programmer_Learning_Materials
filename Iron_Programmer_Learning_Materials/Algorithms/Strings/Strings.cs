using System;
using System.Text;

namespace Algorithms.Strings
{
    public class Strings
    {
        /// <summary>
        /// Calculates Edit Distance between S1 and S2 and the prescription 
        /// </summary>
        /// <param name="s">First input string</param>
        /// <param name="t">Second input string</param>
        /// <returns>Prescription - the edit distance and the path retraced</returns>
        public static Prescription Levenshtein(string s, string t)
        {
            int m = s.Length, n = t.Length;
            var d = new int[m + 1, n + 1];
            var p = new char[m + 1, n + 1];
            int i, j;
            // First fill the basic values
            for (i = 0; i <= m; i++)
            {
                d[i, 0] = i;
                p[i, 0] = 'D';
            }
            for (i = 0; i <= n; i++)
            {
                d[0, i] = i;
                p[0, i] = 'I';
            }

            for (i = 1; i <= m; i++)
                for (j = 1; j <= n; j++)
                {
                    int cost = s[i - 1] != t[j - 1] ? 1 : 0;
                    if (cost == 0)
                    {
                        d[i, j] = d[i - 1, j - 1];
                    }
                    if (d[i, j - 1] < d[i - 1, j] && d[i, j - 1] < d[i - 1, j - 1] + cost)
                    {
                        //Inserting
                        d[i, j] = d[i, j - 1] + 1;
                        p[i, j] = 'I';
                    }
                    else if (d[i - 1, j] < d[i - 1, j - 1] + cost)
                    {
                        //Deleting
                        d[i, j] = d[i - 1, j] + 1;
                        p[i, j] = 'D';
                    }
                    else
                    {
                        //Doing nothing or replacing
                        d[i, j] = d[i - 1, j - 1] + cost;
                        p[i, j] = cost == 1 ? 'R' : 'M';
                    }
                }

            //Retracing
            var route = new StringBuilder("");
            i = m;
            j = n;
            do
            {
                var c = p[i, j];
                route.Append(c);
                switch (c)
                {
                    case 'R':
                    case 'M':
                        i--;
                        j--;
                        break;
                    case 'D':
                        i--;
                        break;
                    default:
                        j--;
                        break;
                }
            } while (i != 0 && j != 0);

            var charArray = route.ToString().ToCharArray();
            Array.Reverse(charArray);
            return new Prescription(d[m, n], new string(charArray));
        }

        /// <summary>
        /// Calculates Edit Distance between S1 and S2
        /// </summary>
        /// <param name="s">First input string</param>
        /// <param name="t">Second input string</param>
        /// <returns></returns>
        public static int LevenshteinDistance(string s, string t)
        {
            return Levenshtein(s, t).Distance;
        }

        /// <summary>
        /// Calculates Edit path between S1 and S2 
        /// </summary>
        /// <param name="s">First input string</param>
        /// <param name="t">Second input string</param>
        /// <returns></returns>
        public static string LevenshteinPath(string s, string t)
        {
            return Levenshtein(s, t).Path;
        }
    }
}
