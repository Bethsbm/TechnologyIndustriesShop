using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyIndustriesShop.BL;

namespace TechnologyIndustriesShop.WebAdmin.Controllers
{
    public class OrdenDetalleController : Controller
    {
        OrdenesBL _ordenBL;
        ProductosBL _productosBL;

        public OrdenDetalleController()
        {
            _ordenBL = new OrdenesBL();
            _productosBL = new ProductosBL();
        }

        // GET: OrdenDetalle
        public ActionResult Index(int id)
        {
            var orden = _ordenBL.ObtenerOrden(id);
            orden.ListaDeOrdenDetalle = _ordenBL.ObtenerOrdenDetalle(id);

            return View(orden);
        }

        public ActionResult Crear(int id)
        {
            var nuevoDetalleOrden = new OrdenDetalle();
            nuevoDetalleOrden.OrdenId = id;

            var productos = _productosBL.AccederProductos();

            ViewBag.ProductoId = new SelectList(productos, "Id", "Descripcion");

            return View(nuevoDetalleOrden);
        }

        [HttpPost]
        public ActionResult Crear(OrdenDetalle ordenDetalle)
        {
            if (ModelState.IsValid)
            {
                if (ordenDetalle.ProductoId == 0)
                {
                    ModelState.AddModelError("ProductoId", "Seleccione un producto");
                    return View(ordenDetalle);
                }

                _ordenBL.GuardarDetalleOrden(ordenDetalle);
                return RedirectToAction("Index", new { id =ordenDetalle.OrdenId });
            }

            var productos = _productosBL.AccederProductos();

            ViewBag.ProductoId = new SelectList(productos, "Id", "Descripcion");

            return View(ordenDetalle);
        }
    }
}