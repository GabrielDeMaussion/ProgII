using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaApp.Entidades
{
    internal class Cliente
    {
        //Atributos
        string nombre;
        string sexo;
        int codigo;
        List<Mascota> mascotas;


        //Propiedades
        public string Nombre            { get {  return nombre; }       set {  nombre = value; } }
        public string Sexo              { get {  return sexo; }         set {  sexo = value; } }
        public int Codigo               { get {  return codigo; }       set {  codigo = value; } }
        public List<Mascota> Mascotas   { get { return mascotas; }      set {  mascotas = value; } }


        //Constructor
        public Cliente(string Nombre = "(Sin especificar)", string Sexo = "(Sin especificar)", int Codigo = -1, List<Mascota> Mascotas = null)
        {
            this.Nombre = Nombre;
            this.Sexo = Sexo;
            this.Codigo = Codigo;

            //Creacion de la lista vacia en caso de "null"
            if (Mascotas != null)
            {
                this.Mascotas = Mascotas;
            }
            else
            {
                this.Mascotas = new List<Mascota>();
            }

        }
    }
}
