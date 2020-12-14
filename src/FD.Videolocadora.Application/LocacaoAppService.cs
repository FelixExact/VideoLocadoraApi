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
    public class LocacaoAppService : AppService, IlocacaoAppService
    {
        private readonly ILocacaoService _service;

        public LocacaoAppService(ILocacaoService service, IUnitOfWork uow)
            : base(uow)
        {
            _service = service;
        }

        public void Adicionar(LocacaoModel locacaoModel)
        {
            var locacao = Mapper.Map<LocacaoModel, Locacao>(locacaoModel);
          
            BeginTransaction();
            _service.Adicionar(locacao);
            Commit();
        }

        public LocacaoModel Atualizar(LocacaoModel locacao)
        {
            _service.Atualizar(Mapper.Map<LocacaoModel, Locacao>(locacao));
            return locacao;
        }

        public void Dispose()
        {
            _service.Dispose();
            GC.SuppressFinalize(this);
        }

        public LocacaoModel ObterPorId(Guid id)
        {
            return Mapper.Map<Locacao, LocacaoModel>(_service.ObterPorId(id));
        }

        public IEnumerable<LocacaoModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Locacao>, IEnumerable<LocacaoModel>>(_service.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _service.Remover(id);
        }

    }
}
