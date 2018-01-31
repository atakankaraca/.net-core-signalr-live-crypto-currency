using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace CurrencyService
{
    class Program
    {
        public static WebClient client;
        public static HubConnection connectionSignalR;
        public static string apiUrl = "https://api.binance.com/api/v1/ticker/price?symbol=";

        static void Main(string[] args)
        {
            //Hub'a bağlanmayı bekle
            ConnectRemote().Wait();
            
            while (true)
            {
                client = new WebClient();
                var currencies = new List<Currency>();
                List<string> symbols = new List<string>()
                {
                    "BTCUSDT",
                    "LTCBTC",
                    "ETHBTC",
                    "ICXBTC",
                    "IOTABTC",
                    "XLMBTC",
                    "XRPBTC",
                    "STRATBTC",
                    "ENGBTC"
                };

                foreach (var item in symbols)
                {
                    var json = client.DownloadString(apiUrl + item);
                    var result = JsonConvert.DeserializeObject<Currency>(json);
                    currencies.Add(result);
                }

                connectionSignalR.InvokeAsync("PushAllCurrencies", currencies);
            }

        }

        public static async Task ConnectRemote()
        {
            connectionSignalR = new HubConnectionBuilder()
                //.WithUrl("http://localhost:62118/currencyHub")
                .WithUrl("https://signalr-app.herokuapp.com/currencyHub")
                .Build();

            await connectionSignalR.StartAsync();
        }
    }
}
