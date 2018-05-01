using dominio.interfaces.memoria;
using dominio.interfaces.servicos;
using dominio.models;
using System.Collections.Generic;
using System.Linq;

namespace dominio.servicos
{
    public class LancheServico : ILancheServico
    {
        private readonly ILancheDados _lancheDados;

        public LancheServico(ILancheDados lancheDados)
        {
            _lancheDados = lancheDados;
        }

        /// <summary>
        /// Recebe lista de ingredientes personalizada e monta um novo Lanche
        /// </summary>
        /// <param name="lista Ingredientes"></param>
        public Lanche MontarLancheCustomizado(List<Ingrediente> lstIngredientes)
        {
            return new Lanche { Codigo = 4, NomeLanche = "Customizado" ,Ingredientes = lstIngredientes, Valor = lstIngredientes.Sum(x => x.ValorIngrediente) };
           
        }

        /// <summary>
        /// Retorna lista de todos os lanches prontos criados na classe LanchesDados no projeto infraestrutura.memoria
        /// </summary>
        public List<Lanche> PegarTodosLanchesProntos()
        {
           return  _lancheDados.PegarTodosLanches();
        }
    }
}
