using FD.Videolocadora.Api.Cache;
using FD.Videolocadora.Application.Interfaces;
using FD.Videolocadora.Application.Models;
using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Helper;
using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Web.Http;

namespace FD.Videolocadora.Api.Controllers
{
    public class GeneroController : ApiController
    {
        private readonly IGeneroAppService _generoAppService;
        private readonly ICache _cache ;
        private const string _CONNECTION_STRING = "Endpoint=sb://spottermessagebusdev.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=qhv+vddxzeoK0KFj7xMWovjvXKUEIzyjcRHYfQbNSus=";
        private const string _NAME_QUEUE = "treinamento_felix";
        static QueueClient _Queue;

        public GeneroController(IGeneroAppService generoAppService, ICache cache)
        {
            _generoAppService = generoAppService;
            _cache = cache;
        }
        // GET: api/Genero
        public IHttpActionResult Get()
        {
            try
            {
                //_cache.SetCache("teste1", _generoAppService.ObterTodos());
                //var a = _cache.GetCache("teste1");

                return Ok(_generoAppService.ObterTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Genero/5
        public IHttpActionResult Get(Guid id)
        {
            try
            {

                return Ok(_generoAppService.ObterPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Genero
        public IHttpActionResult Post([FromBody] GeneroModel value)
        {
            try
            {
                if (value == null) { throw new Exception("Json invalido."); }

                Genero g = value.ToEntity();
                //--------   Service Bus
                var message = new Message(Encoding.Default.GetBytes(StackExchangeRedisExtension.ToJson(g)));
                _Queue = new QueueClient(_CONNECTION_STRING, _NAME_QUEUE);

                _Queue.SendAsync(message);
                //--------
                //_generoAppService.Adicionar(g);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // PUT: api/Genero/5
        public IHttpActionResult Put(Guid id, [FromBody] GeneroModel value)
        {


            try
            {
                if (value == null) { throw new Exception("Json invalido."); }
                Genero novoGenero = new Genero();
                novoGenero.GeneroId = id;
                novoGenero.Nome = value.Nome;
                _generoAppService.Atualizar(novoGenero);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Genero/5
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                _generoAppService.Remover(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
