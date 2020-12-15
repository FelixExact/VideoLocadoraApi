
using FD.Videolocadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Application.Interfaces
{
    public interface IFilmeAppService
    {
        void Adicionar(Filme Filme);
        Filme ObterPorId(Guid id);
        IEnumerable<Filme> ObterTodos();
        Filme Atualizar(Filme Filme);

        void Remover(Guid id);
        void Dispose();
    }
}
