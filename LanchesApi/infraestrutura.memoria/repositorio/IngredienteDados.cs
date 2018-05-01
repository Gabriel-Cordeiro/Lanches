using dominio.interfaces.memoria;
using dominio.models;
using System.Collections.Generic;
using System.Linq;
using static dominio.models.Ingrediente;

namespace infraestrutura.memoria
{
    public class IngredienteDados : IIngredienteDados
    {
        internal List<Ingrediente> _ingredientes = new List<Ingrediente>
        {
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.Alface, NomeIngrediente =  enumIngredientes.Alface.ToString(), ValorIngrediente = 0.40M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.Bacon, NomeIngrediente =  enumIngredientes.Bacon.ToString(), ValorIngrediente = 2.00M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.HamburguerCarne, NomeIngrediente =  enumIngredientes.HamburguerCarne.ToString(), ValorIngrediente = 3.00M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.Ovo, NomeIngrediente =  enumIngredientes.Ovo.ToString(), ValorIngrediente = 0.80M},
            new Ingrediente {CodigoIngrediente = (int)enumIngredientes.Queijo, NomeIngrediente =  enumIngredientes.Queijo.ToString(), ValorIngrediente = 1.50M}
        };

        public List<Ingrediente> PegarTodosIngredientes()
        {
            return _ingredientes;
        }

        public Ingrediente PegarIngredientePorNome(string nome)
        {
            return _ingredientes.Where(x=>x.NomeIngrediente == nome).FirstOrDefault();
        }

        public Ingrediente PegarIngredientePorCodigo(int codigo)
        {
            return _ingredientes.Where(x => x.CodigoIngrediente == codigo).FirstOrDefault();

        }
    }
}
