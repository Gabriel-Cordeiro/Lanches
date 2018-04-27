namespace dominio.models
{
    public class Ingrediente
    {
        public string NomeIngrediente { get; set; }
        public decimal ValorIngrediente { get; set; }
        public enum enumIngredientes
        {
            Alface = 0,
            Bacon = 1,
            HamburguerCarne = 2,
            Ovo = 3,
            Queijo = 4
        }
    }
}
