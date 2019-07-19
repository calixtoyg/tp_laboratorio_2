using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Archivos;
using Excepciones;
using TP_03;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clases;
        private Profesor instructor;

        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clases, Profesor instructor) : this()
        {
            this.clases = clases;
            this.instructor = instructor;
        }

        public List<Alumno> Alumnos
        {
            get => alumnos;
            set => alumnos = value;
        }

        public Universidad.EClases Clases
        {
            get => clases;
            set => clases = value;
        }

        public Profesor Instructor
        {
            get => instructor;
            set => instructor = value;
        }

        public static bool Guardar(Jornada jornada)
        {
            try
            {
                Texto txt = new Texto();
                txt.Guardar("Jornada.txt", jornada.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }

        /// <summary>
        /// Override a ToString para imprimir la clase de una manera especifica(respecto a formato archivo).
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder jornadaBuilder = new StringBuilder();
            jornadaBuilder.AppendLine("<------------------------------------------------>");
            jornadaBuilder.AppendLine($"CLASE DE {clases.ToString()} POR {instructor.MostrarDatos()}");


            jornadaBuilder.Append("ALUMNOS: \n");
            foreach (Alumno alumno in alumnos)
            {
                jornadaBuilder.Append($"{alumno.MostrarDatos()}");
            }

            jornadaBuilder.AppendLine("<------------------------------------------------>");
            return jornadaBuilder.ToString();
        }

        /// <summary>
        /// Lee del archivo Jornada.txt e imprime y returna el texto en un string.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArchivosException">En caso de haya habido una expection a la hora de procesar el archivo.</exception>
        public static string Leer()
        {
            try
            {
                Texto txt = new Texto();
                string datos;
                txt.Leer("Jornada.txt", out datos);
                return datos;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }

        /// <summary>
        /// Una Jornada no es igual a un Alumno si, y solo si, el Alumno no esta en la lista de alumnos de la Jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            if (!ReferenceEquals(jornada, null) && !ReferenceEquals(alumno, null))
            {
                foreach (Alumno alumnoJornada in jornada.alumnos)
                {
                    if (alumno == alumnoJornada)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator !=(Jornada jornada, Alumno alumno)
        {
            return !(jornada == alumno);
        }

        /// <summary>
        /// Agrega un Alumno a la Jornada si, y solo si, el Alumno no se encuentra en la lista de alumnos de esta
        /// </summary>
        /// <param name="jornada">Jornada a la que se le agrega</param>
        /// <param name="alumno">Alumno a ser agregado a la Jornada</param>
        /// <returns></returns>
        public static Jornada operator +(Jornada jornada, Alumno alumno)
        {
            if (jornada != alumno) 
                jornada.alumnos.Add(alumno);
            return jornada;
        }
    }
}