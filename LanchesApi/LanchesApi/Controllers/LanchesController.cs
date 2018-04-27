using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dominio.interfaces.servicos;
using dominio.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanchesApi.Controllers
{


    [Produces("application/json")]

    public class LanchesController : Controller
    {
        private readonly ILancheServico _lancheServico;
        public LanchesController(ILancheServico lancheServico )
        {
            _lancheServico = lancheServico;
        }

        [HttpGet]
        [Route("api/Lanches")]
        public IActionResult RetornaTodoslanches()
        {
            var lstLanches =_lancheServico.PegarTodosLanchesProntos();
            return StatusCode(200, lstLanches);
        }
        [HttpPost]
        [Route("api/LancheCustomizado")]
        public IActionResult RetornaLancheCustomizado([FromBody] List<Ingrediente> lstingredientes)
        {
            return StatusCode(200, "ok");
        }
    }
}