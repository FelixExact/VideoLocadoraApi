using FD.Videolocadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Domain.Interfaces.Services
{
    public interface IGeneroService : IEntityService<Genero>
    {
        Genero Adicionar(Genero Genero);
        Genero ObterPorId(Guid id);
        IEnumerable<Genero> ObterTodos();
        Genero Atualizar(Genero Genero);
        void Remover(Guid id);
    }
}
