using FD.Videolocadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Application.Models
{
    public class FilmeModel
    {
        public FilmeModel()
        {
            FilmeId = Guid.NewGuid();

        }
        public Guid FilmeId { get; set; }
        public String Nome { get; set; }
        public double Valor { get; set; }
        public int Disponivel { get; set; }
        public Guid GeneroId { get; set; }

        internal Filme ToEntity()
        {
            return new Filme()
            {
                FilmeId = FilmeId,
                Nome = Nome,
                Valor = Valor,
                Disponivel = Disponivel,
                GeneroId = GeneroId
            };
        }
    }
}
