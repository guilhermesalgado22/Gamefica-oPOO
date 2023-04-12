using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Vendas.Interfaces;
    using Vendas.Models;

    public class CategoriaService : ICategoriaService
    {
        private List<Categoria> _categorias;

        public CategoriaService()
        {
            _categorias = new List<Categoria>();
        }

        public Categoria CriarCategoria(int id, string nome, string descricao)
        {
            Categoria novaCategoria = new Categoria
            {
                Id = _categorias.Count + 1,
                Nome = nome,
                Descricao = descricao
            };

            _categorias.Add(novaCategoria);
            return novaCategoria;
        }

        public Categoria EditarCategoria(int id, string nome, string descricao)
        {
            Categoria categoria = ObterCategoriaPorId(id);
            if (categoria != null)
            {
                categoria.Nome = nome;
                categoria.Descricao = descricao;
                return categoria;
            }
            else
            {
                throw new ArgumentException($"Categoria ID {id} não encontrada.");
            }
        }

        public bool ExcluirCategoria(int id)
        {
            Categoria categoria = ObterCategoriaPorId(id);
            if (categoria != null)
            {
                _categorias.Remove(categoria);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Categoria> ObterCategorias()
        {
            return _categorias;
        }

        public Categoria ObterCategoriaPorId(int id)
        {
            return _categorias.FirstOrDefault(c => c.Id == id);
        }
    }

}
