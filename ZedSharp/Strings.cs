﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZedSharp
{
    public static class Strings
    {
        public static String ToLF(this String s)
        {
            return s.Replace("\r\n", "\n");
        }

        public static String ToCRLF(this String s)
        {
            return s.Replace("\r\n", "\n").Replace("\n", "\r\n");
        }

        public static IEnumerable<String> SplitSeq(this String s, Regex r)
        {
            var m = r.Match(s);

            while (m.Success)
            {
                yield return m.Value;
                m = m.NextMatch();
            }
        }

        public static IEnumerable<String> SplitSeq(this String s, String sep)
        {
            int i = 0;
            int j = 0;

            while ((j = s.IndexOf(sep, i)).NotNeg())
            {
                yield return s.Substring(i, j - i);
                i = j + sep.Length;
            }

            yield return s.Substring(i, s.Length - i);
        }

        public static bool EqualsIgnoreCase(this String x, String y)
        {
            return String.Equals(x, y, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool NotEmpty(this String x)
        {
            return String.IsNullOrEmpty(x).Not();
        }

        public static bool NotBlank(this String x)
        {
            return String.IsNullOrWhiteSpace(x).Not();
        }

        public static String IfEmpty(this String x, String y)
        {
            return String.IsNullOrEmpty(x) ? y : x;
        }

        public static String IfBlank(this String x, String y)
        {
            return String.IsNullOrWhiteSpace(x) ? y : x;
        }

        public static readonly Regex WhiteSpaceRegex = new Regex("\\s+");

        public static String CollapseSpace(this String x)
        {
            return WhiteSpaceRegex.Split(x.Trim()).StringJoin(" ");
        }

        public static String ToTitleCase(this String x)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x);
        }

        public static IEnumerable<String> TrimAll(this IEnumerable<String> seq)
        {
            return seq.Where(NotBlank).Select(x => x.Trim());
        }

        public static String StringJoin(this IEnumerable<Object> seq, String sep = null)
        {
            return String.Join(sep ?? "", seq);
        }
    }
}
