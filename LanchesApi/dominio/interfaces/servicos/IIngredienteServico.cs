using dominio.models;
using System.Collections.Generic;

namespace dominio.interfaces.servicos
{
    public interface IIngredienteServico
    {
        List<Ingrediente> PegarTodosIngredientes();

        Ingrediente PegarIngredientePorNome(string NomeIngrendiente);
    }
}
