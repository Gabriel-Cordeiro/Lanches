using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static dominio.models.Ingrediente;

namespace dominio.models
{
    public class Lanche
    {
        public int Codigo { get; set; }
        public string NomeLanche { get; set; }
        public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();
        public bool DescontoLight { get; private set; }
        public bool DescontoMuitaCoisa { get; private set; }
        private bool _muitaCoisa { get; set; }

        private decimal _valor;
        public decimal Valor
        {
            get { return _valor; }
            set
            {
                _valor = value;
                PromocaoLight(Ingredientes);
                PromocaoMuitoIngrediente(Ingredientes.Where(i => i.CodigoIngrediente == (int)enumIngredientes.HamburguerCarne).ToList());
                PromocaoMuitoIngrediente(Ingredientes.Where(i => i.CodigoIngrediente == (int)enumIngredientes.Queijo).ToList());
            }
        }

        public enum enumLanches
        {
            XBacon = 1,
            XBurguer = 2,
            XEgg = 3,
            XEggBacon = 4,
        }

        /// <summary>
        /// Verifica se o lanche se enquadra na promoção Light(Com Alface e sem Bacon)
        /// </summary>
        /// <param name="Ingredientes"></param>
        public void PromocaoLight(List<Ingrediente> lstIngredientes)
        {
            var TemPromocao = !lstIngredientes.Any(x => x.CodigoIngrediente.Equals((int)enumIngredientes.Bacon)) &&
                              lstIngredientes.Any(x => x.CodigoIngrediente.Equals((int)enumIngredientes.Alface));

            if (TemPromocao)
            {
                _valor -= _valor * 0.10M;
                DescontoLight = true;
            }
        }

        /// <summary>
        /// Caso haja 3 porções de carne ou queijo o cliente só paga 2
        /// </summary>
        /// <param name="Ingredientes"></param>
        public void PromocaoMuitoIngrediente(List<Ingrediente> lstIngredientes)
        {
            if (lstIngredientes.Count > 0)
            {
                var valorDesconto = (lstIngredientes.Count() / 3) >= 1 ? lstIngredientes.Count() / 3 : 0;
                if (valorDesconto > 0)
                {
                    _valor -= lstIngredientes.First().ValorIngrediente * valorDesconto;
                    DescontoMuitaCoisa = true;
                }
            }

        }

    }
}
