using System;
using System.Collections.Generic;
using System.Text;

namespace AmiFriendo.CommandHandler.Arguments
{
    public class DateArgument : IArgument
    {
        const string DEFAULT_NAME = "date";
        const bool DEFAULT_REQUIRED = true;

        #region IArgumentImplementation
        public string Name => _name;
        public string FriendlyName
        {
            get => _friendlyName;
            set => _friendlyName = value;
        }
        public string Description => "date, ex: 21.11"; // Resources.ArgumentDescription.ValueArgument;
        public string ExamplesInput => "todo"; // Resources.ArgumentExamplesInput.ValueArgument;
        public string ExampleOutput => "Friday, December 10, 2021"; //Resources.ArgumentExampleOutput.ValueArgument;
        public string Value => _date.ToLongDateString();
        public bool IsRequired => _isRequired;
        public bool ParseValue(string inputValue)
        {
            if (inputValue == "now")
            {
                _date = DateTime.Now;
            }
            else
            {
                try
                {
                    _date = DateTime.Parse(inputValue);
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        public DateArgument()
        {
            string nameArgument = DEFAULT_NAME;
            bool isRequired = DEFAULT_REQUIRED;

            _name = nameArgument;
            _isRequired = isRequired;
        }

        private string _name;
        private DateTime _date;
        private string _friendlyName = "date"; // Resources.ArgumentFriendlyNames.ValueArgument;
        private bool _isRequired;
    }
}
