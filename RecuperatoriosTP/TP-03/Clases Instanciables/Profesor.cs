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
            return ToString();
        }

        /// <summary>
        /// Agrega dos EClase elegidas de forma aleatorea a la lista de clases
        /// </summary>
        void _randomClases()
        {
            random = new Random();
            claseDelDia.Enqueue((Universidad.EClases) random.Next(0, 4));
            claseDelDia.Enqueue((Universidad.EClases) random.Next(0, 4));
        }

        /// <summary>
        /// Un Profesor es igual a una EClase si, y solo si, el Profesor da esa EClase
        /// </summary>
        /// <param name="profesor"></param>
        /// <param name="clases"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor profesor, Universidad.EClases clases)
        {
            if (ReferenceEquals(profesor, null))
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

        /// <summary>
        /// Un Profesor no es igual a una EClase si, y solo si, el Profesor no da esa EClase
        /// </summary>
        /// <param name="profesor"></param>
        /// <param name="clases"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Retorna un string con todos los datos del Profesor
        /// </summary>
        /// <returns></returns>
        public override string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder(base.MostrarDatos());
            return stringBuilder.AppendLine(ToString()).ToString();
        }
    }
}