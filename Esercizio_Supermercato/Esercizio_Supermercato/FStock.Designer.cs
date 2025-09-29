namespace Esercizio_Supermercato
{
    partial class FStock
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
            dtg_Alimentari = new DataGridView();
            colNome = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            dtg_Elettronica = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dtg_Igiene = new DataGridView();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dtg_Vestiti = new DataGridView();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            lbl_Title = new Label();
            ((System.ComponentModel.ISupportInitialize)dtg_Alimentari).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtg_Elettronica).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtg_Igiene).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtg_Vestiti).BeginInit();
            SuspendLayout();
            // 
            // dtg_Alimentari
            // 
            dtg_Alimentari.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_Alimentari.Columns.AddRange(new DataGridViewColumn[] { colNome, Price, Quantity });
            dtg_Alimentari.Location = new Point(83, 351);
            dtg_Alimentari.Margin = new Padding(3, 4, 3, 4);
            dtg_Alimentari.Name = "dtg_Alimentari";
            dtg_Alimentari.RowHeadersWidth = 51;
            dtg_Alimentari.RowTemplate.Height = 25;
            dtg_Alimentari.Size = new Size(400, 500);
            dtg_Alimentari.TabIndex = 0;
            // 
            // colNome
            // 
            colNome.HeaderText = "Nome";
            colNome.MinimumWidth = 6;
            colNome.Name = "colNome";
            colNome.Width = 125;
            // 
            // Price
            // 
            Price.HeaderText = "Prezzo";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.Width = 125;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantita Stock";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.Width = 125;
            // 
            // dtg_Elettronica
            // 
            dtg_Elettronica.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_Elettronica.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dtg_Elettronica.Location = new Point(536, 351);
            dtg_Elettronica.Margin = new Padding(3, 4, 3, 4);
            dtg_Elettronica.Name = "dtg_Elettronica";
            dtg_Elettronica.RowHeadersWidth = 51;
            dtg_Elettronica.RowTemplate.Height = 25;
            dtg_Elettronica.Size = new Size(400, 500);
            dtg_Elettronica.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Nome";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Prezzo";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Quantita Stock";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dtg_Igiene
            // 
            dtg_Igiene.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_Igiene.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dtg_Igiene.Location = new Point(989, 351);
            dtg_Igiene.Margin = new Padding(3, 4, 3, 4);
            dtg_Igiene.Name = "dtg_Igiene";
            dtg_Igiene.RowHeadersWidth = 51;
            dtg_Igiene.RowTemplate.Height = 25;
            dtg_Igiene.Size = new Size(400, 500);
            dtg_Igiene.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Nome";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Prezzo";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Quantita Stock";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dtg_Vestiti
            // 
            dtg_Vestiti.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_Vestiti.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9 });
            dtg_Vestiti.Location = new Point(1442, 351);
            dtg_Vestiti.Margin = new Padding(3, 4, 3, 4);
            dtg_Vestiti.Name = "dtg_Vestiti";
            dtg_Vestiti.RowHeadersWidth = 51;
            dtg_Vestiti.RowTemplate.Height = 25;
            dtg_Vestiti.Size = new Size(400, 500);
            dtg_Vestiti.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Nome";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Prezzo";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.Width = 125;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "Quantita Stock";
            dataGridViewTextBoxColumn9.MinimumWidth = 6;
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.Width = 125;
            // 
            // lbl_Title
            // 
            lbl_Title.AutoSize = true;
            lbl_Title.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Title.ForeColor = Color.FromArgb(255, 128, 0);
            lbl_Title.Location = new Point(22, 25);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(175, 62);
            lbl_Title.TabIndex = 4;
            lbl_Title.Text = "STOCK";
            // 
            // FStock
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(lbl_Title);
            Controls.Add(dtg_Vestiti);
            Controls.Add(dtg_Igiene);
            Controls.Add(dtg_Elettronica);
            Controls.Add(dtg_Alimentari);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FStock";
            Text = "FStock";
            Load += FStock_Load;
            ((System.ComponentModel.ISupportInitialize)dtg_Alimentari).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtg_Elettronica).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtg_Igiene).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtg_Vestiti).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtg_Alimentari;
        private DataGridViewTextBoxColumn colNome;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridView dtg_Elettronica;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridView dtg_Igiene;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridView dtg_Vestiti;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private Label lbl_Title;
    }
}
