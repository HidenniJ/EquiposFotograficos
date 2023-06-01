using EquiposFotograficos.Data.Request;
namespace EquiposFotograficos.Data.Response
{
    public class ProductoResponse
    {
		public int Id { get; set; }
		public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public decimal PrecioDeVenta { get; set; }
        public decimal PrecioDeCompra { get; set; }
        public int CantidadEnInventario { get; set; }

		public ProductoRequest ToRequest()
		{
			return new ProductoRequest()
			{
				Id = Id,
				Nombre = Nombre,
				Descripcion = Descripcion,
				Categoria = Categoria,
				Marca = Marca,
				Modelo = Modelo,
				PrecioDeVenta = PrecioDeVenta,
				PrecioDeCompra = PrecioDeCompra,
				CantidadEnInventario = CantidadEnInventario
			};
		}
	}
}
