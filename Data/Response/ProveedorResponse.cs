using EquiposFotograficos.Data.Request;
namespace EquiposFotograficos.Data.Response
{
    public class ProveedorResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;

		public ProveedorRequest ToRequest()
		{
			return new ProveedorRequest()
			{
				Id = Id,
				Nombre = Nombre,
				Direccion = Direccion,
				Telefono = Telefono,
				CorreoElectronico = CorreoElectronico
			};
		}
	}
}
