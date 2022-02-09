using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyIndustriesShop.BL
{
    public class ProductosBL
    {
        Contexto _contexto;
        public List<Producto> ListaDeProductos { get; set; }

        public ProductosBL()
        {
            _contexto = new Contexto();
            ListaDeProductos = new List<Producto>();
        }

        public List<Producto> AccederProductos()
        {
            ListaDeProductos = _contexto.Productos.ToList();
            return ListaDeProductos;
        }
    }
}
