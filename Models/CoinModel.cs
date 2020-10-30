using System;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;
using Newtonsoft.Json;

namespace WebApplication2
{
    public class CoinModel
    {
        public int Id { get; set; }

        public string Slug { get; set; }

        [JsonProperty("market")]
        public string Market { get; set; }

        [JsonProperty("last")]
        public double Last { get; set; }

        [JsonProperty("percentChange")]
        public double PercentChange { get; set; }

        [JsonProperty("baseVolume24")]
        public double BaseVolume24 { get; set; }

        [JsonProperty("quoteVolume24")]
        public double QuoteVolume24 { get; set; }

        [JsonProperty("baseVolume")]
        public double BaseVolume { get; set; }

        [JsonProperty("quoteVolume")]
        public double QuoteVolume { get; set; }

        [JsonProperty("highestBid24")]
        public double HighestBid24 { get; set; }

        [JsonProperty("lowestAsk24")]
        public double LowestAsk24 { get; set; }

        [JsonProperty("highestBid")]
        public double Hwap { get; set; }

        [JsonProperty("lowestAsk")]
        public double LowestAsk { get; set; }

        public DateTime Date { get; set; }

        internal AppDb Db { get; set; }

        public CoinModel()
        {
        }

        internal CoinModel(AppDb db)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = "INSERT INTO coin_db." + @Slug.ToString() + @" (`Slug`, `Market`, `Last`, `PercentChange`, `BaseVolume24`, `QuoteVolume24`, `BaseVolume`, `QuoteVolume`, `HighestBid24`, `LowestAsk24`, `Hwap`, `LowestAsk`, `Date`) VALUES (@Slug, @Market, @Last, @PercentChange, @BaseVolume24, @QuoteVolume24, @BaseVolume, @QuoteVolume, @HighestBid24, @LowestAsk24, @Hwap, @LowestAsk, @Date);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = "UPDATE coin_db." + @Slug.ToString() + @" SET `Slug` = @Slug, `Market` = @Market, `Last` = @Last, `PercentChange` = @PercentChange, `BaseVolume24` = @BaseVolume24, `QuoteVolume24` = @QuoteVolume24, `BaseVolume` = @BaseVolume, `QuoteVolume` = @QuoteVolume, `HighestBid24` = @HighestBid24, `LowestAsk24` = @LowestAsk24, `Hwap` = @Hwap, `LowestAsk` = @LowestAsk, `Date` = @Date WHERE `Id` = @id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = "DELETE FROM coin_db." + @Slug.ToString() + @" WHERE `Id` = @id;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = Id,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Slug",
                DbType = DbType.String,
                Value = Slug,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Market",
                DbType = DbType.String,
                Value = Market,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Last",
                DbType = DbType.Double,
                Value = Last,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@PercentChange",
                DbType = DbType.Double,
                Value = PercentChange,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@BaseVolume24",
                DbType = DbType.Double,
                Value = BaseVolume24,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@QuoteVolume24",
                DbType = DbType.Double,
                Value = QuoteVolume24,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@BaseVolume",
                DbType = DbType.Double,
                Value = BaseVolume,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@QuoteVolume",
                DbType = DbType.Double,
                Value = QuoteVolume,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@HighestBid24",
                DbType = DbType.Double,
                Value = HighestBid24,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@LowestAsk24",
                DbType = DbType.Double,
                Value = LowestAsk24,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Hwap",
                DbType = DbType.Double,
                Value = Hwap,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@LowestAsk",
                DbType = DbType.Double,
                Value = LowestAsk,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Date",
                DbType = DbType.DateTime,
                Value = Date,
            });
        }
    }
}