using System;
using System.Collections.Generic;
using System.Text;

using AmiFriendo.CommandHandler.Actions;

namespace AmiFriendo.CommandHandler
{
    using CommandContext = Dictionary<string, string>;
    public class Command
    {
        public List<string> Commands { get; } = new List<string>();
        public List<IAction> Actions { get; } = new List<IAction>();
        public CommandContext Context { get; } = new CommandContext();

        public string execute()
        {
            return null;
        }
    }
}
