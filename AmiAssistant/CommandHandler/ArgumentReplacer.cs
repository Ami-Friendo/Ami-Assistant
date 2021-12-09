using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AmiFriendo.CommandHandler
{
    using CommandContext = Dictionary<string, string>;
    public class ArgumentReplacer
    {
        //public string Replace(string textWithTemplate, CommandContext cc)
        //{
        //    const string pattern = @"\$\(carg:(\w+)\)";
        //    foreach (Match match in Regex.Matches(textWithTemplate, pattern, RegexOptions.IgnoreCase))
        //    {
        //        Console.WriteLine("{0} (duplicates '{1}') at position {2}",
        //                          match.Value, match.Groups[1].Value, match.Index);
        //    }
        //    return textWithTemplate;
        //}
        public string Replace(string textWithTemplate, CommandContext cc)
        {
            const string pattern = @"\$\(carg:(\w+)\)";
            foreach (Match match in Regex.Matches(textWithTemplate, pattern, RegexOptions.IgnoreCase))
            {
                textWithTemplate = textWithTemplate.Replace(match.Value, cc[match.Groups[1].Value]);
                //Console.WriteLine("{0} (duplicates '{1}') at position {2}",
                //                  match.Value, match.Groups[1].Value, match.Index);
            }
            return textWithTemplate;
        }
    }
}
