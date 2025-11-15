using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DS4_Parcial2
{
    public class Conexion
    {
        public static MySqlConnection ObtenerConecion()
        {
            string cadena = "server=localhost; database=GI_MEM; Uid=root; password=3$Knq84gpiLzye;";

            MySqlConnection conexion = new MySqlConnection(cadena);

            return conexion;
        }
    }
}
