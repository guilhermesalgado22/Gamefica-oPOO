using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Services
{
    using System.Collections.Generic;
    using Vendas.Interfaces;
    using Vendas.Models;

    public class ClienteService : IClienteService
    {
        private List<Cliente> _clientes;

        public ClienteService()
        {
            _clientes = new List<Cliente>
        {
            new Cliente
            {
                Id = 1,
                Nome = "João",
                Sobrenome = "Silva",
                Endereco = "Rua das Flores, 123",
                Telefone = "+55 (11) 91234-5678"
            },
            new Cliente
            {
                Id = 2,
                Nome = "Maria",
                Sobrenome = "Pereira",
                Endereco = "Avenida das Orquídeas, 456",
                Telefone = "+55 (11) 92345-6789"
            }
        };
        }

        public List<Cliente> ObterClientes()
        {
            return _clientes;
        }
        public Cliente ObterClientePorId(int id)
        {
            return _clientes.Find(cliente => cliente.Id == id);
        }
    }

}
