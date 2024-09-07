using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace ASP_MVC.Models
{
    public class AdmCliente
    {
        private SqlConnection conexion;

        private void Conectar()
        {
            string stringConexion = ConfigurationManager.ConnectionStrings["Conexion"].ToString();
            conexion = new SqlConnection(stringConexion);
        }
        public int Alta(Cliente cliente)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("insert into Clientes (Nombre, Apellido, Email) values (@nombre, @apellido, @email)", conexion);
            sentencia.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar);
            sentencia.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar);
            sentencia.Parameters.Add("@email", System.Data.SqlDbType.VarChar);

            sentencia.Parameters["@nombre"].Value = cliente.Nombre;
            sentencia.Parameters["@apellido"].Value = cliente.Apellido;
            sentencia.Parameters["@email"].Value = cliente.Email;

            conexion.Open();
            int i = sentencia.ExecuteNonQuery();
            conexion.Close();
            return i;
        }
        public List<Cliente> TraerTodos()
        {
            Conectar();
            List<Cliente> clientes = new List<Cliente>();

            SqlCommand sentencia = new SqlCommand("select codigo, nombre, apellido, email from clientes", conexion);
            conexion.Open();
            SqlDataReader registros = sentencia.ExecuteReader();
            while (registros.Read())
            {
                Cliente cliente = new Cliente
                {
                    Codigo = int.Parse(registros["codigo"].ToString()),
                    Nombre = registros["nombre"].ToString(),
                    Apellido = registros["apellido"].ToString(),
                    Email = registros["email"].ToString()
                };
                clientes.Add(cliente);
            }
            conexion.Close();
            return clientes;
        }
        public Cliente TraerCliente(int Codigo)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("select codigo, nombre, apellido, email from clientes where codigo = @codigo", conexion);
            sentencia.Parameters.Add("@codigo", System.Data.SqlDbType.Int);
            sentencia.Parameters["@codigo"].Value = Codigo;
            conexion.Open();
            SqlDataReader registros = sentencia.ExecuteReader();
            Cliente retorno = new Cliente();
            if (registros.Read())
            {
                retorno.Codigo = int.Parse(registros["codigo"].ToString());
                retorno.Nombre = registros["nombre"].ToString();
                retorno.Apellido = registros["apellido"].ToString();
                retorno.Email = registros["email"].ToString();
            };
            conexion.Close();
            return retorno;
        }
        public int Modificar(Cliente pCliente)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("update clientes set nombre = @nombre, apellido = @apellido, email = @email where codigo = @codigo", conexion);
            sentencia.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar);
            sentencia.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar);
            sentencia.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
            sentencia.Parameters.Add("@codigo", System.Data.SqlDbType.Int);
            sentencia.Parameters["@nombre"].Value = pCliente.Nombre;
            sentencia.Parameters["@apellido"].Value = pCliente.Apellido;
            sentencia.Parameters["@email"].Value = pCliente.Email;
            sentencia.Parameters["@codigo"].Value = pCliente.Codigo;
            conexion.Open();
            int i = sentencia.ExecuteNonQuery();
            conexion.Close();
            return i;
        }
        public int Borrar(int pCodigo)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("delete from clientes where codigo = @codigo", conexion);
            sentencia.Parameters.Add("@codigo", System.Data.SqlDbType.Int);
            sentencia.Parameters["@codigo"].Value = pCodigo;
            conexion.Open();
            int i = sentencia.ExecuteNonQuery();
            conexion.Close();
            return i;
        }
    }
}