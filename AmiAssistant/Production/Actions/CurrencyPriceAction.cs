using System;
using System.Collections.Generic;
using System.Text;

using AmiFriendo.CommandHandler.Exceptions;
using AmiFriendo.CommandHandler.Arguments;

using AmiFriendo.AuxiliaryFunctions;
using AmiFriendo.AuxiliaryFunctions.ClientInterfaces;

namespace AmiFriendo.CommandHandler.Actions
{
    using CommandContext = Dictionary<string, string>;
    public class CurrencyPriceAction : IAction
    {
        const string DEFAULT_NAME = "currency";

        #region IAction Implementation
        public string Name => _name;
        public string FriendlyName
        {
            get => _friendlyName;
            set => _friendlyName = value;
        }
        public string Description => "get price currency"; //  Resources.ActionDescription.ReturnAction;
        public IArgument[] InputArguments => _inputArguments;
        public IArgument[] OutputArguments => _outputArguments;

        public void Execute(ref CommandContext context)
        {
            if (!CanExecute())
                throw new NonCanExecuteActionException();

            var price = client.GetCurrencyBySymbol(InputArguments[0].Value, InputArguments[1].Value);

            context.Add("value", String.Format("{0:C3}", price).Substring(1) + " " + InputArguments[1].Value);
        }

        public bool CanExecute()
        {
            string str;
            return CanExecute(out str);
        }

        public bool CanExecute(out string cause)
        {
            cause = null;
            return true;
        }
        #endregion
        public CurrencyPriceAction(string nameAction = DEFAULT_NAME)
        {
            _name = nameAction;

            InputArguments[0] = new CurrencyArgument();
            InputArguments[1] = new CurrencyArgument();
            OutputArguments[0] = new ValueArgument();

            client = new CoinMarketCapClient();
        }

        private string _name;
        private string _friendlyName = "todo"; //Resources.ActionFriendlyName.ReturnAction;
        private IArgument[] _inputArguments = new IArgument[2];
        private IArgument[] _outputArguments = new IArgument[1];
        private ICryptoCurrency client;
    }
}
