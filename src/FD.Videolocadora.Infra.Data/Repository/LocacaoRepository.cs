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
    public class LocacaoRepository : Repository<Locacao>, IRepository<Locacao>
    {
        public LocacaoRepository(VideolocadoraContext context)
        : base(context)
        {

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

            SaveChanges();
        }
    }
    
    
}
