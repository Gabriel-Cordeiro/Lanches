using dominio.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dominio.interfaces.servicos
{
    public interface ILancheServico
    {
        List<Lanche> PegarTodosLanchesProntos();

        Lanche MontarLancheCustomizado(List<Ingrediente> lstIngredientes);

    }
}
