using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeterinariaApp.Entidades
{
    public class Usuario
    {
        //                 Esto no esta aun implementado, la idea seria que los clientes heredan de usuario
        //Atributos
        string user;
        string pass;
        enum permisos {cliente, admin}

        //Propiedades
        public string User 
        { 
            get 
            { 
                return user; 
            } 

            set
            {
                if (value != "")
                {
                    user = value;
                }
                else
                {
                    MessageBox.Show("El nombre de usuario no puede quedar vacio...");
                }
            }
        }
        public string Pass
        {
            get
            {
                return pass;
            }

            set
            {
                if (value != "")
                {
                    pass = value;
                }
                else
                {
                    MessageBox.Show("La contraseña no puede quedar vacia...");
                }
            }
        }


        //Constructor
        public Usuario(string user = "", string pass = "")
        {
            this.user = user;
            this.pass = pass;
        }



        //Metodos
        public void CambiarUser(string user)
        {
            this.User = user;
        }

        public void CambiarPass(string pass)
        {
            this.Pass = pass;
        }


    }
}
