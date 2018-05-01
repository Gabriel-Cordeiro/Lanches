using dominio.interfaces.memoria;
using dominio.interfaces.servicos;
using dominio.models;
using dominio.servicos;
using infraestrutura.memoria;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static dominio.models.Ingrediente;

namespace Lanches.Testes
{
    [TestClass]
    public class IngredienteServicoTeste
    {
        internal IIngredienteServico _ingredienteServico;
        internal IIngredienteDados _ingredienteDados;


        public void Initialize()
        {
            _ingredienteDados = new IngredienteDados();
            _ingredienteServico = new IngredienteServico(_ingredienteDados);
        }
        [TestMethod]
        public void PegarTodosIngredientes_CompararTotalIngredientes_DeveRetornarVerdadeiro()
        {

            Initialize();

            List<Ingrediente> ValorEsperado = new List<Ingrediente> {
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.Alface, NomeIngrediente =  enumIngredientes.Alface.ToString(), ValorIngrediente = 0.40M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.Bacon, NomeIngrediente =  enumIngredientes.Bacon.ToString(), ValorIngrediente = 2.00M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.HamburguerCarne, NomeIngrediente =  enumIngredientes.HamburguerCarne.ToString(), ValorIngrediente = 3.00M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.Ovo, NomeIngrediente =  enumIngredientes.Ovo.ToString(), ValorIngrediente = 0.80M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.Queijo, NomeIngrediente =  enumIngredientes.Queijo.ToString(), ValorIngrediente = 1.50M}
            };

            List<Ingrediente> resultadoAtual = _ingredienteServico.PegarTodosIngredientes();
            Assert.IsTrue(ValorEsperado.Count == resultadoAtual.Count);

        }

        [TestMethod]
        public void Ingrediente_QuandoInformarONome_RetornaIngrediente()
        {
            Initialize();

            string ingredienteNome = "Alface";

            var esperado = new Ingrediente { CodigoIngrediente = 1, NomeIngrediente = "Alface", ValorIngrediente = 0.40M };
            var atual = _ingredienteServico.PegarIngredientePorNome(ingredienteNome);

            Assert.AreEqual(esperado.NomeIngrediente, atual.NomeIngrediente);
        }


    }
}
