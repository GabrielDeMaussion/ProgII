using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaApp.Datos
{
    internal class Parametros
    {
        //Atributos
        string nombre;
        object valor;


        //Propiedades
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public object Valor { get {  return valor; } set {  valor = value; } }


        //Constructor
        public Parametros(string Nombre = "", object Valor = null) 
        { 
            this.nombre = Nombre;
            this.Valor = Valor;
        }


    }
}
