using EquiposFotograficos.Data.Context;
using EquiposFotograficos.Data.Entities;
using EquiposFotograficos.Data.Request;
using EquiposFotograficos.Data.Response;
using EquiposFotograficos.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquiposFotograficos.Data.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IEquiposFotograficoDbContext dbContext;

        public UsuarioServices(IEquiposFotograficoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Método AgregarUsuario
        public async Task<Result<UsuarioResponse>> AgregarUsuario(UsuarioRequest request)
        {
            try
            {
                var usuario = new Usuario
                {
                    NombreUsuario = request.NombreUsuario,
                    CorreoElectronico = request.CorreoElectronico,
                    Contrasena = request.Contrasena
                };

                dbContext.Usuarios.Add(usuario);
                await dbContext.SaveChangesAsync();

                var usuarioResponse = usuario.ToResponse();
                return new Result<UsuarioResponse>() { Message = "El usuario ha sido creado exitosamente", Success = true, Data = usuarioResponse };
            }
            catch (Exception e)
            {
                return new Result<UsuarioResponse>() { Message = e.Message, Success = false };
            }
        }

        // Método ObtenerUsuarioPorId
        public async Task<Result<UsuarioResponse>> ObtenerUsuarioPorId(int id)
        {
            try
            {
                var usuario = await dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
                if (usuario == null)
                    return new Result<UsuarioResponse>() { Message = "No se encontró el usuario", Success = false };

                var usuarioResponse = usuario.ToResponse();
                return new Result<UsuarioResponse>() { Message = "Ok", Success = true, Data = usuarioResponse };
            }
            catch (Exception e)
            {
                return new Result<UsuarioResponse>() { Message = e.Message, Success = false };
            }
        }

        // Método ObtenerUsuarios
        public async Task<Result<List<UsuarioResponse>>> ObtenerUsuarios()
        {
            try
            {
                var usuarios = await dbContext.Usuarios.ToListAsync();
                var usuariosResponse = usuarios.Select(u => u.ToResponse()).ToList();
                return new Result<List<UsuarioResponse>>() { Message = "Ok", Success = true, Data = usuariosResponse };
            }
            catch (Exception e)
            {
                return new Result<List<UsuarioResponse>>() { Message = e.Message, Success = false };
            }
        }

        // Método ActualizarUsuario
        public async Task<Result<UsuarioResponse>> ActualizarUsuario(int id, UsuarioRequest request)
        {
            try
            {
                var usuario = await dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
                if (usuario == null)
                    return new Result<UsuarioResponse>() { Message = "No se encontró el usuario", Success = false };

                usuario.NombreUsuario = request.NombreUsuario;
                usuario.CorreoElectronico = request.CorreoElectronico;
                usuario.Contrasena = request.Contrasena;
                await dbContext.SaveChangesAsync();

                var usuarioResponse = usuario.ToResponse();
                return new Result<UsuarioResponse>() { Message = "El usuario ha sido actualizado exitosamente", Success = true, Data = usuarioResponse };
            }
            catch (Exception e)
            {
                return new Result<UsuarioResponse>() { Message = e.Message, Success = false };
            }
        }

        // Método EliminarUsuario
        public async Task<Result> EliminarUsuario(int id)
        {
            try
            {
                var usuario = await dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
                if (usuario == null)
                    return new Result() { Message = "No se encontró el usuario", Success = false };

                dbContext.Usuarios.Remove(usuario);
                await dbContext.SaveChangesAsync();

                return new Result() { Message = "El usuario ha sido eliminado exitosamente", Success = true };
            }
            catch (Exception e)
            {
                return new Result() { Message = e.Message, Success = false };
            }
        }
    }
}
