using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyIndustriesShop.BL;

namespace TechnologyIndustriesShop.WebAdmin.Controllers
{
    [Authorize]

    public class CategoriasController : Controller
    {
        CategoriasBL _categoriasBL;

        public CategoriasController()
        {
            _categoriasBL = new CategoriasBL();
        }

        // GET: Categorias
        public ActionResult Index()
        {
            var listaDeCategorias = _categoriasBL.AccederCategorias();
            return View(listaDeCategorias);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            var nuevaCategoria = new Categoria();

            return View(nuevaCategoria);
        }

        [HttpPost]
        public ActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La descripción no debe tener espacios al inicio o al final");
                    return View(categoria);
                }
                _categoriasBL.GuardarCategoria(categoria);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);

            return View(categoria);
        }

        [HttpPost]
        public ActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La descripción no debe tener espacios al inicio o al final");
                    return View(categoria);
                }
                _categoriasBL.GuardarCategoria(categoria);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        [HttpGet]
        public ActionResult Detalle(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);

            return View(categoria);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);

            return View(categoria);
        }

        [HttpPost]
        public ActionResult Eliminar(Categoria categoria)
        {
            _categoriasBL.EliminarCategoria(categoria.Id);
            return RedirectToAction("Index");
        }
    }
}