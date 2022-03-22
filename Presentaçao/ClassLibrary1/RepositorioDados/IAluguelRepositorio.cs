using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.RepositorioDados
{
    public interface IAluguelRepositorio
    {
        Aluguel ObterAluguelIDCarro(int id);
        Aluguel ObterAluguelIDCliente (int id);
        List<Aluguel> ObterListaAluguel();
        bool Editar(Aluguel aluguelEditado);
        bool Inserir(Aluguel novoaluguel);
        bool Excluir(int id);
    }
}
