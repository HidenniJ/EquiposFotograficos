using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EquiposFotograficos.Data.Entities
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public bool GestionClientes { get; set; }

        [Required]
        public bool GestionVentas { get; set; }

        [Required]
        public bool GestionProductos { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
