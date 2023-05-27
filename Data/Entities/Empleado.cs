using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EquiposFotograficos.Data.Request;
using EquiposFotograficos.Data.Response;
namespace EquiposFotograficos.Data.Entities
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;

            [Required]
        public string Apellido { get; set; } = null!;

        [Required]
        public string Direccion { get; set; } = null!;

        [Required]
        public string Telefono { get; set; }  = null!;

        [Required]
        [EmailAddress]
        public string CorreoElectronico { get; set; } = null!;

        [Required]
        public string Cargo { get; set; } = null!;

        [Required]
        public DateTime FechaDeContratacion { get; set; }

        [Required]
        public decimal SalarioBase { get; set; }

        public static Empleado Crear(EmpleadoRequest empleado)
            => new Empleado()
            {
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                Direccion = empleado.Direccion,
                Telefono = empleado.Telefono,
                CorreoElectronico = empleado.CorreoElectronico,
                Cargo = empleado.Cargo,
                FechaDeContratacion = empleado.FechaDeContratacion,
                SalarioBase = empleado.SalarioBase
            };

        public bool Modificar(EmpleadoRequest empleado)
        {
            var cambio = false;

            if (Nombre != empleado.Nombre)
            {
                Nombre = empleado.Nombre;
                cambio = true;
            }

            if (Apellido != empleado.Apellido)
            {
                Apellido = empleado.Apellido;
                cambio = true;
            }

            if (Direccion != empleado.Direccion)
            {
                Direccion = empleado.Direccion;
                cambio = true;
            }

            if (Telefono != empleado.Telefono)
            {
                Telefono = empleado.Telefono;
                cambio = true;
            }

            if (CorreoElectronico != empleado.CorreoElectronico)
            {
                CorreoElectronico = empleado.CorreoElectronico;
                cambio = true;
            }

            if (Cargo != empleado.Cargo)
            {
                Cargo = empleado.Cargo;
                cambio = true;
            }

            if (FechaDeContratacion != empleado.FechaDeContratacion)
            {
                FechaDeContratacion = empleado.FechaDeContratacion;
                cambio = true;
            }

            if (SalarioBase != empleado.SalarioBase)
            {
                SalarioBase = empleado.SalarioBase;
                cambio = true;
            }

            return cambio;
        }

        public EmpleadoResponse ToResponse()
            => new EmpleadoResponse()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Direccion = Direccion,
                Telefono = Telefono,
                CorreoElectronico = CorreoElectronico,
                Cargo = Cargo,
                FechaDeContratacion = FechaDeContratacion,
                SalarioBase = SalarioBase
            };
    }
}
