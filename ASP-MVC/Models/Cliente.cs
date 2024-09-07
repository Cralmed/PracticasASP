using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_MVC.Models
{
    public class Cliente
    {
        private int _codigo;
        private string _nombre;
        private string _apellido;
        private string _email;

        public int Codigo { get => _codigo; set => _codigo = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Email { get => _email; set => _email = value; }
    }
}