using FD.Videolocadora.Domain.Entities;
using System;

namespace FD.Videolocadora.Domain.Interfaces.Services
{
    public interface ILocacaoService : IEntityService<Locacao>
    {
        void RemoverPorUsuario(Guid id);
    }
}
