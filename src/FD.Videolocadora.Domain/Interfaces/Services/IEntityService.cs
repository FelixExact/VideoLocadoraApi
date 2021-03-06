﻿using System;
using System.Collections.Generic;

namespace FD.Videolocadora.Domain.Interfaces.Services
{
    public interface IEntityService<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity TEntity);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        TEntity Atualizar(TEntity TEntity);
        void Remover(Guid id);
    }
}
