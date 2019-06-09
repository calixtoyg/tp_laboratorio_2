using System.Text;
using TP_03;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        private EClase claseQueToma;
        private EEstadoDeCuenta estadoCuenta;

        private Alumno()
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
            EClase claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
            EClase claseQueToma, EEstadoDeCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }


        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASES DE {0} \n", claseQueToma);
        }

        public override string ToString()
        {
            return new StringBuilder().AppendFormat("Alumno Estado de cuenta: {0} Clase que toma: {1} \n", estadoCuenta, claseQueToma)
                .ToString();
        }

        public override string MostrarDatos()
        {
            StringBuilder mostrarDatos = new StringBuilder(base.MostrarDatos());
            //Todo checkear
            return mostrarDatos.Append(ToString()).ToString();
        }

        public static bool operator ==(Alumno alumno, EClase clase)
        {
            return alumno.claseQueToma.Equals(clase) && !alumno.estadoCuenta.Equals(EEstadoDeCuenta.Deudor);
        }

        public static bool operator !=(Alumno alumno, EClase clase)
        {
            return !alumno.claseQueToma.Equals(clase);
        }
    }

    public enum EEstadoDeCuenta
    {
        AlDia,
        Deudor,
        Becado
    }
}