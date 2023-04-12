using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Models;

namespace Vendas.Interfaces
{
    public interface ICategoriaService
    {
        Categoria CriarCategoria(int id, string nome, string descricao);
        Categoria EditarCategoria(int id, string nome, string descricao);
        bool ExcluirCategoria(int id);
        List<Categoria> ObterCategorias();
        Categoria ObterCategoriaPorId(int id);
    }

}
