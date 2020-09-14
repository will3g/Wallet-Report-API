using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using System.Net.Http;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Coin : ControllerBase
    {
        [HttpGet("{coin}")]
        public async Task<IActionResult> CoinTask(string coin)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://brasilbitcoin.com.br");
                    var response = await client.GetAsync($"/API/prices/{coin}");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawWeather = JsonConvert.DeserializeObject<CoinModel>(stringResult);

                    return Ok(new
                    {
                        Last = rawWeather.Last,
                        Max = rawWeather.Max,
                        Min = rawWeather.Min,
                        Buy = rawWeather.Buy,
                        Sell = rawWeather.Sell,
                        Open = rawWeather.Open,
                        Vol = rawWeather.Vol,
                        Trade = rawWeather.Trade,
                        Trades = rawWeather.Trades,
                        Vwap = rawWeather.Vwap,
                        Money = rawWeather.Money,
                    });
                 }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                }
            }
        }
    }
}