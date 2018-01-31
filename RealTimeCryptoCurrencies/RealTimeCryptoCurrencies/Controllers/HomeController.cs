using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeCryptoCurrencies.Models;

namespace RealTimeCryptoCurrencies.Controllers
{
    public class HomeController : Controller
    {
        public static List<Currency> currencyList = new List<Currency>{
            new Currency{Symbol = "BTCUSDT", Price = 0, Name = "Bitcoin"},
            new Currency{Symbol = "ETHBTC", Price = 0, Name =  "Ethereum"},
            new Currency{Symbol = "LTCBTC", Price = 0, Name = "Litecoin"},
            new Currency{Symbol = "IOTABTC", Price = 0, Name = "Iota"},
            new Currency{Symbol = "XLMBTC", Price = 0, Name = "Stellar"},
            new Currency{Symbol = "STRATBTC", Price = 0, Name = "Stratis"},
            new Currency{Symbol = "XRPBTC", Price = 0, Name = "Ripple"},
            new Currency{Symbol = "ICXBTC", Price = 0, Name = "Icon"},
            new Currency{Symbol = "ENGBTC", Price = 0, Name = "Enigma"}
        };

        public IActionResult Index()
        {
            return View(currencyList);
        }

        public IActionResult Detail()
        {
            return View(currencyList.First());
        }
    }
}
