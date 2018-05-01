using dominio.models;
using System.Collections.Generic;

namespace dominio.interfaces.servicos
{
    public interface ILancheServico
    {
        List<Lanche> PegarTodosLanchesProntos();

        Lanche MontarLancheCustomizado(List<Ingrediente> lstIngredientes);

    }
}
