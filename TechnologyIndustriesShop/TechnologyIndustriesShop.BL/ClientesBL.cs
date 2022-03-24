using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyIndustriesShop.BL
{
    public class ClientesBL
    {
        Contexto _contexto;
        public List<Cliente> ListaDeClientes { get; set; }

        public ClientesBL()
        {
            _contexto = new Contexto();
            ListaDeClientes = new List<Cliente>();
        }

        public List<Cliente> AccederClientes()
        {
            ListaDeClientes = _contexto.Clientes
                .OrderBy(r => r.Nombre)
                .ToList();

            return ListaDeClientes;
        }

        public List<Cliente> ObtenerClientesActivos()
        {
            ListaDeClientes = _contexto.Clientes
                .Where(r => r.Activo == true)
                .OrderBy(r => r.Nombre)
                .ToList();

            return ListaDeClientes;
        }

        public void GuardarCliente(Cliente cliente)
        {
            if (cliente.Id == 0)
            {
                _contexto.Clientes.Add(cliente);
            }
            else
            {
                var clienteExistente = _contexto.Clientes.Find(cliente.Id);

                clienteExistente.Nombre = cliente.Nombre;
                clienteExistente.Direccion = cliente.Direccion;
                clienteExistente.Telefono = cliente.Telefono;
                clienteExistente.Activo = cliente.Activo;
            }
            _contexto.SaveChanges();
        }

        public Cliente ObtenerCliente(int id)
        {
            var cliente = _contexto.Clientes.Find(id);

            return cliente;
        }

        public void EliminarCliente(int id)
        {
            var cliente = _contexto.Clientes.Find(id);
            _contexto.Clientes.Remove(cliente);
            _contexto.SaveChanges();
        }
    }
}
