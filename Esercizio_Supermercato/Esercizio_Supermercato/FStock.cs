using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Json;

namespace Esercizio_Supermercato
{
    public partial class FStock : Form
    {
        public List<CProdotto> Prodotti { get; private set; } = new List<CProdotto>(); //Metto il get pubblico per poterlo  chiamare nello scontrino

        public FStock()
        {
            InitializeComponent();
        }

        private void FStock_Load(object sender, EventArgs e)
        {
            ProdottiLoader();
            FillDgv();
            Styler();
            ComboBoxLoader();
        }

        public void ProdottiLoader()
        {
            string nameJson = "stock.json";
            string directory = Application.StartupPath;
            string path = Path.Combine(directory, nameJson); //  ombino la directory al nome del file

            string JsonContent = File.ReadAllText(path); // legge tutto il contenuto del json

            if (JsonContent != null)
            {
                try
                {
                    Prodotti = JsonConvert.DeserializeObject<List<CProdotto>>(JsonContent); //deserializzo tutto come singoli CProdotto nella list Prodotti
                    // deserializzare significa trasformare il testo del json in oggetti utilizzabili nel codice, in questo caso in CProdotto 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Json errore"); //try catch in caso di errore nella deserializzzazione
                }
            }
            else
            {
                MessageBox.Show("Prodotti is already loaded");
            }
        }

        public List<CProdotto> ReturnStock()
        {
            return Prodotti; // ritorno lo stock
        }
        private void Styler()
        {
            // grafica
            var grids = new List<DataGridView> { dtg_Alimentari, dtg_Elettronica, dtg_Igiene, dtg_Vestiti };

            foreach (var dgv in grids)
            {
                dgv.BorderStyle = BorderStyle.None;
                dgv.BackgroundColor = Color.FromArgb(30, 30, 30); // nero/grigio scuro moderno
                dgv.EnableHeadersVisualStyles = false;
                dgv.GridColor = Color.FromArgb(255, 120, 0); // arancione vivo

                // Header
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 120, 0);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Celle
                dgv.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                dgv.DefaultCellStyle.ForeColor = Color.White;
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 140, 0);
                dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Pixel);

                // Alternanza righe
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(55, 55, 55);

                // Row header nascosto per look pulito
                dgv.RowHeadersVisible = false;

                // Auto-sizing per riempire lo spazio
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgv.ReadOnly = true;
            }
        }

        private void ComboBoxLoader() // combobox per l'aggiunta allo stock
        {
            // pulisco la lista
            box_Nome.Items.Clear();

            if (Prodotti == null || Prodotti.Count == 0) // controllo che ci siano prodotti
            {
                box_Nome.Items.Add("Nessun prodotto disponibile");
                box_Nome.SelectedIndex = 0;
                box_Nome.Enabled = false;
                return;
            }

            // aggiungo tutti i nomi
            foreach (var p in Prodotti)
            {
                if (p != null)
                {
                    box_Nome.Items.Add(p.Nome);
                }
            }

            // imposto al primo elemento sempre
            if (box_Nome.Items.Count > 0)
            {
                box_Nome.SelectedIndex = 0;
                box_Nome.Enabled = true;
            }
        }

        private void FillDgv()
        {
            // cleaning dtg
            dtg_Alimentari.Rows.Clear();
            dtg_Elettronica.Rows.Clear();
            dtg_Igiene.Rows.Clear();
            dtg_Vestiti.Rows.Clear();

            foreach (var p in Prodotti)
            {
                //controllo se e nullo
                if (p != null)
                {
                    switch (p.Categoria) // divido per categoria la visuale dello stock
                    {
                        case "alimentari":
                            dtg_Alimentari.Rows.Add(p.Nome, p.Prezzo, p.Quantita);
                            break;

                        case "vestiti":
                            dtg_Vestiti.Rows.Add(p.Nome, p.Prezzo, p.Quantita);
                            break;
                        case "elettronica":
                            dtg_Elettronica.Rows.Add(p.Nome, p.Prezzo, p.Quantita);
                            break;
                        case "igiene":
                            dtg_Igiene.Rows.Add(p.Nome, p.Prezzo, p.Quantita);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Prodotti è vuoto");
                    return;
                }
            }
        }

        private void btn_aggiungiProdotto_Click(object sender, EventArgs e)
        {
            // deve esserci almeno un nome selezionato
            if (box_Nome.SelectedItem == null)
            {
                MessageBox.Show("Seleziona un prodotto dal menu.");
                return;
            }

            string prodottoSelezionato = box_Nome.SelectedItem.ToString(); // ritorna il nome del combobox
            int quantitaDaAggiungere = (int)num_Quantity.Value; //trasforma il numericupdown in int

            if (quantitaDaAggiungere <= 0)
            {
                MessageBox.Show("Inserisci una quantità valida."); // quantita minima
                return;
            }

            // cerco il prodotto nello stock
            var prodotto = Prodotti.FirstOrDefault(p => p.Nome == prodottoSelezionato); //funzione lambda che con FirstOrDefault assegna o il primo elemento che rispetta
                                                                                        // il parametro ( p.nome == prodottoSelezionato in questo caso scorre la lista 
                                                                                        // dei prodotti sino a che non trova un pordotto con lo stesso nome) oppure ritorna
                                                                                        // null, ovvero la parte Default
            if (prodotto != null)
            {
                // ora che ho il prodotto ne modifico la quantita
                prodotto.Quantita += quantitaDaAggiungere;

                // salvo nel json
                string nameJson = "stock.json";
                string directory = Application.StartupPath;
                string path = Path.Combine(directory, nameJson);

                try
                {
                    string jsonAggiornato = JsonConvert.SerializeObject(Prodotti, Formatting.Indented); //serializzo ( Formatting.Intended crea la formattazione come
                                                                                                        // spazi e caporiga

                    File.WriteAllText(path, jsonAggiornato); //scrivo tutto nel file, se ha gia qualcosa lo scrivo se il file non ce lo crea
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore nel salvataggio dello stock: " + ex.Message); // in caso di errore di serializzazione
                }

                // aggiorna
                FillDgv();

                // aggiorna
                ComboBoxLoader();
                 
                MessageBox.Show($"Aggiunti/o {quantitaDaAggiungere} elementi/o di {prodottoSelezionato}."); // debug
            }  
            else
            {
                MessageBox.Show("Prodotto non trovato nello stock.");
            }
        }

    }
}
