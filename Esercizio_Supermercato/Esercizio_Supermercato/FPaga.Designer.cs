namespace Esercizio_Supermercato
{
    partial class FPaga
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
            lst_Scontrino = new ListBox();
            label1 = new Label();
            btn_Paga = new Button();
            lbl_Totale = new Label();
            SuspendLayout();
            // 
            // lst_Scontrino
            // 
            lst_Scontrino.FormattingEnabled = true;
            lst_Scontrino.ItemHeight = 20;
            lst_Scontrino.Location = new Point(22, 57);
            lst_Scontrino.Name = "lst_Scontrino";
            lst_Scontrino.Size = new Size(374, 364);
            lst_Scontrino.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(171, 9);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 1;
            label1.Text = "SCONTINO";
            // 
            // btn_Paga
            // 
            btn_Paga.Location = new Point(402, 57);
            btn_Paga.Name = "btn_Paga";
            btn_Paga.Size = new Size(94, 59);
            btn_Paga.TabIndex = 2;
            btn_Paga.Text = "Pagaa";
            btn_Paga.UseVisualStyleBackColor = true;
            btn_Paga.Click += btn_Paga_Click;
            // 
            // lbl_Totale
            // 
            lbl_Totale.AutoSize = true;
            lbl_Totale.Location = new Point(402, 135);
            lbl_Totale.Name = "lbl_Totale";
            lbl_Totale.Size = new Size(82, 20);
            lbl_Totale.TabIndex = 3;
            lbl_Totale.Text = "SCONTINO";
            // 
            // FPaga
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_Totale);
            Controls.Add(btn_Paga);
            Controls.Add(label1);
            Controls.Add(lst_Scontrino);
            Name = "FPaga";
            Text = "FPaga";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lst_Scontrino;
        private Label label1;
        private Button btn_Paga;
        private Label lbl_Totale;
    }
}