using FD.Videolocadora.Application;
using FD.Videolocadora.Application.Interfaces;
using FD.Videolocadora.Application.Models;
using FD.Videolocadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FD.Videolocadora.Api.Controllers
{
    public class LocacaoController : ApiController
    {
        private readonly ILocacaoAppService _appService;
        public LocacaoController(ILocacaoAppService appService)
        {
            _appService = appService;
        }

        // GET: api/locacao
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_appService.ObterTodos());

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/locacao/5
        public IHttpActionResult Get(Guid id)
        {

            try
            {
                return Ok(_appService.ObterPorId(id));

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // POST: api/locacao
        public IHttpActionResult Post([FromBody] LocacaoModel value)
        {
            try
            
            {
                if (value == null) { throw new Exception("Json invalido."); }
                Locacao l = value.ToEntity();
                _appService.Adicionar(l);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // PUT: api/locacao/5
        public IHttpActionResult Put(Guid id, [FromBody] Locacao value)
        {
            
            try
            {
                if (value == null) { throw new Exception("Json invalido."); }
                Locacao novo = new Locacao();
                novo.LocacaoId = id;
                novo.FilmeId = value.FilmeId;
                novo.UsuarioId = value.UsuarioId;
                novo.DataDevolucao = value.DataDevolucao;
                _appService.Atualizar(novo);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/locacao/5
        public IHttpActionResult Delete(Guid id)
        {

            try
            {
                _appService.Remover(id);
                return Ok();

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

    }
}
