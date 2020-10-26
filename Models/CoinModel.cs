using System;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;

namespace WebApplication2
{
    public class CoinModel
    {
        public int Id { get; set; }

        public string Slug { get; set; }

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
            cmd.CommandText = "INSERT INTO coin_db." + @Slug.ToString() + @" (`Slug`, `Last`, `Max`, `Min`, `Buy`, `Sell`, `Open`, `Vol`, `Trade`, `Trades`, `Vwap`, `Money`, `Date`) VALUES (@Slug, @Last, @Max, @Min, @Buy, @Sell, @Open, @Vol, @Trade, @Trades, @Vwap, @Money, @Date);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = "UPDATE coin_db." + @Slug.ToString() + @" SET `Slug` = @Slug, `Last` = @Last, `Max` = @Max, `Min` = @Min, `Buy` = @Buy, `Sell` = @Sell, `Open` = @Open, `Vol` = @Vol, `Trade` = @Trade, `Trades` = @Trades, `Vwap` = @Vwap, `Money` = @Money, `Date` = @Date WHERE `Id` = @id;";
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
                ParameterName = "@Last",
                DbType = DbType.Double,
                Value = Last,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Max",
                DbType = DbType.Double,
                Value = Max,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Min",
                DbType = DbType.Double,
                Value = Min,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Buy",
                DbType = DbType.Double,
                Value = Buy,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Sell",
                DbType = DbType.Double,
                Value = Sell,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Open",
                DbType = DbType.Double,
                Value = Open,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Vol",
                DbType = DbType.Double,
                Value = Vol,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Trade",
                DbType = DbType.Double,
                Value = Trade,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Trades",
                DbType = DbType.Int32,
                Value = Trades,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Vwap",
                DbType = DbType.Double,
                Value = Vwap,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Money",
                DbType = DbType.Double,
                Value = Money,
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