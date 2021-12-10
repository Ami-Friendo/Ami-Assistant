using System;
using System.Collections.Generic;
using System.Text;

namespace AmiFriendo.CommandHandler.Arguments
{
    public class TimeArgument : IArgument
    {
        const string DEFAULT_NAME = "time";
        const bool DEFAULT_REQUIRED = true;

        #region IArgumentImplementation
        public string Name => _name;
        public string FriendlyName
        {
            get => _friendlyName;
            set => _friendlyName = value;
        }
        public string Description => "time, ex: 14:00"; // Resources.ArgumentDescription.ValueArgument;
        public string ExamplesInput => "todo"; // Resources.ArgumentExamplesInput.ValueArgument;
        public string ExampleOutput => "12:32:01 PM"; //Resources.ArgumentExampleOutput.ValueArgument;
        public string Value => _time.ToLongTimeString();
        public bool IsRequired => _isRequired;
        public bool ParseValue(string inputValue)
        {
            if (inputValue == "now")
            {
                _time = DateTime.Now;
            }
            else
            {
                try
                {
                    _time = DateTime.Parse(inputValue);
                }
                catch
                {
                    return false;
                }
            } 

            return true;
        }
        #endregion

        public TimeArgument()
        {
            string nameArgument = DEFAULT_NAME;
            bool isRequired = DEFAULT_REQUIRED;

            _name = nameArgument;
            _isRequired = isRequired;
        }

        private string _name;
        private DateTime _time;
        private string _friendlyName = "time"; // Resources.ArgumentFriendlyNames.ValueArgument;
        private bool _isRequired;
    }
}
