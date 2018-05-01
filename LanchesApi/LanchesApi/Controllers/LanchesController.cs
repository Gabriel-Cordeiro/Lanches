using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dominio.interfaces.servicos;
using dominio.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LanchesApi.Controllers
{


    [Produces("application/json")]

    public class LanchesController : Controller
    {
        private readonly ILancheServico _lancheServico;
        private readonly IIngredienteServico _ingredienteServico;
        public LanchesController(ILancheServico lancheServico, IIngredienteServico ingredienteServico)
        {
            _lancheServico = lancheServico;
            _ingredienteServico = ingredienteServico;
        }

        [HttpGet]
        [Route("api/Lanches")]
        public IActionResult RetornaTodoslanches()
        {
            var lstLanches = _lancheServico.PegarTodosLanchesProntos();
            return StatusCode(200, lstLanches);
        }


        [HttpPost]
        [Route("api/Customizado")]
        public IActionResult RetornaLancheCustomizado([FromBody] List<Ingrediente> lstQtdIngredientes)
        {
            List<Ingrediente> lstingredientes = new List<Ingrediente>();
            lstQtdIngredientes.ForEach(x =>
            {
                lstingredientes.Add(_ingredienteServico.PegarIngredientePorNome(x.NomeIngrediente));
            });
            
            var lancheCustomizado = _lancheServico.MontarLancheCustomizado(lstingredientes);
            return StatusCode(200, lancheCustomizado);
        }


    }
}