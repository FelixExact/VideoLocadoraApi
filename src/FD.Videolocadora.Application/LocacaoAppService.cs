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
    public class LocacaoAppService : EntityAppService<Locacao>
    {
        private readonly IEntityService<Locacao> _service;


        public LocacaoAppService(IEntityService<Locacao> service, IUnitOfWork uow)
            : base(service, uow)
        {
            _service = service;
        }

        //public void Adicionar(Locacao locacaoModel)
        //{
        //    var locacao = locacaoModel;
        //  
        //    BeginTransaction();
        //    _service.Adicionar(locacao);
        //    Commit();
        //}
        //
        //public Locacao Atualizar(Locacao locacao)
        //{
        //    _service.Atualizar(locacao);
        //    return locacao;
        //}
        //
        //public void Dispose()
        //{
        //    _service.Dispose();
        //    GC.SuppressFinalize(this);
        //}
        //
        //public Locacao ObterPorId(Guid id)
        //{
        //    return _service.ObterPorId(id);
        //}
        //
        //public IEnumerable<Locacao> ObterTodos()
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
