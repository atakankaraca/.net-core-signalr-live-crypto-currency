using System;
using System.Net;
using System.Threading.Tasks;
using BitcoinService.Model;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace BitcoinService
{
    class Program
    {
        public static WebClient client;
        public static HubConnection connection;
        public static string api = "http://api.binance.com/api/v1/ticker";
        public static string queryString = "/price?symbol=BTCUSDT";

        static void Main(string[] args)
        {
            //Hub'a bağlanmayı bekle.
            ConnectHub().Wait();
            var tempPrice = 0M;

            while (true)
            {
                client = new WebClient();
                var json = client.DownloadString(api + queryString);
                var result = JsonConvert.DeserializeObject<Currency>(json);

                if (tempPrice != result.Price)
                {
                    connection.InvokeAsync("PushSingleCurrency", result);
                }
                tempPrice = result.Price;
            }
        }

        public static async Task ConnectHub()
        {
            connection = new HubConnectionBuilder()
                //.WithUrl("http://localhost:62118/currencyHub")
                .WithUrl("https://signalr-app.herokuapp.com/currencyHub")
                .Build();

            await connection.StartAsync();
        }
    }
}
