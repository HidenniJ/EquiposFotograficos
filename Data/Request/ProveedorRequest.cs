namespace EquiposFotograficos.Data.Request
{
    //Clase de respuesta
    public class ProveedorRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
    }
}
