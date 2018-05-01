using dominio.models;
using System.Collections.Generic;

namespace dominio.interfaces.memoria
{
    public interface ILancheDados
    {
        List<Lanche> PegarTodosLanches();
    }
}
