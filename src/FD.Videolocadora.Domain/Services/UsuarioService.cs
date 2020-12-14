using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Interfaces.Repository;
using FD.Videolocadora.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepository<Usuario> _repository;

        public UsuarioService(IRepository<Usuario> repository)
        {
            _repository = repository;
        }

        public Usuario Adicionar(Usuario Usuario)
        {
            if (!Usuario.IsValid()) { return Usuario; }
            return _repository.Adicionar(Usuario);
        }

        public Usuario Atualizar(Usuario Usuario)
        {
            return _repository.Atualizar(Usuario);
        }

        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Usuario ObterPorId(Guid id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _repository.Remover(id);
        }
    }
}
