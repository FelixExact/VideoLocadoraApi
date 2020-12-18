using Dapper;
using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Interfaces.Repository;
using FD.Videolocadora.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
            using (var ContextTransaction = Db.Database.BeginTransaction())
            {
                try
                {
                    var objReturn = DbSet.Add(obj);
                    Db.SaveChanges();
                    ContextTransaction.Commit();

                    return objReturn;
                }
                catch (Exception)
                {

                    ContextTransaction.Rollback();
                    throw;
                }
            }
            
                
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            Db.SaveChanges();

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
            DbSet.Remove(Remo);
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

        //public void Commit()
        //{
        //    Db.SaveChanges();
        //}

        public void Rollback()
        {
            Db.Database.CurrentTransaction.Rollback();
        }
    }
}
