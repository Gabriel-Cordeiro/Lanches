using dominio.interfaces.memoria;
using dominio.interfaces.servicos;
using dominio.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dominio.servicos
{
    public class IngredienteServico : IIngredienteServico
    {
        private readonly IIngredienteDados _ingredientes;

        public IngredienteServico(IIngredienteDados ingredientes)
        {
            _ingredientes = ingredientes;
        }

        public IEnumerable<Ingrediente> PegarTodosIngredientes()
        {
            return _ingredientes.PegarTodosIngredientes();
        }
    }
}
