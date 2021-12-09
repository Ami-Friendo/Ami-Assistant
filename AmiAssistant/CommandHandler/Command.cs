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
        //public CommandContext Context => _context;

        public string Execute()
        {
            _context = new CommandContext();
            foreach (var action in Actions)
            {
                action.Execute(ref _context);
            }

            try
            {
                return _context["return"];
            }
            catch
            {
                return null;
            }
        }

        private CommandContext _context;
    }
}
