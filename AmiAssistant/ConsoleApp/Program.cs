using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

using AmiFriendo.CommandHandler;
using AmiFriendo.CommandHandler.Exceptions;
using AmiFriendo.CommandHandler.Actions;
using AmiFriendo.CommandHandler.Arguments;

using AmiFriendo.AuxiliaryFunctions;
using AmiFriendo.AuxiliaryFunctions.ClientInterfaces;

namespace AmiFriendo.ConsoleApp
{
    using CommandContext = Dictionary<string, string>;
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo culture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            if (true)
            {
                ///
                /// Command test 
                ///
                CommandStore cs = new();

                while (true)
                {
                    Console.Write("Enter your command -> ");
                    var command = Console.ReadLine();
                    var res = cs.Execute(command);
                    Console.WriteLine(res);
                    Console.WriteLine();
                }
            }
            ///
            /// other test
            ///
            if (false)
            {
                CommandContext cc = new();

                ///
                /// TestAction
                ///
                //IAction action = new TestAction();
                //action.InputArguments[0].ParseValue("50");
                //Console.WriteLine("InputArguments[0]");
                //Console.WriteLine(action.InputArguments[0].Name);
                //Console.WriteLine(action.InputArguments[0].FriendlyName);
                //Console.WriteLine(action.InputArguments[0].Description);
                //Console.WriteLine(action.InputArguments[0].ExamplesInput);
                //Console.WriteLine(action.InputArguments[0].ExampleOutput);

                //Console.WriteLine("InputArguments[1]");
                //action.InputArguments[1].ParseValue("20");

                //action.Execute(ref cc);

                //Console.WriteLine(cc["return"]);

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

                ///
                /// TimeArgument
                ///
                var time = new TimeArgument();
                Console.WriteLine(time.ParseValue("now"));
                Console.WriteLine(time.Value);

                ///
                /// DateArgument
                ///
                var date = new DateArgument();
                Console.WriteLine(date.ParseValue("12.11"));
                Console.WriteLine(date.Value);
            }
        }
    }
}
