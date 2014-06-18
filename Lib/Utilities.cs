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
        private static string PATTERN_RFC1123 = "EEE, dd MMM yyyy HH:mm:ss zzz";

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

            return date.ToString(pattern);

    }

    }
}
