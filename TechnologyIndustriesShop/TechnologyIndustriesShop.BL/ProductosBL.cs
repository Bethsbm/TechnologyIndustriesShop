using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyIndustriesShop.BL
{
    public class ProductosBL
    {
        public List<Producto> AccederProductos()
        {
            var producto1 = new Producto();
            producto1.Id = 1;
            producto1.Descripcion = "iPhone 13 Pro";
            producto1.Precio = 35000;
            

            var producto2 = new Producto();
            producto2.Id = 2;
            producto2.Descripcion = "iPhone 13 Pro Max";
            producto2.Precio = 50000;

            var listaDeProductos = new List<Producto>();
            listaDeProductos.Add(producto1);
            listaDeProductos.Add(producto2);

            return listaDeProductos;
        }
    }
}
