using EquiposFotograficos.Data.Request;
using EquiposFotograficos.Data.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EquiposFotograficos.Data.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreUsuario { get; set; }=null!;

        [Required]
        [EmailAddress]
        public string CorreoElectronico { get; set; } = null!;

        [Required]
        public string Contrasena { get; set; } = null!;

        [ForeignKey("Rol")]
        public int RolId { get; set; }
        public Rol Rol { get; set; } = null!;

        public static Usuario Crear(UsuarioRequest usuario)
            => new Usuario()
            {
                NombreUsuario = usuario.NombreUsuario,
                CorreoElectronico = usuario.CorreoElectronico,
                Contrasena = usuario.Contrasena,
            };
        public bool Modificar(UsuarioRequest usuario)
        {
              var cambio = false;
            if (NombreUsuario != usuario.NombreUsuario)
            {
                NombreUsuario = usuario.NombreUsuario;
                cambio = true;
            }
            if (CorreoElectronico != usuario.CorreoElectronico)
            {
                CorreoElectronico = usuario.CorreoElectronico;
                cambio = true;
            }
            if (Contrasena != usuario.Contrasena)
            {
                Contrasena = usuario.Contrasena;
                cambio = true;
            }
            return cambio;
            
        }

        public UsuarioResponse ToResponse()
        => new UsuarioResponse()
        {
            NombreUsuario = NombreUsuario,
            CorreoElectronico = CorreoElectronico,
            Contrasena = Contrasena
        };
    }
}
