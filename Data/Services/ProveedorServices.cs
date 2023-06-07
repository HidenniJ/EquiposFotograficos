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


    public class ProveedorServices : IProveedorServices
    {
        private readonly IEquiposFotograficoDbContext dbContext;

        public ProveedorServices(IEquiposFotograficoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result<List<ProveedorResponse>>> Consultar()
        {
            try
            {
                var proveedores = await dbContext.Proveedores.ToListAsync();
                var proveedoresResponse = proveedores.Select(p => p.ToResponse()).ToList();

                return new Result<List<ProveedorResponse>> { Success = true, Data = proveedoresResponse };
            }
            catch (Exception ex)
            {
                return new Result<List<ProveedorResponse>> { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result<ProveedorResponse>> ConsultarPorId(int proveedorId)
        {
            try
            {
                var proveedor = await dbContext.Proveedores.FindAsync(proveedorId);
                if (proveedor == null)
                {
                    return new Result<ProveedorResponse> { Success = false, Message = "No se encontró el proveedor" };
                }

                var proveedorResponse = proveedor.ToResponse();
                return new Result<ProveedorResponse> { Success = true, Data = proveedorResponse };
            }
            catch (Exception ex)
            {
                return new Result<ProveedorResponse> { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result> Crear(ProveedorRequest request)
        {
            try
            {
                var proveedor = new Proveedor
                {
                    Nombre = request.Nombre,
                    Direccion = request.Direccion,
                    Telefono = request.Telefono,
                    CorreoElectronico = request.CorreoElectronico
                };

                dbContext.Proveedores.Add(proveedor);
                await dbContext.SaveChangesAsync();

                return new Result { Success = true, Message = "Proveedor creado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result> Modificar(int proveedorId, ProveedorRequest request)
        {
            try
            {
                var proveedor = await dbContext.Proveedores.FindAsync(proveedorId);
                if (proveedor == null)
                {
                    return new Result { Success = false, Message = "No se encontró el proveedor" };
                }

                proveedor.Nombre = request.Nombre;
                proveedor.Direccion = request.Direccion;
                proveedor.Telefono = request.Telefono;
                proveedor.CorreoElectronico = request.CorreoElectronico;

                await dbContext.SaveChangesAsync();

                return new Result { Success = true, Message = "Proveedor modificado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result> Eliminar(int proveedorId)
        {
            try
            {
                var proveedor = await dbContext.Proveedores.FindAsync(proveedorId);
                if (proveedor == null)
                {
                    return new Result { Success = false, Message = "No se encontró el proveedor" };
                }

                dbContext.Proveedores.Remove(proveedor);
                await dbContext.SaveChangesAsync();

                return new Result { Success = true, Message = "Proveedor eliminado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = ex.Message };
            }
        }
    }
}
