namespace EquiposFotograficos.Data.Request
{
    public class ProductoRequest
    {
        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public string Categoria { get; set; } = null!;

        public string Marca { get; set; } = null!;

        public string Modelo { get; set; } = null!;

        public decimal PrecioDeVenta { get; set; } 

        public decimal PrecioDeCompra { get; set; } 

        public int CantidadEnInventario { get; set; }
    }
}
