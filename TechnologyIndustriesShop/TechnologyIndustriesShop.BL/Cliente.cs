using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyIndustriesShop.BL
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del cliente")]
        [MinLength(3, ErrorMessage = "Ingrese un mínimo de 3 caracteres")]
        [MaxLength(60, ErrorMessage = "Ingrese un máximo de 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese el teléfono del cliente")]
        [MinLength(8, ErrorMessage = "Ingrese un mínimo de 8 caracteres")]
        [MaxLength(8, ErrorMessage = "Ingrese un máximo de 8 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Ingrese la dirección del cliente")]
        [MinLength(3, ErrorMessage = "Ingrese un mínimo de 3 caracteres")]
        public string Direccion { get; set; }
        public bool Activo { get; set; }
    }
}
