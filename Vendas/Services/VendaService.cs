using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Services
{
    using System;
    using System.Collections.Generic;
    using Vendas.Interfaces;
    using Vendas.Models;

    public class VendaService : IVendaService
    {
        private List<Venda> _vendas;
        private IClienteService _clienteService;
        private IProdutoService _produtoService;

        public VendaService(IClienteService clienteService, IProdutoService produtoService)
        {
            _vendas = new List<Venda>();
            _clienteService = clienteService;
            _produtoService = produtoService;
        }

        public Venda RealizarVenda(int clienteId, List<ProdutoVendido> produtosVendidos)
        {
            Cliente cliente = _clienteService.ObterClientePorId(clienteId);

            if (cliente == null)
            {
                throw new ArgumentException("Cliente não encontrado.");
            }

            decimal valorTotal = 0m;
            foreach (var produtoVendido in produtosVendidos)
            {
                Produto produto = _produtoService.ObterProdutoPorId(produtoVendido.Produto.Id);

                if (produto == null)
                {
                    throw new ArgumentException($"Produto ID {produtoVendido.Produto.Id} não encontrado.");
                }

                if (produto.Quantidade < produtoVendido.Quantidade)
                {
                    throw new ArgumentException($"Quantidade insuficiente do produto ID {produtoVendido.Produto.Id}. Disponível: {produto.Quantidade}");
                }

                produtoVendido.PrecoUnitario = produto.Preco;
                valorTotal += produtoVendido.PrecoUnitario * produtoVendido.Quantidade;

                // Atualize a quantidade disponível do produto
                _produtoService.AtualizarQuantidade(produto.Id, produto.Quantidade - produtoVendido.Quantidade);
            }

            Venda novaVenda = new Venda
            {
                Id = _vendas.Count + 1,
                Cliente = cliente,
                ProdutosVendidos = produtosVendidos,
                DataVenda = DateTime.Now,
                ValorTotal = valorTotal
            };

            _vendas.Add(novaVenda);
            return novaVenda;
        }
    }

}
