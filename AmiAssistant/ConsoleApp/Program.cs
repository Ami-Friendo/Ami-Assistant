using System;

using AmiFriendo.CommandHandler;
using AmiFriendo.CommandHandler.Actions;

namespace AmiFriendo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandContext cc = new();

            IAction action = new ReturnAction();
            var i = action?.OutputArguments[0].Name;
            Console.WriteLine(i);


            //action.InputArguments[0].ParseValue("50");
            //action.InputArguments[1].ParseValue("20");

            //action.Execute(ref cc);

            //Console.WriteLine(cc.Context["return"]);
        }
    }
}
