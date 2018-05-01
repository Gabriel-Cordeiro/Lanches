using dominio.models;
using System.Collections.Generic;

namespace dominio.interfaces.memoria
{
    public interface IIngredienteDados
    {
        List<Ingrediente> PegarTodosIngredientes();

        Ingrediente PegarIngredientePorNome(string nome);

        Ingrediente PegarIngredientePorCodigo(int codigo);
    }
}
