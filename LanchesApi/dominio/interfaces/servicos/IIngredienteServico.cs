using dominio.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dominio.interfaces.servicos
{
    public interface IIngredienteServico
    {
        IEnumerable<Ingrediente> PegarTodosIngredientes();

        Ingrediente PegarIngredientePorNome(string NomeIngrendiente);
    }
}
