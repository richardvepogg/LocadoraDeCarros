using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ServiçoNegocio.Base
{
    public interface IClienteServico
    {
        Cliente ObterClienteEmail(string email);
        Cliente ObterClienteNome(string nome);
        Cliente ObterClienteCarteiraMotorista(string carteiraMotorista);
        Cliente ObterClientePorID(int id);
        List<Cliente> ObterListaClientes();
        bool Editar(Cliente clienteEditado);
        bool Inserir(Cliente novoCliente);
        bool Excluir(int id);

    }
}
