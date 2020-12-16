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
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioAppService _appService;
        public UsuarioController(IUsuarioAppService appService)
        {
            _appService = appService;
        }
        // GET: api/Usuario
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

        // GET: api/Usuario/5
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

         //POST: api/Usuario
        public IHttpActionResult Post([FromBody] UsuarioModel value)
        {
            try
            {
                if (value == null) { throw new Exception("Json invalido."); }
                Usuario u = value.ToEntity();
                Usuario model =_appService.Adicionar(u);
                return Ok("Sucesso!!");

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // PUT: api/Usuario/5
        public IHttpActionResult Put(Guid id, [FromBody] UsuarioModel value)
        {
            
            try
            {
                if (value == null) { throw new Exception("Json invalido."); }
                Usuario novo = new Usuario();
                novo.Usuarioid = id;
                novo.CPF = value.CPF;
                novo.DataNascimento = value.DataNascimento;
                novo.Endereco = value.Endereco;
                novo.Nome = value.Nome;
                novo.Ativo = value.Ativo;
                _appService.Atualizar(novo);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
        
         //DELETE: api/Usuario/5
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
