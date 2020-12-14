using FD.Videolocadora.Application;
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
            catch
            {
                return BadRequest("Aconteceu um erro!");
            }
        }

        // GET: api/Usuario/5
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                return Ok(_appService.ObterPorId(id));

            }
            catch
            {
                return BadRequest("Aconteceu um erro!");
            }
            
        }

         //POST: api/Usuario
        public IHttpActionResult Post([FromBody] UsuarioModel value)
        {
            try
            {
                UsuarioModel model =_appService.Adicionar(value);
                if (!model.ValidationResult.IsValid) 
                {
                    String RetornoErro = "";
                    foreach (var erro in model.ValidationResult.Erros)
                    {
                        RetornoErro = RetornoErro + " " + erro.Message;

                        //erro (string.empty, erro.message)
                    }
                    return BadRequest(RetornoErro);
                }
                return Ok("Sucesso!!");

            }
            catch
            {
                return BadRequest("Aconteceu um erro!");
            }
        }
        
        // PUT: api/Usuario/5
        public IHttpActionResult Put(Guid id, [FromBody] UsuarioModel value)
        {
            
            try
            {
                UsuarioModel novo = new UsuarioModel();
                novo.Usuarioid = id;
                novo.CPF = value.CPF;
                novo.DataNascimento = value.DataNascimento;
                novo.Endereco = value.Endereco;
                novo.Nome = value.Nome;
                novo.Ativo = value.Ativo;
                _appService.Atualizar(novo);
                return Ok();
            }
            catch
            {
                return BadRequest("Aconteceu um erro!");
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
            catch
            {
                return BadRequest("Aconteceu um erro!");
            }
            
        }
    }
}
