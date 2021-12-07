using System;
using System.Collections.Generic;

using AmiFriendo.CommandHandler;
using AmiFriendo.CommandHandler.Actions;
using AmiFriendo.CommandHandler.Arguments;

namespace AmiFriendo.ConsoleApp
{
    using CommandContext = Dictionary<string, string>;
    class Program
    {
        static void Main(string[] args)
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
            action2.InputArguments[1].ParseValue(@"notepad++.ex");
            action2.Execute(ref cc);
        }
    }
}
