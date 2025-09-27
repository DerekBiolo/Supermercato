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

namespace Esercizio_Supermercato
{
    public partial class FStock : Form
    {
        List<CProdotto> Prodotti = new List<CProdotto>();

        public FStock()
        {
            InitializeComponent();
        }

        private void FStock_Load(object sender, EventArgs e)
        {
            string nameJson = "stock.json";
            string directory = Application.StartupPath;
            string path = Path.Combine(directory, nameJson); // Combino la directory al nome del file

            string JsonContent = File.ReadAllText(path); // Legge tutto il contenuto del json

            try
            {
                Prodotti = JsonConvert.DeserializeObject<List<CProdotto>>(JsonContent);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Json errore");
            }

            FillDgv();
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
                            dtg_Alimentari.Rows.Add(p.Nome, p.Prezzo, p.Quantita)
                            break;
                    }
                }
            }
        }
    }
}
