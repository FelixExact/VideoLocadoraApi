using FD.Videolocadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Infra.Data.EntityConfig
{
    class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(c => c.Usuarioid);
            //HasKey(c => new {c.ClienteId, c.CPF});

            Property(c => c.Nome)
                .IsRequired()
                //.HasColumnName("STR_Nm")
                .HasMaxLength(150);

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                // deixar unico e criar annotation
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            ToTable("Usuarios");
        }
    }
}
