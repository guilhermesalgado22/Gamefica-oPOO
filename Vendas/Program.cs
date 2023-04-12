using Vendas.Interfaces;
using Vendas.Models;
using Vendas.Services;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        IProdutoService produtoService = new ProdutoService();
        IClienteService clienteService = new ClienteService();
        IVendaService vendaService = new VendaService(clienteService, produtoService);
        ICategoriaService categoriaService = new CategoriaService();

        int opcao;
        do
        {

            Console.WriteLine("\nSistema de Vendas");
            Console.WriteLine("-----------------");
            Console.WriteLine("1 - Listar produtos");
            Console.WriteLine("2 - Realizar venda");
            Console.WriteLine("3 - Listar clientes");
            Console.WriteLine("4 - Criar produto");
            Console.WriteLine("5 - Editar produto");
            Console.WriteLine("6 - Excluir produto");
            Console.WriteLine("7 - Listar categorias");
            Console.WriteLine("8 - Criar categoria");
            Console.WriteLine("9 - Editar categoria");
            Console.WriteLine("10 - Excluir categoria");
            Console.WriteLine("0 - Sair");

            Console.Write("\nDigite uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {


                case 1:
                    Console.WriteLine("Produtos disponíveis:");
                    Console.WriteLine("---------------------");

                    List<Produto> produtos = produtoService.ObterProdutos();
                    foreach (Produto produto in produtos)
                    {
                        Console.WriteLine($"ID: {produto.Id}\n | Nome: {produto.Nome}\n | Preço: {produto.Preco}\n | Categoria: {produto.Categoria.Nome} \n| Quantidad: {produto.Quantidade}\n");
                    }
                    break;
                case 2:
                    Console.WriteLine("Realizar venda");



                    Console.WriteLine("Produtos disponíveis:");
                    Console.WriteLine("---------------------");

                    List<Produto> produtoss = produtoService.ObterProdutos();
                    foreach (Produto produto in produtoss)
                    {
                        Console.WriteLine($"ID: {produto.Id}\n | Nome: {produto.Nome}\n | Preço: {produto.Preco}\n | Categoria: {produto.Categoria.Nome} \n| Quantidade: {produto.Quantidade}\n");
                    }

                    Console.WriteLine("\nDigite o ID do produto que você gostaria de comprar:");
                    int produtoId = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nDigite a quantidade desejada:");
                    int quantidade = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nClientes disponíveis:");
                    Console.WriteLine("---------------------");

                    List<Cliente> clientes = clienteService.ObterClientes();
                    foreach (Cliente cliente in clientes)
                    {
                        Console.WriteLine($"ID: {cliente.Id} | Nome: {cliente.Nome} {cliente.Sobrenome} | Endereço: {cliente.Endereco} | Telefone: {cliente.Telefone}");
                    }

                    Console.WriteLine("\nDigite o ID do cliente que está realizando a compra:");
                    int clienteId = int.Parse(Console.ReadLine());

                    List<ProdutoVendido> produtosVendidos = new List<ProdutoVendido>
                    {
                        new ProdutoVendido
                        {
                            Produto = produtoService.ObterProdutoPorId(produtoId),
                            Quantidade = quantidade
                        }
                    };

                    Venda vendaRealizada = vendaService.RealizarVenda(clienteId, produtosVendidos);

                    // Exibir a venda realizada
                    Console.WriteLine("\nVenda realizada:");
                    Console.WriteLine("----------------");
                    Console.WriteLine($"ID: {vendaRealizada.Id} | Cliente: {vendaRealizada.Cliente.Nome} {vendaRealizada.Cliente.Sobrenome} | Data: {vendaRealizada.DataVenda} | Valor Total: {vendaRealizada.ValorTotal}");

                    Console.WriteLine("\nProdutos vendidos:");
                    Console.WriteLine("------------------");
                    foreach (ProdutoVendido produtoVendido in vendaRealizada.ProdutosVendidos)
                    {
                        Console.WriteLine($"ID: {produtoVendido.Produto.Id} | Nome: {produtoVendido.Produto.Nome} | Quantidade: {produtoVendido.Quantidade} | Preço Unitário: {produtoVendido.PrecoUnitario}");
                    }

                    break;

                case 3:
                    Console.WriteLine("Clientes disponíveis:");
                    Console.WriteLine("---------------------");

                    List<Cliente> clientess = clienteService.ObterClientes();
                    foreach (Cliente cliente in clientess)
                    {
                        Console.WriteLine($"ID: {cliente.Id} | Nome: {cliente.Nome} {cliente.Sobrenome} | Endereço: {cliente.Endereco} | Telefone: {cliente.Telefone}");
                    }
                    break;
                case 4:
                    Console.WriteLine("Criar produto");
                    Console.WriteLine("Digite o nome do produto:");
                    string nome = Console.ReadLine();

                    Console.WriteLine("Digite a descrição do produto:");
                    string descricao = Console.ReadLine();

                    Console.WriteLine("Digite o preço do produto:");
                    decimal preco = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Digite a quantidade do produto:");
                    int quantidades = int.Parse(Console.ReadLine());

                    Console.WriteLine("Escolha a categoria do produto:");

                    List<Categoria> categorias = categoriaService.ObterCategorias();

                    foreach (Categoria categoria in categorias)
                    {
                        Console.WriteLine($"{categoria.Id} - {categoria.Nome}");
                    }

                    int idCategoria = int.Parse(Console.ReadLine());

                    Categoria categoriaSelecionada = categoriaService.ObterCategoriaPorId(idCategoria);

                    Produto novoProduto = produtoService.CriarProduto(nome, descricao, preco, quantidades, categoriaSelecionada);

                    Console.WriteLine($"Produto '{novoProduto.Nome}' criado com sucesso!");
                    break;
                case 5:
                    Console.WriteLine("Editar produto");
                    Console.WriteLine("Digite o ID do produto que você deseja editar:");
                    int idEditar = int.Parse(Console.ReadLine());
                    Produto produtoEditar = produtoService.ObterProdutoPorId(idEditar);

                    if (produtoEditar != null)
                    {
                        Console.WriteLine($"Produto selecionado: {produtoEditar.Nome}");

                        Console.WriteLine("Digite o novo nome do produto:");
                        string novoNome = Console.ReadLine();

                        Console.WriteLine("Digite a nova descrição do produto:");
                        string novaDescricao = Console.ReadLine();

                        Console.WriteLine("Digite o novo preço do produto:");
                        decimal novoPreco = decimal.Parse(Console.ReadLine());

                        Console.WriteLine("Digite a nova quantidade do produto:");
                        int novaQuantidade = int.Parse(Console.ReadLine());

                        Console.WriteLine("Escolha a nova categoria do produto:");

                        List<Categoria> categoriasEditar = categoriaService.ObterCategorias();

                        foreach (Categoria categoria in categoriasEditar)
                        {
                            Console.WriteLine($"{categoria.Id} - {categoria.Nome}");
                        }

                        int idCategoriaEditar = int.Parse(Console.ReadLine());

                        Categoria categoriaSelecionadaEditar = categoriaService.ObterCategoriaPorId(idCategoriaEditar);

                        produtoService.EditarProduto(idEditar, novoNome, novaDescricao, novoPreco, novaQuantidade, categoriaSelecionadaEditar);

                        Console.WriteLine($"Produto ID {idEditar} editado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine($"Produto ID {idEditar} não encontrado.");
                    }
                    break;


                case 6:
                    Console.WriteLine("Excluir produto");
                    Console.WriteLine("Digite o ID do produto que você deseja excluir:");
                    int idExcluir = int.Parse(Console.ReadLine());
                    Produto produtoExcluir = produtoService.ObterProdutoPorId(idExcluir);

                    if (produtoExcluir != null)
                    {
                        produtoService.ExcluirProduto(idExcluir);

                        Console.WriteLine($"Produto ID {idExcluir} excluído com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine($"Produto ID {idExcluir} não encontrado.");
                    }
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;


            }

        } while (opcao != 0);
    }
}

