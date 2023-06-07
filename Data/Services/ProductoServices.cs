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


    public class ProductoServices : IProductoServices
    {
        private readonly IEquiposFotograficoDbContext dbContext;

        public ProductoServices(IEquiposFotograficoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result<List<ProductoResponse>>> Consultar()
        {
            try
            {
                var productos = await dbContext.Productos.ToListAsync();
                var productosResponse = productos.Select(p => p.ToResponse()).ToList();

                return new Result<List<ProductoResponse>> { Success = true, Data = productosResponse };
            }
            catch (Exception ex)
            {
                return new Result<List<ProductoResponse>> { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result<ProductoResponse>> ConsultarPorId(int productoId)
        {
            try
            {
                var producto = await dbContext.Productos.FindAsync(productoId);
                if (producto == null)
                {
                    return new Result<ProductoResponse> { Success = false, Message = "No se encontró el producto" };
                }

                var productoResponse = producto.ToResponse();
                return new Result<ProductoResponse> { Success = true, Data = productoResponse };
            }
            catch (Exception ex)
            {
                return new Result<ProductoResponse> { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result> Crear(ProductoRequest request)
        {
            try
            {
                var producto = new Producto
                {
                    Nombre = request.Nombre,
                    Descripcion = request.Descripcion,
                    Categoria = request.Categoria,
                    Marca = request.Marca,
                    Modelo = request.Modelo,
                    PrecioDeVenta = request.PrecioDeVenta,
                    PrecioDeCompra = request.PrecioDeCompra,
                    CantidadEnInventario = request.CantidadEnInventario
                };

                dbContext.Productos.Add(producto);
                await dbContext.SaveChangesAsync();

                return new Result { Success = true, Message = "Producto creado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result> Modificar(int productoId, ProductoRequest request)
        {
            try
            {
                var producto = await dbContext.Productos.FindAsync(productoId);
                if (producto == null)
                {
                    return new Result { Success = false, Message = "No se encontró el producto" };
                }

                producto.Nombre = request.Nombre;
                producto.Descripcion = request.Descripcion;
                producto.Categoria = request.Categoria;
                producto.Marca = request.Marca;
                producto.Modelo = request.Modelo;
                producto.PrecioDeVenta = request.PrecioDeVenta;
                producto.PrecioDeCompra = request.PrecioDeCompra;
                producto.CantidadEnInventario = request.CantidadEnInventario;

                await dbContext.SaveChangesAsync();

                return new Result { Success = true, Message = "Producto modificado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result> Eliminar(int productoId)
        {
            try
            {
                var producto = await dbContext.Productos.FindAsync(productoId);
                if (producto == null)
                {
                    return new Result { Success = false, Message = "No se encontró el producto" };
                }

                dbContext.Productos.Remove(producto);
                await dbContext.SaveChangesAsync();

                return new Result { Success = true, Message = "Producto eliminado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = ex.Message };
            }
        }
    }
}
