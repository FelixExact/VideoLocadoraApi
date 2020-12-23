using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Interfaces.Repository;
using FD.Videolocadora.Domain.Interfaces.Services;

namespace FD.Videolocadora.Domain.Services
{
    public class UsuarioService : EntityService<Usuario>, IUsuarioService
    {
        private readonly IRepository<Usuario> _repository;

        public UsuarioService(IRepository<Usuario> repository) : base(repository)
        {
            _repository = repository;
        }

        public override Usuario Adicionar(Usuario Usuario)
        {
            Usuario.Valido();
            return _repository.Adicionar(Usuario);
        }

        public override Usuario Atualizar(Usuario Usuario)
        {
            Usuario.Valido();
            return _repository.Atualizar(Usuario);
        }


    }
}
