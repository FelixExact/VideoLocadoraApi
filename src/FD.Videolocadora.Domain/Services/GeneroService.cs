using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Interfaces.Repository;
using FD.Videolocadora.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Domain.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IRepository<Genero> _Repository;

        public GeneroService(IRepository<Genero> Repository)
        {
            _Repository = Repository;
        }
        public void Adicionar(Genero Genero)
        {
            _Repository.Adicionar(Genero);
        }

        public Genero Atualizar(Genero Genero)
        {
            return _Repository.Atualizar(Genero);
        }

        public void Dispose()
        {
            _Repository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Genero ObterPorId(Guid id)
        {
            return _Repository.ObterPorId(id);
        }

        public IEnumerable<Genero> ObterTodos()
        {
            return _Repository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _Repository.Remover(id);
        }

    }
}
