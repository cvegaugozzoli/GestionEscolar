using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public class Funciones
        {
            static GESTIONESCOLAR.Datos.Gestor ocdGestor = new GESTIONESCOLAR.Datos.Gestor();
            static DataTable Tabla = new DataTable();
            static string Cadena = "";

            public static string CantidadConLetra(string NumeroDecimal)
            {
                Cadena = "";
                try
                {
                    Tabla = ocdGestor.EjecutarReaderSql("select dbo.CantidadConLetra(" + NumeroDecimal.Replace(",", ".") + ") as CantidadEnLetra");
                    Cadena = Tabla.Rows[0]["CantidadEnLetra"].ToString();
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Cadena;
            }
        }
    }
}