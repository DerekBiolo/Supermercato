using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Drawing.Printing;


namespace Esercizio_Supermercato
{
    public partial class FPaga : Form
    {
        private bool affiliato; // indica se il cliente ha diritto allo sconto
        private List<CProdotto> carrelloProdotti; // lista dei prodotti nel carrello
        private List<CProdotto> stockProdotti;    // lista dello stock
        private string path;

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
            MessageBox.Show(affiliato ? "Cliente affiliato: sconto del 5% applicato" : "Cliente non affiliato: nessuno sconto applicato");

            CalcolaTotale(); // calcolo totale e sconto
            InizializzaLista(); // preparo lista scontrino
        }

        private void btn_Paga_Click(object sender, EventArgs e)
        {
            //aggiiorno quantita dello stock
            foreach (var prodottoCarrello in carrelloProdotti)
            {
                var prodottoStock = stockProdotti.FirstOrDefault(p => p.Nome == prodottoCarrello.Nome);

                if (prodottoStock != null)
                {
                    prodottoStock.Quantita -= prodottoCarrello.Quantita; // sottraggo quantità acquistata

                    if (prodottoStock.Quantita < 0)
                    {
                        prodottoStock.Quantita = 0;
                    }
                }
            }

            SalvaStock(stockProdotti);


            using (PrintDialog printerDialog = new PrintDialog())
            {
                PrintDocument printDoc = new PrintDocument();

                // gestisco la stampa pagina per pagina
                printDoc.PrintPage += (s, ev) =>
                {
                    using (Font f = new Font("Consolas", 10))
                    {
                        int rigaIndex = 0;
                        foreach (string riga in lst_Scontrino.Items)
                        {
                            ev.Graphics.DrawString(riga, f, Brushes.Black, 0, rigaIndex * f.GetHeight(ev.Graphics));
                            rigaIndex++;
                        }
                    }

                };

                printerDialog.Document = printDoc; // assegno il documento al dialog
                if (printerDialog.ShowDialog() == DialogResult.OK) // se confermato
                {
                    printDoc.Print(); // eseguo la stampa
                }
            }

            //chiudo ik form di pagamento
            this.Close();
        }

        private List<CProdotto> CaricaStock()
        {
            try
            {
                if (!File.Exists(path)) return new List<CProdotto>();
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<CProdotto>>(json) ?? new List<CProdotto>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dello stock: " + ex.Message);
                return new List<CProdotto>();
            }
        }

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
        private void CalcolaTotale()
        {
            decimal totale = carrelloProdotti.Sum(p => p.Prezzo * p.Quantita); // somma prezzo*quantità per ogni prodotto
            decimal sconto = affiliato ? totale * 0.05m : 0m; // calcolo sconto se affiliato
            decimal totaleScontato = totale - sconto; // totale dopo sconto

            lbl_Totale.Text = affiliato
                ? $"Totale: {totaleScontato:F2} $, applicato uno sconto di {sconto:F2} $" // testo se affiliato
                : $"Totale: {totaleScontato:F2} $"; // testo se non affiliato
        }

        private void InizializzaLista()
        {
            lst_Scontrino.Items.Clear(); // pulisco listbox

            if (carrelloProdotti == null || carrelloProdotti.Count == 0) // se carrello vuoto
            {
                lst_Scontrino.Items.Add("Nessun prodotto nel carrello"); // messaggio vuoto
                return;
            }

            lst_Scontrino.Items.Add("SCONTRINO"); // intestazione

            lst_Scontrino.Items.Add(
                "Prodotto".PadRight(20) +   // nome colonna
                "Qty".PadLeft(3) + " " +    // quantità
                "Prezzo".PadLeft(8) + " " + // prezzo
                "Totale".PadLeft(10)        // totale
            );

            foreach (var p in carrelloProdotti) // ciclo sui prodotti
            {
                decimal totaleProdotto = p.Prezzo * p.Quantita; // calcolo totale per prodotto
                string nomeProdotto = p.Nome;

                // aggiungo riga alla listbox
                lst_Scontrino.Items.Add(
                    nomeProdotto.PadRight(20) +                  // nome prodotto
                    p.Quantita.ToString().PadLeft(3) + " " +     // quantità
                    p.Prezzo.ToString("F2").PadLeft(8) + "$ " +  // prezzo unitario
                    totaleProdotto.ToString("F2").PadLeft(10) + "$" // totale prodotto
                );

            }

            decimal totale = carrelloProdotti.Sum(p => p.Prezzo * p.Quantita); // sommo tutto
            decimal sconto = affiliato ? totale * 0.05m : 0m; // calcolo sconto se affiliato
            decimal totaleScontato = totale - sconto; // totale finale

            lst_Scontrino.Items.Add("-----------------------------------");
            if (affiliato) // se cliente affiliato
            {
                lst_Scontrino.Items.Add("Sconto 5%".PadRight(20) + sconto.ToString("F2").PadLeft(24) + "$");
            }
            lst_Scontrino.Items.Add("Totale da pagare".PadRight(20) + totaleScontato.ToString("F2").PadLeft(24) + "$");
            lst_Scontrino.Items.Add("-----------------------------------");
        }
    }
}
