using System;
using System.Text;
using Algorithms.Strings;

namespace Algorithms.Metrics
{
    public class Levenshtein
    {
        /// <summary>
        /// Calculates Edit Distance between S1 and S2 and the prescription 
        /// </summary>
        /// <param name="s">First input string</param>
        /// <param name="t">Second input string</param>
        /// <param name="costInsert">Cost for insert</param>
        /// <param name="costDelete">Cost for delete</param>
        /// <param name="costReplace">Cost for replaces</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>Prescription - the edit distance and the path retraced</returns>
        public static Prescription Solve(string s, string t, int costInsert = 1, int costDelete = 1, int costReplace = 1)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            int m = s.Length, n = t.Length;
            var d = new int[m + 1, n + 1];
            var p = new char[m + 1, n + 1];
            int i, j;
            // First fill the basic values
            for (i = 0; i <= m; i++)
            {
                d[i, 0] = i * costDelete;
                p[i, 0] = 'D';
            }
            for (i = 0; i <= n; i++)
            {
                d[0, i] = i * costInsert;
                p[0, i] = 'I';
            }

            for (i = 1; i <= m; i++)
                for (j = 1; j <= n; j++)
                {
                    if (s[i - 1] == t[j - 1])
                    {
                        d[i, j] = d[i - 1, j - 1];
                        p[i, j] = 'M';
                        continue;
                    }

                    if (d[i, j - 1] + costInsert < d[i - 1, j] + costDelete && d[i, j - 1] + costInsert < d[i - 1, j - 1] + costReplace)
                    {
                        //Inserting
                        d[i, j] = d[i, j - 1] + costInsert;
                        p[i, j] = 'I';
                    }
                    else if (d[i - 1, j] + costDelete < d[i - 1, j - 1] + costReplace)
                    {
                        //Deleting
                        d[i, j] = d[i - 1, j] + costDelete;
                        p[i, j] = 'D';
                    }
                    else
                    {
                        //Replacing
                        d[i, j] = d[i - 1, j - 1] + costReplace;
                        p[i, j] = 'R';
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
            return Solve(s, t).Distance;
        }

        /// <summary>
        /// Calculates Edit path between S1 and S2 
        /// </summary>
        /// <param name="s">First input string</param>
        /// <param name="t">Second input string</param>
        /// <returns></returns>
        public static string LevenshteinPath(string s, string t)
        {
            return Solve(s, t).Path;
        }
    }
}
