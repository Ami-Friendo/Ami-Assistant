using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AmiFriendo.CommandHandler.Arguments
{
    public class DirectoryArgument : IArgument
    {
        const string DEFAULT_NAME = "directory";
        const bool DEFAULT_REQUIRED = true;

        #region IArgumentImplementation
        public string Name => _name;
        public string FriendlyName
        {
            get => _friendlyName;
            set => _friendlyName = value;
        }
        public string Description => "todo"; // Resources.ArgumentDescription.ValueArgument;
        public string ExamplesInput => "todo"; // Resources.ArgumentExamplesInput.ValueArgument;
        public string ExampleOutput => "todo"; //Resources.ArgumentExampleOutput.ValueArgument;
        public string Value => _value.FullName;
        public bool IsRequired => _isRequired;
        public bool ParseValue(string inputValue)
        {
            try
            {
                _value = new DirectoryInfo(inputValue);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        public DirectoryArgument(string nameArgument = DEFAULT_NAME, bool isRequired = DEFAULT_REQUIRED)
        {
            _name = nameArgument;
            _isRequired = isRequired;
        }

        private string _name;
        private DirectoryInfo _value;
        private string _friendlyName = "todo"; // Resources.ArgumentFriendlyNames.ValueArgument;
        private bool _isRequired;
    }
}
