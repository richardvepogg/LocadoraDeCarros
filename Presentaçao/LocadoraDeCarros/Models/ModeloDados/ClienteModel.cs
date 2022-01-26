namespace LocadoraDeCarros.Models.ModeloDados
{
    public class ClienteModel
    {
        public int id { get; set; } 
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone  { get; set; }
        public string Endereço { get; set; }
        public string NumeroCartaoCredito { get; set; }
    }
}
