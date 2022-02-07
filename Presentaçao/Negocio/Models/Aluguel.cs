using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Aluguel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string CarroId { get; set; }
        public DateTime DataTransacao { get; set; }
        public DateTime DataReserva { get; set; }
        public Boolean Efetivado { get; set; }
    }
}
