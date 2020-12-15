using FD.Videolocadora.Domain.Interfaces.Repository;
using FD.Videolocadora.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Domain.Services
{
    public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        public EntityService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public TEntity Adicionar(TEntity TEntity)
        {
            return _repository.Adicionar(TEntity);
        }

        public virtual TEntity Atualizar(TEntity TEntity)
        {
            return _repository.Atualizar(TEntity);
        }

        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }

        public TEntity ObterPorId(Guid id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _repository.Remover(id);
        }
    }
}
