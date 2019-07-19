using System;
using System.Collections.Generic;
using System.Text;
using Clases_Instanciables;

namespace TP_03
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> claseDelDia;
        private static Random random;

        private Profesor()
        {
            _randomClases();
        }

        static Profesor()
        {
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) :
            base(id, nombre, apellido, dni, nacionalidad)
        {
           claseDelDia = new Queue<Universidad.EClases>();
           _randomClases();
        }

        protected override string ParticiparEnClase()
        {
//            string clases = GetClasesToString();
            return ToString();
        }

//        private string GetClasesToString()
//        {
//            StringBuilder builder = new StringBuilder();
//            if (!ReferenceEquals(claseDelDia, null))
//            {
//                
//                foreach (Universidad.EClases clase in claseDelDia)
//                {
//
//                    builder.Append($"{clase.ToString()}, ");
//                }
//                // Remueve el ultimo espacio y su coma.
//                return builder.Remove(builder.Length-2,2).ToString();
//            }
//            return String.Empty;
//        }

        void _randomClases()
        {    
            random = new Random();
            claseDelDia.Enqueue((Universidad.EClases) random.Next(0,4));
            claseDelDia.Enqueue((Universidad.EClases) random.Next(0,4));
        }

        public static bool operator ==(Profesor profesor, Universidad.EClases clases)
        {
            if (ReferenceEquals(profesor,null))
            {
                return false;
            }
            
            foreach (Universidad.EClases clase in profesor.claseDelDia)
            {
                if (clase.Equals(clases))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Profesor profesor, Universidad.EClases clases)
        {
            return !(profesor == clases);
        }

        public override string ToString()
        {
            StringBuilder clasesDelDiaBuilder = new StringBuilder();
            foreach (Universidad.EClases clases in claseDelDia)
            {
                clasesDelDiaBuilder.AppendLine(clases.ToString());
            }
            return $"CLASES DEL DÍA:\n{clasesDelDiaBuilder}";
        }

        public override string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder(base.MostrarDatos());
            return stringBuilder.AppendLine(ToString()).ToString();
        }
    }
}