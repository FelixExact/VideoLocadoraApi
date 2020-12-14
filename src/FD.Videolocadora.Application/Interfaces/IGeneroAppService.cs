using FD.Videolocadora.Application.Models;
using FD.Videolocadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Application.Interfaces
{
    public interface IGeneroAppService 
    {
        void Adicionar(GeneroModel Genero);
        GeneroModel ObterPorId(Guid id);
        IEnumerable<GeneroModel> ObterTodos();
        GeneroModel Atualizar(GeneroModel Genero);

        void Remover(Guid id);
        void Dispose();
    }
}
