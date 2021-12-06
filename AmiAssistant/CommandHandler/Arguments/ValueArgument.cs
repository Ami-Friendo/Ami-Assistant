using System;
using System.Collections.Generic;
using System.Text;

namespace AmiFriendo.CommandHandler.Arguments
{
    public class ValueArgument : IArgument
    {
        const string DEFAULT_NAME = "value";
        const bool DEFAULT_REQUIRED = false;

        #region IArgumentImplementation
        public string Name => _name;
        public string FriendlyName 
        {
            get => _friendlyName;
            set => _friendlyName = value; 
        }
        public string Description => _descrption;
        public string ExamplesInput => _examplesInput;
        public string ExampleOutput => _exampleOutput;
        public string Value => _value;
        public bool IsRequired => _isRequired;
        public bool parseValue(string inputValue)
        {
            _value = inputValue;
            return true;
        }
        #endregion

        public ValueArgument(string nameArgument = DEFAULT_NAME, bool isRequired = DEFAULT_REQUIRED)
        {
            _name = nameArgument;
            _isRequired = isRequired;
        }

        private string _name;
        private string _value;
        private string _friendlyName = Resources.ArgumentFriendlyNames.ValueArgument;
        private string _descrption = Resources.ArgumentDescription.ValueArgument;
        private string _examplesInput = Resources.ArgumentExamplesInput.ValueArgument;
        private string _exampleOutput = Resources.ArgumentExampleOutput.ValueArgument;
        private bool _isRequired;
    }
}
