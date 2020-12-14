using FD.Videolocadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
