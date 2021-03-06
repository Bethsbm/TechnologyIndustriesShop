using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechnologyIndustriesShop.BL;

namespace TechnologyIndustriesShop.Win
{
    public partial class Form2 : Form
    {
        ReportedeVentasPorProductoBL _reporteVentasPorProductoBL;
        public Form2()
        {
            InitializeComponent();
            _reporteVentasPorProductoBL = new ReportedeVentasPorProductoBL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActualizarDatos();
        }

        private void ActualizarDatos()
        {
            var listaDeVentasPorProducto = _reporteVentasPorProductoBL.ObtenerVentasPorProducto();
            listaDeVentasPorProductoBindingSource.DataSource = listaDeVentasPorProducto;
            listaDeVentasPorProductoBindingSource.ResetBindings(false);
        }
    }
}
