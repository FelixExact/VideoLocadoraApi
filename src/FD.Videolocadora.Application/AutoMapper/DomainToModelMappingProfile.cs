using AutoMapper;
using FD.Videolocadora.Application.Models;
using FD.Videolocadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Application.AutoMapper
{
    public class DomainToModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Filme, FilmeModel>();
            Mapper.CreateMap<Genero, GeneroModel>();
            Mapper.CreateMap<Locacao, LocacaoModel>();
            Mapper.CreateMap<Usuario, UsuarioModel>();
        }
    }
}
