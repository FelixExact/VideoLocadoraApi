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
                int dispnivel = _repository.FilmeDisponivel(locacao.FilmeId);
                if (dispnivel == 0)
                {
                    throw new Exception("filme indisponivel.");
                }

                //_repository.UpdateLocacao(locacao.FilmeId, (dispnivel - 1));
                var a = _repository.Adicionar(locacao, locacao.FilmeId, (dispnivel - 1));

                _repository.SaveChanges();
                return a;
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




