using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TP_03;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private EClase clase;
        private Profesor instructor;

        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(EClase clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        public List<Alumno> Alumnos
        {
            get => alumnos;
            set => alumnos = value;
        }

        public EClase Clase
        {
            get => clase;
            set => clase = value;
        }

        public Profesor Instructor
        {
            get => instructor;
            set => instructor = value;
        }

        public bool Guardar(Jornada jornada)
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
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Jornada Lista de alumnos: ");
            foreach (Alumno alumno in alumnos)
            {
                builder.Append($"{alumno.MostrarDatos()}");
            }

            return builder.Append(instructor.MostrarDatos()).Append($"Clase {clase} \n").ToString();
        }

        public string Leer()
        {
            return ToString();
        }

        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            return !ReferenceEquals(jornada, null) && jornada.Alumnos.Contains(alumno);
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