using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Domain.Entities
{
    public class Filme
    {
        public Filme()
        {
            FilmeId = Guid.NewGuid();
        }
        public Guid FilmeId { get; set; }
        public String Nome { get; set; }
        public double Valor { get; set; }
        public int Disponivel { get; set; }
        public Guid GeneroId { get; set; }
        public virtual Genero Genero { get; set; }
    }
}
