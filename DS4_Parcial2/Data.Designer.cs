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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DG_Transacciones = new System.Windows.Forms.DataGridView();
            this.btn_Regresar = new System.Windows.Forms.Button();
            this.lbl_Transacciones = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Transacciones)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.lbl_Transacciones);
            this.panel1.Controls.Add(this.btn_Regresar);
            this.panel1.Controls.Add(this.DG_Transacciones);
            this.panel1.Location = new System.Drawing.Point(37, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 389);
            this.panel1.TabIndex = 0;
            // 
            // DG_Transacciones
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Lime;
            this.DG_Transacciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DG_Transacciones.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DG_Transacciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.DG_Transacciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Transacciones.GridColor = System.Drawing.Color.Lime;
            this.DG_Transacciones.Location = new System.Drawing.Point(36, 96);
            this.DG_Transacciones.Name = "DG_Transacciones";
            this.DG_Transacciones.RowHeadersWidth = 51;
            this.DG_Transacciones.RowTemplate.Height = 24;
            this.DG_Transacciones.Size = new System.Drawing.Size(645, 267);
            this.DG_Transacciones.TabIndex = 0;
            // 
            // btn_Regresar
            // 
            this.btn_Regresar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Regresar.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Regresar.ForeColor = System.Drawing.Color.Lime;
            this.btn_Regresar.Location = new System.Drawing.Point(554, 51);
            this.btn_Regresar.Name = "btn_Regresar";
            this.btn_Regresar.Size = new System.Drawing.Size(116, 35);
            this.btn_Regresar.TabIndex = 1;
            this.btn_Regresar.Text = "Regresar";
            this.btn_Regresar.UseVisualStyleBackColor = true;
            this.btn_Regresar.Click += new System.EventHandler(this.btn_Regresar_Click);
            // 
            // lbl_Transacciones
            // 
            this.lbl_Transacciones.AutoSize = true;
            this.lbl_Transacciones.Font = new System.Drawing.Font("Microsoft Tai Le", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Transacciones.ForeColor = System.Drawing.Color.Lime;
            this.lbl_Transacciones.Location = new System.Drawing.Point(49, 48);
            this.lbl_Transacciones.Name = "lbl_Transacciones";
            this.lbl_Transacciones.Size = new System.Drawing.Size(188, 36);
            this.lbl_Transacciones.TabIndex = 2;
            this.lbl_Transacciones.Text = "Transacciones";
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
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Transacciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DG_Transacciones;
        private System.Windows.Forms.Label lbl_Transacciones;
        private System.Windows.Forms.Button btn_Regresar;
    }
}