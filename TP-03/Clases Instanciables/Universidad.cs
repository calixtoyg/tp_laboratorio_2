using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
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

        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
        }

        public static bool Guardar(Universidad uni)
        {
            try
            {
                XmlTextWriter writer; 
                XmlSerializer ser;   
                writer = new XmlTextWriter("Universidad.xml", Encoding.UTF8);
                ser = new XmlSerializer(typeof(Universidad));
                ser.Serialize(writer, uni.Leer());
                writer.Close();
                return true;
            }
            catch (Exception e)
            {
               throw new ArchivosException(e);
            }
        }

        private Universidad Leer()
        {
            return this;
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
            
            universidad.jornada.Add(new Jornada(clases, profesorQuePuedeDarLaClase));
            return universidad;

        }

        public static Universidad operator +(Universidad universidad, Alumno alumno)
        {
            if (universidad.alumnos.Contains(alumno))
            {
                throw new AlumnoRepetidoException($"El alumno {alumno.MostrarDatos()} ya esta la universidad.");
            }
            universidad.alumnos.Add(alumno);
            return universidad;
        }  
        
        public static Universidad operator +(Universidad universidad, Profesor profesor)
        {
            if (universidad.profesores.Contains(profesor))
            {
                return universidad;
            }
            universidad.profesores.Add(profesor);
            return universidad;
        }

        public static Profesor operator ==(Universidad universidad, EClases clases)
        {
            foreach (Profesor profesor in universidad.profesores)
            {
                if (profesor == clases)
                {
                    return profesor;
                }
            }

            throw new SinProfesorException($"Universidad {universidad} no hay profesor que pueda dar la clase.\n");

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

            throw new SinProfesorException($"Universidad {universidad} no hay profesor que no pueda dar la clase.\n");
        }

        public override string ToString()
        {
            return base.ToString();
        }
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
       
    }


 
}