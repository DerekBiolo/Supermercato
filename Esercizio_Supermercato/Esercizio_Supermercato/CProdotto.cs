namespace Esercizio_Supermercato
{
    public class CProdotto
    {
        public string Categoria { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
        public int Quantita { get; set; }

        public override string ToString()
        {
            return $"{Nome} - {Prezzo:C}";
        }
    }
}
