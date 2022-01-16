using Negocio.Models;
using Negocio.RepositorioDados;
using Negocio.ServiçoNegocio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ServiçoNegocio
{
    public class ClienteServico : IClienteServico
    {
        public readonly IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public Cliente ObterClienteEmail(string email)
        {
            return _clienteRepositorio.ObterClientePorEmail(email);
        }

        public Cliente ObterClientePorID(int id)
        {
            return _clienteRepositorio.ObterCliente(id);
        }

        public List<Cliente> ObterListaClientes()
        {
          return _clienteRepositorio.ObterListaClientes();
        }

    public bool Editar(Cliente clienteEditado)
    {
        return _clienteRepositorio.Editar(clienteEditado);
    }

    public bool Inserir(Cliente novoCliente)
    {
        return _clienteRepositorio.Inserir(novoCliente);
    }

    public bool Excluir(int id)
    {
        return _clienteRepositorio.Excluir(id);
    }

}
}
