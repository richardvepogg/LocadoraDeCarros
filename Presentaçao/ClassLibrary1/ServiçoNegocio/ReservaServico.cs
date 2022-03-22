using Negocio.ServiçoNegocio.Base;
using Negocio.Models;
using Negocio.RepositorioDados;

namespace Negocio.ServiçoNegocio
{
    public class ReservaServico : IReservaServico
    {
        public readonly IReservaRepositorio _reservaRepositorio;

        public ReservaServico(IReservaRepositorio reservaRepositorio)
        {
            _reservaRepositorio = reservaRepositorio;
        }


        public bool Editar(Reserva reservaEditada)
        {
            return _reservaRepositorio.Editar(reservaEditada);
        }

        public bool Inserir(Reserva novaReserva)
        {
            return _reservaRepositorio.Inserir(novaReserva);
        }

        public bool Excluir(int id)
        {
            return _reservaRepositorio.Excluir(id);
        }

        public Reserva ObterClienteID(int id)
        {
            return _reservaRepositorio.ObterClienteID(id);
        }

        public Reserva ObterCarroID(int id)
        {
            return _reservaRepositorio.ObterCarroID(id);
        }

        public List<Reserva> ObterListaResereva()
        {
            return _reservaRepositorio.ObterListaResereva();
        }
    }
}
