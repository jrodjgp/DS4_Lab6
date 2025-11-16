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
    public partial class Form1 : Form
    {
        private Cerebro cerebro = new Cerebro();
        private string codigoActual = "";
        private Producto productoSeleccionado = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetearUI();
            lbl_Pantallita.Text = "Bienvenido";
        }

        private void BotonClick(object sender, EventArgs e)
        {
            Button botonPresionado = (Button)sender;

            codigoActual += botonPresionado.Text;

            lbl_Pantallita.Text = codigoActual;

            timerInput.Stop(); 
            timerInput.Start();

            if (codigoActual.Length == 2)
            {
                timerInput.Stop();

                BuscarProductoEnBD(codigoActual);

                codigoActual = "";
            }
        }
        private void BuscarProductoEnBD(string codigo)
        {
            productoSeleccionado = null;
            num_Pago.Enabled = true;
            btn_Pagar.Enabled = true;

            Producto miProducto = cerebro.ObtenerProducto(codigo);
            
            if (miProducto != null)
            {
                if (miProducto.StockLocal > 0)
                {
                    lbl_ProductoElegido.Text = miProducto.Nombre;
                    lbl_Precio.Text = miProducto.Precio.ToString("C");
                    lbl_PagueAqui.Text = "Deposite el monto exacto.";

                    productoSeleccionado = miProducto;

                    num_Pago.Enabled = true;
                    btn_Pagar.Enabled = true;
                    num_Pago.Focus();
                }
                else
                {
                    lbl_ProductoElegido.Text = "Producto agotado. Reponiendo...";
                    lbl_Precio.Text = "--";
                }
            }
            else
            {
                lbl_Pantallita.Text = "Código no válido";
                lbl_Pantallita.Text = "--";
            }
        }

        private void timerInput_Tick(object sender, EventArgs e)
        {
            timerInput.Stop();

            codigoActual = "";

            lbl_Pantallita.Text = "--";
        }

        private void btn_Pagar_Click(object sender, EventArgs e)
        {
            if (productoSeleccionado == null)
            {
                lbl_ProductoElegido.Text = "Seleccione un producto primero.";
                return;
            }

            decimal montoPagado = num_Pago.Value;

            if (montoPagado < productoSeleccionado.Precio)
            {
                lbl_ProductoElegido.Text = "Dinero insuficiente.";
                return;
            }

            btn_Pagar.Enabled = false;
            num_Pago.Enabled = false;

            bool exito = cerebro.RealizarCompra(
                productoSeleccionado.Codigo,
                montoPagado,
                productoSeleccionado.Precio
            );

            if (exito)
            {
                lbl_ProductoElegido.Text = "¡Gracias! Dispensando " + productoSeleccionado.Nombre;

                SimularDispensacion(productoSeleccionado.Codigo);

                timerLimpieza.Start();
            }
            else
            {
                lbl_ProductoElegido.Text = "Error. Stock no disponible o error de BD.";

                ResetearUI();
            }
        }
        private void SimularDispensacion(string codigo)
        {
            switch (codigo)
            {
                case "H1": p_Dispensador.Image = Properties.Resources.H1; break;
                case "C2": p_Dispensador.Image = Properties.Resources.C2; break;
                case "F3": p_Dispensador.Image = Properties.Resources.F3; break;
                case "F2": p_Dispensador.Image = Properties.Resources.F2; break;
                case "C1": p_Dispensador.Image = Properties.Resources.C1; break;
                case "H3": p_Dispensador.Image = Properties.Resources.H3; break;
                case "H2": p_Dispensador.Image = Properties.Resources.H2; break;
                case "F1": p_Dispensador.Image = Properties.Resources.F1; break;
                case "C3": p_Dispensador.Image = Properties.Resources.C3; break;

                default:
                    p_Dispensador.Image = null;
                    break;
            }
            p_Dispensador.Visible = true;
        }
        private void timerLimpieza_Tick(object sender, EventArgs e)
        {
            timerLimpieza.Stop(); 
            ResetearUI();         
            lbl_Pantallita.Text = "Bienvenido";

            btn_1.Enabled = true;
            btn_2.Enabled = true;
            btn_3.Enabled = true;
            btn_F.Enabled = true;
            btn_C.Enabled = true;
            btn_H.Enabled = true;
        }
        private void ResetearUI()
        {
            productoSeleccionado = null;
            lbl_Pantallita.Text = "--";
            num_Pago.Value = 0;
            num_Pago.Enabled = false;
            btn_Pagar.Enabled = false;

            p_Dispensador.Image = null;
            p_Dispensador.Visible = false;
        }

        private void btn_Data_Click(object sender, EventArgs e)
        {
            Data data = new Data();
            data.ShowDialog();
            this.Hide();
        }
    }
    
}
