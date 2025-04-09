using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Pedido.Repository.Context
{
    public class DbContext
    {

        private readonly string _conn;
        public DbContext()
        {
            _conn = "Server=localhost;Port=3306;Database=pedidosdb;Uid=root;Pwd=root;" ;
        }

        public MySqlConnection ObterConexao()
        {
            var conexao = new MySqlConnection(_conn);
            conexao.Open();
            return conexao;
        }


    }
}
