using AmiFriendo.CommandHandler.Arguments;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmiFriendo.CommandHandler.Actions
{
    public class ReturnAction : IAction
    {
        const string DEFAULT_NAME = "return";

        #region IAction Implementation
        public string Name => _name;
        public string FriendlyName
        {
            get => _friendlyName;
            set => _friendlyName = value;
        }
        public string Description => Resources.ActionDescription.ReturnAction;
        public IArgument[] InputArguments => new IArgument[2];
        public IArgument[] OutputArguments => new IArgument[1];

        public void Execute(ref CommandContext context)
        {
            // test
            context.Context.Add("return", (Int32.Parse(InputArguments[0].Value)
                + Int32.Parse(InputArguments[1].Value)).ToString());
        }
        #endregion

        public ReturnAction(string nameAction = DEFAULT_NAME)
        {
            _name = nameAction;

            InputArguments[0] = new ValueArgument();
            InputArguments[1] = new ValueArgument();
            OutputArguments[0] = new ValueArgument();
        }

        private string _name;
        private string _friendlyName = Resources.ActionFriendlyName.ReturnAction;
    }
}
