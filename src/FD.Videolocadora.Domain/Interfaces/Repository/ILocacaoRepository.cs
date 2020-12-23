using FD.Videolocadora.Domain.Entities;
using System;

namespace FD.Videolocadora.Domain.Interfaces.Repository
{
    public interface ILocacaoRepository : IRepository<Locacao>
    {
        Locacao Adicionar(Locacao obj);
        void RemoverPorUsuario(Guid id);
        int FilmeDisponivel(Guid id);
        void UpdateLocacao(Guid id, int quantidade);
    }
}
