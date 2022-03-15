using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyIndustriesShop.BL
{
    public class OrdenesBL
    {
        Contexto _contexto;
        public List<Orden> ListaDeOrdenes { get; set; }
        
        public OrdenesBL()
        {
            _contexto = new Contexto();
            ListaDeOrdenes = new List<Orden>();
        }

        public List<Orden> AccederOrdenes()
        {
            ListaDeOrdenes = _contexto.Ordenes
                .Include("Cliente")
                .ToList();
            return ListaDeOrdenes;
        }

        public void GuardarOrden(Orden orden)
        {
            if (orden.Id == 0)
            {
                _contexto.Ordenes.Add(orden);
            }
            else
            {
                var ordenExistente = _contexto.Ordenes.Find(orden.Id);
                ordenExistente.ClienteId = orden.ClienteId;
                ordenExistente.Activo = orden.Activo;
            }

            _contexto.SaveChanges();
        }

        public Orden ObtenerOrden(int id)
        {
            var orden = _contexto.Ordenes.Include("Cliente").FirstOrDefault(p => p.Id == id);

            return orden;
        }

        public List<OrdenDetalle> ObtenerOrdenDetalle(int ordenId)
        {
            var listaDeOrdenesDetalle = _contexto.OrdenDetalle
                .Include("Producto")
                .Where(o => o.OrdenId == ordenId).ToList();
            return listaDeOrdenesDetalle;
        }

        public OrdenDetalle ObtenerOrdenDetallePorId(int id)
        {
            var ordenDetalle = _contexto.OrdenDetalle.Include("Producto").FirstOrDefault(p => p.Id == id);

            return ordenDetalle;
        }

        public void GuardarDetalleOrden(OrdenDetalle ordenDetalle)
        {
            var producto = _contexto.Productos.Find(ordenDetalle.ProductoId);

            ordenDetalle.Precio = producto.Precio;
            ordenDetalle.Total = ordenDetalle.Cantidad * ordenDetalle.Precio;

            _contexto.OrdenDetalle.Add(ordenDetalle);

            var orden = _contexto.Ordenes.Find(ordenDetalle.OrdenId);
            orden.Total = orden.Total + ordenDetalle.Total;

            _contexto.SaveChanges();
        }

        public void EliminarOrdenDetalle(int id)
        {
            var ordenDetalle = _contexto.OrdenDetalle.Find(id);
            _contexto.OrdenDetalle.Remove(ordenDetalle);

            var orden = _contexto.Ordenes.Find(ordenDetalle.OrdenId);
            orden.Total = orden.Total - ordenDetalle.Total;

            _contexto.SaveChanges();
        }
    }
}
