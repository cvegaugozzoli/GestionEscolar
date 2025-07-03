using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class InscripcionCursadoTerciario
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades
            private Int32 _ictId;
            public Int32 ictId { get { return _ictId; } set { _ictId = value; } }

            private Int32 _icuId;
            public Int32 icuId { get { return _icuId; } set { _icuId = value; } }

            private Int32 _escId;
            public Int32 escId { get { return _escId; } set { _escId = value; } }

            private DateTime _ictFechaInscripcion;
            public DateTime ictFechaInscripcion { get { return _ictFechaInscripcion; } set { _ictFechaInscripcion = value; } }

            private Int32 _ictEstado;
            public Int32 ictEstado { get { return _ictEstado; } set { _ictEstado = value; } }

            private Boolean _ictActivo;
            public Boolean ictActivo { get { return _ictActivo; } set { _ictActivo = value; } }

            private Int32 _cdnId;
            public Int32 cdnId { get { return _cdnId; } set { _cdnId = value; } }

            private DateTime _ictFechaRegularizaPromociona;
            public DateTime ictFechaRegularizaPromociona { get { return _ictFechaRegularizaPromociona; } set { _ictFechaRegularizaPromociona = value; } }

            private Int32 _ictInsConfirmar;
            public Int32 ictInsConfirmar { get { return _ictInsConfirmar; } set { _ictInsConfirmar = value; } }

            private String _ictObservacion;
            public String ictObservacion { get { return _ictObservacion; } set { _ictObservacion = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            private DateTime _ictFechaHoraCreacion;
            public DateTime ictFechaHoraCreacion { get { return _ictFechaHoraCreacion; } set { _ictFechaHoraCreacion = value; } }

            private DateTime _ictFechaHoraUltimaModificacion;
            public DateTime ictFechaHoraUltimaModificacion { get { return _ictFechaHoraUltimaModificacion; } set { _ictFechaHoraUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public InscripcionCursadoTerciario() { try { this.ictId = 0; } catch (Exception oError) { throw oError; } }

            public InscripcionCursadoTerciario(Int32 ictId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerUno]", new object[,] { { "@ictId", ictId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["ictId"].ToString().Trim().Length > 0)
                        {
                            this.ictId = Convert.ToInt32(Fila.Rows[0]["ictId"]);
                        }
                        else
                        {
                            this.ictId = 0;
                        }

                        if (Fila.Rows[0]["icuId"].ToString().Trim().Length > 0)
                        {
                            this.icuId = Convert.ToInt32(Fila.Rows[0]["icuId"]);
                        }
                        else
                        {
                            this.icuId = 0;
                        }

                        if (Fila.Rows[0]["escId"].ToString().Trim().Length > 0)
                        {
                            this.escId = Convert.ToInt32(Fila.Rows[0]["escId"]);
                        }
                        else
                        {
                            this.escId = 0;
                        }


                        if (Fila.Rows[0]["ictFechaInscripcion"].ToString().Trim().Length > 0)
                        {
                            this.ictFechaInscripcion = Convert.ToDateTime(Fila.Rows[0]["ictFechaInscripcion"]);
                        }
                        else
                        {
                            this.ictFechaInscripcion = DateTime.Now;
                        }
                        if (Fila.Rows[0]["ictEstado"].ToString().Trim().Length > 0)
                        {
                            this.ictEstado = Convert.ToInt32(Fila.Rows[0]["ictEstado"]);
                        }
                        else
                        {
                            this.ictEstado = 0;
                        }

                        if (Fila.Rows[0]["ictActivo"].ToString().Trim().Length > 0)
                        {
                            this.ictActivo = (Convert.ToInt32(Fila.Rows[0]["ictActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.ictActivo = false;
                        }

                        if (Fila.Rows[0]["cdnId"].ToString().Trim().Length > 0)
                        {
                            this.cdnId = Convert.ToInt32(Fila.Rows[0]["cdnId"]);
                        }
                        else
                        {
                            this.cdnId = 0;
                        }

                        if (Fila.Rows[0]["ictFechaRegularizaPromociona"].ToString().Trim().Length > 0)
                        {
                            this.ictFechaRegularizaPromociona = Convert.ToDateTime(Fila.Rows[0]["ictFechaRegularizaPromociona"]);
                        }
                        else
                        {
                            this.ictFechaRegularizaPromociona = DateTime.Now;
                        }

                        if (Fila.Rows[0]["ictInsConfirmar"].ToString().Trim().Length > 0)
                        {
                            this.ictInsConfirmar = Convert.ToInt32(Fila.Rows[0]["ictInsConfirmar"]);
                        }
                        else
                        {
                            this.ictInsConfirmar = 1;
                        }
                        if (Fila.Rows[0]["ictObservacion"].ToString().Trim().Length > 0)
                        {
                            this.ictObservacion = Convert.ToString(Fila.Rows[0]["ictObservacion"]);
                        }
                        else
                        {
                            this.ictObservacion = "";
                        }
                        if (Fila.Rows[0]["usuIdCreacion"].ToString().Trim().Length > 0)
                        {
                            this.usuIdCreacion = Convert.ToInt32(Fila.Rows[0]["usuIdCreacion"]);
                        }
                        else
                        {
                            this.usuIdCreacion = 0;
                        }

                        if (Fila.Rows[0]["usuIdUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.usuIdUltimaModificacion = Convert.ToInt32(Fila.Rows[0]["usuIdUltimaModificacion"]);
                        }
                        else
                        {
                            this.usuIdUltimaModificacion = 0;
                        }
                        if (Fila.Rows[0]["ictFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.ictFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["ictFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.ictFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["ictFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.ictFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["ictFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.ictFechaHoraUltimaModificacion = DateTime.Now;
                        }
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public InscripcionCursadoTerciario(Int32 ictId, Int32 icuId, Int32 escId, DateTime icuFechaInscripcion, Int32 ictEstado,
                Boolean ictActivo, Int32 cdnId, DateTime ictFechaRegularizaPromociona, Int32 ictInsConfirmar, String ictObservacion,
                Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime ictFechaHoraCreacion, DateTime ictFechaHoraUltimaModificacion)
            {
                try
                {
                    this.ictId = ictId;
                    this.icuId = icuId;
                    this.escId = escId;
                    this.ictFechaInscripcion = ictFechaInscripcion;
                    this.ictEstado = ictEstado;
                    this.ictActivo = ictActivo;
                    this.cdnId = cdnId;
                    this.ictFechaRegularizaPromociona = ictFechaRegularizaPromociona;
                    this.ictInsConfirmar = ictInsConfirmar;
                    this.ictObservacion = @ictObservacion;
                    this.usuIdCreacion = usuIdCreacion;
                    this.usuIdUltimaModificacion = usuIdUltimaModificacion;
                    this.ictFechaHoraCreacion = ictFechaHoraCreacion;
                    this.ictFechaHoraUltimaModificacion = ictFechaHoraUltimaModificacion;
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            #endregion

            #region Metodos


            public DataTable ObtenerTodo()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }



            public DataTable ObtenerUno(Int32 ictId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerUno]", new object[,] { { "@ictId", ictId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoporCondicionTipo(Int32 aluId, Int32 escId, Int32 cotId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerUnoporCondicionTipo]", new object[,] { { "@aluId", aluId }, { "escId", escId }, { "@cotId", cotId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUnoxAprobadooProm(Int32 aluId, Int32 escId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerUnoxAprobadooProm]", new object[,] { { "@aluId", aluId }, { "escId", escId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUnoxRegular(Int32 carId, Int32 plaId, Int32 curId, Int32 aluId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerUnoxRegular]", new object[,] { { "@carId", carId }, { "plaId", plaId },

                        { "@curId", curId } , { "@aluId", aluId }});
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerxLibre(Int32 carId, Int32 plaId, Int32 curId, Int32 aluId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerxLibre]", new object[,] { { "@carId", carId }, { "plaId", plaId },

                        { "@curId", curId } , { "@aluId", aluId }});
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerxicuId(Int32 icuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerxicuId]", new object[,] { { "@icuId", icuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerMateriasInsc(Int32 insId, Int32 aluId, Int32 curId, Int32 plaId, Int32 Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerMateriasInsc]", new object[,] { { "@insId", insId }, { "@aluId", aluId }, { "@curId", curId }, { "@plaId", plaId }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoControlExiste(Int32 aluId, Int32 curId, Int32 escId, Int32 Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerUnoControlExiste]", new object[,] { { "@aluId", aluId }, { "@curId", curId }, { "@escId", escId }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUltxaluIdxcurIdxescId(Int32 aluId, Int32 curId, Int32 escId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId]", new object[,] { { "@aluId", aluId }, { "@curId", curId }, { "@escId", escId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerInscEspCurrxAluxCurxEscxAnio(Int32 aluId, Int32 curId, Int32 escId, Int32 Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerInscEspCurrxAluxCurxEscxAnio]", new object[,] { { "@aluId", aluId }, { "@curId", curId }, { "@escId", escId }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerxicuIdxescId(Int32 icuId, Int32 escId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerxicuIdxescId]", new object[,] { { "@icuId", icuId }, { "@escId", escId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoxaluIdxescId(Int32 aluId, Int32 escId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerUnoxaluIdxescId]", new object[,] { { "@aluId", aluId }, { "@escId", escId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoxEspCxeceId(Int32 insId, Int32 espCur, Int32 Anio, int eceId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerTodoxEspCxeceId]", new object[,] {
                        { "@insId", insId }, { "@espCur", espCur }, { "@Anio", Anio } , { "@eceId", eceId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoxAsistxRecAsist(Int32 insId, Int32 espCur, Int32 Anio, int curId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerTodoxAsistxRecAsist]", new object[,] {
                        { "@insId", insId }, { "@espCur", espCur }, { "@Anio", Anio } , { "@curId", curId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoxEspC(Int32 insId, Int32 espCur, Int32 Anio, Int32 cdnId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerTodoxEspC]", new object[,] { { "@insId", insId }, { "@espCur", espCur }, { "@Anio", Anio }, { "@cdnId", cdnId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodoxEspCAsist(Int32 insId, Int32 espCur, Int32 Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerTodoxEspCAsist]", new object[,] { { "@insId", insId }, { "@espCur", espCur }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodoxEspCxcurId(Int32 insId, Int32 curId, Int32 espCur, Int32 Anio, Int32 cdnId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursadoTerciario.ObtenerTodoxEspCxcurId]", new object[,] { { "@insId", insId }, { "@curId", curId }, { "@espCur", espCur }, { "@Anio", Anio }, { "@cdnId", cdnId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            //public void Actualizar(Int32 ictId, Int32 icuId, Int32 insId, Int32 aluId, Int32 carId, Int32 plaId, Int32 curId, Int32 camId, Int32 escId, Int32 icuAnoCursado, DateTime icuFechaInscripcion, Int32 icuEstado, Boolean icuActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime icuFechaHoraCreacion, DateTime icuFechaHoraUltimaModificacion, Int32 icuInsConfirmar)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[InscripcionCursadoTerciario.Actualizar]", new object[,] { { "@ictId", ictId }, { "@icuId", icuId }, { "@insId", insId }, { "@aluId", aluId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escId", escId }, { "@icuAnoCursado", icuAnoCursado }, { "@icuFechaInscripcion", icuFechaInscripcion }, { "@icuEstado", icuEstado }, { "@icuActivo", icuActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@icuFechaHoraCreacion", icuFechaHoraCreacion }, { "@icuFechaHoraUltimaModificacion", icuFechaHoraUltimaModificacion }, { "@icuInsConfirmar", icuInsConfirmar } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}
            //public void ActualizarEstado(Int32 icuId, Int32 icuEstado)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[InscripcionCursado.ActualizarEstado]", new object[,] { { "@icuId", icuId }, { "@icuEstado", icuEstado } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}


            public void Eliminar(Int32 ictId, Int32 usuId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionCursadoTerciario.Eliminar]", new object[,] { { "@ictId", ictId }, { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void EliminarActivo0(Int32 ictId, Int32 usuId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionCursadoTerciario.EliminarActivo0]", new object[,] { { "@ictId", ictId }, { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void ActualizarCondicion(Int32 ictId, Int32 cdnId, DateTime? fechaRP, Int32 usuId, DateTime fchMod)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionCursadoTerciario.ActualizarCondicion]", new object[,] { { "@ictId", ictId }, { "@cdnId", cdnId }, { "@fechaRP", fechaRP }, { "@usuId", usuId }, { "@fchMod", fchMod } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
  public void ActualizarObservacion(Int32 ictId, String Observacion, Int32 usuId, DateTime fchMod)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionCursadoTerciario.ActualizarObservacion]", new object[,] { { "@ictId", ictId }, { "@Observacion", Observacion },  { "@usuId", usuId }, { "@fchMod", fchMod } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            //public void Insertar(Int32 insId,Int32 insId, Int32 aluId, Int32 carId, Int32 plaId, Int32 curId, Int32 camId, Int32 escId, Int32 icuAnoCursado, DateTime icuFechaInscripcion, Int32 icuEstado, Boolean icuActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime icuFechaHoraCreacion, DateTime icuFechaHoraUltimaModificacion, Int32 icuInsConfirmar)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[InscripcionCursado.Insertar]", new object[,] { { "@aluId", aluId }, { "@insId", insId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escId", escId }, { "@icuAnoCursado", icuAnoCursado }, { "@icuFechaInscripcion", icuFechaInscripcion }, { "@icuEstado", icuEstado }, { "@icuActivo", icuActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@icuFechaHoraCreacion", icuFechaHoraCreacion }, { "@icuFechaHoraUltimaModificacion", icuFechaHoraUltimaModificacion }, { "@icuInsConfirmar", icuInsConfirmar } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public Int32 InsertarTrarId(Int32 insId, Int32 aluId, Int32 carId, Int32 plaId, Int32 curId, Int32 camId, Int32 escId, Int32 icuAnoCursado, DateTime icuFechaInscripcion, Int32 icuEstado, Boolean icuActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime icuFechaHoraCreacion, DateTime icuFechaHoraUltimaModificacion, Int32 icuInsConfirmar)
            //{
            //    Int32 IdMax;
            //    try
            //    {
            //        IdMax = ocdGestor.EjecutarNonQueryRetornaId("[InscripcionCursado.Insertar]", new object[,] { { "@insId", insId }, { "@aluId", aluId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escId", escId }, { "@icuAnoCursado", icuAnoCursado }, { "@icuFechaInscripcion", icuFechaInscripcion }, { "@icuEstado", icuEstado }, { "@icuActivo", icuActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@icuFechaHoraCreacion", icuFechaHoraCreacion }, { "@icuFechaHoraUltimaModificacion", icuFechaHoraUltimaModificacion }, { "@icuInsConfirmar", icuInsConfirmar } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //    return IdMax;
            //}

            public void Actualizar()
            {
                try
                {
                    if (this.ictId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[InscripcionCursadoTerciario.Actualizar]", new object[,] {  { "@ictId", ictId }, { "@ictId", icuId },
                        { "@escId", escId }, { "@ictFechaInscripcion", ictFechaInscripcion }, { "@ictEstado", ictEstado }, { "@ictActivo", ictActivo },
                          { "@cdnId", cdnId }, { "@ictFechaRegularizaPromociona", ictFechaRegularizaPromociona }, { "@ictInsConfirmar", ictInsConfirmar },{ "@ictObservacion", ictObservacion },
                        { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@ictFechaHoraCreacion", ictFechaHoraCreacion }, { "@ictFechaHoraUltimaModificacion", ictFechaHoraUltimaModificacion } });
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar()
            {
                try
                {
                    if (this.icuId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[InscripcionCursadoTerciario.Eliminar]", new object[,] { { "@ictId", ictId } });
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public Int32 Insertar()
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId2("[InscripcionCursadoTerciario.Insertar]", new object[,] { { "@icuId", icuId },
                        { "@escId", escId }, { "@ictFechaInscripcion", ictFechaInscripcion }, { "@ictEstado", ictEstado }, { "@ictActivo", ictActivo },
                          { "@cdnId", cdnId }, { "@ictFechaRegularizaPromociona", ictFechaRegularizaPromociona }, { "@ictInsConfirmar", ictInsConfirmar }, { "@ictObservacion", ictObservacion },
                        { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@ictFechaHoraCreacion", ictFechaHoraCreacion }, { "@ictFechaHoraUltimaModificacion", ictFechaHoraUltimaModificacion } });
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