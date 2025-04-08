using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace PSC09

{
    public class Item
    {
        public string _Nombre { get; set; }
        public int _Valor { get; set; }

        public Item(string name, int value)
        {
            _Nombre = name;
            _Valor = value;
        }

        public override string ToString()
        {
            return _Nombre;
        }
    }

    public class cnn
    {
        public static string db = @"Data Source =ENMA\MSSQLSERVER01; Initial Catalog=P1; integrated security = true";

    }

    public class Busco
    {
        public static string BuscaUltimoNumero(string nmId)
        {
            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();
            SqlCommand cmd = new SqlCommand("SELECT CONTADOR + 1 AS ULTIMO FROM SECUENCIAS WHERE ID ='" + nmId + "'", cnx);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                return rdr["ULTIMO"].ToString();
            }

            cmd.Dispose();
            cnx.Close();
            return null;
        }

        public static string BuscaNombreAlmacen(string nmId)
        {
            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();
            SqlCommand cmd = new SqlCommand("SELECT NOMBREALMACEN FROM ALMACENES WHERE IDALMACEN ='" + nmId + "'", cnx);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                return rdr["NOMBREALMACEN"].ToString();
            }

            cmd.Dispose();
            cnx.Close();
            return null;
        }

        public static string BuscaNombreCliente(string nmId)
        {
            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();
            SqlCommand cmd = new SqlCommand("SELECT NOMBRECLIENTE FROM CLIENTES WHERE IDCLIENTE ='" + nmId + "'", cnx);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                return rdr["NOMBRECLIENTE"].ToString();
            }

            cmd.Dispose();
            cnx.Close();
            return null;
        }
    }
}
