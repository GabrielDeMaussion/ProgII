using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaApp.Entidades
{
    internal class Mascota
    {
        //Atributos
        internal string nombre;
        internal int edad;
        internal string tipo;


        //Propiedades
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public int Edad { get { return edad; } set {  edad = value; } }
        public string Tipo { get { return tipo; } set { tipo = value; } }


        //Constructor
        public Mascota(string Nombre = "(Sin especificar)", int Edad = -1, string Tipo = "(Sin especificar)") 
        { 
            this.Nombre = Nombre;
            this.Edad = Edad;
            this.Tipo = Tipo;
        }

    }
}
