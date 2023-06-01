using EquiposFotograficos.Data.Request;
namespace EquiposFotograficos.Data.Response
{
	public class EmpleadoResponse
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = null!;
		public string Apellido { get; set; } = null!;
		public string Direccion { get; set; } = null!;
		public string Telefono { get; set; } = null!;
		public string CorreoElectronico { get; set; } = null!;
		public string Cargo { get; set; } = null!;
		public DateTime FechaDeContratacion { get; set; }
		public decimal SalarioBase { get; set; }

		public EmpleadoRequest ToRequest()
		{
			return new EmpleadoRequest()
			{
				Id = Id,
				Nombre = Nombre,
				Apellido = Apellido,
				Direccion = Direccion,
				Telefono = Telefono,
				CorreoElectronico = CorreoElectronico,
				Cargo = Cargo,
				FechaDeContratacion = FechaDeContratacion,
				SalarioBase = SalarioBase
			};
		}
	}
}
