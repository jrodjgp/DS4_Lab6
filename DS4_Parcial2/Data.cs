using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS4_Parcial2
{
    public partial class Data : Form
    {
        public Data()
        {
            InitializeComponent();
        }

        private void Data_Load(object sender, EventArgs e)
        {
            Cerebro cerebro = new Cerebro();

            DG_Transacciones.DataSource = cerebro.ObtenerHistorialVentas();

            DG_Transacciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
