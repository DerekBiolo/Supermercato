namespace Esercizio_Supermercato
{
    partial class FAcquisti
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbbox_Prodotto = new ComboBox();
            numeric_Quantita = new NumericUpDown();
            btn_AggiungiProdotto = new Button();
            listbox_ListaSpesa = new ListBox();
            lbl_Prezzo = new Label();
            lbl_Tot = new Label();
            btn_RemoveProduct = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numeric_Quantita).BeginInit();
            SuspendLayout();
            // 
            // cmbbox_Prodotto
            // 
            cmbbox_Prodotto.FormattingEnabled = true;
            cmbbox_Prodotto.Location = new Point(145, 79);
            cmbbox_Prodotto.Name = "cmbbox_Prodotto";
            cmbbox_Prodotto.Size = new Size(222, 28);
            cmbbox_Prodotto.TabIndex = 0;
            cmbbox_Prodotto.SelectedIndexChanged += cmbbox_Prodotto_SelectedIndexChanged;
            // 
            // numeric_Quantita
            // 
            numeric_Quantita.Location = new Point(145, 119);
            numeric_Quantita.Name = "numeric_Quantita";
            numeric_Quantita.Size = new Size(222, 27);
            numeric_Quantita.TabIndex = 1;
            // 
            // btn_AggiungiProdotto
            // 
            btn_AggiungiProdotto.BackColor = Color.FromArgb(224, 224, 224);
            btn_AggiungiProdotto.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btn_AggiungiProdotto.ForeColor = Color.FromArgb(255, 128, 0);
            btn_AggiungiProdotto.Location = new Point(642, 79);
            btn_AggiungiProdotto.Name = "btn_AggiungiProdotto";
            btn_AggiungiProdotto.Size = new Size(146, 67);
            btn_AggiungiProdotto.TabIndex = 2;
            btn_AggiungiProdotto.Text = "Aggiungi al carrello";
            btn_AggiungiProdotto.UseVisualStyleBackColor = false;
            btn_AggiungiProdotto.Click += btn_AggiungiProdotto_Click;
            // 
            // listbox_ListaSpesa
            // 
            listbox_ListaSpesa.FormattingEnabled = true;
            listbox_ListaSpesa.ItemHeight = 20;
            listbox_ListaSpesa.Location = new Point(24, 163);
            listbox_ListaSpesa.Name = "listbox_ListaSpesa";
            listbox_ListaSpesa.Size = new Size(374, 244);
            listbox_ListaSpesa.TabIndex = 3;
            // 
            // lbl_Prezzo
            // 
            lbl_Prezzo.AutoSize = true;
            lbl_Prezzo.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_Prezzo.ForeColor = Color.FromArgb(255, 128, 0);
            lbl_Prezzo.Location = new Point(373, 80);
            lbl_Prezzo.Name = "lbl_Prezzo";
            lbl_Prezzo.Size = new Size(59, 23);
            lbl_Prezzo.TabIndex = 4;
            lbl_Prezzo.Text = "label1";
            // 
            // lbl_Tot
            // 
            lbl_Tot.AutoSize = true;
            lbl_Tot.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_Tot.ForeColor = Color.FromArgb(255, 128, 0);
            lbl_Tot.Location = new Point(24, 410);
            lbl_Tot.Name = "lbl_Tot";
            lbl_Tot.Size = new Size(96, 28);
            lbl_Tot.TabIndex = 5;
            lbl_Tot.Text = "lblTotale";
            // 
            // btn_RemoveProduct
            // 
            btn_RemoveProduct.BackColor = Color.FromArgb(224, 224, 224);
            btn_RemoveProduct.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 0);
            btn_RemoveProduct.FlatAppearance.BorderSize = 0;
            btn_RemoveProduct.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btn_RemoveProduct.ForeColor = Color.FromArgb(255, 128, 0);
            btn_RemoveProduct.Location = new Point(404, 346);
            btn_RemoveProduct.Name = "btn_RemoveProduct";
            btn_RemoveProduct.Size = new Size(146, 61);
            btn_RemoveProduct.TabIndex = 6;
            btn_RemoveProduct.Text = "Rimuovi prodotto";
            btn_RemoveProduct.UseVisualStyleBackColor = false;
            btn_RemoveProduct.Click += btn_RemoveProduct_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(24, 82);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 7;
            label1.Text = "Prodotto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(24, 121);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 8;
            label2.Text = "Quantità";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(255, 128, 0);
            label3.Location = new Point(24, 19);
            label3.Name = "label3";
            label3.Size = new Size(275, 41);
            label3.TabIndex = 9;
            label3.Text = "Acquista Prodotto";
            // 
            // FAcquisti
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_RemoveProduct);
            Controls.Add(lbl_Tot);
            Controls.Add(lbl_Prezzo);
            Controls.Add(listbox_ListaSpesa);
            Controls.Add(btn_AggiungiProdotto);
            Controls.Add(numeric_Quantita);
            Controls.Add(cmbbox_Prodotto);
            Name = "FAcquisti";
            Text = "FAcquisti";
            Load += FAcquisti_Load;
            ((System.ComponentModel.ISupportInitialize)numeric_Quantita).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbbox_Prodotto;
        private NumericUpDown numeric_Quantita;
        private Button btn_AggiungiProdotto;
        private ListBox listbox_ListaSpesa;
        private Label lbl_Prezzo;
        private Label lbl_Tot;
        private Button btn_RemoveProduct;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}