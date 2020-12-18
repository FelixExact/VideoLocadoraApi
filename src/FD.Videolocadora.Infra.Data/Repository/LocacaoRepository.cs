﻿using Dapper;
using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Interfaces.Repository;
using FD.Videolocadora.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Infra.Data.Repository
{
    public class LocacaoRepository : Repository<Locacao>, ILocacaoRepository
    {
        protected DbSet DbSetFilme;
        public LocacaoRepository(VideolocadoraContext context)
        : base(context)
        {
            DbSetFilme = Db.Set<Filme>();
        }


        public virtual Locacao Adicionar(Locacao obj, Guid id, int quantidade)
        {
            using (var ContextTransaction = Db.Database.BeginTransaction())
            {
                try
                {
                    var objReturn = DbSet.Add(obj);
                    

                    var cn = Db.Database.Connection;

                    Filme filme = (Filme)DbSetFilme.Find(id);
                    filme.Disponivel = (filme.Disponivel - 1);

                    var entry = Db.Entry(filme);
                    DbSetFilme.Attach(filme);
                    entry.State = EntityState.Modified;
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

        public override IEnumerable<Locacao> ObterTodos()
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Locacoes";

            return cn.Query<Locacao>(sql);
            //return DbSet.ToList();
        }

        public override Locacao ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Locacoes c " +
                       "WHERE c.LocacaoId = @sid";
            return cn.Query<Locacao>(sql, new { sid = id }).FirstOrDefault();

        }
        public override void Remover(Guid id)
        {
            var cn = Db.Database.Connection;

            var sql = @"DELETE FROM Locacoes  " +
                       "WHERE LocacaoId = @sid";
            cn.Execute(sql, new { sid = id });
        }

        public void RemoverPorUsuario(Guid id) {
            var cn = Db.Database.Connection;

            var sql = @"DELETE FROM Locacoes  " +
                       "WHERE UsuarioId = @sid";
            cn.Execute(sql, new { sid = id });
        }


        public int FilmeDisponivel(Guid id)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Filmes c " +
                       "WHERE c.FilmeId = @sid";
            var a = cn.Query<Filme>(sql, new { sid = id }).FirstOrDefault();
            
            return a.Disponivel;

        }
        public void UpdateLocacao(Guid id, int quantidade)
        {
            var cn = Db.Database.Connection;

            var sql = @"UPDATE Filmes  " +
                       "SET Disponivel = @squantidade " +
                        "WHERE FilmeId = @sid";
            cn.Execute(sql, new { sid = id, squantidade = quantidade });
        }
    }
    
    
}
