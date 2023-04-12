using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Models;

namespace Vendas.Interfaces
{
    public interface IProdutoService
    {
        List<Produto> ObterProdutos();
        Produto ObterProdutoPorId(int id);
        public void AtualizarQuantidade(int id, int novaQuantidade);
        public Produto CriarProduto(string nome, string descricao, decimal preco, int quantidade, Categoria categoria);
        void EditarProduto(int id, string novoNome, string novaDescricao, decimal novoPreco, int novaQuantidade, Categoria novaCategoria);
        void ExcluirProduto(int id);
    }


}
