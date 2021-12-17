using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using AmiFriendo.CommandHandler.Actions;

namespace AmiFriendo.CommandHandler
{
    public class CommandStore
    {
        public List<Command> Commands { get; set; }

        public CommandStore()
        {
            Commands = new List<Command>();
            AddDefaultCoomands();
        }

        public string Execute(string commandText)
        {
            var context = new Dictionary<string, string>();
            Command command = null;

            /// find static text
            /// ex, show time
            command = (from item in Commands
                       from text in item.Commands
                       where text == commandText.ToLower()
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

        private void AddDefaultCoomands()
        {
            Command command = new Command();

            Command command3 = new Command();
            command3.Commands.Add("show time");
            command3.Commands.Add("time");
            command3.Commands.Add("время");
            command3.Commands.Add("покажи время");
            command3.Actions.Add(new SpeakAction());
            command3.Actions[0].InputArguments[0].ParseValue(@"$(TimeArgument:now)");
            command3.Actions.Add(new ReturnAction());
            command3.Actions[1].InputArguments[0].ParseValue(@"$(TimeArgument:now)");
            Commands.Add(command3);

            Command command4 = new Command();
            command4.Commands.Add("show date");
            command4.Commands.Add("date");
            command4.Commands.Add("дата");
            command4.Commands.Add("покажи дату");
            command4.Actions.Add(new SpeakAction());
            command4.Actions[0].InputArguments[0].ParseValue(@"$(DateArgument:now)");
            command4.Actions.Add(new ReturnAction());
            command4.Actions[1].InputArguments[0].ParseValue(@"$(DateArgument:now)");
            Commands.Add(command4);

            Command command5 = new Command();
            command5.Commands.Add("bitcoin");
            command5.Commands.Add("btc");
            command5.Actions.Add(new CurrencyPriceAction());
            command5.Actions[0].InputArguments[0].ParseValue("btc");
            command5.Actions[0].InputArguments[1].ParseValue("usd");
            command5.Actions.Add(new SpeakAction());
            command5.Actions[1].InputArguments[0].ParseValue(@"$(carg:value)");
            command5.Actions.Add(new ReturnAction());
            command5.Actions[2].InputArguments[0].ParseValue($"$(carg:value)");
            Commands.Add(command5);

            Command command6 = new Command();
            command6.Commands.Add("bitcoin uah");
            command6.Actions.Add(new CurrencyPriceAction());
            command6.Actions[0].InputArguments[0].ParseValue("btc");
            command6.Actions[0].InputArguments[1].ParseValue("uah");
            command6.Actions.Add(new SpeakAction());
            command6.Actions[1].InputArguments[0].ParseValue(@"$(carg:value)");
            command6.Actions.Add(new ReturnAction());
            command6.Actions[2].InputArguments[0].ParseValue($"$(carg:value)");
            Commands.Add(command6);

            Command command7 = new Command();
            command7.Commands.Add("dogecoin");
            command7.Actions.Add(new CurrencyPriceAction());
            command7.Actions[0].InputArguments[0].ParseValue("doge");
            command7.Actions[0].InputArguments[1].ParseValue("usdt");
            command7.Actions.Add(new SpeakAction());
            command7.Actions[1].InputArguments[0].ParseValue(@"$(carg:value)");
            command7.Actions.Add(new ReturnAction());
            command7.Actions[2].InputArguments[0].ParseValue(@"$(carg:value)");
            Commands.Add(command7);

            Command command8 = new Command();
            command8.Commands.Add("запусти текстовый редактор");
            command8.Commands.Add("start a text editor");
            command8.Actions.Add(new ExecuteAction());
            command8.Actions[0].InputArguments[0].ParseValue(@"C:\Windows\System32");
            command8.Actions[0].InputArguments[1].ParseValue(@"notepad.exe");
            command8.Actions.Add(new SpeakAction());
            command8.Actions[1].InputArguments[0].ParseValue(@"текстовый редактор запущен");
            command8.Actions.Add(new ReturnAction());
            command8.Actions[2].InputArguments[0].ParseValue(@"launched");
            Commands.Add(command8);

            command = new Command();
            command.Commands.Add("запусти калькулятор");
            command.Commands.Add("start a calculator");
            command.Actions.Add(new ExecuteAction());
            command.Actions[0].InputArguments[0].ParseValue(@"C:\Windows\System32");
            command.Actions[0].InputArguments[1].ParseValue(@"calc.exe");
            command.Actions.Add(new SpeakAction());
            command.Actions[1].InputArguments[0].ParseValue(@"launched");
            command.Actions.Add(new ReturnAction());
            command.Actions[2].InputArguments[0].ParseValue(@"launched");
            Commands.Add(command);

            //command = new Command();
            //command.Commands.Add("запусти командную строку");
            //command.Commands.Add("start a command line");
            //command.Actions.Add(new ExecuteAction());
            //command.Actions[0].InputArguments[0].ParseValue(@"C:\Windows\System32");
            //command.Actions[0].InputArguments[1].ParseValue(@"cmd.exe");
            //command.Actions.Add(new SpeakAction());
            //command.Actions[1].InputArguments[0].ParseValue(@"командная строка запущенна");
            //command.Actions.Add(new ReturnAction());
            //command.Actions[2].InputArguments[0].ParseValue(@"launched");
            //Commands.Add(command);
        }
    }
}
