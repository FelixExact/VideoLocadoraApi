using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Infra.Data.EntityConfig;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FD.Videolocadora.Infra.Data.Context
{
    public class VideolocadoraContext : IdentityDbContext
    {
        public VideolocadoraContext() : base("Videolocadora1")
        {

        }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<Filme> Filmes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // alterando a forma do Remove.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //configuração geral
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            // cadastrando as cofigs das tabelas
            modelBuilder.Configurations.Add(new FilmeConfig());
            modelBuilder.Configurations.Add(new GeneroConfig());
            modelBuilder.Configurations.Add(new LocacaoConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());

            base.OnModelCreating(modelBuilder);
        }




    }
}
