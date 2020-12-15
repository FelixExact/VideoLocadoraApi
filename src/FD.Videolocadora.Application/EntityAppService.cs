using FD.Videolocadora.Application.Interfaces;
using FD.Videolocadora.Domain.Interfaces.Services;
using FD.Videolocadora.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Application
{
    public class EntityAppService<TEntity> : AppService,IEntityAppService<TEntity> where TEntity : class
    {
        private readonly IEntityService<TEntity> _service;

        public EntityAppService(IEntityService<TEntity> service, IUnitOfWork uow)
            : base(uow)
        {
            _service = service;
        }

        public virtual TEntity Adicionar(TEntity TEntity)
        {
            BeginTransaction();
            var retorno = _service.Adicionar(TEntity);
            Commit();
            return retorno;
        }

        public virtual TEntity Atualizar(TEntity TEntity)
        {
            return _service.Atualizar(TEntity);
        }

        public virtual void Dispose()
        {
            _service.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return _service.ObterPorId(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return _service.ObterTodos();
        }

        public virtual void Remover(Guid id)
        {
            _service.Remover(id);
        }
    }
}
