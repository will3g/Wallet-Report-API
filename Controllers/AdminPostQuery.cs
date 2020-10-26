using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MySqlConnector;

namespace WebApplication2
{
    public class AdminPostQuery
    {
        public AppDb Db { get; }

        public AdminPostQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<List<AdminModel>> AllDBAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"show databases;";
            return await ReadAllDBAsync(await cmd.ExecuteReaderAsync());
        }

        public async Task<List<AdminModel>> AllTableAsync(string NomeDB)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"USE " + NomeDB + "; show tables;";
            return await ReadAllTableAsync(NomeDB, await cmd.ExecuteReaderAsync());
        }

        public async Task<List<AdminModel>> FirstPostTableAsync(string NomeDB, string NomeTable, string NewNomeTable)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"USE " + NomeDB + "; RENAME TABLE " + NomeTable + " TO " + NewNomeTable + ";";
            return await ReadAllTableAsync(NomeDB, await cmd.ExecuteReaderAsync());
        }

        private async Task<List<AdminModel>> ReadAllDBAsync(DbDataReader reader)
        {
            var posts = new List<AdminModel>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new AdminModel(Db)
                    {
                        NomeDB = reader.GetString(0),
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }

        private async Task<List<AdminModel>> ReadAllTableAsync(string NomeDB, DbDataReader reader)
        {
            var get = new List<AdminModel>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var adminModel = new AdminModel(Db)
                    {
                        NomeDB = NomeDB,
                        NomeTable = reader.GetString(0),
                    };
                    get.Add(adminModel);
                }
            }
            return get;
        }

        internal Task ReadAllDBAsync(ClaimsPrincipal admin)
        {
            throw new NotImplementedException();
        }
        internal Task ReadAllTableAsync(ClaimsPrincipal admin)
        {
            throw new NotImplementedException();
        }
    }
}