using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EquiposFotograficos.Data.Request;
using EquiposFotograficos.Data.Response;
namespace EquiposFotograficos.Data.Entities
{
    public class Producto
    {
       
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public string Categoria { get; set; } = null!;

        public string Marca { get; set; } = null!;

        public string Modelo { get; set; } = null!;

        public decimal PrecioDeVenta { get; set; }

        public decimal PrecioDeCompra { get; set; }

        public int CantidadEnInventario { get; set; }

        public static Producto Crear(ProductoRequest producto)
        {
            return new Producto()
            {
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Categoria = producto.Categoria,
                Marca = producto.Marca,
                Modelo = producto.Modelo,
                PrecioDeVenta = producto.PrecioDeVenta,
                PrecioDeCompra = producto.PrecioDeCompra,
                CantidadEnInventario = producto.CantidadEnInventario
            };
        }

        public bool Modificar(ProductoRequest producto)
        {
            var cambio = false;

            if (Nombre != producto.Nombre)
            {
                Nombre = producto.Nombre;
                cambio = true;
            }
            if (Descripcion != producto.Descripcion)
            {
                Descripcion = producto.Descripcion;
                cambio = true;
            }
            if (Categoria != producto.Categoria)
            {
                Categoria = producto.Categoria;
                cambio = true;
            }
            if (Marca != producto.Marca)
            {
                Marca = producto.Marca;
                cambio = true;
            }
            if (Modelo != producto.Modelo)
            {
                Modelo = producto.Modelo;
                cambio = true;
            }
            if (PrecioDeVenta != producto.PrecioDeVenta)
            {
                PrecioDeVenta = producto.PrecioDeVenta;
                cambio = true;
            }
            if (PrecioDeCompra != producto.PrecioDeCompra)
            {
                PrecioDeCompra = producto.PrecioDeCompra;
                cambio = true;
            }
            if (CantidadEnInventario != producto.CantidadEnInventario)
            {
                CantidadEnInventario = producto.CantidadEnInventario;
                cambio = true;
            }

            return cambio;
        }

    }
}
