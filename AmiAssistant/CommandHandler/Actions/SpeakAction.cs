using System;
using System.Collections.Generic;
using System.Text;

using AmiFriendo.CommandHandler.Arguments;
using AmiFriendo.CommandHandler.Exceptions;
using AmiFriendo.AuxiliaryFunctions;

namespace AmiFriendo.CommandHandler.Actions
{
    using CommandContext = Dictionary<string, string>;
    public class SpeakAction : IAction
    {
        const string DEFAULT_NAME = "speak";

        #region IAction Implementation
        public string Name => _name;
        public string FriendlyName
        {
            get => _friendlyName;
            set => _friendlyName = value;
        }
        public string Description => "todo"; // Resources.ActionDescription.ReturnAction;
        public IArgument[] InputArguments => _inputArguments;
        public IArgument[] OutputArguments => _outputArguments;

        public void Execute(ref CommandContext context)
        {
            ArgumentReplacer ar = new ArgumentReplacer();
            ar.InitInputArgumentsByContext(InputArguments, context);

            if (!CanExecute())
                throw new NonCanExecuteActionException();

            Speaker_Engine.Talker.Speecher_Voice(InputArguments[0].Value);
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

        public SpeakAction(string nameAction = DEFAULT_NAME)
        {
            _name = nameAction;
            InputArguments[0] = new ValueArgument();
        }

        private string _name;
        private string _friendlyName = "todo"; // Resources.ActionFriendlyName.ReturnAction;
        private IArgument[] _inputArguments = new IArgument[1];
        private IArgument[] _outputArguments = null;
    }
}
