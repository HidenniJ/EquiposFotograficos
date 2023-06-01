using EquiposFotograficos.Data.Request;
namespace EquiposFotograficos.Data.Response
{
    public class VentaResponse
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

		public VentaRequest ToRequest()
		{
			return new VentaRequest
			{
				Id = Id,
				ClienteId = ClienteId,
				Fecha = Fecha,
				Total = Total
			};
		}
	}
}
