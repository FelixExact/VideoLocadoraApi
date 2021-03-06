﻿using System;
using System.Collections.Generic;

namespace FD.Videolocadora.Application.Interfaces
{
    public interface IEntityAppService<TEntity> where TEntity : class
    {
        TEntity Adicionar(TEntity TEntity);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        TEntity Atualizar(TEntity Filme);
        void Remover(Guid id);
    }
}
