using FD.Videolocadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Domain.Interfaces.Services
{
    public interface IFilmeService : IDisposable
    {
        Filme Adicionar(Filme Filme);
        Filme ObterPorId(Guid id);
        IEnumerable<Filme> ObterTodos();
        Filme Atualizar(Filme Filme);

        void Remover(Guid id);
    }
}
