using FD.Videolocadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Domain.Interfaces.Services
{
    public interface IUsuarioService : IDisposable
    {
        Usuario Adicionar(Usuario Usuario);
        Usuario ObterPorId(Guid id);
        IEnumerable<Usuario> ObterTodos();
        Usuario Atualizar(Usuario Usuario);

        void Remover(Guid id);
    }
}
