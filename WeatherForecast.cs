using System;
using Newtonsoft.Json;

namespace WebApplication1
{
    public class WeatherForecast
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
