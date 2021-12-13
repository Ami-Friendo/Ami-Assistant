using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AmiFriendo.AuxiliaryFunctions.ClientInterfaces;
using NoobsMuc.Coinmarketcap.Client;

namespace AmiFriendo.AuxiliaryFunctions
{
    public class CoinMarketCapClient : ICryptoCurrency
    {
        public double GetCurrencyBySlug(string slug)
        {
            return client.GetCurrencyBySlug(slug).Price;
        }

        public double GetCurrencyBySlug(string slug, string convertCurrency)
        {
            return client.GetCurrencyBySlug(slug, convertCurrency).Price;
        }

        public double GetCurrencyBySymbol(string symbol)
        {
            return client.GetCurrencyBySymbol(symbol).Price;
        }

        public double GetCurrencyBySymbol(string symbol, string convertCurrency)
        {
            return client.GetCurrencyBySymbol(symbol, convertCurrency).Price;
        }

        public CoinMarketCapClient()
        {
            client = new CoinmarketcapClient("7633e1e0-f651-4ca8-8146-87d69fa39fe0");
        }

        private ICoinmarketcapClient client;
    }
}
