using AutoMapper;
using FD.Videolocadora.Application.Interfaces;
using FD.Videolocadora.Application.Models;
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
    public class UsuarioAppService : AppService, IUsuarioAppService
    {
        private readonly IUsuarioService _service;

        public UsuarioAppService(IUsuarioService service, IUnitOfWork uow)
            :base(uow)
        {
            _service = service;
        }
        public UsuarioModel Adicionar(UsuarioModel usuarioModel)
        {
            var usuario = Mapper.Map<UsuarioModel,Usuario>(usuarioModel);
           BeginTransaction();
            var usuarioReturn = _service.Adicionar(usuario);
            if (usuarioReturn.ValidationResult.IsValid)
            {
                Commit();
            }
            var retornoUsuario = Mapper.Map<Usuario, UsuarioModel>(usuario);
            
            return retornoUsuario;


        }

        public UsuarioModel Atualizar(UsuarioModel Usuario)
        {
            _service.Atualizar(Mapper.Map<UsuarioModel, Usuario>(Usuario));
            return Usuario;
        }

        public void Dispose()
        {
            _service.Dispose();
            GC.SuppressFinalize(this);
        }

        public UsuarioModel ObterPorId(Guid id)
        {
            return Mapper.Map < Usuario,UsuarioModel >(_service.ObterPorId(id));
        }

        public IEnumerable<UsuarioModel> ObterTodos()
        {
            return Mapper.Map < IEnumerable<Usuario>,IEnumerable<UsuarioModel>>(_service.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _service.Remover(id);
        }

    }
}
