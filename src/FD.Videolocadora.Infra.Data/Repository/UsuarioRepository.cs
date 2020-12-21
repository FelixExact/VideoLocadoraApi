using Dapper;
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
    public class UsuarioRepository : Repository<Usuario>, IRepository<Usuario>
    {
        public UsuarioRepository(VideolocadoraContext context)
        : base(context)
        {

        }
        public override IEnumerable<Usuario> ObterTodos()
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Usuarios";

            return cn.Query<Usuario>(sql);
            //return DbSet.ToList();
        }

        public override Usuario ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Usuarios c " +
                       "WHERE c.UsuarioId = @sid";
            return cn.Query<Usuario>(sql, new { sid = id }).FirstOrDefault();

        }
        public override void Remover(Guid id)
        {
            var cn = Db.Database.Connection;

            var sql = @"DELETE FROM Usuarios  " +
                       "WHERE UsuarioId = @sid";
            cn.Execute(sql, new { sid = id });
            SaveChanges();

        }
    }
}
