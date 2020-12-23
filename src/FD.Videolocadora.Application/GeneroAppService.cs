using FD.Videolocadora.Application.Interfaces;
using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Interfaces.Services;
using FD.Videolocadora.Infra.Data.Interface;

namespace FD.Videolocadora.Application
{
    public class GeneroAppService : EntityAppService<Genero>, IGeneroAppService
    {
        private readonly IGeneroService _service;


        public GeneroAppService(IGeneroService service, IUnitOfWork uow)
            : base(service, uow)
        {
            _service = service;
        }



        public override Genero Adicionar(Genero generoModel)
        {
            var genero = generoModel;

            var retorno = _service.Adicionar(genero);
            return retorno;
        }

        public override Genero Atualizar(Genero genero)
        {
            _service.Atualizar(genero);
            return genero;
        }

        //public Genero ObterPorId(Guid id)
        //{
        //    return _service.ObterPorId(id);
        //}
        //
        //public IEnumerable<Genero> ObterTodos()
        //{
        //    return _service.ObterTodos();
        //}
        //
        //public void Remover(Guid id)
        //{
        //    _service.Remover(id);
        //}
        //
        //public void Dispose()
        //{
        //    _service.Dispose();
        //    GC.SuppressFinalize(this);
        //}
    }
}
