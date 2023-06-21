 using EquiposFotograficos.Data.Request;

namespace EquiposFotograficos.Data.Response
{
    public class ClienteResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; }  = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;

		//Función ToResquest() 
		public ClienteRequest ToRequest()
		{
			return new ClienteRequest()
			{
				Id = Id,
				Nombre = Nombre,
				Apellido = Apellido,
				Direccion = Direccion,
				Telefono = Telefono,
				CorreoElectronico = CorreoElectronico
			};

		}
	}
}
