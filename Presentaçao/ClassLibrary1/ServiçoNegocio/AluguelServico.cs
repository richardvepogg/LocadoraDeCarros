using Negocio.RepositorioDados;
using Negocio.ServiçoNegocio.Base;

namespace Negocio.ServiçoNegocio
{
    public class AluguelServico : IAluguelServico
    {
        public readonly IAluguelRepositorio _aluguelRepositorio;

        public AluguelServico(IAluguelRepositorio aluguelRepositorio)
        {
            _aluguelRepositorio = aluguelRepositorio;
        }


        public bool Editar(Aluguel reservaEditada)
        {
            return _aluguelRepositorio.Editar(reservaEditada);
        }

        public bool Inserir(Aluguel novaReserva)
        {
            return _aluguelRepositorio.Inserir(novaReserva);
        }

        public bool Excluir(int id)
        {
            return _aluguelRepositorio.Excluir(id);
        }

        public Aluguel ObterAluguelIDCarro(int id)
        {
            return _aluguelRepositorio.ObterAluguelIDCarro(id);
        }

        public Aluguel ObterAluguelIDCliente(int id)
        {
            return _aluguelRepositorio.ObterAluguelIDCliente(id);
        }
            public List<Aluguel> ObterListaAluguel()
        {
            return _aluguelRepositorio.ObterListaAluguel();
        }
    }
}
