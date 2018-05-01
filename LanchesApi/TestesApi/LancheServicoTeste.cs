using dominio.interfaces.memoria;
using dominio.interfaces.servicos;
using dominio.models;
using dominio.servicos;
using infraestrutura.memoria;
using infraestrutura.memoria.repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using static dominio.models.Ingrediente;
using static dominio.models.Lanche;

namespace Lanches.Testes
{
    [TestClass]
   public class LancheServicoTeste
    {
        internal ILancheServico _lancheServico;
        internal ILancheDados _lancheDados;
        internal IIngredienteServico _ingredienteServico;
        internal IIngredienteDados _ingredienteDados;

        public void Initialize()
        {
            _ingredienteDados = new IngredienteDados();
            _ingredienteServico = new IngredienteServico(_ingredienteDados);
            _lancheDados = new LancheDados(_ingredienteDados);
            _lancheServico = new LancheServico(_lancheDados);

        }

        [TestMethod]
        public void PromocaoLight_DeveRetornarLancheComDesconto() {
            Initialize();

            var todosIngredientesParaPromocaoLight = _ingredienteServico.PegarTodosIngredientes().Where(x => x.NomeIngrediente != "Bacon").ToList();
            var totalLanche = todosIngredientesParaPromocaoLight.Sum(x => x.ValorIngrediente);
            var totalLancheComDesconto = totalLanche - (totalLanche * 0.10M);
            var atual = _lancheServico.MontarLancheCustomizado(todosIngredientesParaPromocaoLight);

            Assert.AreEqual(atual.DescontoLight, true);
            Assert.AreEqual(atual.Valor, totalLancheComDesconto);

        }


        [TestMethod]
        public void PromocaoMuitoHamburguer_DeveRetornarLancheComDesconto()
        {
            Initialize();

            List<Ingrediente> lstIngredientes = new List<Ingrediente> {
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.HamburguerCarne, NomeIngrediente =  enumIngredientes.HamburguerCarne.ToString(), ValorIngrediente = 3.00M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.HamburguerCarne, NomeIngrediente =  enumIngredientes.HamburguerCarne.ToString(), ValorIngrediente = 3.00M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.HamburguerCarne, NomeIngrediente =  enumIngredientes.HamburguerCarne.ToString(), ValorIngrediente = 3.00M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.HamburguerCarne, NomeIngrediente =  enumIngredientes.HamburguerCarne.ToString(), ValorIngrediente = 3.00M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.HamburguerCarne, NomeIngrediente =  enumIngredientes.HamburguerCarne.ToString(), ValorIngrediente = 3.00M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.HamburguerCarne, NomeIngrediente =  enumIngredientes.HamburguerCarne.ToString(), ValorIngrediente = 3.00M},
            };

            var valorTotalSemDesconto = lstIngredientes.Sum(x => x.ValorIngrediente);
            var valorFinalEsperado = lstIngredientes.First().ValorIngrediente * 4;
            var atual = _lancheServico.MontarLancheCustomizado(lstIngredientes);

            Assert.AreEqual(valorFinalEsperado, atual.Valor);
            Assert.AreEqual(atual.DescontoMuitaCoisa, true);

        }

        [TestMethod]
        public void PromocaoMuitoQueijo_DeveRetornarLancheComDesconto()
        {
            Initialize();

            List<Ingrediente> lstIngredientes = new List<Ingrediente> {
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.Queijo, NomeIngrediente =  enumIngredientes.Queijo.ToString(), ValorIngrediente = 3.00M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.Queijo, NomeIngrediente =  enumIngredientes.Queijo.ToString(), ValorIngrediente = 3.00M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.Queijo, NomeIngrediente =  enumIngredientes.Queijo.ToString(), ValorIngrediente = 3.00M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.Queijo, NomeIngrediente =  enumIngredientes.Queijo.ToString(), ValorIngrediente = 3.00M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.Queijo, NomeIngrediente =  enumIngredientes.Queijo.ToString(), ValorIngrediente = 3.00M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.Queijo, NomeIngrediente =  enumIngredientes.Queijo.ToString(), ValorIngrediente = 3.00M},
            };

