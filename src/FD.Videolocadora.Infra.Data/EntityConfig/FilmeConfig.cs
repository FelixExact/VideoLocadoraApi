using FD.Videolocadora.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

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
