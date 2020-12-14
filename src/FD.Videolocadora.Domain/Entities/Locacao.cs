using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Domain.Entities
{
    public class Locacao
    {
        public Locacao()
        {
            LocacaoId = Guid.NewGuid();
        }
        public Guid LocacaoId { get; set; }
        public DateTime DataDevolucao { get; set; }
        public Guid FilmeId { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Filme Filme { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
