using System;
using Clases_Instanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_03;

namespace UnitTestExceptions
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void UniversidadPlusOperatorWithInvalidDniForNationalityShouldThrowNacionalidadInvalidaException()
        {
            Universidad gim = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
                Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);
            Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458",
                Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
                Alumno.EEstadoCuenta.Deudor);
            gim += a1;
            gim += a2;
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void UniversidadPlusOperatorWithSameAlumnoShouldThrowAlumnoRepetidoException()
        {
            Universidad gim = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
                Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);
            Alumno a2 = new Alumno(2, "Juana", "Martinez", "92234458",
                Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
                Alumno.EEstadoCuenta.Deudor);
            Alumno a3 = new Alumno(3, "José", "Gutierrez", "12234456",
                Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);
            
            
            gim += a1;
            gim += a2;
            gim += a3;
        }   
        
        [TestMethod]
        public void AlumnoDniIsSameAsConstructorStringDni()
        {
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
                Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);
            
            Assert.AreEqual(Int32.Parse("12234456"), a1.Dni);
        }
        
        [TestMethod]
        public void UniversidadPlusOperatorShouldAddExaclyThreeAlumnosToAlumnosList()
        {
            Universidad gim = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
                Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);
            Alumno a2 = new Alumno(2, "Juana", "Martinez", "92234458",
                Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
                Alumno.EEstadoCuenta.Deudor);
            Alumno a3 = new Alumno(3, "José", "Gutierrez", "13234456",
                Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);
            
            gim += a1;
            gim += a2;
            gim += a3;
            
            Assert.IsNotNull(gim.Alumnos.Count);
            Assert.AreEqual(3, gim.Alumnos.Count);
        }

        [TestMethod]
        public void ProfesorEqualityOperatorShouldReturnFalseIfProfesorIsNull()
        {
            Profesor profesor = null;
            Universidad.EClases clases = Universidad.EClases.Laboratorio;

            bool actual = profesor == clases;
            
            Assert.IsNull(profesor);
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void UniversidadPlusOperatorShouldAddExaclyTwoProfesoresToProfesoresList()
        {
            Universidad gim = new Universidad();

            Profesor i1 = new Profesor(1, "Juan", "Lopez", "12234456",
                Persona.ENacionalidad.Argentino);
            Profesor i2 = new Profesor(2, "Roberto", "Juarez", "32234456",
                Persona.ENacionalidad.Argentino);
            
                
            gim += i1;
            gim += i2;
            
            Assert.IsNotNull(gim.Instructores.Count);
            Assert.IsNotNull(gim.Instructores[0]);
            Assert.IsNotNull(gim.Instructores[1]);
            Assert.AreEqual(i1.Apellido, gim.Instructores[0].Apellido);
            Assert.AreEqual(i1.Nombre, gim.Instructores[0].Nombre);
            Assert.AreEqual(i1.Dni, gim.Instructores[0].Dni);
            Assert.AreEqual(i1.Nacionalidad, gim.Instructores[0].Nacionalidad);
        }

        


    }
}
