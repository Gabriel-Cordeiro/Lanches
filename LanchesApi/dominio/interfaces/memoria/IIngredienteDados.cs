using dominio.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dominio.interfaces.memoria
{
    public interface IIngredienteDados
    {
        List<Ingrediente> PegarTodosIngredientes();

        Ingrediente PegarIngredientePorNome(string nome);

        Ingrediente PegarIngredientePorCodigo(int codigo);
    }
}
