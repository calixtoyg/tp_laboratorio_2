using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using Excepciones;
using TP_03;

namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
        }

        public bool Guardar(Universidad uni)
        {
            try
            {
                StreamWriter fichero;
                fichero = File.CreateText("universidad.txt");
                fichero.WriteLine(uni.Leer());
                fichero.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private string Leer()
        {
            return ToString();
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

        public static bool operator ==(Universidad universidad, Alumno alumno)
        {
            return !ReferenceEquals(universidad, null) && universidad.alumnos.Contains(alumno);
        }

        public static bool operator !=(Universidad universidad, Alumno alumno)
        {
            return !(universidad == alumno);
        }

        public static bool operator ==(Universidad universidad, Profesor profesor)
        {
            return !ReferenceEquals(universidad, null) && universidad.profesores.Contains(profesor);
        }

        public static bool operator !=(Universidad universidad, Profesor profesor)
        {
            return !(universidad == profesor);
        }

        public static bool operator +(Universidad universidad, EClase clase)
        {
            List<Alumno> alumnosQuePuedenTomarLaClase = new List<Alumno>();
            Profesor profesorQuePuedeDarLaClase = universidad == clase;

            foreach (Alumno alumno in universidad.alumnos)
            {
                if (alumno == clase)
                {
                    alumnosQuePuedenTomarLaClase.Add(alumno);
                }
            }

            if (ReferenceEquals(profesorQuePuedeDarLaClase, null)) return false;
            universidad.jornada.Add(new Jornada(clase, profesorQuePuedeDarLaClase));
            return true;
            return false;

        }

        public static bool operator +(Universidad universidad, Alumno alumno)
        {
            if (universidad.alumnos.Contains(alumno))
            {
                return false;
            }
            universidad.alumnos.Add(alumno);
            return true;
        }  
        
        public static bool operator +(Universidad universidad, Profesor profesor)
        {
            if (universidad.profesores.Contains(profesor))
            {
                return false;
            }
            universidad.profesores.Add(profesor);
            return true;
        }

        public static Profesor operator ==(Universidad universidad, EClase clase)
        {
            foreach (Profesor profesor in universidad.profesores)
            {
                if (profesor == clase)
                {
                    return profesor;
                }
            }

            throw new SinProfesorException($"Universidad {universidad} no hay profesor que pueda dar la clase.\n");

        }

        public static Profesor operator !=(Universidad universidad, EClase clase)
        {
            foreach (Profesor profesor in universidad.profesores)
            {
                if (profesor != clase)
                {
                    return profesor;
                }
            }

            throw new SinProfesorException($"Universidad {universidad} no hay profesor que no pueda dar la clase.\n");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public enum EClase
    {
        Programacion, Laboratorio, Legislacion, SPD
    }
}