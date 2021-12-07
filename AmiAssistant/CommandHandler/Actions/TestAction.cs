using AmiFriendo.CommandHandler.Arguments;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmiFriendo.CommandHandler.Actions
{
    using CommandContext = Dictionary<string, string>;
    public class TestAction : IAction
    {
        const string DEFAULT_NAME = "test";

        #region IAction Implementation
        public string Name => _name;
        public string FriendlyName
        {
            get => _friendlyName;
            set => _friendlyName = value;
        }
        public string Description => Resources.ActionDescription.ReturnAction;
        public IArgument[] InputArguments => _inputArguments;
        public IArgument[] OutputArguments => _outputArguments;

        public void Execute(ref CommandContext context)
        {
            // test
            context.Add("return", (Int32.Parse(InputArguments[0].Value)
                + Int32.Parse(InputArguments[1].Value)).ToString());
        }
        #endregion

        public TestAction(string nameAction = DEFAULT_NAME)
        {
            _name = nameAction;

            InputArguments[0] = new ValueArgument();
            InputArguments[1] = new ValueArgument();
            OutputArguments[0] = new ValueArgument();
        }

        private string _name;
        private string _friendlyName = Resources.ActionFriendlyName.ReturnAction;
        private IArgument[] _inputArguments = new IArgument[2];
        private IArgument[] _outputArguments = new IArgument[1];
    }
}
