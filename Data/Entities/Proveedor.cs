using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EquiposFotograficos.Data.Request;
using EquiposFotograficos.Data.Response;
namespace EquiposFotograficos.Data.Entities
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }

        [Required] public string Nombre { get; set; } = null!;

        [Required] public string Direccion { get; set; } = null!;

        [Required] public string Telefono { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string CorreoElectronico { get; set; } = null!;

        public static Proveedor Crear(ProveedorRequest proveedor)
        {
            return new Proveedor()
            {
                Nombre = proveedor.Nombre,
                Direccion = proveedor.Direccion,
                Telefono = proveedor.Telefono,
                CorreoElectronico = proveedor.CorreoElectronico
            };
        }

        public bool Modificar(ProveedorRequest proveedor)
        {
            var cambio = false;

            if (Nombre != proveedor.Nombre)
            {
                Nombre = proveedor.Nombre;
                cambio = true;
            }
            if (Direccion != proveedor.Direccion)
            {
                Direccion = proveedor.Direccion;
                cambio = true;
            }
            if (Telefono != proveedor.Telefono)
            {
                Telefono = proveedor.Telefono;
                cambio = true;
            }
            if (CorreoElectronico != proveedor.CorreoElectronico)
            {
                CorreoElectronico = proveedor.CorreoElectronico;
                cambio = true;
            }

            return cambio;
        }
    }
}
