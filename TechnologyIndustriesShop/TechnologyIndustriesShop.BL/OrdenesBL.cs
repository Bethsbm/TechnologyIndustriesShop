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
    }
}
