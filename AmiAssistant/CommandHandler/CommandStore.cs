using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AmiFriendo.CommandHandler
{
    public class CommandStore
    {
        public List<Command> Commands { get; set; }

        public CommandStore()
        {
            Commands = new List<Command>();
        }

        public string Execute(string commandText)
        {
            var context = new Dictionary<string, string>();
            Command command = null;

            // find templates
            // ex, show rate $(carg:bitcoin) in $(carg:currency)
            string commandPattern = commandText;
            const string pattern_carg = @"\$\(carg:(\w+)\)";
            foreach (Match match in Regex.Matches(commandText, pattern_carg, RegexOptions.IgnoreCase))
            {
                commandPattern = commandPattern.Replace(match.Value, @"(\w+)");
            }

            // find command with this template
            foreach (var c in Commands)
            {
                var match = Regex.Match(c.Commands[0], commandPattern);
                if (match.Success)
                {
                    command = c;
                    break;
                }
            }

            ArgumentReplacer ar = new ArgumentReplacer();
            ar.InitContextByCommandText(commandText, command.Commands[0], context);

            /// find static text
            /// ex, show time
            //var query = (from item in Commands
            //            from text in item.Commands
            //            where text == commandText
            //            select item).FirstOrDefault();

            //if (query == null)
            //    return "not found command";
            ///
            ///

            /// execute command
            string result = null;
            //try
            //{
                result = command.Execute(context);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


            /// return result
            if (result != null)
                return result;
            else
                return "empty result";
        }
    }
}
