using System;
using System.Collections.Generic;
using System.Text;

namespace AmiFriendo.CommandHandler.ClientInterfaces
{
    public interface ICryptoCurrency
    {
        double GetCurrencyBySlug(string slug);
        double GetCurrencyBySymbol(string symbol);
        double GetCurrencyBySlug(string slug, string convertCurrency);
        double GetCurrencyBySymbol(string symbol, string convertCurrency);
    }
}
