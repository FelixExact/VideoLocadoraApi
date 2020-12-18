using FD.Videolocadora.Application.Interfaces;
using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Interfaces.Services;
using FD.Videolocadora.Infra.Data.Interface;
using System;

namespace FD.Videolocadora.Application
{
    public class LocacaoAppService : EntityAppService<Locacao>, ILocacaoAppService
    {
        private readonly ILocacaoService _service;


        public LocacaoAppService(ILocacaoService service, IUnitOfWork uow)
            : base(service, uow)
        {
            _service = service;
        }

        public override Locacao Adicionar(Locacao locacaoModel)
        {
            var locacao = locacaoModel;
            var retorno =  _service.Adicionar(locacao);
            return retorno;
        }
        
        public override Locacao Atualizar(Locacao locacao)
        {
            BeginTransaction();
            _service.Atualizar(locacao);
            Commit();
            return locacao;
        }

        public void RemoverPorUsuario(Guid id)
        {
            BeginTransaction();
            _service.RemoverPorUsuario(id);
            Commit();
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
