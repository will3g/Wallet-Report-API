using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    public class Coin : ControllerBase
    {
        public Coin(AppDb db)
        {
            Db = db;
        }

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
                    var coinAttr = JsonConvert.DeserializeObject<CoinModel>(stringResult);
                    coinAttr.Slug = coin;

                    await Db.Connection.OpenAsync();
                    coinAttr.Db = Db;
                    await coinAttr.InsertAsync();
                    return new OkObjectResult(coinAttr);

                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting criptocurrency {httpRequestException}");
                }
            }
        }

        // GET api/coin/{slug}
        [HttpGet("/details/latest/{slug}")]
        public async Task<IActionResult> GetLatest(string slug)
        {
            await Db.Connection.OpenAsync();
            var query = new CoinPostQuery(Db);
            var result = await query.LatestPostsAsync(slug);
            return new OkObjectResult(result);
        }

        [HttpGet("/details/{slug}")]
        public async Task<IActionResult> GetResult(string slug)
        {
            await Db.Connection.OpenAsync();
            var query = new CoinPostQuery(Db);
            var result = await query.AllPostsAsync(slug);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST api/coin
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CoinModel body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        // PUT api/coin/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody] CoinModel body)
        {
            await Db.Connection.OpenAsync();
            var query = new CoinPostQuery(Db);
            var result = await query.FirstPostAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.Slug = body.Slug;
            result.Last = body.Last;
            result.Max = body.Max;
            result.Min = body.Min;
            result.Buy = body.Buy;
            result.Sell = body.Sell;
            result.Open = body.Open;
            result.Vol = body.Vol;
            result.Trade = body.Trade;
            result.Trades = body.Trades;
            result.Vwap = body.Vwap;
            result.Money = body.Money;
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE api/coin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new CoinPostQuery(Db);
            var result = await query.FirstPostAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }

        // DELETE api/coin
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await Db.Connection.OpenAsync();
            var query = new CoinPostQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }

        public AppDb Db { get; }
    }
}