using EquiposFotograficos.Data.Request;
using EquiposFotograficos.Data.Response;

namespace EquiposFotograficos.Data.Services.Interfaces
{
    public interface IVentaServices
    {
        Task<Result<VentaResponse>> CrearVenta(VentaRequest request);
        Task<Result<List<VentaResponse>>> ListarVentas();
    }
}