using EquiposFotograficos.Data.Request;
using EquiposFotograficos.Data.Response;

namespace EquiposFotograficos.Data.Services.Interfaces
{
    public interface IProductoServices
    {
        Task<Result<List<ProductoResponse>>> Consultar();
        Task<Result<ProductoResponse>> ConsultarPorId(int productoId);
        Task<Result> Crear(ProductoRequest request);
        Task<Result> Eliminar(int productoId);
        Task<Result> Modificar(int productoId, ProductoRequest request);
    }
}