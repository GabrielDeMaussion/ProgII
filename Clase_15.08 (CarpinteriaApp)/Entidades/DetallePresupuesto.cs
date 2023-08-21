using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_15._08__CarpinteriaApp_.Entidades
{
    internal class DetallePresupuesto
    {
        //Atributos
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        
        //Metodos

        //Calcular subtotal
        public double CalcularSubtotal()
        {
            double total = 0;
            total = Producto.Precio * Cantidad;
            return total;
        }
    }
}
