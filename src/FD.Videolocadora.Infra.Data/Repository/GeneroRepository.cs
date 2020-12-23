using Dapper;
using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Interfaces.Repository;
using FD.Videolocadora.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FD.Videolocadora.Infra.Data.Repository
{
    public class GeneroRepository : Repository<Genero>, IRepository<Genero>
    {
        public GeneroRepository(VideolocadoraContext context)
        : base(context)
        {

        }
        public override IEnumerable<Genero> ObterTodos()
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Generos";

            return cn.Query<Genero>(sql);
            //return DbSet.ToList();
        }

        public override Genero ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Generos c " +
                       "WHERE c.GeneroId = @sid";
            return cn.Query<Genero>(sql, new { sid = id }).FirstOrDefault();

        }
        public override void Remover(Guid id)
        {
            var cn = Db.Database.Connection;

            var sql = @"DELETE FROM Generos  " +
                       "WHERE GeneroId = @sid";
            cn.Execute(sql, new { sid = id });

            SaveChanges();
        }
    }
}
