using FD.Videolocadora.Application.Models;
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
        void Adicionar(FilmeModel Filme);
        FilmeModel ObterPorId(Guid id);
        IEnumerable<FilmeModel> ObterTodos();
        FilmeModel Atualizar(FilmeModel Filme);

        void Remover(Guid id);
        void Dispose();
    }
}
