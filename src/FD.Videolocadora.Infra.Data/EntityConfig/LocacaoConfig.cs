using FD.Videolocadora.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FD.Videolocadora.Infra.Data.EntityConfig
{
    class LocacaoConfig : EntityTypeConfiguration<Locacao>
    {
        public LocacaoConfig()
        {
            HasKey(c => c.LocacaoId);

            Property(c => c.DataDevolucao)
                .IsRequired();

            Property(c => c.FilmeId)
                .IsRequired();

            Property(c => c.UsuarioId)
                .IsRequired();


            ToTable("Locacoes");
        }
    }
}
