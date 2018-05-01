using dominio.interfaces.memoria;
using dominio.interfaces.servicos;
using dominio.models;
using System.Collections.Generic;

namespace dominio.servicos
{
    public class IngredienteServico : IIngredienteServico
    {
        private readonly IIngredienteDados _ingredientes;

        public IngredienteServico(IIngredienteDados ingredientes)
        {
            _ingredientes = ingredientes;
        }

        /// <summary>
        /// Retorna todos os ingredientes criados da classe IngredienteDados.cs no projeto infraestrutura.memoria
        /// </summary>
        public List<Ingrediente> PegarTodosIngredientes()
        {
            return _ingredientes.PegarTodosIngredientes();
        }

        /// <summary>
        /// Retorna ingrediente por nome da classe IngredienteDados.cs no projeto infraestrutura.memoria
        /// </summary>
        /// <param name="lista Ingredientes"></param>
        public Ingrediente PegarIngredientePorNome(string NomeIngrendiente)
        {
            return _ingredientes.PegarIngredientePorNome(NomeIngrendiente);
        }


    }
}
