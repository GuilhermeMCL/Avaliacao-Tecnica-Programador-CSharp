using Pedido.Domain.Entities;
using Pedido.Repository.Context;
using MySql.Data.MySqlClient;

namespace Pedido.Repository
{
    public class PedidoRepository
    {
        private readonly DbContext _context;

        public PedidoRepository()
        {
            _context = new DbContext();
        }

        public int CriarPedido(Pedido.Domain.Entities.Pedido pedido)
        {
            int pedidoId;

            using (var conn = _context.CriarConexao())
            {
                var cmd = new MySqlCommand("INSERT INTO pedidos (nome_solicitante, mesa, status) VALUES (@nome, @mesa, @status); SELECT LAST_INSERT_ID();", conn);
                cmd.Parameters.AddWithValue("@nome", pedido.NomeSolicitante);
                cmd.Parameters.AddWithValue("@mesa", pedido.Mesa);
                cmd.Parameters.AddWithValue("@status", pedido.Status);
                pedidoId = Convert.ToInt32(cmd.ExecuteScalar());

                foreach (var item in pedido.Itens)
                {
                    var cmdItem = new MySqlCommand("INSERT INTO pedido_itens (pedido_id, produto_id, quantidade) VALUES (@pedidoId, @produtoId, @qtd)", conn);
                    cmdItem.Parameters.AddWithValue("@pedidoId", pedidoId);
                    cmdItem.Parameters.AddWithValue("@produtoId", item.ProdutoId);
                    cmdItem.Parameters.AddWithValue("@qtd", item.Quantidade);
                    cmdItem.ExecuteNonQuery();
                }
            }

            return pedidoId;
        }

        public void AtualizarStatus(int pedidoId, string novoStatus)
        {
            using (var conn = _context.CriarConexao())
            {
                var cmd = new MySqlCommand("UPDATE pedidos SET status = @status WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@status", novoStatus);
                cmd.Parameters.AddWithValue("@id", pedidoId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
