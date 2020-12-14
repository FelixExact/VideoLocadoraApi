using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Application.Models
{
    public class LocacaoModel
    {
        public LocacaoModel()
        {
            LocacaoId = Guid.NewGuid();
        }
        public Guid LocacaoId { get; set; }
        public DateTime DataDevolucao { get; set; }
        public Guid FilmeId { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
