using AutoMapper;
using Dados.Contexts;
using Dados.Models;
using Negocio;
using Negocio.RepositorioDados;

namespace Dados.Repositorio
{
    public class AluguelRepositorio : IAluguelRepositorio
    {
        private readonly IMapper _mapper;
        private readonly LocadoraDbContext _dbContext;

        public AluguelRepositorio(IMapper mapper, LocadoraDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public bool Editar(Aluguel aluguelEditado)
        {
            try
            {
                var aluguelUpdate = _dbContext.Cliente.FirstOrDefault(x => x.Id == aluguelEditado.Id);
                _mapper.Map(aluguelEditado, aluguelUpdate);
                _dbContext.Cliente.Update(aluguelUpdate);
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
                var aluguelExcluir = _dbContext.Cliente.FirstOrDefault(aluguel => aluguel.Id == id);
                _dbContext.Cliente.Remove(aluguelExcluir);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Inserir(Aluguel novoAluguel)
        {
            try
            {
                _dbContext.Aluguel.Add(_mapper.Map<AluguelDataModel>(novoAluguel));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Aluguel ObterAluguelIDCarro(int id)
        {
           AluguelDataModel aluguelDM = _dbContext.Aluguel.FirstOrDefault(x => x.CarroId == id);

            return _mapper.Map<Aluguel>(aluguelDM);
        }

        public Aluguel ObterAluguelIDCliente(int id)
        {
            AluguelDataModel aluguelDM = _dbContext.Aluguel.FirstOrDefault(x => x.ClienteId == id);

            return _mapper.Map<Aluguel>(aluguelDM);
        }

        public List<Aluguel> ObterListaAluguel()
        {
            List<AluguelDataModel> lstAluguel = _dbContext.Aluguel.ToList();

            return _mapper.Map<List<Aluguel>>(lstAluguel);
        }
    }
}

