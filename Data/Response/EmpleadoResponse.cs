namespace EquiposFotograficos.Data.Response
{
    public class EmpleadoResponse
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        public DateTime FechaDeContratacion { get; set; }
        public decimal SalarioBase { get; set; }
    }
}
