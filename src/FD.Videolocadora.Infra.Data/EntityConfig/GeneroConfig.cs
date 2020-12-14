using FD.Videolocadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Infra.Data.EntityConfig
{
    class GeneroConfig : EntityTypeConfiguration<Genero>
    {
        public GeneroConfig()
        {
            HasKey(c => c.GeneroId);

            Property(c => c.Nome)
                .IsRequired();

            ToTable("Generos");
        }
    }
}
