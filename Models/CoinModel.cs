using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CoinModel
    {
        [JsonProperty("last")]
        public double Last { get; set; }

        [JsonProperty("max")]
        public double Max { get; set; }

        [JsonProperty("min")]
        public double Min { get; set; }

        [JsonProperty("buy")]
        public double Buy { get; set; }

        [JsonProperty("sell")]
        public double Sell { get; set; }

        [JsonProperty("open")]
        public double Open { get; set; }

        [JsonProperty("vol")]
        public double Vol { get; set; }

        [JsonProperty("trade")]
        public double Trade { get; set; }

        [JsonProperty("trades")]
        public int Trades { get; set; }

        [JsonProperty("vwap")]
        public double Vwap { get; set; }

        [JsonProperty("money")]
        public double Money { get; set; }
    }
}
