using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RealTimeCryptoCurrencies.Models;

namespace RealTimeCryptoCurrencies.Hubs
{
    public class CurrencyHub : Hub
    {
        public Task PushSingleCurrency(Currency currencyData)
        {
            return Clients.All.InvokeAsync("ChangeCurrency", currencyData);
        }

        public Task PushAllCurrencies(List<Currency> currencyData)
        {
            return Clients.All.InvokeAsync("ChangeCurrencies", currencyData);
        }
    }
}
