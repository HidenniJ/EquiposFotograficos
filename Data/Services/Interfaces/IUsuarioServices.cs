using EquiposFotograficos.Data.Request;
using EquiposFotograficos.Data.Response;

namespace EquiposFotograficos.Data.Services.Interfaces
{
    public interface IUsuarioServices
    {
        Task<Result<UsuarioResponse>> ActualizarUsuario(int id, UsuarioRequest request);
        Task<Result<UsuarioResponse>> AgregarUsuario(UsuarioRequest request);
        Task<Result> EliminarUsuario(int id);
        Task<Result<UsuarioResponse>> ObtenerUsuarioPorId(int id);
        Task<Result<List<UsuarioResponse>>> ObtenerUsuarios();
    }
}