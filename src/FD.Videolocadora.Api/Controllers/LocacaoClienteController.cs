using FD.Videolocadora.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FD.Videolocadora.Api.Controllers
{
    public class LocacaoClienteController : ApiController
    {

        private readonly ILocacaoAppService _appService;
        public LocacaoClienteController(ILocacaoAppService appService)
        {
            _appService = appService;
        }


        // DELETE: api/LocacaoCliente/5
        public IHttpActionResult Delete(Guid id)
        {

            try
            {
                _appService.RemoverPorUsuario(id);
                return Ok();

            }
            catch
            {
                return BadRequest("Aconteceu um erro!");
            }

        }
    }
}
