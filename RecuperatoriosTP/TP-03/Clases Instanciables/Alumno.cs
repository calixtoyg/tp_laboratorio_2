﻿using System.ComponentModel;
using System.Text;
using TP_03;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases clasesQueToma;
        private EEstadoCuenta estadoCuenta;
        
        private Alumno()
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
            Universidad.EClases clasesQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesQueToma = clasesQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
            Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Retorna un string indicando que clase toma.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASES DE {0}", clasesQueToma);
        }

        public override string ToString()
        {
            return new StringBuilder().AppendFormat("ESTADO DE CUENTA: {0} \n", estadoCuenta)
                .AppendLine(ParticiparEnClase())
                .ToString();
        }

        /// <summary>
        /// Muestra los datos de un Alumno.
        /// </summary>
        /// <returns></returns>
        public override string MostrarDatos()
        {
            StringBuilder mostrarDatos = new StringBuilder(base.MostrarDatos());
            return mostrarDatos.Append(ToString()).ToString();
        }

        /// <summary>
        /// Un Alumno es igual a una EClase si, y solo si, el Alumno toma esa clase.
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="clases"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno alumno, Universidad.EClases clases)
        {
            return alumno.clasesQueToma.Equals(clases) && !alumno.estadoCuenta.Equals(EEstadoCuenta.Deudor);
        }

        public static bool operator !=(Alumno alumno, Universidad.EClases clases)
        {
            return !alumno.clasesQueToma.Equals(clases);
        }

        public enum EEstadoCuenta
        {
            [Description("Cuota al día")] AlDia,
            Deudor,
            Becado
        }
    }
}