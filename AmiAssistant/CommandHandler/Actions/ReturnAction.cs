using AmiFriendo.CommandHandler.Arguments;
using System;
using System.Collections.Generic;
using System.Text;

using AmiFriendo.CommandHandler.Exceptions;

namespace AmiFriendo.CommandHandler.Actions
{
    using CommandContext = Dictionary<string, string>;
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
        public IArgument[] InputArguments => _inputArguments;
        public IArgument[] OutputArguments => _outputArguments;

        public void Execute(ref CommandContext context)
        {
            ArgumentReplacer ar = new ArgumentReplacer();
            ar.InitInputArgumentsByContext(InputArguments, context);

            if (!CanExecute())
                throw new NonCanExecuteActionException();

            context.Add("return", _inputArguments[0].Value);
        }

        public bool CanExecute()
        {
            string str;
            return CanExecute(out str);
        }

        public bool CanExecute(out string cause)
        {
            if (_inputArguments[0].Value == null)
            {
                cause = "";
                return false;
            }
                
            cause = null;
            return true;
        }
        #endregion

        public ReturnAction(string nameAction = DEFAULT_NAME)
        {
            _name = nameAction;

            InputArguments[0] = new ValueArgument();
            OutputArguments[0] = new ValueArgument();
        }

        private string _name;
        private string _friendlyName = Resources.ActionFriendlyName.ReturnAction;
        private IArgument[] _inputArguments = new IArgument[1];
        private IArgument[] _outputArguments = new IArgument[1];
    }
}
