using Negocio.Models;
namespace Negocio.RepositorioDados
{
    public interface IReservaRepositorio
    {
        Reserva ObterCarroID(int id);
        Reserva ObterClienteID(int id);
        List<Reserva> ObterListaResereva();
        bool Editar(Reserva ReservaEditada);
        bool Inserir(Reserva novaReserva);
        bool Excluir(int id);
    }
}
