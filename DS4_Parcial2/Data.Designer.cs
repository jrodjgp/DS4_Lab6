namespace DS4_Parcial2
{
    partial class Data
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.DG_Transacciones = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Transacciones)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.DG_Transacciones);
            this.panel1.Location = new System.Drawing.Point(37, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 389);
            this.panel1.TabIndex = 0;
            // 
            // DG_Transacciones
            // 
            this.DG_Transacciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Transacciones.Location = new System.Drawing.Point(36, 96);
            this.DG_Transacciones.Name = "DG_Transacciones";
            this.DG_Transacciones.RowHeadersWidth = 51;
            this.DG_Transacciones.RowTemplate.Height = 24;
            this.DG_Transacciones.Size = new System.Drawing.Size(645, 267);
            this.DG_Transacciones.TabIndex = 0;
            // 
            // Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Data";
            this.Text = "Data";
            this.Load += new System.EventHandler(this.Data_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Transacciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DG_Transacciones;
    }
}