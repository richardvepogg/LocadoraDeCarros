using AutoMapper;
using Dados.Models;
using Negocio.Models;
using Negocio.RepositorioDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly IMapper _mapper;

        public ClienteRepositorio(IMapper mapper)
        { 
          _mapper = mapper;
        }

        public bool Editar(Cliente clienteEditado)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public bool Inserir(Cliente novoCliente)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterCliente(int id)
        {
            ClienteDataModel clienteDM = new ClienteDataModel();

            clienteDM.Email = "jose@email.com";
            clienteDM.Nome = "jose";

            return _mapper.Map<Cliente>(clienteDM);
        }

        public Cliente ObterClientePorEmail(string email)
        {
            ClienteDataModel clienteDM = new ClienteDataModel();

            clienteDM.Email = "jose@email.com";
            clienteDM.Nome = "jose";

            return _mapper.Map<Cliente>(clienteDM);
        }

        public List<Cliente> ObterListaClientes()
        {
            ClienteDataModel clienteDM = new ClienteDataModel();

            clienteDM.Email = "jose@email.com";
            clienteDM.Nome = "jose";


            List<ClienteDataModel> lstClientes = new List<ClienteDataModel>();
            lstClientes.Add(clienteDM);
            return _mapper.Map<List<Cliente>>(lstClientes);
        }
    }
}
