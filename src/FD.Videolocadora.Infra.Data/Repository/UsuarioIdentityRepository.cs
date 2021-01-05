using FD.Videolocadora.Infra.Data.Context;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FD.Videolocadora.Infra.Data.Repository
{
    public class UsuarioIdentityRepository
    {
        protected VideolocadoraContext Db;
        protected IdentityUser User;
        public UsuarioIdentityRepository(VideolocadoraContext context)
        {
            Db = context;
            User = new IdentityUser();
        }

        public void Adicionar(IdentityUser identityUser)
        {
            Db.Users.Add(identityUser);
            Db.SaveChanges();
        }
    }
}
