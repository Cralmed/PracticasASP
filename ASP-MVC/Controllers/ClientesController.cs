using ASP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            AdmCliente cliente = new AdmCliente();
            return View(cliente.TraerTodos());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            AdmCliente admCliente = new AdmCliente();
            Cliente cliente = admCliente.TraerCliente(id);

            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(FormCollection coleccion)
        {
            try
            {
                AdmCliente admCliente = new AdmCliente();
                Cliente cliente = new Cliente
                {
                    Nombre = coleccion["nombre"],
                    Apellido = coleccion["apellido"],
                    Email = coleccion["email"],
                };
                admCliente.Alta(cliente);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return View(); // sin manejo de errores aun
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {

            AdmCliente admCliente = new AdmCliente();
            Cliente cliente = admCliente.TraerCliente(id);

            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection coleccion)
        {
            try
            {
                AdmCliente admCliente = new AdmCliente();
                Cliente cliente = new Cliente
                {
                    Codigo = id,
                    Nombre = coleccion["nombre"],
                    Apellido = coleccion["apellido"],
                    Email = coleccion["email"],
                };
                admCliente.Modificar(cliente);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return View(); // sin manejo de errores aun
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            AdmCliente admCliente = new AdmCliente();
            Cliente cliente = admCliente.TraerCliente(id);

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                AdmCliente admCliente = new AdmCliente();
                admCliente.Borrar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
