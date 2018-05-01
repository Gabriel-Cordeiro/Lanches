using System;
using dominio.interfaces.servicos;
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
            try
            {
                var lstIngredientes = _ingrediente.PegarTodosIngredientes();
                return StatusCode(200, lstIngredientes);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

        }
    }
}