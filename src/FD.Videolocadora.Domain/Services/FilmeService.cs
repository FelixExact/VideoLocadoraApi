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
    public class FilmeService : IFilmeService
    {
        private readonly IRepository<Filme> _repository;

        public FilmeService(IRepository<Filme> repository)
        {
            _repository = repository;
        }

        public void Adicionar(Filme Filme)
        {
            _repository.Adicionar(Filme);
        }

        public Filme Atualizar(Filme Filme)
        {
            return _repository.Atualizar(Filme);
        }

        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Filme ObterPorId(Guid id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<Filme> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _repository.Remover(id);
        }
    }
}
