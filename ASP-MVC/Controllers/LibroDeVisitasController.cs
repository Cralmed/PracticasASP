using ASP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC.Controllers
{
    public class LibroDeVisitasController : Controller
    {
        // GET: LibroDeVisitas
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Formulario()
        {
            return View();
        }
        public ActionResult CargaDeDatos()
        {
            string nombre = Request.Form["nombre"].ToString();
            string comentarios = Request.Form["comentarios"].ToString();
            LibroDeVisitas libro = new LibroDeVisitas();
            libro.Grabar(nombre, comentarios);
            return View("Index");
        }
        public ActionResult ListadoDeVisitas()
        {
            LibroDeVisitas libro = new LibroDeVisitas();
            string contenido = libro.Leer();
            ViewData["libro"] = contenido;
            return View();
        }
    }
}