using dominio.interfaces.memoria;
using dominio.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static dominio.models.Ingrediente;

namespace infraestrutura.memoria
{
    public class IngredienteDados : IIngredienteDados
    {
        internal List<Ingrediente> _ingredientes = new List<Ingrediente>
        {
            new Ingrediente {NomeIngrediente =  enumIngredientes.Alface.ToString(), ValorIngrediente = 0.40M},
            new Ingrediente {NomeIngrediente =  enumIngredientes.Bacon.ToString(), ValorIngrediente = 2.00M},
            new Ingrediente {NomeIngrediente =  enumIngredientes.HamburguerCarne.ToString(), ValorIngrediente = 3.00M},
            new Ingrediente {NomeIngrediente =  enumIngredientes.Ovo.ToString(), ValorIngrediente = 0.80M},
            new Ingrediente {NomeIngrediente =  enumIngredientes.Queijo.ToString(), ValorIngrediente = 1.50M}
        };

        public List<Ingrediente> PegarTodosIngredientes()
        {
            return _ingredientes;
        }

        public Ingrediente PegarIngredientePorNome(string nome)
        {
            return _ingredientes.Where(x=>x.NomeIngrediente == nome).FirstOrDefault();
        }
    }
}
