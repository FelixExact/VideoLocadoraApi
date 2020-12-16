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
    public class LocacaoAppService : EntityAppService<Locacao>, ILocacaoAppService
    {
        private readonly ILocacaoService _service;


        public LocacaoAppService(ILocacaoService service, IEntityService<Locacao> services, IUnitOfWork uow)
            : base(services, uow)
        {
            _service = service;
        }

        public override Locacao Adicionar(Locacao locacaoModel)
        {
            var locacao = locacaoModel;
          
            BeginTransaction();
            var retorno =  _service.Adicionar(locacao);
            Commit();
            return retorno;
        }
        
        public override Locacao Atualizar(Locacao locacao)
        {
            _service.Atualizar(locacao);
            return locacao;
        }
        
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
