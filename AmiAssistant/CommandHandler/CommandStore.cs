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

            /// find static text
            /// ex, show time
            command = (from item in Commands
                       from text in item.Commands
                       where text == commandText
                       select item).FirstOrDefault();

            if (command == null)
            {
                // find templates
                // ex, show rate $(carg:bitcoin) in $(carg:currency)

                //string commandPattern = commandText;

                //string commandPattern = "";
                //// find command with this template
                //foreach (var c in Commands)
                //{
                //    commandPattern = "";
                //    const string pattern_carg = @"\$\(carg:(\w+)\)";
                //    foreach (Match match in Regex.Matches(c.Commands[0], pattern_carg, RegexOptions.IgnoreCase))
                //    {
                //        commandPattern = c.Commands[0].Replace(match.Value, @"(\w+)");
                //    }

                //    var match2 = Regex.Match(c.Commands[0], commandPattern);
                //    if (match2.Success)
                //    {
                //        command = c;
                //        break;
                //    }
                //}

                if (command == null)
                    return "not found command";

                //ArgumentReplacer ar = new ArgumentReplacer();
                //ar.InitContextByCommandText(commandText, command.Commands[0], context);
            }
                
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
