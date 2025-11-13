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
            string cadena = "server=localhost; database=GI_MEM; Uid=root; password=admin;";

            MySqlConnection conexion = new MySqlConnection(cadena);

            return conexion;
            /*CREATE DATABASE GI_MEM;

USE ME;

CREATE TABLE productos(
id INT PRIMARY KEY NOT NULL,
seccion VARCHAR(25) NOT NULL,
nombre VARCHAR(25) NOT NULL,
precio DECIMAL NOT NULL,
stock INT NOT NULL
);

CREATE TABLE transacciones(
id_venta INT PRIMARY KEY NOT NULL,
ventas decimal not null,
cantitadVentas INT NOT NULL
);*/
            
        }
    }
}
