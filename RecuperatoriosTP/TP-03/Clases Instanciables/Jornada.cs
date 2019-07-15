using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
                StreamWriter fichero;
                fichero = File.CreateText("jornada.txt");
                fichero.WriteLine(jornada.Leer());
                fichero.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("ALUMNOS: ");
            foreach (Alumno alumno in alumnos)
            {
                builder.Append($"{alumno.MostrarDatos()}\n");
            }

            return builder.Append(instructor.MostrarDatos()).Append($"Clase {clases} \n").ToString();
        }

        public string Leer()
        {
            return ToString();
        }

        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            if (!ReferenceEquals(jornada, null) && !ReferenceEquals(alumno,null))
            {
                if (alumno == jornada.clases)
                {
                    return true;
                }
                
            }

            return false;
        }

        public static bool operator !=(Jornada jornada, Alumno alumno)
        {
            return !(jornada == alumno);
        }

        public static Jornada operator +(Jornada jornada, Alumno alumno)
        {
            if (jornada == alumno) return jornada;
            jornada.alumnos.Add(alumno);
            return jornada;
        }
    }
}