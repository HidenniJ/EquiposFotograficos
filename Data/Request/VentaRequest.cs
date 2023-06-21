using EquiposFotograficos.Data.Entities;

namespace EquiposFotograficos.Data.Request
{
    
    public class VentaRequest
    {
		public int Id { get; set; }
		public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<DetalleVenta> DetallesVenta { get; set; }
    }
}
