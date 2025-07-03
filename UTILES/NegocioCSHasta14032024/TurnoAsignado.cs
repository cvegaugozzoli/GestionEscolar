using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class TurnoAsignado
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _tuaId;
            public Int32 tuaId { get { return _tuaId; } set { _tuaId = value; } }

            private Int32 _insId;
            public Int32 insId { get { return _insId; } set { _insId = value; } }

            private String _tuaNombreTutor;
            public String traDescripcion { get { return _tuaNombreTutor; } set { _tuaNombreTutor = value; } }

            private String _tuaDni;
            public String tuaDni { get { return _tuaDni; } set { _tuaDni = value; } }

            private Int32 _horId;
            public Int32 horId { get { return _horId; } set { _horId = value; } }

            private Int32 _traId;
            public Int32 traId { get { return _traId; } set { _traId = value; } }

            private DateTime _tuaDia;
            public DateTime tuaDia { get { return _tuaDia; } set { _tuaDia = value; } }

            private DateTime _tuaFechaHoraCreacion;
            public DateTime tuaFechaHoraCreacion { get { return _tuaFechaHoraCreacion; } set { _tuaFechaHoraCreacion = value; } }

            private DateTime _tuaFechaHoraUltimaModificacion;
            public DateTime tuaFechaHoraUltimaModificacion { get { return _tuaFechaHoraUltimaModificacion; } set { _tuaFechaHoraUltimaModificacion = value; } }


            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }



            #endregion

            #region Constructores

            public TurnoAsignado() { try { this.traId = 0; } catch (Exception oError) { throw oError; } }


            #endregion

            #region Metodos



            public DataTable BuscarxDnixIns(String Dni, int insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TurnoAsignado.BuscarxDnixIns]", new object[,] { { "@Dni", Dni }, { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable TurnoAsignadoTraerPorFecha(DateTime fecha)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TurnoAsignadoTraerPorFecha]", new object[,] { { "@fecha", fecha } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ControlTurnoAsignado(String Dni, int insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TurnoAsignado.ControlTurnoAsignado]", new object[,] { { "@Dni", Dni }, { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ControlHorarioAsignado(DateTime fecha, int horario)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TurnoAsignado.ControlHorarioAsignado]", new object[,] { { "@fecha", fecha }, { "@horario", horario } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public Int32 Insertar(int insId, String NombreTutor, String Dni, int horId, int traId, DateTime tuaDia)
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[TurnoAsignado.Insertar]", new object[,] {{ "@insId", insId } , { "@NombreTutor", NombreTutor },{ "@Dni", Dni },
                        { "@horId", horId },  { "@traId", traId },{ "@tuaDia", tuaDia }});
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }






            public DataTable Insertar2(int insId, String NombreTutor, String Dni, int horId, int traId, DateTime tuaDia)
            {
              
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TurnoAsignado.Insertar]", new object[,] {{ "@insId", insId } , { "@NombreTutor", NombreTutor },{ "@Dni", Dni }, 
                        { "@horId", horId },  { "@traId", traId },{ "@tuaDia", tuaDia }});
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable Eliminar(int Id)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TurnoAsignado.Eliminar]", new object[,] { { "@Id", Id } });
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