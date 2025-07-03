using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class InscripcionAnio
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _Anio;
            public Int32 Anio { get { return _Anio; } set { _Anio = value; } }

            private Int32 _CantConcAnt;
            public Int32 CantConcAnt { get { return _CantConcAnt; } set { _CantConcAnt = value; } }
            private Int32 _CanConcAtrasados;
            public Int32 CanConcAtrasados { get { return _CanConcAtrasados; } set { _CanConcAtrasados = value; } }
            private Int32 _Estado;
            public Int32 Estado { get { return _Estado; } set { _Estado = value; } }
    private DateTime _FechMod;
            public DateTime FechMod { get { return _FechMod; } set { _FechMod = value; } }

            #endregion

            #region Constructores

            public InscripcionAnio() { try { this.Anio = 0; } catch (Exception oError) { throw oError; } }

            public InscripcionAnio(Int32 Anio)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[InscripcionAnio.ObtenerUno]", new object[,] { { "@Anio", Anio } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["Anio"].ToString().Trim().Length > 0)
                        {
                            this.Anio = Convert.ToInt32(Fila.Rows[0]["Anio"]);
                        }
                        else
                        {
                            this.Anio = 0;
                        }

                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void ActualizarEstados()
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionAnio.ActualizarEstados]", new object[,] {  });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            #endregion

            #region Metodos
            public DataTable ObtenerUno()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionAnio.ObtenerUno]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public Int32 Insertar(int Anio, int CantConcAnt, int CanConcAtrasados, int Estado, DateTime FechMod)
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[InscripcionAnio.Insertar]", new object[,] { { "@Anio", Anio }, { "@CantConcAnt", CantConcAnt }, { "@CanConcAtrasados", CanConcAtrasados } ,{ "@Estado", Estado },{ "@FechMod", FechMod } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }

            #endregion
        }
    }
}