using System;
using System.Linq;
using System.Collections.Generic;

namespace AmiFriendo.CommandHandler
{
    public class CommandStore
    {
        public List<Command> Commands { get; set; }

        public CommandStore()
        {
            Commands = new List<Command>();
        }

        public string Execute(string command)
        {
            var query = (from item in Commands
                        from text in item.Commands
                        where text == command
                        select item).FirstOrDefault();

            if (query == null)
                return "not found command";

            // execute command
            string result = null;
            //try
            //{
                result = query.Execute();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            if (result != null)
                return result;
            else
                return "empty result";
        }
    }
}
