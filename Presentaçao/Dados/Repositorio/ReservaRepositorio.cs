using AutoMapper;
using Dados.Contexts;
using Dados.Models;
using Negocio;
using Negocio.RepositorioDados;

namespace Dados.Repositorio
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        private readonly IMapper _mapper;
        private readonly LocadoraDbContext _dbContext;

        public ReservaRepositorio(IMapper mapper, LocadoraDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public bool Editar(Reserva ReservaEditado)
        {
            try
            {
                var reservaUpdate = _dbContext.Cliente.FirstOrDefault(x => x.Id == ReservaEditado.Id);
                _mapper.Map(ReservaEditado, reservaUpdate);
                _dbContext.Cliente.Update(reservaUpdate);
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
                var reservaExcluir = _dbContext.Cliente.FirstOrDefault(reserva => reserva.Id == id);
                _dbContext.Cliente.Remove(reservaExcluir);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Inserir(Reserva novaReserva)
        {
            try
            {
                _dbContext.Reserva.Add(_mapper.Map<ReservaDataModel>(novaReserva));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Reserva ObterCarroID(int id)
        {
            ReservaDataModel reservaDM = _dbContext.Reserva.FirstOrDefault(x => x.CarroId == id);

            return _mapper.Map<Reserva>(reservaDM);
        }

        public Reserva ObterClienteID(int id)
        {
            ReservaDataModel reservaDM = _dbContext.Reserva.FirstOrDefault(x => x.ClienteId == id);

            return _mapper.Map<Reserva>(reservaDM);

        }

        public List<Reserva> ObterListaResereva()
        {
            List<ReservaDataModel> lstReserva = _dbContext.Reserva.ToList();

            return _mapper.Map<List<Reserva>>(lstReserva);
        }

    }
}
