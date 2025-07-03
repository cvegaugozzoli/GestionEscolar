using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class HorariosTurno
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _horId; 
			public Int32 horId { get { return _horId; } set { _horId = value; } }

            private String _horDescripcion; 
			public String horDescripcion { get { return _horDescripcion; } set { _horDescripcion = value; } }

        

            private DateTime _horFechaHoraCreacion; 
			public DateTime horFechaHoraCreacion { get { return _horFechaHoraCreacion; } set { _horFechaHoraCreacion = value; } }

            private DateTime _horFechaHoraUltimaModificacion; 
			public DateTime horFechaHoraUltimaModificacion { get { return _horFechaHoraUltimaModificacion; } set { _horFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public HorariosTurno() { try { this.horId = 0; } catch (Exception oError) { throw oError; } }            

          
            #endregion

            #region Metodos

               
                			
            public DataTable ObtenerLista(String PrimerItem, DateTime fecha)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[HorarioTurno.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem},{ "@fecha", fecha } });
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