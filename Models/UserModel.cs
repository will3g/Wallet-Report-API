using System.Data;
using System.Threading.Tasks;
using MySqlConnector;

namespace WebApplication2
{
    public class UserModel
    {
        public int Id { get; set; }

        public string CPF { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        public bool Admin { get; set; }

        internal AppDb Db { get; set; }

        public UserModel()
        {
        }

        internal UserModel(AppDb db)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = "INSERT INTO user_db.user (`CPF`, `Nome`, `Senha`, `Email`, `Admin`) VALUES (@CPF, @Nome, @Senha, @Email, @Admin);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = "UPDATE user_db.user SET `CPF` = @CPF, `Nome` = @Nome, `Senha` = @Senha, `Email` = @Email, `Admin` = @Admin WHERE `Id` = @id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = "DELETE FROM user_db.user WHERE `CPF` = @CPF;";
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
                ParameterName = "@CPF",
                DbType = DbType.String,
                Value = CPF,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Nome",
                DbType = DbType.String,
                Value = Nome,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Senha",
                DbType = DbType.String,
                Value = Senha,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Email",
                DbType = DbType.String,
                Value = Email,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Admin",
                DbType = DbType.Boolean,
                Value = Admin,
            });
        }
    }
} 