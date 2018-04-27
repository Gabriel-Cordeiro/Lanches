using System;
using System.Collections.Generic;
using System.Text;

namespace dominio.models
{
    public class Lanche
    {
        public int Codigo { get; set; }
        public string NomeLanche { get; set; }
        public IEnumerable<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();
        public decimal Total { get; set; }

        public enum enumLanches
        {
            XBacon = 1,
            XBurguer = 2,
            XEgg = 3,
            XEggBacon = 4,
        }

    }
}
