using FD.Videolocadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Domain.Interfaces.Repository
{
    public interface ILocacaoRepository : IRepository<Locacao>
    {
        void RemoverPorUsuario(Guid id);
    }
}
