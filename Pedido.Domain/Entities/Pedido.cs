namespace Pedido.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public string NomeSolicitante { get; set; }
        public int Mesa { get; set; }
        public string Status { get; set; } = "Em preparo";
        public List<PedidoItem> Itens { get; set; }
    }

    public class PedidoItem
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
