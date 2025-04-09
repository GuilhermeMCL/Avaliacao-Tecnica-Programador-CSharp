namespace Pedido.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; } 
        public decimal Preco { get; set; }
    }
}
