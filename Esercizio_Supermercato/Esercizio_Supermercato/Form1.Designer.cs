namespace Esercizio_Supermercato
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lst_CarrelloCliente = new ListBox();
            lbl_title = new Label();
            ckb_clienteAffiliato = new CheckBox();
            btn_visualizzaStock = new Button();
            btn_scansionaProdotto = new Button();
            btn_Paga = new Button();
            SuspendLayout();
            // 
            // lst_CarrelloCliente
            // 
            lst_CarrelloCliente.FormattingEnabled = true;
            lst_CarrelloCliente.ItemHeight = 20;
            lst_CarrelloCliente.Location = new Point(31, 80);
            lst_CarrelloCliente.Margin = new Padding(3, 4, 3, 4);
            lst_CarrelloCliente.Name = "lst_CarrelloCliente";
            lst_CarrelloCliente.Size = new Size(355, 384);
            lst_CarrelloCliente.TabIndex = 0;
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.Font = new Font("Yu Gothic UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_title.Location = new Point(31, 9);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(370, 62);
            lbl_title.TabIndex = 1;
            lbl_title.Text = "Lista della spesa";
            // 
            // ckb_clienteAffiliato
            // 
            ckb_clienteAffiliato.AutoSize = true;
            ckb_clienteAffiliato.Location = new Point(393, 440);
            ckb_clienteAffiliato.Margin = new Padding(3, 4, 3, 4);
            ckb_clienteAffiliato.Name = "ckb_clienteAffiliato";
            ckb_clienteAffiliato.Size = new Size(185, 24);
            ckb_clienteAffiliato.TabIndex = 2;
            ckb_clienteAffiliato.Text = "Sconto Cliente Affiliato";
            ckb_clienteAffiliato.UseVisualStyleBackColor = true;
            // 
            // btn_visualizzaStock
            // 
            btn_visualizzaStock.BackColor = Color.Linen;
            btn_visualizzaStock.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_visualizzaStock.Location = new Point(393, 80);
            btn_visualizzaStock.Margin = new Padding(3, 4, 3, 4);
            btn_visualizzaStock.Name = "btn_visualizzaStock";
            btn_visualizzaStock.Size = new Size(169, 76);
            btn_visualizzaStock.TabIndex = 3;
            btn_visualizzaStock.Text = "Visualizza Stock";
            btn_visualizzaStock.UseVisualStyleBackColor = false;
            btn_visualizzaStock.Click += btn_visualizzaStock_Click;
            // 
            // btn_scansionaProdotto
            // 
            btn_scansionaProdotto.BackColor = Color.Linen;
            btn_scansionaProdotto.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_scansionaProdotto.Location = new Point(393, 200);
            btn_scansionaProdotto.Margin = new Padding(3, 4, 3, 4);
            btn_scansionaProdotto.Name = "btn_scansionaProdotto";
            btn_scansionaProdotto.Size = new Size(169, 76);
            btn_scansionaProdotto.TabIndex = 4;
            btn_scansionaProdotto.Text = "Acquista Prodotto";
            btn_scansionaProdotto.UseVisualStyleBackColor = false;
            btn_scansionaProdotto.Click += btn_scansionaProdotto_Click;
            // 
            // btn_Paga
            // 
            btn_Paga.BackColor = Color.Linen;
            btn_Paga.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Paga.Location = new Point(393, 320);
            btn_Paga.Margin = new Padding(3, 4, 3, 4);
            btn_Paga.Name = "btn_Paga";
            btn_Paga.Size = new Size(169, 76);
            btn_Paga.TabIndex = 5;
            btn_Paga.Text = "Paga Totale";
            btn_Paga.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 681);
            Controls.Add(btn_Paga);
            Controls.Add(btn_scansionaProdotto);
            Controls.Add(btn_visualizzaStock);
            Controls.Add(ckb_clienteAffiliato);
            Controls.Add(lbl_title);
            Controls.Add(lst_CarrelloCliente);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lst_CarrelloCliente;
        private Label lbl_title;
        private CheckBox ckb_clienteAffiliato;
        private Button btn_visualizzaStock;
        private Button btn_scansionaProdotto;
        private Button btn_Paga;
    }
}