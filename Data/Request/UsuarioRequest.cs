namespace EquiposFotograficos.Data.Request
{
    public class UsuarioRequest
    {

        public int Id { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string Contrasena { get; set; } = null!;

    }
}
