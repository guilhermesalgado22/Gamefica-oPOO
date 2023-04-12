using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Models;

namespace Vendas.Interfaces
{
    public interface IClienteService
    {
        List<Cliente> ObterClientes();
        Cliente ObterClientePorId(int id);
    }

}
