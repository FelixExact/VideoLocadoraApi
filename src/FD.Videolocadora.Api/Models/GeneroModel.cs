using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Helper;
using System;

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

