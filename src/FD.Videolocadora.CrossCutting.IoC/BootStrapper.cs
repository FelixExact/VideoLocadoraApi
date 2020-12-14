using FD.Videolocadora.Application;
using FD.Videolocadora.Application.Interfaces;
using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Interfaces.Repository;
using FD.Videolocadora.Domain.Interfaces.Services;
using FD.Videolocadora.Domain.Services;
using FD.Videolocadora.Infra.Data.Context;
using FD.Videolocadora.Infra.Data.Interface;
using FD.Videolocadora.Infra.Data.Repository;
using FD.Videolocadora.Infra.Data.Uow;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container) {

            //API
            container.Register<IGeneroAppService, GeneroAppService>(Lifestyle.Scoped);
            //container.RegisterPerWebRequest<IGeneroAppService, GeneroAppService>();
            container.Register<IFilmeAppService, FilmeAppService>(Lifestyle.Scoped);
            container.Register<IlocacaoAppService, LocacaoAppService>(Lifestyle.Scoped);
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);


            //Domain
            container.Register<IGeneroService, GeneroService>(Lifestyle.Scoped);
            container.Register<IFilmeService, FilmeService>(Lifestyle.Scoped);
            container.Register<ILocacaoService, LocacaoService>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);


            //Infra
            container.Register<IRepository<Genero>, GeneroRepository>(Lifestyle.Scoped);
            //container.Register(typeof(IRepository<>), typeof(Repository<>));
            container.Register<IRepository<Filme>, FilmeRepository>(Lifestyle.Scoped);
            container.Register<IRepository<Locacao>, LocacaoRepository>(Lifestyle.Scoped);
            container.Register<IRepository<Usuario>, UsuarioRepository>(Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<VideolocadoraContext>(Lifestyle.Scoped);


        }
    }
}
