using System.Data;
using System.Threading.Tasks;
using MySqlConnector;
using Newtonsoft.Json;

namespace WebApplication2
{
    public class AdminModel
    {
        public string NomeDB { get; set; }
        public string NomeTable { get; set; }

        internal AppDb Db { get; set; }

        public AdminModel()
        {
        }

        internal AdminModel(AppDb db)
        {
            Db = db;
        }

        public async Task InsertDBAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CREATE DATABASE " + NomeDB + ";";
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task InsertTableAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"USE " + NomeDB + "; CREATE TABLE " + NomeTable + "(" +
                                                    "id int(4) AUTO_INCREMENT," +
                                                    "CPF varchar(20) NOT NULL," +
                                                    "Nome varchar(30) NOT NULL," +
                                                    "Senha varchar(20) NOT NULL,"+
                                                    "Email varchar(50) NOT NULL," +
                                                    "Admin boolean," +
                                                    "PRIMARY KEY(id)" +
                                                    ");";
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task InsertCoinAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"USE " + NomeDB + "; CREATE TABLE " + NomeTable + "(" +
                                                    "id int NOT NULL AUTO_INCREMENT,"+
                                                    "Slug varchar(30) DEFAULT NULL," +
                                                    "Market varchar(30) DEFAULT NULL," +
                                                    "Last float DEFAULT NULL," +
                                                    "PercentChange float DEFAULT NULL," +
                                                    "BaseVolume24 float DEFAULT NULL," +
                                                    "QuoteVolume24 float DEFAULT NULL," +
                                                    "BaseVolume float DEFAULT NULL," +
                                                    "QuoteVolume float DEFAULT NULL," +
                                                    "HighestBid24 float DEFAULT NULL," +
                                                    "LowestAsk24 float DEFAULT NULL," +
                                                    "Hwap float DEFAULT NULL," +
                                                    "LowestAsk float DEFAULT NULL," +
                                                    "Date datetime," +
                                                    "PRIMARY KEY(id)" +
                                                    ");";
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteDBAsync(string NomeDB)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DROP DATABASE " + NomeDB + ";";
            await cmd.ExecuteNonQueryAsync();
        }
        public async Task DeleteTableAsync(string NomeDB, string NomeTable)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"USE " + NomeDB + "; DROP TABLE " + NomeTable + ";";
            await cmd.ExecuteNonQueryAsync();
        }
    }
}