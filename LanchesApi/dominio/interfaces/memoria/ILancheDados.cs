using dominio.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dominio.interfaces.memoria
{
    public interface ILancheDados
    {
        List<Lanche> PegarTodosLanches();
    }
}
