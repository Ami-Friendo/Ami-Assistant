using System;
using System.Collections.Generic;
using System.Text;

namespace AmiFriendo.CommandHandler
{
    public class CommandContext
    {
        // <название аргумента, значение аргумента>
        public Dictionary<string, string> Context { get; } = new Dictionary<string, string>();
    }
}
