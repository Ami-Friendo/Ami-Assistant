﻿using System;
using System.Collections.Generic;
using System.IO;

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
            System.Diagnostics.Process.Start(file.FullName);
        }

        public bool CanExecute(ref string cause)
        {
            if(getFile().Exists)
            {
                return false;
                cause = "";
            }


            return true;
        }
        #endregion

        public ExecuteAction(string nameAction = DEFAULT_NAME)
        {
            _name = nameAction;

            InputArguments[0] = new DirectoryArgument(isRequired: true);
            InputArguments[1] = new FileArgument(isRequired: true);
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
        private string _friendlyName = Resources.ActionFriendlyName.ReturnAction;
        private IArgument[] _inputArguments = new IArgument[2];
        private IArgument[] _outputArguments = null;
    }
}
