using MySql.Data.MySqlClient;

namespace Pedido.Repository.Context
{
    public class DbContext
    {
        private readonly string _connectionString;

        public DbContext()
        {
            _connectionString = "Server=localhost;Port=3306;Database=pedidosdb;Uid=root;Pwd=root;";
        }

        public MySqlConnection CriarConexao()
        {
            var conn = new MySqlConnection(_connectionString);
            conn.Open();
            return conn;
        }
    }
}
