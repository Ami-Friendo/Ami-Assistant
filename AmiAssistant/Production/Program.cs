//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Threading;

//using AmiFriendo.CommandHandler;
//using AmiFriendo.CommandHandler.Exceptions;
//using AmiFriendo.CommandHandler.Actions;
//using AmiFriendo.CommandHandler.Arguments;

//using AmiFriendo.AuxiliaryFunctions;
//using AmiFriendo.AuxiliaryFunctions.ClientInterfaces;

//namespace AmiFriendo.ConsoleApp
//{
//    using CommandContext = Dictionary<string, string>;
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            CultureInfo culture = new CultureInfo("en-US");
//            Thread.CurrentThread.CurrentCulture = culture;
//            Thread.CurrentThread.CurrentUICulture = culture;

//            if (true)
//            {
//                ///
//                /// Command test 
//                ///
//                CommandStore cs = new();

//                // create command hardcode
//                Command command1 = new();
//                command1.Commands.Add("command first");
//                command1.Commands.Add("launch notepad");
//                command1.Actions.Add(new ExecuteAction());
//                command1.Actions[0].InputArguments[0].ParseValue(@"C:\Program Files (x86)\Notepad++");
//                command1.Actions[0].InputArguments[1].ParseValue(@"notepad++.exe");
//                command1.Actions.Add(new ReturnAction());
//                command1.Actions[1].InputArguments[0].ParseValue(@"launch");
//                cs.Commands.Add(command1);

//                Command command2 = new();
//                command2.Commands.Add("command two");
//                command2.Commands.Add("command 2");
//                command2.Actions.Add(new TestAction());
//                command2.Actions[0].InputArguments[0].ParseValue("5");
//                command2.Actions[0].InputArguments[1].ParseValue("7");
//                // var output = command2.Actions[0].OutputArguments[0].Name; // value

//                command2.Actions.Add(new ReturnAction());
//                command2.Actions[1].InputArguments[0].ParseValue($"Результат $(carg:value).");
//                cs.Commands.Add(command2);


//                Command command3 = new();
//                command3.Commands.Add("show time");
//                command3.Actions.Add(new ReturnAction());
//                command3.Actions[0].InputArguments[0].ParseValue($"$(TimeArgument:now)");
//                cs.Commands.Add(command3);
                
//                Command command4 = new();
//                command4.Commands.Add("show date");
//                command4.Actions.Add(new ReturnAction());
//                command4.Actions[0].InputArguments[0].ParseValue($"$(DateArgument:now)");
//                cs.Commands.Add(command4);

//                Command command5 = new();
//                command5.Commands.Add("bitcoin");
//                command5.Commands.Add("btc");
//                command5.Actions.Add(new CurrencyPriceAction());
//                command5.Actions[0].InputArguments[0].ParseValue("btc");
//                command5.Actions[0].InputArguments[1].ParseValue("usd");
//                command5.Actions.Add(new ReturnAction());
//                command5.Actions[1].InputArguments[0].ParseValue($"$(carg:value)");
//                cs.Commands.Add(command5);

//                Command command6 = new();
//                command6.Commands.Add("bitcoin uah");
//                command6.Actions.Add(new CurrencyPriceAction());
//                command6.Actions[0].InputArguments[0].ParseValue("btc");
//                command6.Actions[0].InputArguments[1].ParseValue("uah");
//                command6.Actions.Add(new ReturnAction());
//                command6.Actions[1].InputArguments[0].ParseValue($"$(carg:value)");
//                cs.Commands.Add(command6);

//                Command command7 = new();
//                command7.Commands.Add("dogecoin");
//                command7.Actions.Add(new CurrencyPriceAction());
//                command7.Actions[0].InputArguments[0].ParseValue("doge");
//                command7.Actions[0].InputArguments[1].ParseValue("usdt");
//                command7.Actions.Add(new ReturnAction());
//                command7.Actions[1].InputArguments[0].ParseValue($"$(carg:value)");
//                cs.Commands.Add(command7);

//                while (true)
//                {
//                    Console.Write("Enter your command -> ");
//                    var command = Console.ReadLine();
//                    var res = cs.Execute(command);
//                    Console.WriteLine(res);
//                    Console.WriteLine();
//                }
//            }

//            ///
//            /// other test
//            ///
//            if (false)
//            {
//                CommandContext cc = new();

//                ///
//                /// TestAction
//                ///
//                //IAction action = new TestAction();
//                //action.InputArguments[0].ParseValue("50");
//                //Console.WriteLine("InputArguments[0]");
//                //Console.WriteLine(action.InputArguments[0].Name);
//                //Console.WriteLine(action.InputArguments[0].FriendlyName);
//                //Console.WriteLine(action.InputArguments[0].Description);
//                //Console.WriteLine(action.InputArguments[0].ExamplesInput);
//                //Console.WriteLine(action.InputArguments[0].ExampleOutput);

//                //Console.WriteLine("InputArguments[1]");
//                //action.InputArguments[1].ParseValue("20");

//                //action.Execute(ref cc);

//                //Console.WriteLine(cc["return"]);

//                ///
//                /// Directory Argument
//                ///
//                var directory = new DirectoryArgument();
//                Console.WriteLine(directory.ParseValue(@"C:\Users\Krav_up8d\Desktop\Ami-assistant"));
//                Console.WriteLine(directory.Value);

//                ///
//                /// File Argument
//                ///
//                Console.WriteLine();
//                var file = new FileArgument();
//                Console.WriteLine(file.ParseValue(@"/photo.txt"));
//                Console.WriteLine(file.Value);

//                ///
//                /// ExecuteAction
//                ///
//                Console.WriteLine();
//                var action2 = new ExecuteAction();
//                action2.InputArguments[0].ParseValue(@"C:\Program Files (x86)\Notepad++");
//                action2.InputArguments[1].ParseValue(@"notepad++.exee");
//                Console.WriteLine($"Can execute: {action2.CanExecute()}");
//                if (action2.CanExecute())
//                {
//                    action2.Execute(ref cc);
//                }
//                else
//                {
//                    string str;
//                    action2.CanExecute(out str);
//                    Console.WriteLine($"cause: {str}");
//                }

//                ///
//                /// TimeArgument
//                ///
//                var time = new TimeArgument();
//                Console.WriteLine(time.ParseValue("now"));
//                Console.WriteLine(time.Value);

//                ///
//                /// DateArgument
//                ///
//                var date = new DateArgument();
//                Console.WriteLine(date.ParseValue("12.11"));
//                Console.WriteLine(date.Value);
//            }
//        }
//    }
//}
