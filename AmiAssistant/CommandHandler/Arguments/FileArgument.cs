using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AmiFriendo.CommandHandler.Arguments
{
    public class FileArgument : IArgument
    {
        const string DEFAULT_NAME = "filename";
        const bool DEFAULT_REQUIRED = true;

        #region IArgumentImplementation
        public string Name => _name;
        public string FriendlyName
        {
            get => _friendlyName;
            set => _friendlyName = value;
        }
        public string Description => "filename+extenion, example: photo.jpg"; // Resources.ArgumentDescription.ValueArgument;
        public string ExamplesInput => "todo"; // Resources.ArgumentExamplesInput.ValueArgument;
        public string ExampleOutput => "todo"; //Resources.ArgumentExampleOutput.ValueArgument;
        public string Value => _value.Name;
        public bool IsRequired => _isRequired;
        public bool ParseValue(string inputValue)
        {
            if (inputValue.Contains(Path.DirectorySeparatorChar))
                return false;

            try
            {
                _value = new FileInfo(inputValue);
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        public FileArgument(string nameArgument = DEFAULT_NAME, bool isRequired = DEFAULT_REQUIRED)
        {
            _name = nameArgument;
            _isRequired = isRequired;
        }

        private string _name;
        private FileInfo _value;
        private string _friendlyName = "todo"; // Resources.ArgumentFriendlyNames.ValueArgument;
        private bool _isRequired;
    }
}
