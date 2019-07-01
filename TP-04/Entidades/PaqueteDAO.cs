using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;
using CustomExceptions;

namespace TP_04
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static PaqueteDAO()
        {
            conexion = new SqlConnection(
                "Data Source=.\\SQLEXPRESS;Initial Catalog=patentes-sp-2018;Integrated Security=True");
            // CREO UN OBJETO SQLCOMMAND
            comando = new SqlCommand();
            // INDICO EL TIPO DE COMANDO
            comando.CommandType = System.Data.CommandType.Text;
            // ESTABLEZCO LA CONEXION
            comando.Connection = conexion;
        }

        public static void Insertar(Paquete paquete)
        {
            if (ReferenceEquals(paquete, null) || ReferenceEquals(paquete.DireccionEntrega, null) || ReferenceEquals(paquete.DireccionEntrega, String.Empty) ||
                ReferenceEquals(paquete.Estado, null) || ReferenceEquals(paquete.TrackingID, null) || ReferenceEquals(paquete.TrackingID, String.Empty))
            {
                throw new NullReferenceException("Error. Algun dato del paquete no fue completado.");
            }

            Paquete paqueteRepeated = GetByTrackingId(paquete.TrackingID);
            if (!ReferenceEquals(paqueteRepeated,null))
            {
                throw new TrackingIdRepetidoException($"TrackingId {paquete.TrackingID} ya está en la base de datos");
            }


            string alumno = "Calixto Gonzalez";
            string sql =
                $"INSERT INTO [correo-sp-2017].[dbo].[Paquetes] VALUES ({paquete.DireccionEntrega},{paquete.TrackingID},{alumno})";

            try
            {
                comando.CommandText = sql;
                conexion.Open();
                int rowsAffected = comando.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} were affected.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        private static Paquete GetByTrackingId(string paqueteTrackingId)
        {
            Paquete paqueteToReturn = null;
            try
            {
                comando.CommandText = $"Select trackingID from [correo-sp-2017].[dbo].[Paquetes] where trackingID={paqueteTrackingId}";

                conexion.Open();

                SqlDataReader oDr = comando.ExecuteReader();

                while (oDr.Read())
                {
                    paqueteToReturn = new Paquete(oDr["direccionEntrega"].ToString(), oDr["trackingID"].ToString());
                }
                
                oDr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                comando.CommandText = String.Empty;
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return paqueteToReturn;


        }
    }
}