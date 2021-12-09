using System;
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
    }
}
