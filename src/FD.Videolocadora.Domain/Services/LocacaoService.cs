using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Interfaces.Repository;
using FD.Videolocadora.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Domain.Services
{
    public class LocacaoService : EntityService<Locacao>,ILocacaoService
    {
        private readonly ILocacaoRepository _repository;

        public LocacaoService(ILocacaoRepository repository): base(repository)
        {
            _repository = repository;
        }

        public override Locacao Adicionar(Locacao locacao)
        {
           return _repository.Adicionar(locacao);
        }

        public override Locacao Atualizar(Locacao locacao)
        {
            return _repository.Atualizar(locacao);
        }

        public void RemoverPorUsuario(Guid id)
        {
            _repository.RemoverPorUsuario(id);
        }
    }
}
