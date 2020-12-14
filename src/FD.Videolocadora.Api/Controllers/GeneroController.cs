
using FD.Videolocadora.Application.Interfaces;
using FD.Videolocadora.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FD.Videolocadora.Api.Controllers
{
    public class GeneroController : ApiController
    {
        private readonly IGeneroAppService _generoAppService;

        public GeneroController(IGeneroAppService generoAppService)
        {
            _generoAppService = generoAppService;
        }
        // GET: api/Genero
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_generoAppService.ObterTodos());
            }
            catch
            {
                return BadRequest("Aconteceu um erro!");
            }
        }

        // GET: api/Genero/5
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                return Ok(_generoAppService.ObterPorId(id));
            }
            catch
            {
                return BadRequest("Aconteceu um erro!");
            }
        }

        // POST: api/Genero
        public IHttpActionResult Post([FromBody] GeneroModel value)
        {
            try
            {
                _generoAppService.Adicionar(value);
                return Ok();
            }
            catch
            {
                return BadRequest("Aconteceu um erro!");
            }

        }

        // PUT: api/Genero/5
        public IHttpActionResult Put(Guid id, [FromBody] GeneroModel value)
        {
            

            try
            {
                GeneroModel novoGenero = new GeneroModel();
                novoGenero.GeneroId = id;
                novoGenero.Nome = value.Nome;
                _generoAppService.Atualizar(novoGenero);
                return Ok();
            }
            catch
            {
                return BadRequest("Aconteceu um erro!");
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
            catch
            {
                return BadRequest("Aconteceu um erro!");
            }
        }
    }
}
