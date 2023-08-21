using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_15._08__CarpinteriaApp_.Entidades
{
    internal class Presupuesto
    {
        //Atributos
        public int PresupuestoNro { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public double CostoMO { get; set; }
        public double Descuento { get; set; }
        public DateTime FechaBaja { get; set; }
        public List<DetallePresupuesto> Detalles { get; set; }


        //Metodos
        //Constructor
        public Presupuesto()
        {
            Detalles = new List<DetallePresupuesto>();
        }

        //Agrega un detalle a la lista, se envia el objeto detalle como parametro de entrada
        public void AgregarDetalle(DetallePresupuesto detalle)
        {
            Detalles.Add(detalle);
        }

        //Remueve un detalle de la lista en una posicion enviada como parametro
        public void QuitarDetalle(int posicion)
        {

            Detalles.RemoveAt(posicion);
        }

        //Metodo para calcular el importe total sumando los subtotales de todos los detalles en el presupuesto
        public double CalcularTotal()
        {
            double total = 0;

            //Alternativa con for
            /*
            for (int i = 0; i < Detalles.Count; i++)
            {
                total += Detalles[i].CalcularSubtotal();
            }
            */

            //Alternativa con foreach
            foreach (DetallePresupuesto detalle in Detalles)
            {
                total += detalle.CalcularSubtotal();
            }

            return total;
        }

    }
}
