using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_15._08__CarpinteriaApp_.Datos
{
    internal class Parametros
    {
        public string Nombre { get; set; }
        public object Valor { get; set; }

        public Parametros(string nombre = "", object valor = null) 
        {
            Nombre = nombre;
            Valor = valor;
        }
    }
}
