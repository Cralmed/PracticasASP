using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ASP_MVC.Models
{
    public class AdmArticulo
    {
        private SqlConnection conexion;

        private void Conectar()
        {
            string stringConexion = ConfigurationManager.ConnectionStrings["Conexion"].ToString();
            conexion = new SqlConnection(stringConexion);
        }
        public int Alta(Articulo articulo)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("insert into Articulos (Codigo, Descripcion, Precio) values (@codigo, @descripcion, @precio)", conexion);
            sentencia.Parameters.Add("@codigo", System.Data.SqlDbType.Int);
            sentencia.Parameters.Add("@descripcion", System.Data.SqlDbType.VarChar);
            sentencia.Parameters.Add("@precio", System.Data.SqlDbType.Float);

            sentencia.Parameters["@codigo"].Value = articulo.Codigo;
            sentencia.Parameters["@descripcion"].Value = articulo.Descripcion;
            sentencia.Parameters["@precio"].Value = articulo.Precio;

            conexion.Open();
            int i = sentencia.ExecuteNonQuery();
            conexion.Close();
            return i;
        }
        public List<Articulo> TraerTodos()
        {
            Conectar();
            List<Articulo> articulos = new List<Articulo>();

            SqlCommand sentencia = new SqlCommand("select codigo, descripcion, precio from articulos", conexion);
            conexion.Open();
            SqlDataReader registros = sentencia.ExecuteReader();
            while (registros.Read())
            {
                Articulo articulo = new Articulo
                {
                    Codigo = int.Parse(registros["codigo"].ToString()),
                    Descripcion = registros["descripcion"].ToString(),
                    Precio = float.Parse(registros["precio"].ToString())
                };
                articulos.Add(articulo);
            }
            conexion.Close();
            return articulos;
        }
        public Articulo TraerArticulo(int Codigo)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("select codigo, descripcion, precio from articulos where codigo = @codigo", conexion);
            sentencia.Parameters.Add("@codigo",System.Data.SqlDbType.Int);
            sentencia.Parameters["@codigo"].Value = Codigo;
            conexion.Open();
            SqlDataReader registros = sentencia.ExecuteReader();
            Articulo retorno = new Articulo();
            if (registros.Read())
            {
                retorno.Codigo = int.Parse(registros["codigo"].ToString());
                retorno.Descripcion = registros["descripcion"].ToString();
                retorno.Precio = float.Parse(registros["precio"].ToString());
            }
            conexion.Close();
            return retorno;
        }
        public int Modificar(Articulo pArticulo)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("update articulos set descripcion = @descripcion, precio = @precio where codigo = @codigo", conexion);
            sentencia.Parameters.Add("@descripcion", System.Data.SqlDbType.VarChar);
            sentencia.Parameters.Add("@precio", System.Data.SqlDbType.Float);
            sentencia.Parameters.Add("@codigo", System.Data.SqlDbType.Int);
            sentencia.Parameters["@descripcion"].Value = pArticulo.Descripcion;
            sentencia.Parameters["@precio"].Value = pArticulo.Precio;
            sentencia.Parameters["@codigo"].Value = pArticulo.Codigo;
            conexion.Open();
            int i = sentencia.ExecuteNonQuery();
            conexion.Close();
            return i;
        }
        public int Borrar(int pCodigo)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("delete from articulos where codigo = @codigo", conexion);
            sentencia.Parameters.Add("@codigo", System.Data.SqlDbType.Int);
            sentencia.Parameters["@codigo"].Value = pCodigo;
            conexion.Open();
            int i = sentencia.ExecuteNonQuery();
            conexion.Close();
            return i;
        }


    }
}