using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Domain.Entities
{
    public class Genero
    {
        public Genero()
        {
            GeneroId = Guid.NewGuid();
        }
        public Guid GeneroId { get; set; }
        public String Nome { get; set; }
       public virtual ICollection<Filme> Filmes { get; set; }

        public void ValidaNome()
        {
            if (Nome == string.Empty)
            {
                throw new Exception("Nome do filme invalido.");
            }
        }
    }
}
