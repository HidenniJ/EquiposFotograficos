using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EquiposFotograficos.Data.Entities
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Categoria { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public decimal PrecioDeVenta { get; set; }

        [Required]
        public decimal PrecioDeCompra { get; set; }

        [Required]
        public int CantidadEnInventario { get; set; }
    }
}
