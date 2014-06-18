using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrotiNet
{
    public class Utilities
    {
       
        /// <summary>
        /// Date format pattern used to parse HTTP date headers in RFC 1123 format.
        /// </summary>
        private static string PATTERN_RFC1123 = "r";

        /// <summary>
        /// Formats the given date according to the RFC 1123 pattern.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string FormatDate(DateTime date)
        {
            return FormatDate(date, PATTERN_RFC1123);
        }

        /// <summary>
        /// Formats the given date according to the specified pattern. 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static String FormatDate(DateTime date, String pattern) 
        {
            if (date == null)
                throw new ArgumentNullException("date is null");
            if (pattern == null)
                throw new ArgumentNullException("pattern is null");

            return date.ToUniversalTime().ToString(pattern);

        }

    }

    public static class StringUtils
    {
        /// <summary>
        /// Get string value after [first] a.
        /// </summary>
        public static string Before(this string value, string a)
        {
            int posA = value.IndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            return value.Substring(0, posA);
        }

        /// <summary>
        /// Get string value after [last] a.
        /// </summary>
        public static string After(this string value, string a)
        {
            int posA = value.LastIndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= value.Length)
            {
                return "";
            }
            return value.Substring(adjustedPosA);
        }
    }
}
