using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedido.Domain.Entity;
using Pedido.Repository.Context;

namespace Pedido.Repository
{
    public class PedidoRepository
    {
        private readonly DbContext _context;
        public PedidoRepository()
        {
            _context = new DbContext();
        }

        public int CriarPedido(Pedidos pedido)
        {
            int pedidoId;

            using(var conexao = _context.ObterConexao())
            {
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Pedidos (NomeCliente, Mesa, Status) VALUES (@NomeCliente, @Mesa, @Status); SELECT LAST_INSERT_ID();";
                    cmd.Parameters.AddWithValue("@NomeCliente", pedido.NomeCliente);
                    cmd.Parameters.AddWithValue("@Mesa", pedido.Mesa);
                    cmd.Parameters.AddWithValue("@Status", pedido.Status);
                    pedidoId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                foreach (var item in pedido.Itens)
                {
                    using (var cmd = conexao.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO PedidoItem (PedidoId, ProdutoId, Quantidade) VALUES (@PedidoId, @ProdutoId, @Quantidade)";
                        cmd.Parameters.AddWithValue("@PedidoId", pedidoId);
                        cmd.Parameters.AddWithValue("@ProdutoId", item.ProdutoId);
                        cmd.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            return pedidoId;
        }


        public void AtualizarStatusPedido(int pedidoId, string status)
        {
            using (var conexao = _context.ObterConexao())
            {
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Pedidos SET Status = @Status WHERE id = @PedidoId";
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@PedidoId", pedidoId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
