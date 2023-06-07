using EquiposFotograficos.Data.Request;
using EquiposFotograficos.Data.Response;

namespace EquiposFotograficos.Data.Services.Interfaces
{
    public interface IProveedorServices
    {
        Task<Result<List<ProveedorResponse>>> Consultar();
        Task<Result<ProveedorResponse>> ConsultarPorId(int proveedorId);
        Task<Result> Crear(ProveedorRequest request);
        Task<Result> Eliminar(int proveedorId);
        Task<Result> Modificar(int proveedorId, ProveedorRequest request);
    }
}