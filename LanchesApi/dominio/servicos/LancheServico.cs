using dominio.interfaces.memoria;
using dominio.interfaces.servicos;
using dominio.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dominio.servicos
{
    public class LancheServico : ILancheServico
    {
        private readonly ILancheDados _lancheDados;

        public LancheServico(ILancheDados lancheDados)
        {
            _lancheDados = lancheDados;
        }


        public Lanche MontarLancheCustomizado(List<Ingrediente> lstIngredientes)
        {
            return new Lanche { Codigo = 4, NomeLanche = "Customizado" ,Ingredientes = lstIngredientes, Valor = lstIngredientes.Sum(x => x.ValorIngrediente) };
           
        }


        public List<Lanche> PegarTodosLanchesProntos()
        {
           return  _lancheDados.PegarTodosLanches();
        }
    }
}
