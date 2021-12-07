using System;
using System.Collections.Generic;

using AmiFriendo.CommandHandler;
using AmiFriendo.CommandHandler.Actions;

namespace AmiFriendo.ConsoleApp
{
    using CommandContext = Dictionary<string, string>;
    class Program
    {
        static void Main(string[] args)
        {
            CommandContext cc = new();

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
        }
    }
}
