using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json; // Assicurati di avere Newtonsoft.Json via NuGet

namespace Esercizio_Supermercato
{
    public partial class FPaga : Form
    {
        private bool affiliato; // indica se il cliente ha diritto allo sconto
        private List<CProdotto> carrelloProdotti; // lista dei prodotti nel carrello
        private List<CProdotto> stockProdotti;    // lista dello stock

        // Percorso del file JSON
        private readonly string path;

        public FPaga(bool clienteAffiliato, List<CProdotto> carrello)
        {
            InitializeComponent();

            affiliato = clienteAffiliato; // memorizzo se il cliente è affiliato
            carrelloProdotti = carrello; // memorizzo il carrello passato dal form principale

            // Costruisco il path del file JSON
            string nameJson = "stock.json"; // nome file JSON
            string directory = Application.StartupPath; // directory dell'applicazione
            path = Path.Combine(directory, nameJson); // path completo

            // Carico stock dal JSON
            stockProdotti = CaricaStock();

            // Mostro messaggio iniziale in base all'affiliazione
            MessageBox.Show(affiliato
                ? "Cliente affiliato: sconto del 5% applicato"
                : "Cliente non affiliato: nessuno sconto applicato");

            // Calcolo totale e preparo la listbox come scontrino
            CalcolaTotale(); // calcolo totale e sconto
            InizializzaLista(); // preparo lista scontrino
        }

        private void btn_Paga_Click(object sender, EventArgs e)
        {
            // 1. Aggiorno lo stock sottraendo le quantità acquistate
            foreach (var prodottoCarrello in carrelloProdotti)
            {
                var prodottoStock = stockProdotti.FirstOrDefault(p => p.Nome == prodottoCarrello.Nome);
                if (prodottoStock != null)
                {
                    prodottoStock.Quantita -= prodottoCarrello.Quantita; // sottraggo quantità acquistata
                    if (prodottoStock.Quantita < 0) // controllo quantità negativa
                        prodottoStock.Quantita = 0;
                }
            }

            // 2. Salvo lo stock aggiornato sul file JSON
            SalvaStock(stockProdotti);

            // 3. Creo e apro il dialog di stampa
            using (PrintDialog printerDialog = new PrintDialog())
            {
                System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();

                // gestisco la stampa pagina per pagina
                printDoc.PrintPage += (s, ev) =>
                {
                    float yPos = 10; // posizione verticale iniziale
                    int leftMargin = 10; // margine sinistro

                    using (System.Drawing.Font font = new System.Drawing.Font("Consolas", 10))
                    {
                        // stampo ogni riga della listbox
                        foreach (string line in lst_Scontrino.Items)
                        {
                            ev.Graphics.DrawString(line, font, System.Drawing.Brushes.Black, leftMargin, yPos);
                            yPos += font.GetHeight(ev.Graphics); // incremento la posizione verticale
                        }
                    }
                };

                printerDialog.Document = printDoc; // assegno il documento al dialog
                if (printerDialog.ShowDialog() == DialogResult.OK) // se confermato
                {
                    printDoc.Print(); // eseguo la stampa
                }
            }

            // 4. Chiudo il form di pagamento
            this.Close();
        }

        /// <summary>
        /// Carica lo stock dal file JSON
        /// </summary>
        private List<CProdotto> CaricaStock()
        {
            try
            {
                if (File.Exists(path)) // se il file esiste
                {
                    string json = File.ReadAllText(path); // leggo il contenuto
                    return JsonConvert.DeserializeObject<List<CProdotto>>(json) ?? new List<CProdotto>(); // deserializzo in lista
                }
                else
                {
                    return new List<CProdotto>(); // ritorno lista vuota se il file non esiste
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dello stock: " + ex.Message); // messaggio di errore
                return new List<CProdotto>();
            }
        }

        /// <summary>
        /// Salva lo stock sul file JSON
        /// </summary>
        private void SalvaStock(List<CProdotto> stock)
        {
            try
            {
                string jsonAggiornato = JsonConvert.SerializeObject(stock, Formatting.Indented); // converto in JSON
                File.WriteAllText(path, jsonAggiornato); // scrivo su file
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel salvataggio dello stock: " + ex.Message); // messaggio di errore
            }
        }

        /// <summary>
        /// Calcola totale, sconto e aggiorna la label del totale
        /// </summary>
        private void CalcolaTotale()
        {
            decimal totale = carrelloProdotti.Sum(p => p.Prezzo * p.Quantita); // somma prezzo*quantità per ogni prodotto
            decimal sconto = affiliato ? totale * 0.05m : 0m; // calcolo sconto se affiliato
            decimal totaleScontato = totale - sconto; // totale dopo sconto

            lbl_Totale.Text = affiliato
                ? $"Totale: {totaleScontato:F2} $, applicato uno sconto di {sconto:F2} $" // testo se affiliato
                : $"Totale: {totaleScontato:F2} $"; // testo se non affiliato
        }

        /// <summary>
        /// Inizializza la listbox come uno scontrino allineato
        /// </summary>
        private void InizializzaLista()
        {
            lst_Scontrino.Items.Clear(); // pulisco listbox

            if (carrelloProdotti == null || carrelloProdotti.Count == 0) // se carrello vuoto
            {
                lst_Scontrino.Items.Add("Nessun prodotto nel carrello"); // messaggio vuoto
                return;
            }

            lst_Scontrino.Items.Add("======== SCONTRINO ========"); // intestazione
            lst_Scontrino.Items.Add(string.Format("{0,-20} {1,3} {2,8} {3,10}", "Prodotto", "Qty", "Prezzo", "Totale")); // intestazione colonne
            lst_Scontrino.Items.Add(new string('-', 45)); // linea separatrice

            foreach (var p in carrelloProdotti) // ciclo sui prodotti
            {
                decimal totaleProdotto = p.Prezzo * p.Quantita; // calcolo totale per prodotto
                string nomeProdotto = p.Nome.Length > 20 ? p.Nome.Substring(0, 20) : p.Nome; // taglio nome lungo

                // aggiungo riga alla listbox
                lst_Scontrino.Items.Add(string.Format("{0,-20} {1,3} {2,8:F2}$ {3,10:F2}$",
                    nomeProdotto,      // nome prodotto
                    p.Quantita,        // quantità
                    p.Prezzo,          // prezzo unitario
                    totaleProdotto));  // totale prodotto
            }

            decimal totale = carrelloProdotti.Sum(p => p.Prezzo * p.Quantita); // sommo tutto
            decimal sconto = affiliato ? totale * 0.05m : 0m; // calcolo sconto se affiliato
            decimal totaleScontato = totale - sconto; // totale finale

            lst_Scontrino.Items.Add(new string('-', 45)); // linea separatrice
            if (affiliato) // se cliente affiliato
                lst_Scontrino.Items.Add(string.Format("{0,-20} {1,24:F2}$", "Sconto 5%", sconto)); // linea sconto
            lst_Scontrino.Items.Add(string.Format("{0,-20} {1,24:F2}$", "Totale da pagare", totaleScontato)); // linea totale
            lst_Scontrino.Items.Add("============================="); // fine scontrino
        }
    }
}
