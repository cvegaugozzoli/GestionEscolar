using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class Tramite
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _traId; 
			public Int32 traId { get { return _traId; } set { _traId = value; } }

            private String _traDescripcion; 
			public String traDescripcion { get { return _traDescripcion; } set { _traDescripcion = value; } }

        

            #endregion

            #region Constructores

            public Tramite() { try { this.traId = 0; } catch (Exception oError) { throw oError; } }            

          
            #endregion

            #region Metodos

               
                			
            public DataTable ObtenerLista(String PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Tramite.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
  

            #endregion
        }
    }
}