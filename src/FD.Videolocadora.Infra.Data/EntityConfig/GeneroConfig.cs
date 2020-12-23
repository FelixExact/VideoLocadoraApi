using FD.Videolocadora.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

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
