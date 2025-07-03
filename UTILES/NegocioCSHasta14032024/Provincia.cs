using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class Provincia
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();
            
            private int _PROVI_ID;
            public int PROVI_ID
            {
                get { return _PROVI_ID; }
                set { _PROVI_ID = value; }
            }

            private String _PROVI_DESCRIPCION;
            public String PROVI_DESCRIPCION
            {
                get { return _PROVI_DESCRIPCION; }
                set { _PROVI_DESCRIPCION = value; }
            }


            public Provincia()
            {
                try
                {
                    this.PROVI_ID = 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            public DataTable ObtenerLista(string PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Provincias_ObtenerLista]", new object[,] { {

                     "@PrimerItem",
                        PrimerItem

                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

        }

    }
}
