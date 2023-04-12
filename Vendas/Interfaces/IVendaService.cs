using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Models;

namespace Vendas.Interfaces
{
    public interface IVendaService
    {
        Venda RealizarVenda(int clienteId, List<ProdutoVendido> produtosVendidos);
    }

}
