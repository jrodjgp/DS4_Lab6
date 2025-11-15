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

        }

        private void BotonClick(object sender, EventArgs e)
        {
            // 1. Identifica qué botón se presionó
            Button botonPresionado = (Button)sender;

            // 2. Añade su texto a nuestra variable "memoria"
            codigoActual += botonPresionado.Text;

            // 3. Actualiza la "pantalla" (el Label)
            lbl_Pantallita.Text = codigoActual;

            // 4. Reinicia el timer (la parte clave)
            timerInput.Stop();  // Detiene el conteo anterior
            timerInput.Start(); // Inicia un nuevo conteo de 2 segundos

            // 5. ¿Ya se formó un código completo (ej. "H1")?
            if (codigoActual.Length == 2)
            {
                // ¡Código completo!
                timerInput.Stop(); // Detenemos el timer, ya no lo necesitamos

                // ---> ¡AQUÍ LLAMAS A LA BASE DE DATOS! <---
                BuscarProductoEnBD(codigoActual);

                // Limpiamos la memoria para la próxima compra
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
    }
    
}
