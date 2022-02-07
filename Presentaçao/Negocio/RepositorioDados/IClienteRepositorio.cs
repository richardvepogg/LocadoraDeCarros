using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.RepositorioDados
{
    public interface IClienteRepositorio
    {
        Cliente ObterCliente(int id);
        Cliente ObterClientePorEmail(string email);
        List<Cliente> ObterListaClientes();
        bool Editar(Cliente clienteEditado);
        bool Inserir(Cliente novoCliente);
        bool Excluir(int id);
    }
}
