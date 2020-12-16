using FD.Videolocadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Domain.Interfaces.Services
{
    public interface ILocacaoService : IEntityService<Locacao>
    {
        Locacao Adicionar(Locacao locacao);
        Locacao ObterPorId(Guid id);
        IEnumerable<Locacao> ObterTodos();
        Locacao Atualizar(Locacao locacao);
        void Remover(Guid id);
        void RemoverPorUsuario(Guid id);
    }
}
