using Negocio.Models;


namespace Negocio.RepositorioDados
{
    public interface IClienteRepositorio
    {
        Cliente ObterCliente(int id);
        Cliente ObterClientePorEmail(string email);
        Cliente ObterClienteNome(string email);
        Cliente ObterClienteCarteiraMotorista(string email);
        List<Cliente> ObterListaClientes();
        bool Editar(Cliente clienteEditado);
        bool Inserir(Cliente novoCliente);
        bool Excluir(int id);
    }
}
