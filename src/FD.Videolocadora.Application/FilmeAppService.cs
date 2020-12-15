using AutoMapper;
using FD.Videolocadora.Application.Interfaces;
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
    public class FilmeAppService : EntityAppService<Filme>
    {
        private readonly IEntityService<Filme> _service;


        public FilmeAppService(IEntityService<Filme> service, IUnitOfWork uow)
            : base(service, uow)
        {
            _service = service;
        }

        //public void Adicionar(Filme filmeModel)
        //{
        //    var filme = filmeModel;
        //BeginTransaction();
        //    _service.Adicionar(filme);
        //Commit();
       //
        //
        //public Filme Atualizar(Filme filme)
        //{
        //    _service.Atualizar(filme);
        //    return filme;
        //}
        //
        //public void Dispose()
        //{
        //    _service.Dispose();
        //    GC.SuppressFinalize(this);
        //}
        //
        //public Filme ObterPorId(Guid id)
        //{
        //    return _service.ObterPorId(id);
        //}
        //
        //public IEnumerable<Filme> ObterTodos()
        //{
        //    return _service.ObterTodos();
        //}
        //
        //public void Remover(Guid id)
        //{
        //    _service.Remover(id);
        //}

    }
}
