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
    public class FilmeService : EntityService<Filme>, IFilmeService
    {
        private readonly IRepository<Filme> _repository;

        public FilmeService(IRepository<Filme> repository):base(repository)
        {
            _repository = repository;
        }

        public override Filme Adicionar(Filme Filme)
        {
            Filme.ValidaNome();
            return _repository.Adicionar(Filme);
        }

        public override Filme Atualizar(Filme Filme)
        {
            Filme.ValidaNome();
            return _repository.Atualizar(Filme);
        }

    }
}
