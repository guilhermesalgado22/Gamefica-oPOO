using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<ProdutoVendido> ProdutosVendidos { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }
    }

    public class ProdutoVendido
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }

}
