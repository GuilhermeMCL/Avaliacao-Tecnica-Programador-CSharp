using Pedido.Domain.Entities;
using Pedido.Repository;

namespace Pedido.Service
{
    public class PedidoService
    {
        private readonly PedidoRepository _repo;

        public PedidoService()
        {
            _repo = new PedidoRepository();
        }

        public int CriarPedido(Pedido.Domain.Entities.Pedido pedido)
        {
            if (pedido.Itens == null || !pedido.Itens.Any())
                throw new Exception("O pedido precisa ter pelo menos 1 item.");

            return _repo.CriarPedido(pedido);
        }

        public void AtualizarStatus(int pedidoId, string novoStatus)
        {
            var statusPermitidos = new List<string> { "Em preparo", "Pronto", "Entregue" };

            if (!statusPermitidos.Contains(novoStatus))
                throw new Exception("Status inválido.");

            _repo.AtualizarStatus(pedidoId, novoStatus);
        }
    }
}
