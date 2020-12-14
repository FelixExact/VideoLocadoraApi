using Dapper;
using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Interfaces.Repository;
using FD.Videolocadora.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Infra.Data.Repository
{
    public class FilmeRepository : Repository<Filme>, IRepository<Filme>
    {
        public FilmeRepository(VideolocadoraContext context)
        :base(context){

        }

        public override IEnumerable<Filme> ObterTodos()
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Filmes";

            return cn.Query<Filme>(sql);
            //return DbSet.ToList();
        }

        public override Filme ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Filmes c " +
                       "WHERE c.FilmeId = @sid";
            return cn.Query<Filme>(sql, new { sid = id }).FirstOrDefault();

        }
        public override void Remover(Guid id)
        {
            var cn = Db.Database.Connection;

            var sql = @"DELETE FROM Filmes  " +
                       "WHERE FilmeId = @sid";
            cn.Execute(sql, new { sid = id });

            SaveChanges();
        }
    }
}
