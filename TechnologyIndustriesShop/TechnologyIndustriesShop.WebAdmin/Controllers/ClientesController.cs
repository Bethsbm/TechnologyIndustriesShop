using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyIndustriesShop.BL;

namespace TechnologyIndustriesShop.WebAdmin.Controllers
{
    [Authorize]

    public class ClientesController : Controller
    {
        ClientesBL _clientesBL;

        public ClientesController()
        {
            _clientesBL = new ClientesBL();
        }

        // GET: Clientes
        public ActionResult Index()
        {
            var listaDeClientes = _clientesBL.AccederClientes();

            return View(listaDeClientes);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            var nuevoCliente = new Cliente();

            return View(nuevoCliente);
        }

        [HttpPost]
        public ActionResult Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (cliente.Nombre != cliente.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "El nombre no debe tener espacios al inicio o al final");
                    return View(cliente);
                }
                _clientesBL.GuardarCliente(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var cliente = _clientesBL.ObtenerCliente(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (cliente.Nombre != cliente.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "El nombre no debe tener espacios al inicio o al final");
                    return View(cliente);
                }
                _clientesBL.GuardarCliente(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        [HttpGet]
        public ActionResult Detalle(int id)
        {
            var cliente = _clientesBL.ObtenerCliente(id);

            return View(cliente);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var cliente = _clientesBL.ObtenerCliente(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Eliminar(Cliente cliente)
        {
            _clientesBL.EliminarCliente(cliente.Id);
            return RedirectToAction("Index");
        }
    }
}