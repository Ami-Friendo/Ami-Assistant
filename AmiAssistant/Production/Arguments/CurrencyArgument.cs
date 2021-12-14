using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AmiFriendo.CommandHandler.Arguments
{
    public class CurrencyArgument : IArgument
    {
        const string DEFAULT_NAME = "currency";
        const bool DEFAULT_REQUIRED = true;

        #region IArgumentImplementation
        public string Name => _name;
        public string FriendlyName
        {
            get => _friendlyName;
            set => _friendlyName = value;
        }
        public string Description => "todo";   // Resources.ArgumentDescription.ValueArgument;
        public string ExamplesInput => "todo"; // Resources.ArgumentExamplesInput.ValueArgument;
        public string ExampleOutput => "todo"; // Resources.ArgumentExampleOutput.ValueArgument;
        public string Value => _price;
        public bool IsRequired => _isRequired;
        public bool ParseValue(string inputValue)
        {
            const string pattern = @"^\w+$";

            if (Regex.Matches(inputValue, pattern, RegexOptions.IgnoreCase).Count == 0)
            {
                return false;
            }

            _price = inputValue.ToUpper();
            return true;
        }
        #endregion

        public CurrencyArgument()
        {
            string nameArgument = DEFAULT_NAME;
            bool isRequired = DEFAULT_REQUIRED;

            _name = nameArgument;
            _isRequired = isRequired;
        }

        private string _name;
        private string _price;
        private string _friendlyName = "currency"; // Resources.ArgumentFriendlyNames.ValueArgument;
        private bool _isRequired;
    }
}
