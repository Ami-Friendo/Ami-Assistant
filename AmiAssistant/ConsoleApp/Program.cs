using System;
using System.Collections.Generic;

using AmiFriendo.CommandHandler;
using AmiFriendo.CommandHandler.Exceptions;
using AmiFriendo.CommandHandler.Actions;
using AmiFriendo.CommandHandler.Arguments;

namespace AmiFriendo.ConsoleApp
{
    using CommandContext = Dictionary<string, string>;
    class Program
    {
        static void Main(string[] args)
        {
            ///
            /// Command test 
            ///
            CommandStore cs = new();

            // create command hardcode
            Command command1 = new();
            command1.Commands.Add("command first");
            command1.Commands.Add("command 1");
            command1.Actions.Add(new ExecuteAction());
            command1.Actions[0].InputArguments[0].ParseValue(@"C:\Program Files (x86)\Notepad++");
            command1.Actions[0].InputArguments[1].ParseValue(@"notepad++.exe");
            command1.Actions.Add(new ReturnAction());
            command1.Actions[1].InputArguments[0].ParseValue(@"launch");
            cs.Commands.Add(command1);

            Command command2 = new();
            command2.Commands.Add("command two");
            command2.Commands.Add("command 2");
            command2.Actions.Add(new TestAction());
            command2.Actions[0].InputArguments[0].ParseValue("5");
            command2.Actions[0].InputArguments[1].ParseValue("7");
            var output = command2.Actions[0].OutputArguments[0].Name; // value

            command2.Actions.Add(new ReturnAction());
            command2.Actions[1].InputArguments[0].ParseValue($"Результат $(carg:value)");
            cs.Commands.Add(command2);

            // execute command
            string result = null;
            try
            {
                result = command2.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (result != null)
                Console.WriteLine($"{result}");
            else
                Console.WriteLine($"empty result");





            ///
            /// other test
            ///
            if (false)
            {
                CommandContext cc = new();

                ///
                /// TestAction
                ///
                IAction action = new TestAction();
                action.InputArguments[0].ParseValue("50");
                Console.WriteLine("InputArguments[0]");
                Console.WriteLine(action.InputArguments[0].Name);
                Console.WriteLine(action.InputArguments[0].FriendlyName);
                Console.WriteLine(action.InputArguments[0].Description);
                Console.WriteLine(action.InputArguments[0].ExamplesInput);
                Console.WriteLine(action.InputArguments[0].ExampleOutput);

                Console.WriteLine("InputArguments[1]");
                action.InputArguments[1].ParseValue("20");

                action.Execute(ref cc);

                Console.WriteLine(cc["return"]);

                ///
                /// Directory Argument
                ///
                var directory = new DirectoryArgument();
                Console.WriteLine(directory.ParseValue(@"C:\Users\Krav_up8d\Desktop\Ami-assistant"));
                Console.WriteLine(directory.Value);

                ///
                /// File Argument
                ///
                Console.WriteLine();
                var file = new FileArgument();
                Console.WriteLine(file.ParseValue(@"/photo.txt"));
                Console.WriteLine(file.Value);

                ///
                /// ExecuteAction
                ///
                Console.WriteLine();
                var action2 = new ExecuteAction();
                action2.InputArguments[0].ParseValue(@"C:\Program Files (x86)\Notepad++");
                action2.InputArguments[1].ParseValue(@"notepad++.exee");
                Console.WriteLine($"Can execute: {action2.CanExecute()}");
                if (action2.CanExecute())
                {
                    action2.Execute(ref cc);
                }
                else
                {
                    string str;
                    action2.CanExecute(out str);
                    Console.WriteLine($"cause: {str}");
                }
            }
        }
    }
}
