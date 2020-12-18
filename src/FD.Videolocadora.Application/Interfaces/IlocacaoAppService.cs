using System;
using System.Collections.Generic;
using FD.Videolocadora.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Application.Interfaces
{
    public interface ILocacaoAppService : IEntityAppService<Locacao>
    {
        void RemoverPorUsuario(Guid id);
    }
}
