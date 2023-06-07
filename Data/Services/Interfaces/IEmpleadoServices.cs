using EquiposFotograficos.Data.Request;
using EquiposFotograficos.Data.Response;

namespace EquiposFotograficos.Data.Services.Interfaces
{
    public interface IEmpleadoServices
    {
        Task<Result<List<EmpleadoResponse>>> Consultar(string filtro);
        Task<Result> Crear(EmpleadoRequest request);
        Task<Result> Eliminar(int empleadoId);
        Task<Result> Modificar(EmpleadoRequest request);
    }
}