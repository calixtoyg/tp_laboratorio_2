﻿using System.Text;
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


        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASES DE {0} \n", clasesQueToma);
        }

        public override string ToString()
        {
            return new StringBuilder().AppendFormat("ESTADO DE CUENTA: {0} TOMA CLASES DE: {1} \n", estadoCuenta, clasesQueToma)
                .ToString();
        }

        public override string MostrarDatos()
        {
            StringBuilder mostrarDatos = new StringBuilder(base.MostrarDatos());
            //Todo checkear
            return mostrarDatos.Append(ToString()).ToString();
        }

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
            AlDia,
            Deudor,
            Becado
        }
    }

  
}