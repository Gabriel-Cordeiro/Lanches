namespace dominio.models
{
    public class Ingrediente
    {
        public int CodigoIngrediente { get; set; }
        public string NomeIngrediente { get; set; }
        public decimal ValorIngrediente { get; set; }
        public enum enumIngredientes : int
        {
            Alface = 1,
            Bacon,
            HamburguerCarne,
            Ovo,
            Queijo
        }
    }
}
