using System;
using System.Globalization;
using System.Text;
using Excepciones;

namespace TP_03
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int DNI;


        protected Persona()
        {
        }

        protected Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            Nacionalidad = nacionalidad;
        }

        protected Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            DNI = dni;
        }
        
        protected Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            StringToDNI = dni;
        }

        public string StringToDNI
        {
            set { DNI = ValidarDni(nacionalidad, value); }
        }
        public string Nombre
        {
            get => nombre;
            set
            {
                nombre = ValidarNombreApellido(value);
            }
        }

        public string Apellido
        {
            get => apellido;
            set
            {
                apellido = ValidarNombreApellido(value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get => nacionalidad;
            set
            {
                switch (value)
                {
                    case ENacionalidad.Argentino:
                    case ENacionalidad.Extranjero:
                        nacionalidad = value;
                        break;
                    default:
                        throw new NacionalidadInvalidaException($"Nacionalidad {value} invalida.");
                        
                }

            }
        }

        public int Dni
        {
            get => DNI;
            set
            {
                DNI = ValidarDni(nacionalidad, value);
            }
        }


        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (ENacionalidad.Argentino.Equals(nacionalidad) && dato >= 1 && dato <= 89999999)
            {
                    return dato;
            }

            if (ENacionalidad.Extranjero.Equals(nacionalidad) && dato >= 90000000 && dato <= 99999999)
            {
                    return dato;
            }

            throw new NacionalidadInvalidaException(string.Format("Dni {0} no es valido.", dato));

        }      
        
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (int.TryParse(dato, out int datoInteger))
            {
                switch (nacionalidad)
                {
                    case ENacionalidad.Argentino when datoInteger >= 1 && datoInteger <= 89999999:
                        return datoInteger;
                    case ENacionalidad.Extranjero when datoInteger >= 90000000 && datoInteger <= 99999999:
                        return datoInteger;
                    default:
                        throw new NacionalidadInvalidaException(string.Format("La nacionalidad {0} no coincide con el dni {1}.", nacionalidad, dato));

                }
            }
            throw new DniInvalidoException(string.Format("Dni {0} no es valido.", dato));

        }

        private string ValidarNombreApellido(string value)
        {
            bool anyNonLetters = false;
            foreach (char letra in value)
            {
                if (!Char.IsLetter(letra))
                {
                    anyNonLetters = true;
                }
            }
            return anyNonLetters ? string.Empty : value;
        }


        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");   
            toString.AppendLine($"NACIONALIDAD: {this.Nacionalidad} \n");
            return toString.ToString();

        }
        public enum ENacionalidad
        {
            Argentino,Extranjero
        }

    
    }
    
}