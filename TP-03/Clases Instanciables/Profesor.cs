using System;
using System.Collections.Generic;
using System.Text;
using Clases_Instanciables;
using TP_03;

namespace TP_03
{
    public sealed class Profesor : Universitario
    {
        private Queue<EClase> claseDelDia;
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
                
                foreach (EClase clase in claseDelDia)
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
            Array valores = Enum.GetValues(typeof(EClase));
            random = new Random();
            claseDelDia.Enqueue((EClase)valores.GetValue(random.Next(valores.Length)));
            claseDelDia.Enqueue((EClase)valores.GetValue(random.Next(valores.Length)));
        }

        public static bool operator ==(Profesor profesor, EClase clase)
        {
            return !ReferenceEquals(profesor,null) && profesor.claseDelDia.Contains(clase);
        }

        public static bool operator !=(Profesor profesor, EClase clase)
        {
            return !(profesor == clase);
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