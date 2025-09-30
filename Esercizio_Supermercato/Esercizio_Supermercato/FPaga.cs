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
        private bool affiliato;
        private List<CProdotto> carrelloProdotti;
        private List<CProdotto> stockProdotti;

        // Percorso del file JSON
        private readonly string path;

        public FPaga(bool clienteAffiliato, List<CProdotto> carrello)
        {
            InitializeComponent();

            affiliato = clienteAffiliato;
            carrelloProdotti = carrello;

            // Costruisco il path del file JSON
            string nameJson = "stock.json";
            string directory = Application.StartupPath;
            path = Path.Combine(directory, nameJson);

            // Carico stock dal JSON
            stockProdotti = CaricaStock();

            // Messaggio iniziale
            MessageBox.Show(affiliato
                ? "Cliente affiliato: sconto del 5% applicato"
                : "Cliente non affiliato: nessuno sconto applicato");

            // Calcolo totale e preparo listbox scontrino
            CalcolaTotale();
            InizializzaLista();
        }

        private void btn_Paga_Click(object sender, EventArgs e)
        {
            // 1. Aggiorno lo stock sottraendo le quantità acquistate
            foreach (var prodottoCarrello in carrelloProdotti)
            {
                var prodottoStock = stockProdotti.FirstOrDefault(p => p.Nome == prodottoCarrello.Nome);
                if (prodottoStock != null)
                {
                    prodottoStock.Quantita -= prodottoCarrello.Quantita;
                    if (prodottoStock.Quantita < 0)
                        prodottoStock.Quantita = 0;
                }
            }

            // 2. Salvo lo stock aggiornato sul JSON
            SalvaStock(stockProdotti);

            // 3. Creo e apro il dialog di stampa
            using (PrintDialog printerDialog = new PrintDialog())
            {
                System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
                printDoc.PrintPage += (s, ev) =>
                {
                    float yPos = 10;
                    int leftMargin = 10;
                    using (System.Drawing.Font font = new System.Drawing.Font("Consolas", 10))
                    {
                        foreach (string line in lst_Scontrino.Items)
                        {
                            ev.Graphics.DrawString(line, font, System.Drawing.Brushes.Black, leftMargin, yPos);
                            yPos += font.GetHeight(ev.Graphics);
                        }
                    }
                };

                printerDialog.Document = printDoc;
                if (printerDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
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
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    return JsonConvert.DeserializeObject<List<CProdotto>>(json) ?? new List<CProdotto>();
                }
                else
                {
                    return new List<CProdotto>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dello stock: " + ex.Message);
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
                string jsonAggiornato = JsonConvert.SerializeObject(stock, Formatting.Indented);
                File.WriteAllText(path, jsonAggiornato);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel salvataggio dello stock: " + ex.Message);
            }
        }

        /// <summary>
        /// Calcola totale, sconto e aggiorna la label del totale
        /// </summary>
        private void CalcolaTotale()
        {
            decimal totale = carrelloProdotti.Sum(p => p.Prezzo * p.Quantita);
            decimal sconto = affiliato ? totale * 0.05m : 0m;
            decimal totaleScontato = totale - sconto;

            lbl_Totale.Text = affiliato
                ? $"Totale: {totaleScontato:F2} $, applicato uno sconto di {sconto:F2} $"
                : $"Totale: {totaleScontato:F2} $";
        }

        /// <summary>
        /// Inizializza la listbox come uno scontrino allineato
        /// </summary>
        private void InizializzaLista()
        {
            lst_Scontrino.Items.Clear();

            if (carrelloProdotti == null || carrelloProdotti.Count == 0)
            {
                lst_Scontrino.Items.Add("Nessun prodotto nel carrello");
                return;
            }

            lst_Scontrino.Items.Add("======== SCONTRINO ========");
            lst_Scontrino.Items.Add(string.Format("{0,-20} {1,3} {2,8} {3,10}", "Prodotto", "Qty", "Prezzo", "Totale"));
            lst_Scontrino.Items.Add(new string('-', 45));

            foreach (var p in carrelloProdotti)
            {
                decimal totaleProdotto = p.Prezzo * p.Quantita;
                string nomeProdotto = p.Nome.Length > 20 ? p.Nome.Substring(0, 20) : p.Nome;

                lst_Scontrino.Items.Add(string.Format("{0,-20} {1,3} {2,8:F2}$ {3,10:F2}$",
                    nomeProdotto,
                    p.Quantita,
                    p.Prezzo,
                    totaleProdotto));
            }

            decimal totale = carrelloProdotti.Sum(p => p.Prezzo * p.Quantita);
            decimal sconto = affiliato ? totale * 0.05m : 0m;
            decimal totaleScontato = totale - sconto;

            lst_Scontrino.Items.Add(new string('-', 45));
            if (affiliato)
                lst_Scontrino.Items.Add(string.Format("{0,-20} {1,24:F2}$", "Sconto 5%", sconto));
            lst_Scontrino.Items.Add(string.Format("{0,-20} {1,24:F2}$", "Totale da pagare", totaleScontato));
            lst_Scontrino.Items.Add("=============================");
        }
    }
}
