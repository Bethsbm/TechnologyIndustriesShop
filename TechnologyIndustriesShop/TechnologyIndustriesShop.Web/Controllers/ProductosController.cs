using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyIndustriesShop.Web.Models;

namespace TechnologyIndustriesShop.Web.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            var producto1 = new ProductoModel();
            producto1.Id = 1;
            producto1.Descripcion = "iPhone 13 Pro";

            var producto2 = new ProductoModel();
            producto2.Id = 1;
            producto2.Descripcion = "iPhone 13 Pro Max";

            var listaDeProductos = new List<ProductoModel>();
            listaDeProductos.Add(producto1);
            listaDeProductos.Add(producto2);

            return View(listaDeProductos);
        }
    }
}