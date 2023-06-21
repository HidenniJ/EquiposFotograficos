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
    public class VentaServices : IVentaServices
    {
        private readonly IEquiposFotograficoDbContext dbContext;

        public VentaServices(IEquiposFotograficoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Método CrearVenta
        public async Task<Result<VentaResponse>> CrearVenta(VentaRequest request)
        {
            try
            {
                var venta = Venta.Crear(request);

                dbContext.Ventas.Add(venta);
                await dbContext.SaveChangesAsync();

                var ventaResponse = venta.ToResponse();
                return new Result<VentaResponse>() { Message = "La venta ha sido creada exitosamente", Success = true, Data = ventaResponse };
            }
            catch (Exception e)
            {
                return new Result<VentaResponse>() { Message = e.Message, Success = false };
            }
        }

        // Método ListarVentas
        public async Task<Result<List<VentaResponse>>> ListarVentas()
        {
            try
            {
                var ventas = await dbContext.Ventas
                    .Include(v => v.Cliente)
                    .Include(v => v.DetallesVenta)
                    .ToListAsync();

                var ventasResponse = ventas.Select(v => v.ToResponse()).ToList();
                return new Result<List<VentaResponse>>() { Message = "Ok", Success = true, Data = ventasResponse };
            }
            catch (Exception e)
            {
                return new Result<List<VentaResponse>>() { Message = e.Message, Success = false };
            }
        }
    }
}
