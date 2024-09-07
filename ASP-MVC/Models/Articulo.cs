using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_MVC.Models
{
    public class Articulo
    {
        private int _codigo;
        private string _descripcion;
        private float _precio;

        public int Codigo { get => _codigo; set => _codigo = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public float Precio { get => _precio; set => _precio = value; }
    }
}