using FD.Videolocadora.Application.Interfaces;
using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Interfaces.Services;
using FD.Videolocadora.Infra.Data.Interface;

namespace FD.Videolocadora.Application
{
    public class FilmeAppService : EntityAppService<Filme>, IFilmeAppService
    {
        private readonly IFilmeService _service;


        public FilmeAppService(IFilmeService service, IUnitOfWork uow)
            : base(service, uow)
        {
            _service = service;
        }

        public override Filme Adicionar(Filme filmeModel)
        {
            var filme = _service.Adicionar(filmeModel);
            return filme;
        }

        public override Filme Atualizar(Filme filme)
        {
            _service.Atualizar(filme);
            return filme;
        }

        //public void Dispose()
        //{
        //    _service.Dispose();
        //    GC.SuppressFinalize(this);
        //}
        //
        //public Filme ObterPorId(Guid id)
        //{
        //    return _service.ObterPorId(id);
        //}
        //
        //public IEnumerable<Filme> ObterTodos()
        //{
        //    return _service.ObterTodos();
        //}
        //
        //public void Remover(Guid id)
        //{
        //    _service.Remover(id);
        //}

    }
}
