using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PetCenter.Datos
{
    public class Conexion
    {
        public static SqlConnection AbrirConexion()
        {
            //Los argumentos de conexion a la base de datos
            string strConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            var conexion = new SqlConnection(strConexion);
            conexion.Open();

            return conexion;
        }

        public static void CerrarConexion(ref SqlConnection cnx)
        {
            cnx.Close();
        }  
    }
}