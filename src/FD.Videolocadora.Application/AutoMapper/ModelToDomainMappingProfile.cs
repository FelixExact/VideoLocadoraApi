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
    public class ModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<FilmeModel, Filme>();
            Mapper.CreateMap< GeneroModel, Genero>();
            Mapper.CreateMap< LocacaoModel, Locacao>();
            Mapper.CreateMap< UsuarioModel, Usuario>();
        }
    }
}
