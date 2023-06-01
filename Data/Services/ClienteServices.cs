using EquiposFotograficos.Data.Context;
using EquiposFotograficos.Data.Entities;
using EquiposFotograficos.Data.Request;
using EquiposFotograficos.Data.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EquiposFotograficos.Data.Services
{
    public class Result
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

    }
    public class Result<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

    }
    public class ClienteServices : IClienteServices
    {
        private readonly IEquiposFotograficoDbContext dbContext;

        public ClienteServices(IEquiposFotograficoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //Metodo crear//
        public async Task<Result> Crear(ClienteRequest request)
        {
            try
            {
                var cliente = Cliente.Crear(request);
                dbContext.Clientes.Add(cliente);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "ok", Success = true };

            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }
        //Metodo Modificar//
        public async Task<Result> Modificar(ClienteRequest request)
        {
            try
            {
                var cliente = await dbContext.Clientes
                    .FirstOrDefaultAsync(c => c.Id == request.Id);
                if (cliente == null)
                    return new Result() { Message = "No se encontro el cliente", Success = false };

                if (cliente.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        //Metodo Eliminar//
        public async Task<Result> Eliminar(ClienteRequest request)
        {
            try
            {
                var cliente = await dbContext.Clientes
                    .FirstOrDefaultAsync(c => c.Id == request.Id);
                if (cliente == null)

                    return new Result() { Message = "No se encontro el Cliente", Success = false };

                dbContext.Clientes.Remove(cliente);
                await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        //Metodo Listar o consultar//
        public async Task<Result<List<ClienteResponse>>> Consultar(string filtro)
        {
            try
            {
                var clientes = await dbContext.Clientes
                    .Include(c => c)
                    .Where(c =>
                        (c.Nombre + " " + c.Apellido + " " + c.Direccion + " " + c.Telefono + " " + c.CorreoElectronico)
                        .ToLower()
                        .Contains(filtro.ToLower())
                    )
                    .Select(c => c.ToResponse())
                    .ToListAsync();

                return new Result<List<ClienteResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = clientes
                };
            }
            catch (Exception E)
            {
                return new Result<List<ClienteResponse>>()
                {
                    Message = E.Message,
                    Success = false
                };

            }
        }
    }
}
