using AutoMapper;
using FD.Videolocadora.Application.Interfaces;
using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Interfaces.Services;
using FD.Videolocadora.Infra.Data.Interface;
using FD.Videolocadora.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Application
{
    public class UsuarioAppService : EntityAppService<Usuario>
    {
        private readonly IEntityService<Usuario> _service;


        public UsuarioAppService(IEntityService<Usuario> service, IUnitOfWork uow)
            : base(service, uow)
        {
            _service = service;
        }
       // public Usuario Adicionar(Usuario usuarioModel)
       // {
       //     var usuario = usuarioModel;
       //    BeginTransaction();
       //     var usuarioReturn = _service.Adicionar(usuario);
       //     if (usuarioReturn.ValidationResult.IsValid)
       //     {
       //         Commit();
       //     }
       //     var retornoUsuario = usuario;
       //     
       //     return retornoUsuario;
       //
       //
       // }
       //
       // public Usuario Atualizar(Usuario Usuario)
       // {
       //     _service.Atualizar(Usuario);
       //     return Usuario;
       // }
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
