using FD.Videolocadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Infra.Data.EntityConfig
{
    class FilmeConfig : EntityTypeConfiguration<Filme>
    {
        public FilmeConfig()
        {
            HasKey(c => c.FilmeId);

            Property(c => c.Nome)
                .IsRequired();

            Property(c => c.Valor)
                .IsRequired();

            HasRequired(e => e.Genero)
                .WithMany(c => c.Filmes)
                .HasForeignKey(e => e.GeneroId);

            ToTable("Filmes");
        }
    }
}
