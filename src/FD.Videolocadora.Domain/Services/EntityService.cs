﻿using FD.Videolocadora.Domain.Interfaces.Repository;
using FD.Videolocadora.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace FD.Videolocadora.Domain.Services
{
    public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        public EntityService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public virtual TEntity Adicionar(TEntity TEntity)
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

        public virtual TEntity ObterPorId(Guid id)
        {
            return _repository.ObterPorId(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public virtual void Remover(Guid id)
        {
            _repository.Remover(id);
        }
    }
}
