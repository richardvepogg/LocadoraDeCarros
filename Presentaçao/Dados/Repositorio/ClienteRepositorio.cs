﻿using AutoMapper;
using Dados.Contexts;
using Dados.Models;
using Negocio.Models;
using Negocio.RepositorioDados;

namespace Dados.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly IMapper _mapper;
        private readonly LocadoraDbContext _dbContext;

        public ClienteRepositorio(IMapper mapper, LocadoraDbContext dbContext)
        { 
          _mapper = mapper;
            _dbContext = dbContext;
        }

        public bool Editar(Cliente clienteEditado)
        {
            try
            {
                var clienteUpdate = _dbContext.Cliente.FirstOrDefault(cliente => cliente.Id == clienteEditado.Id);
                _mapper.Map(clienteEditado, clienteUpdate);
                _dbContext.Cliente.Update(clienteUpdate);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool Excluir(int id)
        {
            try
            {
                var clienteExcluir = _dbContext.Cliente.FirstOrDefault(cliente => cliente.Id == id);
                _dbContext.Cliente.Remove(clienteExcluir);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Inserir(Cliente novoCliente)
        {
            try
            {
                _dbContext.Cliente.Add(_mapper.Map<ClienteDataModel>(novoCliente));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Cliente ObterCliente(int id)
        {
            ClienteDataModel clienteDM = _dbContext.Cliente.FirstOrDefault(x => x.Id == id);

            return _mapper.Map<Cliente>(clienteDM);
        }

        public Cliente ObterClientePorEmail(string email)
        {
            ClienteDataModel clienteDM = _dbContext.Cliente.FirstOrDefault(x => x.Email == email);

            return _mapper.Map<Cliente>(clienteDM);
        }

        public List<Cliente> ObterListaClientes()
        {
            List<ClienteDataModel> lstClientes = _dbContext.Cliente.ToList();

            return _mapper.Map<List<Cliente>>(lstClientes);
        }

        public Cliente ObterClienteNome(string nome)
        {
            ClienteDataModel clienteDM = _dbContext.Cliente.FirstOrDefault(x => x.Nome == nome);

            return _mapper.Map<Cliente>(clienteDM);
        }

        public Cliente ObterClienteCarteiraMotorista(string carteiraMotorista)
        {
            ClienteDataModel clienteDM = _dbContext.Cliente.FirstOrDefault(x => x.CarteiraDeMotorista == carteiraMotorista);

            return _mapper.Map<Cliente>(clienteDM);
        }
    }
}
