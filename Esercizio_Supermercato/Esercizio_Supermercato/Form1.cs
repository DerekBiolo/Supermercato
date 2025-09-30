namespace Esercizio_Supermercato
{
    public partial class Form1 : Form
    {
        private FStock stock; // stock 
        List<CProdotto> listaSpesa; // lista della spesa dell'utente

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stock = new FStock(); // creo un nuovo stock
            stock.ProdottiLoader(); // utilizzo la funzione prodotti loader per avere uno stock nel form1 ( principale ) nel caso mi serve in altri form
            btn_Paga.Enabled = false; // disattivo il pulsante all'inizo
            btn_Paga.BackColor = Color.DarkGray; //gli cambio il colore
            AggiornaLista(); // aggiorno la lista della spesa dell'utente
        }

        private void btn_visualizzaStock_Click(object sender, EventArgs e)
        {
            stock.ShowDialog(); // mostro lo stock
        }

        private void btn_scansionaProdotto_Click(object sender, EventArgs e)
        {
            if (listaSpesa == null || listaSpesa.Count == 0) // se la mia lista e vuota allora ne creo una nuova, altrimenti vuol dire che ho gia messo qualcosa nel carrello
            {
                listaSpesa = new List<CProdotto>();
            }

            FAcquisti fAcquisti = new FAcquisti(stock.Prodotti, listaSpesa); // mostro il form per acquistare
            fAcquisti.ShowDialog();

            //quando viene chiuso il form prendo la lista della spesa
            listaSpesa = fAcquisti.GetCarrello(); // prendo il carrello del form d'acquisto
            btn_Paga.Enabled = (listaSpesa.Count > 0) ? true : false; // uso l'operatore ternario per attivarre/disattivare il pulsante paga
            if (btn_Paga.Enabled == true)
            {
                btn_Paga.BackColor = Color.Linen; // lo attivo se ce almeno un elemento nel carrello
            }
            AggiornaLista(); // aggiorno la lista della spesa
        }

        private void btn_Paga_Click(object sender, EventArgs e)
        {
            bool affiliato = false; // controlla il checkbox
            if (ckb_clienteAffiliato.Checked)
            {
                affiliato = true;
            }
            FPaga pagamento = new FPaga(affiliato, listaSpesa); // mando se e affiliato e la lista della spesa attuale
            pagamento.ShowDialog();
        }

        private void AggiornaLista()
        {
            lst_CarrelloCliente.Items.Clear(); // pulisco

            if (listaSpesa == null || listaSpesa.Count == 0)
            {
                lst_CarrelloCliente.Items.Add("Nessun elemento nel carrello");
            }
            else
            {
                foreach (var prodotto in listaSpesa)
                {
                    lst_CarrelloCliente.Items.Add($"{prodotto.Nome} x{prodotto.Quantita} - {prodotto.Prezzo:C} cadauno");
                }
            }
        }
    }
}
