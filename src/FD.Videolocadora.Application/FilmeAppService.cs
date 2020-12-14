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
    public class FilmeAppService : AppService, IFilmeAppService
    {
        private readonly IFilmeService _service;

        public FilmeAppService(IFilmeService service,IUnitOfWork uow)
            : base(uow)
        {
            _service = service;
        }

        public void Adicionar(FilmeModel filmeModel)
        {
            var filme = Mapper.Map<FilmeModel, Filme>(filmeModel);
        BeginTransaction();
            _service.Adicionar(filme);
        Commit();
    }

        public FilmeModel Atualizar(FilmeModel filme)
        {
            _service.Atualizar(Mapper.Map<FilmeModel, Filme>(filme));
            return filme;
        }

        public void Dispose()
        {
            _service.Dispose();
            GC.SuppressFinalize(this);
        }

        public FilmeModel ObterPorId(Guid id)
        {
            return Mapper.Map <Filme, FilmeModel> (_service.ObterPorId(id));
        }

        public IEnumerable<FilmeModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Filme>, IEnumerable<FilmeModel>>(_service.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _service.Remover(id);
        }

    }
}
