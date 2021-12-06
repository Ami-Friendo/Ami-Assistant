using System;
using System.Collections.Generic;
using System.Text;

using AmiFriendo.CommandHandler.Arguments;

namespace AmiFriendo.CommandHandler.Actions
{
    public interface IAction
    {
        string Name { get; }
        string Description { get; }
        IArgument[] InputArguments { get; }
        IArgument[] OutputArguments { get; }

        void Execute(ref CommandContext context);
    }
}
