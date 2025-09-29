namespace Esercizio_Supermercato
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FStock f = new FStock();
            f.ProdottiLoader();
        }

        private void btn_visualizzaStock_Click(object sender, EventArgs e)
        {
            FStock form = new FStock();
            form.ShowDialog();
        }

        private void btn_scansionaProdotto_Click(object sender, EventArgs e)
        {
            FAcquisti fAcquisti = new FAcquisti();
            fAcquisti.ShowDialog();
        }
    }
}