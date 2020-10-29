using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    public class Coin : ControllerBase
    {
        public Coin(AppDb db)
        {
            Db = db;
        }

        public static DateTime GetNetworkTime()
        {
            //Servidor nacional para melhor latência
            const string ntpServer = "a.ntp.br";

            // Tamanho da mensagem NTP - 16 bytes (RFC 2030)
            var ntpData = new byte[48];

            //Indicador de Leap (ver RFC), Versão e Modo
            ntpData[0] = 0x1B; //LI = 0 (sem warnings), VN = 3 (IPv4 apenas), Mode = 3 (modo cliente)

            var addresses = Dns.GetHostEntry(ntpServer).AddressList;

            //123 é a porta padrão do NTP
            var ipEndPoint = new IPEndPoint(addresses[0], 123);

            //NTP usa UDP
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); // IPV4

            socket.Connect(ipEndPoint);

            //Caso NTP esteja bloqueado, ao menos nao trava o app
            socket.ReceiveTimeout = 3000;

            socket.Send(ntpData);
            socket.Receive(ntpData);
            socket.Close();

            //Offset para chegar no campo "Transmit Timestamp" (que é
            //o do momento da saída do servidor, em formato 64-bit timestamp
            const byte serverReplyTime = 40;

            //Pegando os segundos
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            //e a fração de segundos
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            //Passando de big-endian pra little-endian
            intPart = SwapEndianness(intPart);
            fractPart = SwapEndianness(fractPart);

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

            //Tempo em **UTC**
            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

            return networkDateTime.ToLocalTime();
        }

        // Método usado pelo "Passando de big-endian pra little-endian"
        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
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
                    coinAttr.Date = GetNetworkTime();

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

        // GET ALL api/coin/
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
        [HttpPut("{slug}/{id}")]
        public async Task<IActionResult> PutOne(string slug, int id, [FromBody] CoinModel body)
        {
            await Db.Connection.OpenAsync();
            var query = new CoinPostQuery(Db);
            var result = await query.FirstPostAsync(slug, id);
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
            result.Date = body.Date;
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE api/coin/5
        [HttpDelete("{slug}/{id}")]
        public async Task<IActionResult> DeleteOne(string slug, int id)
        {
            await Db.Connection.OpenAsync();
            var query = new CoinPostQuery(Db);
            var result = await query.FirstPostAsync(slug, id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }

        // DELETE api/coin
        [HttpDelete("{slug}/all")]
        public async Task<IActionResult> DeleteAll(string slug)
        {
            await Db.Connection.OpenAsync();
            var query = new CoinPostQuery(Db);
            await query.DeleteAllAsync(slug);
            return new OkResult();
        }

        public AppDb Db { get; }
    }
}