            var valorTotalSemDesconto = lstIngredientes.Sum(x => x.ValorIngrediente);
            var valorFinalEsperado = lstIngredientes.First().ValorIngrediente * 4;
            var atual = _lancheServico.MontarLancheCustomizado(lstIngredientes);

            Assert.AreEqual(valorFinalEsperado, atual.Valor);
            Assert.AreEqual(atual.DescontoMuitaCoisa, true);

        }

        [TestMethod]
        public void XBurguer_QuandoEscolherXBurguer_DevolverLanche()
        {          
            Initialize();

            var valorEsperado = 4.5M;

            var valorIngredientes = _ingredienteDados.PegarTodosIngredientes().Where(x => x.CodigoIngrediente == 
                                            (int)enumIngredientes.HamburguerCarne || x.CodigoIngrediente == (int)enumIngredientes.Queijo).ToList()
                                            .Sum(x=>x.ValorIngrediente);

            var valorAtual = _lancheDados.PegarTodosLanches().Where(x => x.Codigo == (int)enumLanches.XBurguer).FirstOrDefault().Valor;

            Assert.AreEqual(valorEsperado, valorIngredientes);
            Assert.AreEqual(valorIngredientes, valorAtual);

        }

        [TestMethod]
        public void XBacon_QuandoEscolherXBacon_DevolverLanche()
        {
            Initialize();

            var valorEsperado = 6.5M;
            var valorIngredientes = _ingredienteDados.PegarTodosIngredientes().Where(x => x.CodigoIngrediente ==
                                            (int)enumIngredientes.HamburguerCarne
                                            || x.CodigoIngrediente == (int)enumIngredientes.Queijo
                                            || x.CodigoIngrediente == (int)enumIngredientes.Bacon).ToList()
                                            .Sum(x => x.ValorIngrediente);

            var valorAtual = _lancheDados.PegarTodosLanches().Where(x => x.Codigo == (int)enumLanches.XBacon).FirstOrDefault().Valor;
            Assert.AreEqual(valorEsperado, valorIngredientes);
            Assert.AreEqual(valorIngredientes, valorAtual);
        }

        [TestMethod]
        public void XEgg_QuandoEscolherXEgg_DevolverLanche()
        {
            Initialize();

            var valorEsperado = 5.3M;
            var valorIngredientes = _ingredienteDados.PegarTodosIngredientes().Where(x => x.CodigoIngrediente ==
                                            (int)enumIngredientes.HamburguerCarne
                                            || x.CodigoIngrediente == (int)enumIngredientes.Queijo
                                            || x.CodigoIngrediente == (int)enumIngredientes.Ovo).ToList()
                                            .Sum(x => x.ValorIngrediente);

            var valorAtual = _lancheDados.PegarTodosLanches().Where(x => x.Codigo == (int)enumLanches.XEgg).FirstOrDefault().Valor;

            Assert.AreEqual(valorEsperado, valorIngredientes);
            Assert.AreEqual(valorIngredientes, valorAtual);

        }

        [TestMethod]
        public void XEggBacon_QuandoEscolherXEggBacon_DevolverLanche()
        {
            Initialize();

            var valorEsperado = 7.3M;
            var valorIngredientes = _ingredienteDados.PegarTodosIngredientes().Where(x => x.CodigoIngrediente ==
                                            (int)enumIngredientes.HamburguerCarne
                                            || x.CodigoIngrediente == (int)enumIngredientes.Queijo
                                            || x.CodigoIngrediente == (int)enumIngredientes.Ovo
                                            || x.CodigoIngrediente == (int)enumIngredientes.Bacon).ToList()
                                            .Sum(x => x.ValorIngrediente);

            var valorAtual = _lancheDados.PegarTodosLanches().Where(x => x.Codigo == (int)enumLanches.XEggBacon).FirstOrDefault().Valor;

            Assert.AreEqual(valorEsperado, valorIngredientes);
            Assert.AreEqual(valorIngredientes, valorAtual);

        }
    }
}
