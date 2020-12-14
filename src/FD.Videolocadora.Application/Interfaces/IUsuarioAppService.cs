using FD.Videolocadora.Application.Models;
using FD.Videolocadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        UsuarioModel Adicionar(UsuarioModel Usuario);
        UsuarioModel ObterPorId(Guid id);
        IEnumerable<UsuarioModel> ObterTodos();
        UsuarioModel Atualizar(UsuarioModel Usuario);
        
        void Remover(Guid id);
        void Dispose();
    }
}
