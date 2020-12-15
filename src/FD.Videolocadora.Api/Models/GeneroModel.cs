using FD.Videolocadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Application.Models
{
    public class GeneroModel
    {
        public GeneroModel()
        {
            GeneroId = Guid.NewGuid();
        }
        public Guid GeneroId { get; set; }
        public String Nome { get; set; }

        public Genero ToEntity()
        {
            return new Genero()
            {
                GeneroId = GeneroId,
                Nome = Nome
            };
        }
    }

}

