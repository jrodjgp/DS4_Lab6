using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS4_Parcial2
{
    public class Cerebro
    {
        private const int CANTIDAD_REPOSICION = 10;
        public Producto ObtenerProducto(string codigo)
        {
            Producto producto = null;

            using (MySqlConnection conexion = Conexion.ObtenerConecion())
            {
                try
                {
                    conexion.Open();

                    string query = "SELECT nombre, precio, categoria, stock_local, stock_general " +
                                   "FROM productos WHERE codigo = @codigo";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            producto = new Producto();
                            producto.Codigo = codigo;
                            producto.Nombre = reader.GetString("nombre");
                            producto.Precio = reader.GetDecimal("precio");
                            producto.Categoria = reader.GetString("categoria");
                            producto.StockLocal = reader.GetInt32("stock_local");
                            producto.StockGeneral = reader.GetInt32("stock_general");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de excepcion" + ex, "Error");
                    producto = null;
                }
            }

            return producto;
        }

        public bool RealizarCompra(string codigo, decimal montoPagado, decimal precioProducto)
        {
            if (montoPagado < precioProducto)
            {
                return false;
            }

            using (MySqlConnection conn = Conexion.ObtenerConecion())
            {
                MySqlTransaction transaccion = null;
                try
                {
                    conn.Open();
                    transaccion = conn.BeginTransaction();

                    string queryDescuento = "UPDATE productos SET stock_local = stock_local - 1 " +
                                            "WHERE codigo = @codigo AND stock_local > 0";

                    MySqlCommand cmdDescuento = new MySqlCommand(queryDescuento, conn, transaccion);
                    cmdDescuento.Parameters.AddWithValue("@codigo", codigo);

                    int filasAfectadas = cmdDescuento.ExecuteNonQuery();

                    if (filasAfectadas == 0)
                    {
                        throw new Exception("Stock local agotado.");
                    }

                    string queryTransaccion = "INSERT INTO transacciones (codigo_producto, monto_pagado, fecha_hora_venta) " +
                                              "VALUES (@codigo, @monto, NOW())";

                    MySqlCommand cmdTransaccion = new MySqlCommand(queryTransaccion, conn, transaccion);
                    cmdTransaccion.Parameters.AddWithValue("@codigo", codigo);
                    cmdTransaccion.Parameters.AddWithValue("@monto", precioProducto);
                    cmdTransaccion.ExecuteNonQuery();

                    VerificarYReponerStock(codigo, conn, transaccion);

                    transaccion.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de excepcion" + ex, "Error");
                    if (transaccion != null)
                    {
                        transaccion.Rollback();
                    }
                    return false;
                }
            }
        }
        private void VerificarYReponerStock(string codigo, MySqlConnection conn, MySqlTransaction trans)
        {

            Producto producto = null;
            string queryVerificar = "SELECT stock_local, stock_general FROM productos WHERE codigo = @codigo";

            MySqlCommand cmdVerificar = new MySqlCommand(queryVerificar, conn, trans);
            cmdVerificar.Parameters.AddWithValue("@codigo", codigo);

            using (MySqlDataReader reader = cmdVerificar.ExecuteReader())
            {
                if (reader.Read())
                {
                    producto = new Producto
                    {
                        StockLocal = reader.GetInt32("stock_local"),
                        StockGeneral = reader.GetInt32("stock_general")
                    };
                }
            }

            if (producto != null && producto.StockLocal == 0)
            {
                if (producto.StockGeneral > 0)
                {
                    int cantidadAReponer = Math.Min(CANTIDAD_REPOSICION, producto.StockGeneral);

                    string queryReponer = "UPDATE productos SET " +
                                          "stock_local = @stockLocalNuevo, " +
                                          "stock_general = stock_general - @cantidadRepuesta " +
                                          "WHERE codigo = @codigo";

                    MySqlCommand cmdReponer = new MySqlCommand(queryReponer, conn, trans);
                    cmdReponer.Parameters.AddWithValue("@stockLocalNuevo", cantidadAReponer);
                    cmdReponer.Parameters.AddWithValue("@cantidadRepuesta", cantidadAReponer);
                    cmdReponer.Parameters.AddWithValue("@codigo", codigo);

                    cmdReponer.ExecuteNonQuery();

                }
                else
                {
                    MessageBox.Show("Error de excepcion", "Error");
                }
            }
        }
        public DataTable ObtenerHistorialVentas()
        {
            DataTable tablaHistorial = new DataTable();

            using (MySqlConnection conn = Conexion.ObtenerConecion())
            {
                try
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    t.fecha_hora_venta AS 'Fecha y Hora', 
                    p.nombre AS 'Producto', 
                    t.monto_pagado AS 'Monto'
                FROM 
                    transacciones t
                JOIN 
                    productos p ON t.codigo_producto = p.codigo
                ORDER BY 
                    t.fecha_hora_venta DESC";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);

                    adapter.Fill(tablaHistorial);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de excepcion"+ex, "Error");
                }
            }
            return tablaHistorial;
        }
    }
}
