using FD.Videolocadora.Domain.Interfaces.Repository;
using FD.Videolocadora.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace FD.Videolocadora.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected VideolocadoraContext Db;
        protected DbSet<TEntity> DbSet;
        public Repository(VideolocadoraContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objReturn = DbSet.Add(obj);
            Db.SaveChanges();
            return objReturn;
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();

            return obj;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual void Remover(Guid id)
        {
            TEntity Remo = ObterPorId(id);

            var entry = Db.Entry(Remo);
            DbSet.Attach(Remo);
            entry.State = EntityState.Deleted;
            Db.SaveChanges();
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction()
        {
            Db.Database.BeginTransaction();
        }

        public void Commit()
        {
            Db.Database.CurrentTransaction.Commit();
        }

        public void Rollback()
        {
            Db.Database.CurrentTransaction.Rollback();
        }
    }
}
