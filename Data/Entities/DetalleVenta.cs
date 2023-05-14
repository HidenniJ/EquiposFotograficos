using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EquiposFotograficos.Data.Entities
{
    public class DetalleVenta
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Venta")]
        public int VentaId { get; set; }
        public Venta Venta { get; set; }

        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal PrecioVenta { get; set; }
    }
}
