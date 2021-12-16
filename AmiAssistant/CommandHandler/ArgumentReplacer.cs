using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;

using AmiFriendo.CommandHandler.Arguments;

namespace AmiFriendo.CommandHandler
{
    using CommandContext = Dictionary<string, string>;
    public class ArgumentReplacer
    {
        public void InitInputArgumentsByContext(IArgument[] inputArguments, CommandContext context)
        {
            foreach (var argument in inputArguments)
            {
                var replaced_value = ContextToValueReplace(argument.Value, context);
                argument.ParseValue(replaced_value);
            }
        }

        public void InitContextByCommandText(string command, string commandPattern, CommandContext cc)
        {
            const string pattern_carg = @"\$\(carg:(\w+)\)";

            foreach (Match match in Regex.Matches(commandPattern, pattern_carg, RegexOptions.IgnoreCase))
            {
                cc[match.Groups[1].Value] = null;
                commandPattern = commandPattern.Replace(match.Value, @"(\w+)");
                var match2 = Regex.Match(commandPattern, @"(\w+)");

                //textWithTemplate = textWithTemplate.Replace(match.Value, );
            }

            //foreach (Match match in Regex.Matches(command, pattern_carg, RegexOptions.IgnoreCase))
            //{
            //    cc[match.Groups[1].Value]
            //    textWithTemplate = textWithTemplate.Replace(match.Value, cc[match.Groups[1].Value]);
            //}
        }

        private string ContextToValueReplace(string textWithTemplate, CommandContext cc)
        { 
            const string pattern_carg = @"\$\(carg:(\w+)\)";
            const string pattern_arg = @"\$\((\w+Argument):([\w \/ \\:.]+)\)";

            //Console.WriteLine("{0} (duplicates '{1}') at position {2}",
            //                  match.Value, match.Groups[1].Value, match.Index);

            foreach (Match match in Regex.Matches(textWithTemplate, pattern_carg, RegexOptions.IgnoreCase))
            {
                textWithTemplate = textWithTemplate.Replace(match.Value, cc[match.Groups[1].Value]);
            }
            foreach (Match match in Regex.Matches(textWithTemplate, pattern_arg, RegexOptions.IgnoreCase))
            {
                var myClass = match.Groups[1].Value;
                var myValue = match.Groups[2].Value;


                //foreach (MemberInfo mi in myType.GetMembers())
                //{
                //    Console.WriteLine($"{mi.DeclaringType} {mi.MemberType} {mi.Name}");
                //}

                Type myType = Type.GetType($"AmiFriendo.CommandHandler.Arguments.{myClass}", false, true);
                object obj = Activator.CreateInstance(myType);
                MethodInfo methodParseValue = myType.GetMethod(nameof(IArgument.ParseValue));
                PropertyInfo propertyValue = myType.GetProperty(nameof(IArgument.Value));
                object result = methodParseValue.Invoke(obj, new object[] { match.Groups[2].Value });
               
                object value = propertyValue.GetValue(obj);

                textWithTemplate = textWithTemplate.Replace(match.Value, value.ToString());
            }
            return textWithTemplate;
        }
    }
}
