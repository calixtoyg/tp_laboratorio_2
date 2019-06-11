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
            string clases = GetClasesToString();
            return $"CLASES DEL DÍA {clases} \n";
        }

        private string GetClasesToString()
        {
            StringBuilder builder = new StringBuilder();
            if (!ReferenceEquals(claseDelDia, null))
            {
                
                foreach (Universidad.EClases clase in claseDelDia)
                {

                    builder.Append($"{clase.ToString()}, ");
                }
                // Remueve el ultimo espacio y su coma.
                return builder.Remove(builder.Length-2,2).ToString();
            }
            return String.Empty;
        }

        void _randomClases()
        {    
            Array valores = Enum.GetValues(typeof(Universidad.EClases));
            random = new Random();
            claseDelDia.Enqueue((Universidad.EClases)valores.GetValue(random.Next(valores.Length)));
            claseDelDia.Enqueue((Universidad.EClases)valores.GetValue(random.Next(valores.Length)));
        }

        public static bool operator ==(Profesor profesor, Universidad.EClases clases)
        {
            return !ReferenceEquals(profesor,null) && profesor.claseDelDia.Contains(clases);
        }

        public static bool operator !=(Profesor profesor, Universidad.EClases clases)
        {
            return !(profesor == clases);
        }

        public override string ToString()
        {
            return $"Profesor Clase del dia: {claseDelDia} Random: {GetClasesToString()} \n";
        }

        public override string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder(base.MostrarDatos());
            return stringBuilder.AppendLine(ToString()).ToString();
        }
    }
}