namespace EquiposFotograficos.Data.Response
{
    public class VentaResponse
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
    }
}
