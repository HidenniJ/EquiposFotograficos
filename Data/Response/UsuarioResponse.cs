using EquiposFotograficos.Data.Request;
namespace EquiposFotograficos.Data.Response
{
    public class UsuarioResponse
    {

        public int Id { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string Contrasena { get; set; } = null!;


		public UsuarioRequest ToRequest()
		{
			return new UsuarioRequest()
			{
				Id = Id,
				NombreUsuario = NombreUsuario,
				CorreoElectronico = CorreoElectronico,
				Contrasena = Contrasena
			};
		}
	}
}
