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
        public List<CProdotto> Prodotti { get; private set; } = new List<CProdotto>();

        public FStock()
        {
            InitializeComponent();
        }

        private void FStock_Load(object sender, EventArgs e)
        {
            ProdottiLoader();
            FillDgv();
            Styler();
        }

        public void ProdottiLoader()
        {
            string nameJson = "stock.json";
            string directory = Application.StartupPath;
            string path = Path.Combine(directory, nameJson); // Combino la directory al nome del file

            string JsonContent = File.ReadAllText(path); // Legge tutto il contenuto del json
            if (JsonContent != null)
            {
                try
                {
                    Prodotti = JsonConvert.DeserializeObject<List<CProdotto>>(JsonContent);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Json errore");
                }
            } else
            {
                MessageBox.Show("Prodotti is already loaded");
            }
        }

        private void Styler()
        {
            // Lista di tutti i tuoi DataGridView
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
            }
        }


        private void FillDgv()
        {
            // cleaning
            dtg_Alimentari.Rows.Clear();
            dtg_Elettronica.Rows.Clear();
            dtg_Igiene.Rows.Clear();
            dtg_Vestiti.Rows.Clear();

            foreach ( var p in Prodotti)
            {
                //controllo se e nullo
                if (p != null)
                {
                    switch (p.Categoria)
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
                } else
                {
                    MessageBox.Show("Prodotti è vuoto");
                    return;
                }
            }
        }
    }
}
