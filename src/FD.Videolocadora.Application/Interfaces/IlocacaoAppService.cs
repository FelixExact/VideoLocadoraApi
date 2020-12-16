using System;
using System.Collections.Generic;
using FD.Videolocadora.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Application.Interfaces
{
    public interface ILocacaoAppService
    {
        Locacao Adicionar(Locacao locacao);
        Locacao ObterPorId(Guid id);
        IEnumerable<Locacao> ObterTodos();
        Locacao Atualizar(Locacao locacao);
        void Remover(Guid id);
    }
}
