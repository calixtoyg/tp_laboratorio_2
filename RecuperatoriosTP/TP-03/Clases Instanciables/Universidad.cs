using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Archivos;
using Excepciones;
using TP_03;

namespace Clases_Instanciables
{
    [Serializable]
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        /// <summary>
        /// Constructor publico
        /// </summary>
        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
        }

        /// <summary>
        /// Guardar una universidad en archivo Universidad.xml (carpeta bin\Debug)
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        /// <exception cref="ArchivosException"></exception>
        public static bool Guardar(Universidad uni)
        {
                Xml<Universidad> xmlUni = new Xml<Universidad>();
                xmlUni.Guardar("Universidad.xml", uni);
                return true;
        }

        /// <summary>
        /// Lee un archivo tomado de bin\Debug\Universidad.xml y lo convierte a un objecto del tipo Universidad
        /// </summary>
        /// <returns></returns>
        private Universidad Leer()
        {
            Xml<Universidad> xmlUni = new Xml<Universidad>();
            Universidad universidad;
            xmlUni.Leer("Universidad.xml", out universidad);
            return universidad;
        }

        public Jornada this[int index]
        {
            get { return jornada[index]; }
            set { jornada[index] = value; }
        }

        public List<Alumno> Alumnos
        {
            get => alumnos;
            set => alumnos = value;
        }

        public List<Jornada> Jornada
        {
            get => jornada;
            set => jornada = value;
        }

        public List<Profesor> Instructores
        {
            get => profesores;
            set => profesores = value;
        }

        /// <summary>
        /// Compara una Universidad con un Alumno retornado true si el dni o legajo del alumno en la Universidad es igual al Alumno a comparar.
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad universidad, Alumno alumno)
        {
            if (ReferenceEquals(universidad, null))
            {
                return false;
            }

            foreach (Alumno alu in universidad.alumnos)
            {
                if (alumno == alu)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Universidad universidad, Alumno alumno)
        {
            return !(universidad == alumno);
        }
        /// <summary>
        /// Compara una Universidad con un Profesor retornado true si el dni o legajo del profesor en la Universidad es igual al Profesor a comparar.
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="profesor"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad universidad, Profesor profesor)
        {
            if (ReferenceEquals(universidad, null))
            {
                return false;
            }

            foreach (Profesor profe in universidad.profesores)
            {
                if (profe == profesor)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Universidad universidad, Profesor profesor)
        {
            return !(universidad == profesor);
        }

        /// <summary>
        /// Agrega una clase a una universidad verificando que el alumno pueda dar la clase, osea que este en la misma y el profesor tenga esa clase.
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="clases"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad universidad, EClases clases)
        {
            List<Alumno> alumnosQuePuedenTomarLaClase = new List<Alumno>();
            Profesor profesorQuePuedeDarLaClase = universidad == clases;

            foreach (Alumno alumno in universidad.alumnos)
            {
                if (alumno == clases)
                {
                    alumnosQuePuedenTomarLaClase.Add(alumno);
                }
            }

            Jornada jornada = new Jornada(clases, profesorQuePuedeDarLaClase);
            jornada.Alumnos = alumnosQuePuedenTomarLaClase;

            universidad.jornada.Add(jornada);

            return universidad;

        }

        /// <summary>
        /// Suma un Alumno a una Universidad verificando si el alumno se encuentra o no en la lista.
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        /// <exception cref="AlumnoRepetidoException"></exception>
        public static Universidad operator +(Universidad universidad, Alumno alumno)
        {
            if (universidad == alumno)
            {
                throw new AlumnoRepetidoException("El alumno ya se encuentra en la lista");
            }

            universidad.alumnos.Add(alumno);
            return universidad;
        }

        public static Universidad operator +(Universidad universidad, Profesor profesor)
        {
            if (universidad != profesor)
            {
                universidad.profesores.Add(profesor);
            }

            return universidad;
        }

        /// <summary>
        /// Retorna un profesor que pueda dar la clase.
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="clases"></param>
        /// <returns></returns>
        /// <exception cref="SinProfesorException"></exception>
        public static Profesor operator ==(Universidad universidad, EClases clases)
        {
            foreach (Profesor profesor in universidad.profesores)
            {
                if (profesor == clases)
                {
                    return profesor;
                }
            }

            throw new SinProfesorException("No hay profesor que pueda dar la clase.\n");
        }

        public static Profesor operator !=(Universidad universidad, EClases clases)
        {
            foreach (Profesor profesor in universidad.profesores)
            {
                if (profesor != clases)
                {
                    return profesor;
                }
            }

            throw new SinProfesorException("No hay profesor que no pueda dar la clase.\n");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada jornada in jornada)
            {
                sb.Append(jornada.ToString());
            }

            return sb.ToString();
        }

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}