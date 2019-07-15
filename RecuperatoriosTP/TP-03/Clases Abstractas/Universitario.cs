using System.Text;

namespace TP_03
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        protected Universitario()
        {
        }

        protected Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) :
            base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        public virtual string MostrarDatos()
        {
            StringBuilder toString = new StringBuilder(base.ToString());
            return toString.AppendLine($"Legajo: {legajo}").ToString();
        }

        protected abstract string ParticiparEnClase();
        
        public static bool operator ==(Universitario u1, Universitario u2)
        {
            return !ReferenceEquals(u1,null) && !ReferenceEquals(u2, null) && u1.GetType() == u2.GetType() && (u1.Dni.Equals(u2.Dni) || u1.legajo.Equals(u2.legajo));
        }

        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1 == u2);
        }
    }
}