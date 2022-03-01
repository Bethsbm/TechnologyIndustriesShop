using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyIndustriesShop.BL
{
    public class Producto
    {
        public Producto()
        {
            Activo = true;
        }

        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Ingrese una descripción para el producto")]
        [MinLength(5, ErrorMessage = "Ingrese una descripción de al menos 5 caracteres")]
        [MaxLength(30, ErrorMessage = "Ingrese una descripción de 15 caracteres máximo")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese un precio para el producto")]
        [Range(1,1000000000, ErrorMessage = "Ingrese un precio entre 1 y 1000000000")]
        public double Precio { get; set; }
        public bool Activo { get; set; }
        
        [Display(Name = "Categoría")] 
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }
    }
}
