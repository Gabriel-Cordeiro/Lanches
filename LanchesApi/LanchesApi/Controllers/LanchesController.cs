using System;
using System.Collections.Generic;
using dominio.interfaces.servicos;
using dominio.models;
using Microsoft.AspNetCore.Mvc;

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
            try
            {
                var lstLanches = _lancheServico.PegarTodosLanchesProntos();
                return StatusCode(200, lstLanches);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }


        [HttpPost]
        [Route("api/Customizado")]
        public IActionResult RetornaLancheCustomizado([FromBody] List<Ingrediente> lstQtdIngredientes)
        {
            if (lstQtdIngredientes == null)
            {
                return BadRequest( new {erro = "Não foram enviados nenhuma informação de ingredientes" });
                }
            else
            {
                try
                {
                    List<Ingrediente> lstingredientes = new List<Ingrediente>();
                    lstQtdIngredientes.ForEach(x =>
                    {
                        lstingredientes.Add(_ingredienteServico.PegarIngredientePorNome(x.NomeIngrediente));
                    });

                    var lancheCustomizado = _lancheServico.MontarLancheCustomizado(lstingredientes);
                    return Ok(lancheCustomizado);
                }
                catch (Exception)
                {

                    return BadRequest(new { erro = "Erro ao tentar buscar ingredientes, verifique os dados enviados" });
                }

            }
        }

    }
}