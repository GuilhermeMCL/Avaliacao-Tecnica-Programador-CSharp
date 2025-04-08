using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedido.Domain.Entity
{
    public  class Pedido
    {
        public int id { get; set; }
        public string NomeCliente { get; set; }
        public int Mesa { get; set; }
        public string Status { get; set; } = "EM PREPARO";
        public List<PedidoItem> Itens { get; set; } 
    }

    public class PedidoItem
    {
        public int ProdutoId { get; set; }
        public string Quantidade { get; set; }
    }
}
