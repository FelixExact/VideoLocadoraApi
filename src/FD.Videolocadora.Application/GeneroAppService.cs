using AutoMapper;
using FD.Videolocadora.Application.Interfaces;
using FD.Videolocadora.Application.Models;
using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Interfaces.Services;
using FD.Videolocadora.Infra.Data.Interface;
using FD.Videolocadora.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Application
{
    public class GeneroAppService : AppService, IGeneroAppService
    {
        private readonly IGeneroService _service;

        public GeneroAppService(IGeneroService service, IUnitOfWork uow)
            :base(uow)
        {
            _service = service;
        }



        public void Adicionar(GeneroModel generoModel)
        {
            var genero = Mapper.Map<GeneroModel, Genero>(generoModel);

            BeginTransaction();
            _service.Adicionar(genero);
            Commit();
        }

        public GeneroModel Atualizar(GeneroModel genero)
        {
            _service.Atualizar(Mapper.Map<GeneroModel, Genero>(genero));
            return genero;
        }

        public GeneroModel ObterPorId(Guid id)
        {
            return Mapper.Map<Genero,GeneroModel > (_service.ObterPorId(id));
        }

        public IEnumerable<GeneroModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Genero>,IEnumerable<GeneroModel>>(_service.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _service.Remover(id);
        }

        public void Dispose()
        {
            _service.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
