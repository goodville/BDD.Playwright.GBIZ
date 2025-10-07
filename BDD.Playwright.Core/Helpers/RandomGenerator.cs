namespace BDD.Playwright.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provides static helper methods for generating random data and processing special keywords in test data.
    /// Supports generation of random names, numbers, digits, GUIDs, and formatted dates, as well as custom patterns for test automation.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class is typically used to inject dynamic or randomized values into test data, such as unique names, numbers, or dates.
    /// It interprets special keywords (e.g., <c>~randomname{min,max}</c>, <c>~randomnumber{min,max}</c>, <c>~guid</c>, <c>~today</c>) and replaces them with generated values.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// // Generate a random name with 3 to 8 letters
    /// string name = RandomGenerator.ProcessRegExp("~randomname{3,8}");
    ///
    /// // Generate a random number between 100 and 999
    /// string number = RandomGenerator.ProcessRegExp("~randomnumber{100,999}");
    ///
    /// // Generate a GUID
    /// string guid = RandomGenerator.ProcessRegExp("~guid");
    ///
    /// // Generate a date string for tomorrow
    /// string tomorrow = RandomGenerator.ProcessRegExp("~tomorrow");
    /// </code>
    /// </example>
    public static partial class RandomGenerator
    {
        /// <summary>
        /// Processes a keyword and replaces recognized patterns (e.g., random name, number, date, GUID) with generated values.
        /// </summary>
        /// <param name="keyword">The keyword or pattern to process.</param>
        /// <returns>The processed string with random or formatted data as appropriate.</returns>
        public static string ProcessRegExp(string keyword)
        {
            keyword = ProcessName(keyword);
            keyword = ProcessDrivingLicense(keyword);
            keyword = ProcessDate(keyword);
            return keyword;
        }

        private static readonly string[] Separator = new string[] { "," };
        private static readonly string[] SeparatorArray = new string[] { "," };
        private static readonly string[] SeparatorArray0 = new string[] { "," };
        private static readonly string[] SeparatorArray1 = new string[] { "," };
        private static readonly char[] SeparatorArray2 = new char[] { ',' };

        /// <summary>
        /// Processes keywords for random names, numbers, digits, GUIDs, and custom patterns.
        /// </summary>
        /// <param name="keyword">The keyword to process.</param>
        /// <returns>The processed string with generated data.</returns>
        /// <exception cref="Exception">
        /// Thrown for invalid format, out-of-bounds, or invalid min/max values.
        /// </exception>
        private static string ProcessName(string keyword)
        {
            if (keyword.StartsWith("~randomname", StringComparison.CurrentCultureIgnoreCase))
            {
                var rT = keyword.ToLower().TrimEnd().Replace("~randomname", string.Empty).Replace("{", string.Empty).Replace("}", string.Empty);
                var countArray = rT.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
                keyword = countArray.Length == 2
                    ? int.TryParse(countArray[1].Trim(), out var maxCount) && int.TryParse(countArray[0].Trim(), out var minCount)
                        ? minCount >= 1 && minCount <= maxCount ? GetRandomName(minCount, maxCount) : throw new Exception("Invalid Min/Max Values")
                        : throw new Exception("Min/Max Values - Out Of Bounds")
                    : throw new Exception("Invalid Format");
            }
            else if (keyword.StartsWith("~guid", StringComparison.CurrentCultureIgnoreCase))
            {
                keyword = Guid.NewGuid().ToString();
            }
            else if (keyword.StartsWith("~randomnumber", StringComparison.CurrentCultureIgnoreCase))
            {
                var rT = keyword.ToLower().TrimEnd().Replace("~randomnumber", string.Empty).Replace("{", string.Empty).Replace("}", string.Empty);
                var countArray = rT.Split(SeparatorArray, StringSplitOptions.RemoveEmptyEntries);
                keyword = countArray.Length == 2
                    ? int.TryParse(countArray[1].Trim(), out var maxCount) && int.TryParse(countArray[0].Trim(), out var minCount)
                        ? minCount <= maxCount ? GetRandomNumber(minCount, maxCount) : throw new Exception("Invalid Min/Max Values")
                        : throw new Exception("Min/Max Values - Out Of Bounds")
                    : throw new Exception("Invalid Format");
            }
            else if (keyword.StartsWith("~randomdigits", StringComparison.CurrentCultureIgnoreCase))
            {
                var rT = keyword.ToLower().TrimEnd().Replace("~randomdigits", string.Empty).Replace("{", string.Empty).Replace("}", string.Empty);
                var countArray = rT.Split(SeparatorArray0, StringSplitOptions.RemoveEmptyEntries);
                keyword = countArray.Length == 2
                    ? int.TryParse(countArray[1].Trim(), out var maxCount1) && int.TryParse(countArray[0].Trim(), out var minCount)
                        ? minCount >= 1 && minCount <= maxCount1
                            ? GetRandomNumberDigits(minCount, maxCount1, false)
                            : throw new Exception("Invalid Min/Max Values")
                        : throw new Exception("Min/Max Values - Out Of Bounds")
                    : throw new Exception("Invalid Format");
            }
            else if (keyword.StartsWith("~random{", StringComparison.CurrentCultureIgnoreCase) && keyword.ToLower().EndsWith('}'))
            {
                var rT = keyword.TrimEnd().Remove(0, "~random{".Length).TrimEnd(['}']).ToCharArray();
                if (rT.Length > 0)
                {
                    var s = string.Empty;
                    var i = 0;
                    foreach (var r in rT)
                    {
                        if (char.IsDigit(r))
                        {
                            if (i == 0)
                            {
                                s += GetRandomNumber(1, 9); // scripts are failing due to amount starting with "Zero" ex: 0.45
                            }
                            else
                            {
                                s += GetRandomNumber(0, 9);
                            }
                        }
                        else if (char.IsLower(r))
                        {
                            s += GetRandomName(1, 1, "L");
                        }
                        else if (char.IsUpper(r))
                        {
                            s += GetRandomName(1, 1, "U");
                        }
                        else
                        {
                            s += r;
                        }

                        i++;
                    }

                    return s;
                }
            }
            else if (keyword.StartsWith("~randomize{", StringComparison.CurrentCultureIgnoreCase) && keyword.ToLower().EndsWith('}'))
            {
                var rT = keyword.TrimEnd().Remove(0, "~randomize{".Length).TrimEnd(['}']);
                if (rT.Length > 0)
                {
                    var ary = rT.Split(SeparatorArray1, StringSplitOptions.RemoveEmptyEntries);
                    if (ary.Length == 2)
                    {
                        var alpha = -1;
                        var numeric = -1;
                        if (int.TryParse(ary[0], out alpha) && int.TryParse(ary[1], out numeric))
                        {
                            if (alpha >= 0 && numeric >= 0)
                            {
                                return alpha == 0 && numeric == 10
                                    ? GetRandomNumberDigits(3, 3, false) + GetRandomNumberDigits(3, 3, false) + GetRandomNumberDigits(4, 4, true)
                                    : GetRandomName(alpha, alpha) + GetRandomNumberDigits(numeric, numeric, false);
                            }
                        }
                    }
                    else if (ary.Length == 1)
                    {
                        var alpha = -1;
                        if (int.TryParse(ary[0], out alpha))
                        {
                            if (alpha >= 0)
                            {
                                return GetRandomName(alpha, alpha);
                            }
                        }
                    }
                    else if (ary.Length == 3)
                    {
                        var alpha = -1;
                        var numeric = -1;
                        if (int.TryParse(ary[1], out alpha) && int.TryParse(ary[2], out numeric))
                        {
                            if (alpha >= 0 && numeric >= 0)
                            {
                                return alpha == 0 && numeric == 10
                                    ? ary[0] + GetRandomNumberDigits(3, 3, false) + GetRandomNumberDigits(3, 3, false) + GetRandomNumberDigits(4, 4, true)
                                    : ary[0] + GetRandomName(alpha, alpha) + GetRandomNumberDigits(numeric, numeric, false);
                            }
                        }
                    }
                }
            }
            else if (keyword.StartsWith("~rk{", StringComparison.CurrentCultureIgnoreCase) && keyword.ToLower().EndsWith('}'))
            {
                var rT = keyword.TrimEnd().Remove(0, "~rk{".Length).TrimEnd(['}']);
                var nanoSecds = GetRandomNumberDigits(1, 1, false) + DateTime.Now.ToString("ffff");
                keyword = string.Format("TC{0}{1}{2}{3}{4}{5}", rT, DateTime.Now.ToString("yy").Substring(1), DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"), GetRandomName(1, 1).ToUpper(), nanoSecds);
            }
            else if (keyword.StartsWith("~getkey(", StringComparison.CurrentCultureIgnoreCase) && keyword.ToLower().EndsWith(")"))
            {
            }
            else if (keyword.Contains("TEXT(NOW()", StringComparison.CurrentCultureIgnoreCase))
            {
            }

            return keyword;
        }

        /// <summary>
        /// Processes keywords for random driving license numbers based on state or pattern.
        /// </summary>
        /// <param name="keyword">The keyword to process.</param>
        /// <returns>The processed string with generated data.</returns>
        private static string ProcessDrivingLicense(string keyword)
        {
            var regexALL = regex();
            var m = regexALL.Match(keyword.TrimEnd());
            if (m.Success && m.Groups[0].Value.Equals(keyword.ToLower(), StringComparison.CurrentCultureIgnoreCase))
            {
                switch (m.Groups[1].Value.ToLower())
                {
                    case "(ak)":
                        return GetRandomNumberDigits(1, 7);
                    case "(hi)":
                        return GetRandomNumberDigits(1, 9);
                    default:
                        {
                            var ary = m.Groups[1].Value.TrimStart(['(']).TrimEnd([')']).Split(SeparatorArray2);
                            if (ary.Length == 2)
                            {
                                var alphaNumeric = -1;
                                var retString = string.Empty;
                                if (int.TryParse(ary[0], out alphaNumeric))
                                {
                                    foreach (var c in ary[1].ToList())
                                    {
                                        if (c == '#')
                                        {
                                            retString += GetRandomNumber(1);
                                        }
                                        else
                                        {
                                            retString += c;
                                        }
                                    }
                                }

                                return retString;
                            }

                            break;
                        }
                }
            }

            return keyword;
        }

        /// <summary>
        /// Processes keywords for dynamic date generation (e.g., ~today, ~tomorrow, ~lastweek).
        /// </summary>
        /// <param name="keyword">The keyword to process.</param>
        /// <returns>The processed string with the generated date.</returns>
        private static string ProcessDate(string keyword)
        {
            List<string> datekeywords = [
                "~lastmonthw", "~lastweekw", "~lastyearw", "~nextmonthw",
                "~nextweekw", "~nextyearw", "~todayw", "~tomorroww", "~yesterdayw", "~thisyearw",
                "~dw", "~Dw", "~yw", "~Yw", "~Mw", "~mw", "~workingdays", "~lastmonth", "~lastweek", "~lastyear", "~nextmonth",
                "~nextweek", "~nextyear", "~today", "~tomorrow", "~yesterday", "~thisyear",
                "~d", "~D", "~y", "~Y", "~M", "~m"
                ];

            foreach (var dK in datekeywords)
            {
                if (keyword.StartsWith(dK, StringComparison.CurrentCultureIgnoreCase))
                {
                    var actualKeyword = keyword.TrimEnd().Remove(0, dK.Length);
                    var format = "{MM/dd/yyyy}";
                    var add = 0;
                    if (!string.IsNullOrWhiteSpace(actualKeyword))
                    {
                        var startIndex = actualKeyword.IndexOf('{');
                        var endIndex = actualKeyword.IndexOf('}');
                        if (startIndex != -1 && endIndex != -1)
                        {
                            if (endIndex != actualKeyword.Length - 1)
                            {
                                return keyword;
                            }

                            if (startIndex != 0)
                            {
                                if (int.TryParse(actualKeyword.AsSpan(0, startIndex), out add))
                                {
                                    format = actualKeyword.Substring(startIndex, actualKeyword.Length - startIndex);
                                }
                                else
                                {
                                    return keyword;
                                }
                            }
                            else
                            {
                                format = actualKeyword;
                            }
                        }
                        else
                        {
                            if (!int.TryParse(actualKeyword, out add))
                            {
                                return keyword;
                            }
                        }
                    }

                    format = "{0:" + format.Remove(0, 1);
                    return GetDate(keyword, dK, add, format);
                }
            }

            return keyword;
        }

        private static string GetDate(string keyword, string ms, int add, string format)
        {
            if (format.StartsWith('{') && format.EndsWith('}'))
            {
                try
                {
                    switch (ms.ToLower())
                    {
                        case "~yesterday":
                            keyword = string.Format(format, DateTime.Now.AddDays(add - 1));
                            break;
                        case "~tomorrow":
                            keyword = string.Format(format, DateTime.Now.AddDays(add + 1));
                            break;
                        case "~d":
                        case "~today":
                            keyword = string.Format(format, DateTime.Now.AddDays(add));
                            break;
                        case "~lastweek":
                            keyword = string.Format(format, DateTime.Now.AddDays(add - 7));
                            break;
                        case "~nextweek":
                            keyword = string.Format(format, DateTime.Now.AddDays(add + 7));
                            break;
                        case "~m":
                            keyword = string.Format(format, DateTime.Now.AddMonths(add));
                            break;
                        case "~lastmonth":
                            keyword = string.Format(format, DateTime.Now.AddMonths(add - 1));
                            break;
                        case "~nextmonth":
                            keyword = string.Format(format, DateTime.Now.AddMonths(add + 1));
                            break;
                        case "~y":
                        case "~thisyear":
                            keyword = string.Format(format, DateTime.Now.AddYears(add));
                            break;
                        case "~lastyear":
                            keyword = string.Format(format, DateTime.Now.AddYears(add - 1));
                            break;
                        case "~nextyear":
                            keyword = string.Format(format, DateTime.Now.AddYears(add + 1));
                            break;

                        case "~yesterdayw":
                            keyword = string.Format(format, GetWeekDay(DateTime.Now.AddDays(add - 1)));
                            break;
                        case "~tomorroww":
                            keyword = string.Format(format, GetWeekDay(DateTime.Now.AddDays(add + 1)));
                            break;
                        case "~dw":
                        case "~todayw":
                            keyword = string.Format(format, GetWeekDay(DateTime.Now.AddDays(add)));
                            break;
                        case "~lastweekw":
                            keyword = string.Format(format, GetWeekDay(DateTime.Now.AddDays(add - 7)));
                            break;
                        case "~nextweekw":
                            keyword = string.Format(format, GetWeekDay(DateTime.Now.AddDays(add + 7)));
                            break;
                        case "~mw":
                            keyword = string.Format(format, GetWeekDay(DateTime.Now.AddMonths(add)));
                            break;
                        case "~lastmonthw":
                            keyword = string.Format(format, GetWeekDay(DateTime.Now.AddMonths(add - 1)));
                            break;
                        case "~nextmonthw":
                            keyword = string.Format(format, GetWeekDay(DateTime.Now.AddMonths(add + 1)));
                            break;
                        case "~yw":
                        case "~thisyearw":
                            keyword = string.Format(format, GetWeekDay(DateTime.Now.AddYears(add)));
                            break;
                        case "~lastyearw":
                            keyword = string.Format(format, GetWeekDay(DateTime.Now.AddYears(add - 1)));
                            break;
                        case "~nextyearw":
                            keyword = string.Format(format, GetWeekDay(DateTime.Now.AddYears(add + 1)));
                            break;
                        case "~workingdays":
                            keyword = string.Format(format, Workingdays(DateTime.Now, add));
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    keyword = $"Error processing date with format '{format}': {ex.Message}";
                }
            }

            return keyword;
        }

        /// <summary>
        /// Returns the next weekday (Monday-Friday) for a given date.
        /// </summary>
        /// <param name="dT">The date to evaluate.</param>
        /// <returns>The next weekday <see cref="DateTime"/>.</returns>
        private static DateTime GetWeekDay(DateTime dT)
        {
            while (dT.DayOfWeek == DayOfWeek.Sunday || dT.DayOfWeek == DayOfWeek.Saturday)
            {
                dT = dT.AddDays(1);
            }

            return dT;
        }

        /// <summary>
        /// Workingdayses the specified dt.
        /// </summary>
        /// <param name="dT">The dt.</param>
        /// <param name="add">The add.</param>
        /// <returns>The DateTime.</returns>
        private static DateTime Workingdays(DateTime dT, int add)
        {
            // just example  ~workingdays+1
            for (var i = 0; i < add; i++)
            {
                if (dT.DayOfWeek == DayOfWeek.Saturday)
                {
                    dT = dT.AddDays(3);
                }
                else if (dT.DayOfWeek == DayOfWeek.Sunday)
                {
                    dT = dT.AddDays(2);
                }
                else if (dT.DayOfWeek != DayOfWeek.Sunday || dT.DayOfWeek != DayOfWeek.Saturday)
                {
                    dT = dT.AddDays(1);
                }

                if (dT.DayOfWeek != DayOfWeek.Sunday || (dT.DayOfWeek != DayOfWeek.Saturday && i == add))
                {
                    if (dT.DayOfWeek == DayOfWeek.Saturday)
                    {
                        dT = dT.AddDays(2);
                    }
                    else if (dT.DayOfWeek == DayOfWeek.Sunday)
                    {
                        dT = dT.AddDays(1);
                    }
                }
            }

            // just ~workingdays
            if ((dT.DayOfWeek == DayOfWeek.Sunday || dT.DayOfWeek == DayOfWeek.Saturday) && add != 0)
            {
                if (dT.DayOfWeek == DayOfWeek.Saturday)
                {
                    dT = dT.AddDays(3);
                }
                else if (dT.DayOfWeek == DayOfWeek.Sunday)
                {
                    dT = dT.AddDays(2);
                }
            }

            return dT;
        }

        /// <summary>
        /// Generates a random number string with the specified number of digits.
        /// </summary>
        /// <param name="numberOfDigits">The number of digits.</param>
        /// <returns>A string of random digits.</returns>
        private static string GetRandomNumber(int numberOfDigits)
        {
            var numberString = string.Empty;
            for (var i = 0; i < numberOfDigits; i++)
            {
                var myrandomnumber = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
                numberString += myrandomnumber.Next(0, 9).ToString();
            }

            return numberString;
        }

        /// <summary>
        /// Generates a random number string with a digit count in the specified range.
        /// </summary>
        /// <param name="minNumberOfDigits">Minimum number of digits.</param>
        /// <param name="maxNumberOfDigits">Maximum number of digits.</param>
        /// <param name="leadingZero">If true, allows leading zeros.</param>
        /// <returns>A string of random digits.</returns>
        private static string GetRandomNumberDigits(int minNumberOfDigits, int maxNumberOfDigits, bool leadingZero = true)
        {
            if (minNumberOfDigits > maxNumberOfDigits || minNumberOfDigits < 0 || maxNumberOfDigits < 0)
            {
                throw new Exception(string.Format("Invalid RandomNumberDigits MinNumberOfDigits={0} ,MaxNumberOfDigits={1}", minNumberOfDigits, maxNumberOfDigits));
            }

            if (minNumberOfDigits == 0 && maxNumberOfDigits == 0)
            {
                return string.Empty;
            }

            var numberOfDigits = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber)).Next(minNumberOfDigits, maxNumberOfDigits);
            var numberString = string.Empty;
            if (leadingZero)
            {
                for (var i = 0; i < numberOfDigits; i++)
                {
                    var myrandomnumber = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
                    numberString += myrandomnumber.Next(0, 9).ToString();
                }
            }
            else
            {
                var myrandomnumber = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
                numberString = myrandomnumber.Next(2, 9).ToString();
                for (var i = 1; i < numberOfDigits; i++)
                {
                    myrandomnumber = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
                    numberString += myrandomnumber.Next(0, 9).ToString();
                }
            }

            return numberString;
        }

        /// <summary>
        /// Generates a random alphabetic string (name) with a letter count in the specified range.
        /// </summary>
        /// <param name="minNumberOfLetters">Minimum number of letters.</param>
        /// <param name="maxNumberOfLetters">Maximum number of letters.</param>
        /// <param name="uL">"U" for uppercase, "L" for lowercase, or empty for mixed.</param>
        /// <returns>A random alphabetic string.</returns>
        private static string GetRandomName(int minNumberOfLetters, int maxNumberOfLetters, string uL = "")
        {
            var returnString = string.Empty;
            var numberOfLetters = int.Parse(GetRandomNumber(minNumberOfLetters, maxNumberOfLetters));
            var alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            if (uL.Equals("U", StringComparison.CurrentCultureIgnoreCase))
            {
                alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }
            else if (uL.Equals("L", StringComparison.CurrentCultureIgnoreCase))
            {
                alphabets = "abcdefghijklmnopqrstuvwxyz";
            }

            for (var i = 0; i < numberOfLetters; i++)
            {
                returnString += alphabets[int.Parse(GetRandomNumber(0, alphabets.Length - 1))];
            }

            return returnString;
        }

        /// <summary>
        /// Generates a random number string within the specified value range.
        /// </summary>
        /// <param name="minValue">Minimum value (inclusive).</param>
        /// <param name="maxValue">Maximum value (exclusive).</param>
        /// <returns>A string representing the random number.</returns>
        private static string GetRandomNumber(int minValue, int maxValue)
        {
            var myrandomnumber = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            return myrandomnumber.Next(minValue, maxValue).ToString();
        }

        [GeneratedRegex(@"~[d|D][l|L](\(.*\))")]
        private static partial Regex regex();
    }
}
