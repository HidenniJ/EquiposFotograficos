using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EquiposFotograficos.Data.Request;
using EquiposFotograficos.Data.Response;
namespace EquiposFotograficos.Data.Entities
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public decimal Total { get; set; }

        public ICollection<DetalleVenta> DetallesVenta { get; set; } = null!;

        public static Venta Crear(VentaRequest venta)
        {
            return new Venta()
            {
                ClienteId = venta.ClienteId,
                Fecha = venta.Fecha,
                Total = venta.Total
            };
        }

        public bool Modificar(VentaRequest venta)
        {
            bool cambio = false;

            if (ClienteId != venta.ClienteId)
            {
                ClienteId = venta.ClienteId;
                cambio = true;
            }

            if (Fecha != venta.Fecha)
            {
                Fecha = venta.Fecha;
                cambio = true;
            }

            if (Total != venta.Total)
            {
                Total = venta.Total;
                cambio = true;
            }

            return cambio;
        }
        public VentaResponse ToResponse()
        {
            return new VentaResponse()
            {
                Id = Id,
                Cliente = Cliente!.ToResponse()!,
                ClienteId = ClienteId,
                Fecha = Fecha,
                Total = Total
            };
        }
    }
}
