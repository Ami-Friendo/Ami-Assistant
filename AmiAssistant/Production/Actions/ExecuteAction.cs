using System;
using System.Collections.Generic;
using System.IO;

using AmiFriendo.CommandHandler.Exceptions;
using AmiFriendo.CommandHandler.Arguments;

namespace AmiFriendo.CommandHandler.Actions
{
    using CommandContext = Dictionary<string, string>;
    public class ExecuteAction : IAction
    {
        const string DEFAULT_NAME = "execute";

        #region IAction Implementation
        public string Name => _name;
        public string FriendlyName
        {
            get => _friendlyName;
            set => _friendlyName = value;
        }
        public string Description => "execute executable file"; //  Resources.ActionDescription.ReturnAction;
        public IArgument[] InputArguments => _inputArguments;
        public IArgument[] OutputArguments => _outputArguments;

        public void Execute(ref CommandContext context)
        {
            if (!CanExecute())
                throw new NonCanExecuteActionException();

            System.Diagnostics.Process.Start(getFile().FullName);
        }

        public bool CanExecute()
        {
            string str;
            return CanExecute(out str);
        }

        public bool CanExecute(out string cause)
        {
            if(!getFile().Exists)
            {
                cause = "";
                return false;
            }
            cause = null;
            return true;
        }
        #endregion
        public ExecuteAction(string nameAction = DEFAULT_NAME)
        {
            _name = nameAction;

            InputArguments[0] = new DirectoryArgument();
            InputArguments[1] = new FileArgument();
        }

        private FileInfo getFile()
        {
            var directoryValue = InputArguments[0].Value;
            var fileValue = InputArguments[1].Value;

            if (directoryValue[directoryValue.Length - 1] != Path.DirectorySeparatorChar)
                directoryValue += Path.DirectorySeparatorChar;

            FileInfo file = new FileInfo(directoryValue + fileValue);
            return file;
        }

        private string _name;
        private string _friendlyName = Production.Resources.ActionFriendlyName.ReturnAction;
        private IArgument[] _inputArguments = new IArgument[2];
        private IArgument[] _outputArguments = null;
    }
}
