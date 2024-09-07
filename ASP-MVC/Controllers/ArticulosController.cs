using ASP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC.Controllers
{
    public class ArticulosController : Controller
    {
        // GET : Articulos
        public ActionResult Articulos()
        {
            AdmArticulo admArt = new AdmArticulo();
            return View(admArt.TraerTodos());
        }
        public ActionResult Alta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Alta(FormCollection coleccion)
        {
            AdmArticulo oAdmArt = new AdmArticulo();
            Articulo articulo = new Articulo
            {
                Codigo = int.Parse(coleccion["codigo"]),
                Descripcion = coleccion["descripcion"].ToString(),
                Precio = float.Parse(coleccion["precio"].ToString()),
            };
            oAdmArt.Alta(articulo);
            return RedirectToAction("Articulos");
        }
        public ActionResult Baja(int cod)
        {
            AdmArticulo oAdmArt = new AdmArticulo();
            oAdmArt.Borrar(cod);
            return RedirectToAction("Articulos");
        }
        public ActionResult Modificar(int cod) // los parametros pasados por get deben contener el mismo nombre que el declarado en la vista para poder funcionar
        {
            AdmArticulo oAdmArt = new AdmArticulo();
            Articulo articulo = oAdmArt.TraerArticulo(cod);
            return View(articulo);
        }
        [HttpPost]
        public ActionResult Modificar(FormCollection coleccion)
        {
            AdmArticulo oAdmArt = new AdmArticulo();
            Articulo articulo = new Articulo
            {
                Codigo = int.Parse(coleccion["codigo"]),
                Descripcion = coleccion["descripcion"].ToString(),
                Precio = float.Parse(coleccion["precio"].ToString()),
            };
            oAdmArt.Modificar(articulo);
            return RedirectToAction("Articulos");
        }
        /*// GET: Articulos         //PARA REVISAR LOS METODOS Y VOLVERLOS A APLICAR CON LOS MANEJADORES DE EXCEPCIONES PROPIOS DEL CONTROLADOR
        public ActionResult Index()
        {
            return View();
        }

        // GET: Articulos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Articulos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articulos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Articulos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Articulos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
    }
}
