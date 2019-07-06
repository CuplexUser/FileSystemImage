using System.Collections.Generic;
using System.Text;

namespace FileSystemImage.Utils
{
    public static class WildcardRegExpConverter
    {
        public static string Escape(string str)
        {
            // Convert at the same time
            // * --> .*  (not preceded by \)
            // ? --> .   (not preceded by \)
            // . --> \.
            //   --> \s
            // \ --> \\   (\ not followed by [ ] * ?)
            var i = 0;
            var len = str.Length;
            var sb = new StringBuilder(2 * len);
            while (i < len)
            {
                switch (str[i])
                {
                    case '*':
                        sb.Append(".*");
                        break;
                    case '?':
                        sb.Append(".");
                        break;
                    case '.':
                        sb.Append(@"\.");
                        break;
                    case ' ':
                        sb.Append(@"\s");
                        break;
                    case '\\':
                        if (i + 1 < len)
                        {
                            i++;
                            switch (str[i])
                            {
                                case '[':
                                case ']':
                                case '*':
                                case '?':
                                    sb.Append($@"\{str[i]}");
                                    break;
                                default:
                                    sb.Append(@"\\");
                                    i--;
                                    break;
                            }
                        }
                        else
                        {
                            sb.Append(@"\\");
                        }

                        break;
                    default:
                        sb.Append(str[i]);
                        break;
                }

                i++;
            }

            return sb.ToString();
        }

        private static string Special(string str)
        {
            // Convert at the same time
            // * --> \*
            // ? --> \? 
            // . --> \.
            //   --> \s
            // \ --> \\ 
            var s = str.Replace("*", @"\*");
            str = str.Replace("?", @"\?");
            str = str.Replace(".", @"\.");
            str = str.Replace(" ", @"\s");
            str = str.Replace(@"\", @"\\");
            return str;
        }

        public static string WildcardToRegex(string s, out string error)
        {
            var start = new List<int>();
            var end = new List<int>();
            error = "";
            var str = s.Replace(@"\\", "??");
            str = str.Replace(@"\[", "??");
            str = str.Replace(@"\]", "??");
            //replace by ?, according to 
            // the number of characters.
            var len = str.Length;
            var open = false;
            int i;
            for (i = 0; i < len; i++)
                if (str[i] == '[')
                {
                    if (open)
                    {
                        error = $"A bracket was already opened before {i + 1}";
                        return "";
                    }

                    open = true;
                    start.Add(i);
                }
                else
                {
                    if (str[i] == ']')
                    {
                        if (!open)
                        {
                            error = $"No bracket already opened before {i + 1}";
                            return "";
                        }

                        open = false;
                        end.Add(i);
                    }
                }

            if (open)
            {
                error = $"Bracket not closed at {i + 1}";
                return "";
            }

            //Convert to Regex
            var sb = new StringBuilder();
            var backerNumber = start.Count;
            var predesignating = 0;
            sb.Append("^");
            for (var j = 0; j < backerNumber; j++)
            {
                var before = s.Substring(predesignating, start[j] - predesignating);
                var bracket = s.Substring(start[j], end[j] - start[j] + 1);
                predesignating = end[j] + 1;
                before = Escape(before);
                sb.Append(before);
                bracket = Special(bracket);
                sb.Append(bracket);
            }

            if (predesignating < len)
            {
                var after = s.Substring(predesignating, len - predesignating);
                after = Escape(after);
                sb.Append(after);
            }

            sb.Append("$");
            return sb.ToString();
        }
    }
}