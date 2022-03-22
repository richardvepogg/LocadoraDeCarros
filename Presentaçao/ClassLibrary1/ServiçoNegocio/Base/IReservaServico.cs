using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ServiçoNegocio.Base
{
    public interface IReservaServico
    {
        Reserva ObterClienteID(int nome);
        Reserva ObterCarroID(int carteiraMotorista);
        List<Reserva> ObterListaResereva();
        bool Editar(Reserva reservaEditado);
        bool Inserir(Reserva novaReserva);
        bool Excluir(int id);

    }
}
