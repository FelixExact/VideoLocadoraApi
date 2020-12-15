﻿using FD.Videolocadora.Application.Interfaces;
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
    public class FilmeController : ApiController
    {
        private readonly IEntityAppService<Filme> _appService;

        public FilmeController(IEntityAppService<Filme> appService)
        {
            _appService = appService;
        }


        // GET: api/Filme
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

        // GET: api/Filme/5
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

        // POST: api/Filme
        public IHttpActionResult Post([FromBody] FilmeModel value)
        {
            try
            {
                Filme f = value.ToEntity();
                _appService.Adicionar(f);
                return Ok();
            }
            catch
            {
                return BadRequest("Aconteceu um erro!");
            }
            
        }

        // PUT: api/Filme/5
        public IHttpActionResult Put(Guid id, [FromBody]FilmeModel value)
        {
            try
            {
                Filme novo = new Filme();
                novo.FilmeId = id;
                novo.Nome = value.Nome;
                novo.GeneroId = value.GeneroId;
                novo.Valor = value.Valor;
                novo.Disponivel = 1;
                
                return Ok(_appService.Atualizar(novo));
            }
            catch
            {
                return BadRequest("Aconteceu um erro!");
            }
        }

        // DELETE: api/Filme/5
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
