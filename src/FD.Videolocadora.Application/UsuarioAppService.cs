using FD.Videolocadora.Application.Interfaces;
using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Interfaces.Services;
using FD.Videolocadora.Infra.Data.Interface;

namespace FD.Videolocadora.Application
{
    public class UsuarioAppService : EntityAppService<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _service;


        public UsuarioAppService(IUsuarioService service, IUnitOfWork uow)
            : base(service, uow)
        {
            _service = service;
        }
        public override Usuario Adicionar(Usuario usuario)
        {
            BeginTransaction();
            var retorno = _service.Adicionar(usuario);
            Commit();
            return retorno;


        }

        public override Usuario Atualizar(Usuario Usuario)
        {
            _service.Atualizar(Usuario);
            return Usuario;
        }
       //
       // public void Dispose()
       // {
       //     _service.Dispose();
       //     GC.SuppressFinalize(this);
       // }
       //
       // public Usuario ObterPorId(Guid id)
       // {
       //     return _service.ObterPorId(id);
       // }
       //
       // public IEnumerable<Usuario> ObterTodos()
       // {
       //     return _service.ObterTodos();
       // }
       //
       // public void Remover(Guid id)
       // {
       //     _service.Remover(id);
       // }

    }
}
