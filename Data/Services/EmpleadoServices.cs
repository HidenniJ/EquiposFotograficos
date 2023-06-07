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
    //public class Result
    //{
    //    public bool Success { get; set; }
    //    public string? Message { get; set; }
    //}

    //public class Result<T>
    //{
    //    public bool Success { get; set; }
    //    public string? Message { get; set; }
    //    public T? Data { get; set; }
    //}

    public class EmpleadoServices : IEmpleadoServices
    {
        private readonly IEquiposFotograficoDbContext dbContext;

        public EmpleadoServices(IEquiposFotograficoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(EmpleadoRequest request)
        {
            try
            {
                var empleado = new Empleado
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Direccion = request.Direccion,
                    Telefono = request.Telefono,
                    CorreoElectronico = request.CorreoElectronico,
                    Cargo = request.Cargo,
                    FechaDeContratacion = request.FechaDeContratacion,
                    SalarioBase = request.SalarioBase
                };

                dbContext.Empleados.Add(empleado);
                await dbContext.SaveChangesAsync();

                return new Result { Success = true, Message = "Empleado creado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result> Modificar(EmpleadoRequest request)
        {
            try
            {
                var empleado = await dbContext.Empleados.FindAsync(request.Id);
                if (empleado == null)
                {
                    return new Result { Success = false, Message = "No se encontró el empleado" };
                }

                empleado.Nombre = request.Nombre;
                empleado.Apellido = request.Apellido;
                empleado.Direccion = request.Direccion;
                empleado.Telefono = request.Telefono;
                empleado.CorreoElectronico = request.CorreoElectronico;
                empleado.Cargo = request.Cargo;
                empleado.FechaDeContratacion = request.FechaDeContratacion;
                empleado.SalarioBase = request.SalarioBase;

                await dbContext.SaveChangesAsync();

                return new Result { Success = true, Message = "Empleado modificado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result> Eliminar(int empleadoId)
        {
            try
            {
                var empleado = await dbContext.Empleados.FindAsync(empleadoId);
                if (empleado == null)
                {
                    return new Result { Success = false, Message = "No se encontró el empleado" };
                }

                dbContext.Empleados.Remove(empleado);
                await dbContext.SaveChangesAsync();

                return new Result { Success = true, Message = "Empleado eliminado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result<List<EmpleadoResponse>>> Consultar(string filtro)
        {
            try
            {
                var empleados = await dbContext.Empleados
                    .Where(e =>
                        (e.Nombre + " " + e.Apellido).Contains(filtro) ||
                        e.Cargo.Contains(filtro) ||
                        e.CorreoElectronico.Contains(filtro))
                    .ToListAsync();

                var empleadosResponse = empleados.Select(e => e.ToResponse()).ToList();

                return new Result<List<EmpleadoResponse>> { Success = true, Data = empleadosResponse };
            }
            catch (Exception ex)
            {
                return new Result<List<EmpleadoResponse>> { Success = false, Message = ex.Message };
            }
        }
    }
}
