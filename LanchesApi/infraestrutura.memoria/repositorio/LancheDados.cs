using dominio.interfaces.memoria;
using dominio.models;
using System.Collections.Generic;
using System.Linq;
using static dominio.models.Ingrediente;
using static dominio.models.Lanche;

namespace infraestrutura.memoria.repositorio
{
    public class LancheDados : ILancheDados
    {
        private readonly IIngredienteDados _ingredientes;

        public LancheDados(IIngredienteDados ingredientes)
        {
            _ingredientes = ingredientes;
        }
        public List<Lanche> PegarTodosLanches()
        {
            return new List<Lanche>
            {
                MontaXBacon(),
                MontaXBurguer(),
                MontaXEgg(),
                MontaXEggBacon()
            };
        }

        private Lanche MontaXBurguer()
        {
            Lanche xBurguer = new Lanche
            {
                Codigo = (int)enumLanches.XBurguer,
                NomeLanche = enumLanches.XBurguer.ToString(),
                Ingredientes = new List<Ingrediente>
                {
                _ingredientes.PegarIngredientePorCodigo((int)enumIngredientes.HamburguerCarne),
                _ingredientes.PegarIngredientePorCodigo((int)enumIngredientes.Queijo)
                },
            };

            xBurguer.Valor = xBurguer.Ingredientes.Sum(x => x.ValorIngrediente);

            return xBurguer;

        }

        private Lanche MontaXBacon()
        {
            Lanche XBacon = new Lanche
            {
                Codigo = (int)enumLanches.XBacon,
                NomeLanche = enumLanches.XBacon.ToString(),
                Ingredientes = new List<Ingrediente>
                {
                _ingredientes.PegarIngredientePorCodigo((int)enumIngredientes.HamburguerCarne),
                _ingredientes.PegarIngredientePorCodigo((int)enumIngredientes.Queijo),
                _ingredientes.PegarIngredientePorCodigo((int)enumIngredientes.Bacon)
                },
            };

            XBacon.Valor = XBacon.Ingredientes.Sum(x => x.ValorIngrediente);

            return XBacon;

        }

        private Lanche MontaXEgg()
        {
            Lanche xEgg = new Lanche
            {
                Codigo = (int)enumLanches.XEgg,
                NomeLanche = enumLanches.XEgg.ToString(),
                Ingredientes = new List<Ingrediente>
                {
                _ingredientes.PegarIngredientePorCodigo((int)enumIngredientes.HamburguerCarne),
                _ingredientes.PegarIngredientePorCodigo((int)enumIngredientes.Queijo),
                _ingredientes.PegarIngredientePorCodigo((int)enumIngredientes.Ovo)
                },
            };

            xEgg.Valor = xEgg.Ingredientes.Sum(x => x.ValorIngrediente);

            return xEgg;

        }

        private Lanche MontaXEggBacon()
        {
            Lanche xEggBacon = new Lanche
            {
                Codigo = (int)enumLanches.XEggBacon,
                NomeLanche = enumLanches.XEggBacon.ToString(),
                Ingredientes = new List<Ingrediente>
                {
                _ingredientes.PegarIngredientePorCodigo((int)enumIngredientes.HamburguerCarne),
                _ingredientes.PegarIngredientePorCodigo((int)enumIngredientes.Queijo),
                _ingredientes.PegarIngredientePorCodigo((int)enumIngredientes.Ovo),
                _ingredientes.PegarIngredientePorCodigo((int)enumIngredientes.Bacon)
                },
            };

            xEggBacon.Valor = xEggBacon.Ingredientes.Sum(x => x.ValorIngrediente);

            return xEggBacon;

        }

    }
}
