namespace EquiposFotograficos.Data.Request
{
    public class VentaRequest
    {
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
    }
}
