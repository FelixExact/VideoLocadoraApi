using FD.Videolocadora.Domain.Entities;
using System;

namespace FD.Videolocadora.Application.Interfaces
{
    public interface ILocacaoAppService : IEntityAppService<Locacao>
    {
        void RemoverPorUsuario(Guid id);
    }
}
