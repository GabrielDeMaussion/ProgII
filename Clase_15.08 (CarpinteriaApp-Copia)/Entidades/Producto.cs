using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_15._08__CarpinteriaApp_.Entidades
{
    internal class Producto
    {
        public int ProductoNro { get; set; }
        public string Nombre {  get; set; }
        public double Precio { get; set; }
        public bool Activo { get; set; }




        public Producto(int productoNro = 0, string nombre = "", double precio = 0, bool activo = true)
        {
            ProductoNro = productoNro;
            Nombre = nombre;
            Precio = precio;
            Activo = activo;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
