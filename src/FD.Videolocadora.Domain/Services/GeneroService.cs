using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Interfaces.Repository;
using FD.Videolocadora.Domain.Interfaces.Services;

namespace FD.Videolocadora.Domain.Services
{
    public class GeneroService : EntityService<Genero>, IGeneroService
    {
        private readonly IRepository<Genero> _Repository;

        public GeneroService(IRepository<Genero> Repository) : base(Repository)
        {
            _Repository = Repository;
        }
        public override Genero Adicionar(Genero Genero)
        {
            Genero.ValidaNome();
            return _Repository.Adicionar(Genero);
        }

        public override Genero Atualizar(Genero Genero)
        {
            Genero.ValidaNome();
            return _Repository.Atualizar(Genero);
        }



    }
}
