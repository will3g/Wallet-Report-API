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
    public class UserPostQuery
    {
        public AppDb Db { get; }

        public UserPostQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<List<UserModel>> AllPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `user`;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        public async Task<UserModel> FirstPostAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `user` WHERE `Id` = @id;";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result[0];
        }

        public async Task<List<UserModel>> LatestPostsAsync(string CPF)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `user` WHERE `CPF` = @CPF;";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@CPF",
                DbType = DbType.String,
                Value = CPF,
            });
         
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        public async Task DeleteAllAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `user`";
            await cmd.ExecuteNonQueryAsync();
        }

        private async Task<List<UserModel>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<UserModel>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new UserModel(Db)
                    {
                        Id = reader.GetInt32(0),
                        CPF = reader.GetString(1),
                        Nome = reader.GetString(2),
                        Senha = reader.GetString(3),
                        Email = reader.GetString(4),
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }

        internal Task ReadAllAsync(ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }
    }
}