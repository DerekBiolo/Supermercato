using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esercizio_Supermercato
{
    public partial class FAcquisti : Form
    {
        FStock stock = new FStock();

        private List<CProdotto> products;
        public FAcquisti()
        {
            InitializeComponent();

            products = stock.Prodotti;
        }

        private void FAcquisti_Load(object sender, EventArgs e)
        {
            
        }


    }
}
