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
                    string nomess = Console.ReadLine();

                    Console.WriteLine("Digite a descrição do produto:");
                    string descricaoss = Console.ReadLine();

                    Console.WriteLine("Digite o preço do produto:");
                    decimal precoss = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Digite a quantidade do produto:");
                    int quantidadesss = int.Parse(Console.ReadLine());

                    Console.WriteLine("Escolha a categoria do produto:");

                    List<Categoria> categoriassss = categoriaService.ObterCategorias();

                    foreach (Categoria categoria in categoriassss)
                    {
                        Console.WriteLine($"{categoria.Id} - {categoria.Nome}");
                    }

                    int idCategoriass = int.Parse(Console.ReadLine());

                    Categoria categoriaSelecionadass = categoriaService.ObterCategoriaPorId(idCategoriass);

                    if (categoriaSelecionadass == null)
                    {
                        Console.WriteLine($"Categoria com ID {idCategoriass} não encontrada. Criando nova categoria...");
                        Console.WriteLine("Digite o nome da nova categoria:");
                        string nomeCategoriass = Console.ReadLine();

                        Console.WriteLine("Digite a descrição da nova categoria:");
                        string descricaoCategoriass = Console.ReadLine();

                        Categoria categoriaSelecionada = categoriaService.CriarCategoria(idCategoriass, nomeCategoriass, descricaoCategoriass);
                    }

                    Console.WriteLine("Digite a quantidade do produto:");
                    int quantidadessss = int.Parse(Console.ReadLine());

                    Produto novoProdutoss = produtoService.CriarProduto(nomess, descricaoss, precoss, quantidadessss, categoriaSelecionadass);

                    Console.WriteLine($"Produto '{novoProdutoss.Nome}' criado com sucesso!");
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

                case 7:
                    Console.WriteLine("Categorias disponíveis:");
                    Console.WriteLine("----------------------");

                    List<Categoria> categoriasss = categoriaService.ObterCategorias();
                    foreach (Categoria categoria in categoriasss)
                    {
                        Console.WriteLine($"ID: {categoria.Id} | Nome: {categoria.Nome} | Descrição: {categoria.Descricao}");
                    }
                    break;

               
                case 8:
                    Console.WriteLine("Criar categoria");

                    Console.WriteLine("Digite o ID da categoria:");
                    int idCategorias = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o nome da categoria:");
                    string nomeCategoria = Console.ReadLine();

                    Console.WriteLine("Digite a descrição da categoria:");
                    string descricaoCategoria = Console.ReadLine();

                    Categoria novaCategoria = categoriaService.CriarCategoria(idCategorias, nomeCategoria, descricaoCategoria);

                    Console.WriteLine($"Categoria '{novaCategoria.Nome}' criada com sucesso!");

                    break;

                case 9:
                    Console.WriteLine("Editar categoria");
                    Console.WriteLine("Digite o ID da categoria que você deseja editar:");
                    int idEditarCategoria = int.Parse(Console.ReadLine());
                    Categoria categoriaEditar = categoriaService.ObterCategoriaPorId(idEditarCategoria);

                    if (categoriaEditar != null)
                    {
                        Console.WriteLine($"Categoria selecionada: {categoriaEditar.Nome}");

                        Console.WriteLine("Digite o novo nome da categoria:");
                        string novoNomeCategoria = Console.ReadLine();

                        Console.WriteLine("Digite a nova descrição da categoria:");
                        string novaDescricaoCategoria = Console.ReadLine();

                        categoriaService.EditarCategoria(idEditarCategoria, novoNomeCategoria, novaDescricaoCategoria);

                        Console.WriteLine($"Categoria ID {idEditarCategoria} editada com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine($"Categoria ID {idEditarCategoria} não encontrada.");
                    }
                    break;

                case 10:
                    Console.WriteLine("Excluir categoria");
                    Console.WriteLine("Digite o ID da categoria que você deseja excluir:");
                    int idExcluirCategoria = int.Parse(Console.ReadLine());
                    Categoria categoriaExcluir = categoriaService.ObterCategoriaPorId(idExcluirCategoria);

                    if (categoriaExcluir != null)
                    {
                        categoriaService.ExcluirCategoria(idExcluirCategoria);

                        Console.WriteLine($"Categoria ID {idExcluirCategoria} excluída com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine($"Categoria ID {idExcluirCategoria} não encontrada.");
                    }
                    break;

     
                   

            }

        } while (opcao != 0);
    }
}

