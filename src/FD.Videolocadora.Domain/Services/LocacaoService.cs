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
    public class LocacaoService : ILocacaoService
    {
        private readonly IRepository<Locacao> _repository;

        public LocacaoService(IRepository<Locacao> repository)
        {
            _repository = repository;
        }

        public void Adicionar(Locacao locacao)
        {
            _repository.Adicionar(locacao);
        }

        public Locacao Atualizar(Locacao locacao)
        {
            return _repository.Atualizar(locacao);
        }

        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Locacao ObterPorId(Guid id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<Locacao> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _repository.Remover(id);
        }
    }
}
