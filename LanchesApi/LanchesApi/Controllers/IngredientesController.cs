using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dominio.interfaces.servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanchesApi.Controllers
{
    //[Produces("application/json")]
    
    public class IngredientesController : Controller
    {
        private readonly IIngredienteServico _ingrediente;
        public IngredientesController(IIngredienteServico ingrediente)
        {
            _ingrediente = ingrediente;
        }


        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult RetornaTodosIngredientes()
        {
            var lstIngredientes = _ingrediente.PegarTodosIngredientes();
            return StatusCode(200, lstIngredientes);
        }
    }
}