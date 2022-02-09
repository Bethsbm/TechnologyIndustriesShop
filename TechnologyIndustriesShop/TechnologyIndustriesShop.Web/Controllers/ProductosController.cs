using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyIndustriesShop.BL;

namespace TechnologyIndustriesShop.Web.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            var productosBL = new ProductosBL();
            var listaDeProductos = productosBL.AccederProductos();

            return View(listaDeProductos);
        }
    }
}