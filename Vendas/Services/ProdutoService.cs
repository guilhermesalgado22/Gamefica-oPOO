using System.Collections.Generic;
using Vendas.Interfaces;
using Vendas.Models;

public class ProdutoService : IProdutoService
{
    private List<Produto> _produtos;


    public ProdutoService()
    {


        _produtos = new List<Produto>
    {
        //new Produto { 
        //    Id = 1, 
        //    Nome = "Calça  Jeans ",
        //    Descricao = "Boca de sino Feminina", 
        //    Preco = 100m, Categoria= new Categoria 
        //    { Id = 1, Nome = "Calça Feminina", Descricao = "Categoria de calças femininas" }, 
        //    Quantidade = 10 },
        //new Produto { 
        //    Id = 2, 
        //    Nome = "Camiseta Batman", 
        //    Descricao = "Infantil", 
        //    Preco = 150m, Categoria = new Categoria 
        //    { Id = 1, Nome = "Infantil", Descricao = "Categoria Infantil" },
        //    Quantidade = 5 },
        //new Produto 
        //{ Id = 3, Nome = "Chinelo",
        //    Descricao = "Havaianas", 
        //    Preco = 200m, Categoria = new Categoria 
        //    { Id = 2, Nome = "Chinelo", Descricao = "Categoria de Chinelos Unisex" }, 
        //    Quantidade = 8 }
    };
    }

    public Produto CriarProduto(string nome, string descricao, decimal preco, int quantidade, Categoria categoria)
    {
        Produto novoProduto = new Produto
        {
            Id = _produtos.Count,
            Nome = nome,
            Descricao = descricao,
            Preco = preco,
            Quantidade = quantidade,
            Categoria = categoria
        };

        _produtos.Add(novoProduto);
        return novoProduto;
    }

    public List<Produto> ObterProdutos()
    {
        return _produtos;
    }

    public Produto ObterProdutoPorId(int id)
    {
        return _produtos.Find(produto => produto.Id == id);
    }

    public void AtualizarQuantidade(int id, int novaQuantidade)
    {
        Produto produto = ObterProdutoPorId(id);
        if (produto != null)
        {
            produto.Quantidade = novaQuantidade;
        }
        else
        {
            throw new ArgumentException($"Produto ID {id} não encontrado.");
        }
    }
    public void EditarProduto(int id, string novoNome, string novaDescricao, decimal novoPreco, int novaQuantidade, Categoria novaCategoria)
    {
        Produto produto = ObterProdutoPorId(id);
        if (produto != null)
        {
            produto.Nome = novoNome;
            produto.Descricao = novaDescricao;
            produto.Preco = novoPreco;
            produto.Quantidade = novaQuantidade;
            produto.Categoria = novaCategoria;
        }
        else
        {
            throw new ArgumentException($"Produto ID {id} não encontrado.");
        }
    }
    public void ExcluirProduto(int id)
    {
        Produto produto = ObterProdutoPorId(id);
        if (produto != null)
        {
            _produtos.Remove(produto);
        }
        else
        {
            throw new ArgumentException($"Produto ID {id} não encontrado.");
        }
    }
}
