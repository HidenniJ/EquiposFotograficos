using EquiposFotograficos.Data.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EquiposFotograficos.Data.Response;
namespace EquiposFotograficos.Data.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;

        [Required]
        public string Apellido { get; set; } = null!;

        [Required]
        public string Direccion { get; set; } = null!;

        [Required] public string Telefono { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string CorreoElectronico { get; set; } = null!;

        public static Cliente Crear(ClienteRequest cliente)
        {
            return new Cliente()
            {
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                CorreoElectronico = cliente.CorreoElectronico
            };
        }

        public bool Modificar(ClienteRequest cliente)
        {
            var cambio = false;

            if (Nombre != cliente.Nombre)
            {
                Nombre = cliente.Nombre;
                cambio = true;
            }
            if (Apellido != cliente.Apellido)
            {
                Apellido = cliente.Apellido;
                cambio = true;
            }
            if (Direccion != cliente.Direccion)
            {
                Direccion = cliente.Direccion;
                cambio = true;
            }
            if (Telefono != cliente.Telefono)
            {
                Telefono = cliente.Telefono;
                cambio = true;
            }
            if (CorreoElectronico != cliente.CorreoElectronico)
            {
                CorreoElectronico = cliente.CorreoElectronico;
                cambio = true;
            }

            return cambio;
        }
        public ClienteResponse ToResponse()
        {
            return new ClienteResponse()
            {
                Id = Id,
                Nombre = Nombre,
                Apellido = Apellido,
                Direccion = Direccion,
                Telefono = Telefono,
                CorreoElectronico = CorreoElectronico
            };

        }
    }
}
