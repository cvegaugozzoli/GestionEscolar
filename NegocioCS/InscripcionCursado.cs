using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class InscripcionCursado
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _icuId;
            public Int32 icuId { get { return _icuId; } set { _icuId = value; } }

            private Int32 _insId;
            public Int32 insId { get { return _insId; } set { _insId = value; } }

            private Int32 _icuAnoCursado;
            public Int32 icuAnoCursado { get { return _icuAnoCursado; } set { _icuAnoCursado = value; } }

            private DateTime _icuFechaInscripcion;
            public DateTime icuFechaInscripcion { get { return _icuFechaInscripcion; } set { _icuFechaInscripcion = value; } }

            private Boolean _icuActivo;
            public Boolean icuActivo { get { return _icuActivo; } set { _icuActivo = value; } }

            private DateTime _icuFechaHoraCreacion;
            public DateTime icuFechaHoraCreacion { get { return _icuFechaHoraCreacion; } set { _icuFechaHoraCreacion = value; } }

            private DateTime _icuFechaHoraUltimaModificacion;
            public DateTime icuFechaHoraUltimaModificacion { get { return _icuFechaHoraUltimaModificacion; } set { _icuFechaHoraUltimaModificacion = value; } }

            private Int32 _aluId;
            public Int32 aluId { get { return _aluId; } set { _aluId = value; } }

            private Int32 _icuEstado;
            public Int32 icuEstado { get { return _icuEstado; } set { _icuEstado = value; } }

            private Int32 _carId;
            public Int32 carId { get { return _carId; } set { _carId = value; } }

            private Int32 _plaId;
            public Int32 plaId { get { return _plaId; } set { _plaId = value; } }

            private Int32 _curId;
            public Int32 curId { get { return _curId; } set { _curId = value; } }

            private Int32 _camId;
            public Int32 camId { get { return _camId; } set { _camId = value; } }

            private Int32 _escId;
            public Int32 escId { get { return _escId; } set { _escId = value; } }

            private String _icuObserv;
            public String icuObserv { get { return _icuObserv; } set { _icuObserv = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }
            private Int32 _icuInsConfirmar;
            public Int32 icuInsConfirmar { get { return _icuInsConfirmar; } set { _icuInsConfirmar = value; } }

            #endregion

            #region Constructores

            public InscripcionCursado() { try { this.icuId = 0; } catch (Exception oError) { throw oError; } }

            public InscripcionCursado(Int32 icuId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerUno]", new object[,] { { "@icuId", icuId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["icuId"].ToString().Trim().Length > 0)
                        {
                            this.icuId = Convert.ToInt32(Fila.Rows[0]["icuId"]);
                        }
                        else
                        {
                            this.icuId = 0;
                        }

                        if (Fila.Rows[0]["insId"].ToString().Trim().Length > 0)
                        {
                            this.insId = Convert.ToInt32(Fila.Rows[0]["insId"]);
                        }
                        else
                        {
                            this.insId = 0;
                        }

                        if (Fila.Rows[0]["icuAnoCursado"].ToString().Trim().Length > 0)
                        {
                            this.icuAnoCursado = Convert.ToInt32(Fila.Rows[0]["icuAnoCursado"]);
                        }
                        else
                        {
                            this.icuAnoCursado = 0;
                        }

                        if (Fila.Rows[0]["icuFechaInscripcion"].ToString().Trim().Length > 0)
                        {
                            this.icuFechaInscripcion = Convert.ToDateTime(Fila.Rows[0]["icuFechaInscripcion"]);
                        }
                        else
                        {
                            this.icuFechaInscripcion = DateTime.Now;
                        }
                        if (Fila.Rows[0]["icuEstado"].ToString().Trim().Length > 0)
                        {
                            this.icuEstado = Convert.ToInt32(Fila.Rows[0]["icuEstado"]);
                        }
                        else
                        {
                            this.icuEstado = 0;
                        }
                        if (Fila.Rows[0]["icuFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.icuFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["icuFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.icuFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["icuFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.icuFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["icuFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.icuFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["icuActivo"].ToString().Trim().Length > 0)
                        {
                            this.icuActivo = (Convert.ToInt32(Fila.Rows[0]["icuActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.icuActivo = false;
                        }

                        if (Fila.Rows[0]["aluId"].ToString().Trim().Length > 0)
                        {
                            this.aluId = Convert.ToInt32(Fila.Rows[0]["aluId"]);
                        }
                        else
                        {
                            this.aluId = 0;
                        }


                        if (Fila.Rows[0]["icuObserv"].ToString().Trim().Length > 0)
                        {
                            this.icuObserv = Convert.ToString(Fila.Rows[0]["icuObserv"]);
                        }
                        else
                        {
                            this.icuObserv = "";
                        }
                        if (Fila.Rows[0]["plaId"].ToString().Trim().Length > 0)
                        {
                            this.plaId = Convert.ToInt32(Fila.Rows[0]["plaId"]);
                        }
                        else
                        {
                            this.plaId = 0;
                        }

                        if (Fila.Rows[0]["curId"].ToString().Trim().Length > 0)
                        {
                            this.curId = Convert.ToInt32(Fila.Rows[0]["curId"]);
                        }
                        else
                        {
                            this.curId = 0;
                        }

                        if (Fila.Rows[0]["camId"].ToString().Trim().Length > 0)
                        {
                            this.camId = Convert.ToInt32(Fila.Rows[0]["camId"]);
                        }
                        else
                        {
                            this.camId = 0;
                        }

                        if (Fila.Rows[0]["escId"].ToString().Trim().Length > 0)
                        {
                            this.escId = Convert.ToInt32(Fila.Rows[0]["escId"]);
                        }
                        else
                        {
                            this.escId = 0;
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
                        if (Fila.Rows[0]["icuInsConfirmar"].ToString().Trim().Length > 0)
                        {
                            this.icuInsConfirmar = Convert.ToInt32(Fila.Rows[0]["icuInsConfirmar"]);
                        }
                        else
                        {
                            this.icuInsConfirmar = 1;
                        }
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public InscripcionCursado(Int32 icuId, Int32 insId, Int32 icuAnoCursado, DateTime icuFechaInscripcion, Boolean icuActivo, DateTime icuFechaHoraCreacion, String icuObserv, DateTime icuFechaHoraUltimaModificacion, Int32 IaluId, Int32 icuEstado, Int32 IcarId, Int32 IplaId, Int32 IcurId, Int32 IcamId, Int32 IescId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion, Int32 icuInsConfirmar)
            {
                try
                {
                    this.icuId = icuId;
                    this.insId = insId;
                    this.icuAnoCursado = icuAnoCursado;
                    this.icuFechaInscripcion = icuFechaInscripcion;
                    this.icuActivo = icuActivo;
                    this.icuFechaHoraCreacion = icuFechaHoraCreacion;
                    this.icuFechaHoraUltimaModificacion = icuFechaHoraUltimaModificacion;
                    this.aluId = aluId;
                    this.carId = carId;
                    this.plaId = plaId;
                    this.curId = curId;
                    this.camId = camId;
                    this.escId = escId;
                    this.icuEstado = icuEstado;
    this.icuObserv = icuObserv;
                    this.usuIdCreacion = usuIdCreacion;
                    this.usuIdUltimaModificacion = usuIdUltimaModificacion;
                    this.icuInsConfirmar = icuInsConfirmar;
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
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoporAlumno(String aluNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerTodoporAlumno]", new object[,] { { "@aluNombre", aluNombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
   public DataTable ObtenerTodoporAlumnoxAnioxInst(String aluNombre, Int32 Anio, Int32 inst)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerTodoporAlumnoxAnioxInst]", new object[,] { { "@aluNombre", aluNombre },  { "@Anio", Anio }, { "@inst", inst } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoxDnixCursxAnio(int insId, String Dni, int curId, int Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerUnoxDnixCursxAnio]", new object[,] { { "@insId", insId }, { "@Dni", Dni }, { "@curId", curId }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return Tabla;
            }


            public DataTable ObtenexCarIdxAluId(Int32 carId, Int32 aluId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenexCarIdxAluId]", new object[,] { { "@carId", carId }, { "aluId", aluId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ControlCursoExisteTerciario(Int32 insId, Int32 aluId, Int32 curId, int Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ControlCursoExisteTerciario]", new object[,] { { "@insId", insId }, { "@aluId", aluId }, { "@curId", curId }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUnoxDnixAnio(String Dni, int Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerUnoxDnixAnio]", new object[,] { { "@Dni", Dni }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return Tabla;
            }

  public DataTable ObtenerUnoxDnixAnioxInst(String Dni, int Anio, Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerUnoxDnixAnioxInst]", new object[,] { { "@Dni", Dni }, { "@Anio", Anio }, { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return Tabla;
            }
            public DataTable ObtenerporCarporPlaporCurxEstxAnio(Int32 insId, Int32 carId, Int32 plaId, Int32 curId, Int32 anio, Int32 Estado)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerporCarporPlaporCurxEstxAnio]", new object[,] { { "@insId", insId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@anio", anio }, { "@Estado", Estado } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerListadoBecado(Int32 insId, Int32 curId, Int32 anio, Int32 conId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerListadoBecado]", new object[,] { { "@insId", insId }, { "@curId", curId }, { "@anio", anio }, { "@conId", conId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerListadoBecadoFra(Int32 insId, Int32 curId, Int32 anio, Int32 conId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerListadoBecadoFra]", new object[,] { { "@insId", insId }, { "@curId", curId }, { "@anio", anio }, { "@conId", conId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerporCarporPlaporCurxAnioxConId(Int32 insId, Int32 carId, Int32 plaId, Int32 curId, Int32 anio, Int32 conId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerporCarporPlaporCurxAnioxConId]", new object[,] { { "@insId", insId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@anio", anio }, { "@conId", conId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerporCarporPlaporCurAnioPrimaria(Int32 insId, Int32 carId, Int32 plaId, Int32 curId, Int32 anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerporCarporPlaporCurAnioPrimaria]", new object[,] { { "@insId", insId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@anio", anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerporCarporPlaporCurAnio(Int32 insId, Int32 carId, Int32 plaId, Int32 curId, Int32 anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerporCarporPlaporCurAnio]", new object[,] { { "@insId", insId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@anio", anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerporCarporPlaporCurAnioxConf(Int32 insId, Int32 carId, Int32 plaId, Int32 curId, Int32 anio, int ParamInt1)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerporCarporPlaporCurAnioxConf]", new object[,] { { "@insId", insId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@anio", anio }, { "@ParamInt1", ParamInt1 } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodoporaluId(int aluId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerTodoporaluId]", new object[,] { { "@aluId", aluId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodoxaluIdxAnio(int aluId, int Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerTodoxaluIdxAnio]", new object[,] { { "@aluId", aluId }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodoxInsIdxaluIdxAnioCursado(int insId, int Anio, int aluId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado]", new object[,] { { "@insId", insId }, { "@Anio", Anio }, { "@aluId", aluId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return Tabla;
            }

            public DataTable ObtenerporInstCarporPlaporCurporAlu(Int32 insId, Int32 carId, Int32 plaId, Int32 curId, String aluNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerporInstCarporPlaporCurporAlu]", new object[,] { { "@insId", insId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@aluNombre", aluNombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerUno(Int32 icuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerUno]", new object[,] { { "@icuId", icuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerUnoControlExiste(Int32 aluId, Int32 escId, Int32 icuAnoCursado)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerUnoControlExiste]", new object[,] { { "@aluId", aluId }, { "@escId", escId }, { "@icuAnoCursado", icuAnoCursado } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoControlExisteMismoAño(Int32 insId, Int32 aluId, Int32 icuAnoCursado)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerUnoControlExisteMismoAño]", new object[,] { { "@insId", insId }, { "@aluId", aluId }, { "@icuAnoCursado", icuAnoCursado } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoControlExisteNoTerciario(Int32 insId, Int32 aluId, Int32 curId, Int32 icuAnoCursado)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerUnoControlExisteNoTerciario]", new object[,] { { "@insId", insId }, { "@aluId", aluId }, { "@curId", curId }, { "@icuAnoCursado", icuAnoCursado } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoControlExisteTerciario(Int32 insId, Int32 aluId, Int32 curId, Int32 icuAnoCursado)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerUnoControlExisteTerciario]", new object[,] { { "@insId", insId }, { "@aluId", aluId }, { "@curId", curId }, { "@icuAnoCursado", icuAnoCursado } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            //@aluId int,
            //@escId int,
            //@conId int
            public DataTable ObtenerUnoporCondicionTipo(Int32 aluId, Int32 escId, Int32 conId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerUnoporCondicionTipo]", new object[,] { { "@aluId", aluId }, { "escId", escId }, { "@conId", conId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }



            public DataTable ObtenerUnoporAprobadooPromocionado(Int32 aluId, Int32 escId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerUnoporAprobadooPromocionado]", new object[,] { { "@aluId", aluId }, { "escId", escId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoporAlumnoporEspacioCurricular(Int32 aluId, Int32 escId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionCursado.ObtenerUnoporAlumnoporEspacioCurricular]", new object[,] { { "@aluId", aluId }, { "escId", escId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public void Actualizar(Int32 icuId, Int32 insId, Int32 aluId, Int32 carId, Int32 plaId, Int32 curId, Int32 camId, Int32 escId, Int32 icuAnoCursado, DateTime icuFechaInscripcion, Int32 icuEstado, Boolean icuActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime icuFechaHoraCreacion, DateTime icuFechaHoraUltimaModificacion, Int32 icuInsConfirmar)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionCursado.Actualizar]", new object[,] { { "@icuId", icuId }, { "@insId", insId }, { "@aluId", aluId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escId", escId }, { "@icuAnoCursado", icuAnoCursado }, { "@icuFechaInscripcion", icuFechaInscripcion }, { "@icuEstado", icuEstado }, { "@icuActivo", icuActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@icuFechaHoraCreacion", icuFechaHoraCreacion }, { "@icuFechaHoraUltimaModificacion", icuFechaHoraUltimaModificacion }, { "@icuInsConfirmar", icuInsConfirmar } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void ActualizarEstado(Int32 icuId, Int32 icuEstado)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionCursado.ActualizarEstado]", new object[,] { { "@icuId", icuId }, { "@icuEstado", icuEstado } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void ActualizarActivo(Int32 icuId, Int32 activo)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionCursado.ActualizarActivo]", new object[,] { { "@icuId", icuId }, { "@activo", activo } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void ActualizarObserv(Int32 icuId, String icuObserv)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionCursado.ActualizarObserv]", new object[,] { { "@icuId", icuId }, { "@icuObserv", icuObserv } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void ActualizarEstadoActivo(Int32 icuId, Int32 icuEstado)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionCursado.ActualizarEstadoActivo]", new object[,] { { "@icuId", icuId }, { "@icuEstado", icuEstado } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void ActualizarEstadoInscConf(Int32 icuId, Int32 icuEstado)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionCursado.ActualizarEstadoInscConf]", new object[,] { { "@icuId", icuId }, { "@icuEstado", icuEstado } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void Eliminar(Int32 icuId, Int32 usuId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionCursado.Eliminar]", new object[,] { { "@icuId", icuId }, { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(Int32 insId, Int32 aluId, Int32 carId, Int32 plaId, Int32 curId, Int32 camId, Int32 escId, Int32 icuAnoCursado, DateTime icuFechaInscripcion, Int32 icuEstado, Boolean icuActivo, String icuObserv, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime icuFechaHoraCreacion, DateTime icuFechaHoraUltimaModificacion, Int32 icuInsConfirmar)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionCursado.Insertar]", new object[,] { { "@aluId", aluId }, { "@insId", insId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escId", escId }, { "@icuAnoCursado", icuAnoCursado }, { "@icuFechaInscripcion", icuFechaInscripcion }, { "@icuEstado", icuEstado }, { "@icuActivo", icuActivo }, { "@icuObserv", icuObserv }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@icuFechaHoraCreacion", icuFechaHoraCreacion }, { "@icuFechaHoraUltimaModificacion", icuFechaHoraUltimaModificacion }, { "@icuInsConfirmar", icuInsConfirmar } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public Int32 InsertarTrarId(Int32 insId, Int32 aluId, Int32 carId, Int32 plaId, Int32 curId, Int32 camId, Int32 escId, Int32 icuAnoCursado, DateTime icuFechaInscripcion, Int32 icuEstado, Boolean icuActivo,String icuObserv, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime icuFechaHoraCreacion, DateTime icuFechaHoraUltimaModificacion, Int32 icuInsConfirmar)
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[InscripcionCursado.Insertar]", new object[,] { { "@insId", insId }, { "@aluId", aluId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escId", escId }, { "@icuAnoCursado", icuAnoCursado }, { "@icuFechaInscripcion", icuFechaInscripcion }, { "@icuEstado", icuEstado }, { "@icuActivo", icuActivo }, { "@icuObserv", icuObserv }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@icuFechaHoraCreacion", icuFechaHoraCreacion }, { "@icuFechaHoraUltimaModificacion", icuFechaHoraUltimaModificacion }, { "@icuInsConfirmar", icuInsConfirmar } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }

            public void Actualizar()
            {
                try
                {
                    if (this.icuId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[InscripcionCursado.Actualizar]", new object[,] { { "@icuId", icuId }, { "@insId", insId }, { "@aluId", aluId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escId", escId }, { "@icuAnoCursado", icuAnoCursado }, { "@icuFechaInscripcion", icuFechaInscripcion }, { "@icuEstado", icuEstado }, { "@icuActivo", icuActivo }, { "@icuObserv", icuObserv },{ "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@icuFechaHoraCreacion", icuFechaHoraCreacion }, { "@icuFechaHoraUltimaModificacion", icuFechaHoraUltimaModificacion }, { "@icuInsConfirmar", icuInsConfirmar } });
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
                        ocdGestor.EjecutarNonQuery("[InscripcionCursado.Eliminar]", new object[,] { { "@icuId", icuId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[InscripcionCursado.Insertar]", new object[,] { { "@insId", insId }, { "@aluId", aluId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escId", escId }, { "@icuAnoCursado", icuAnoCursado }, { "@icuFechaInscripcion", icuFechaInscripcion }, { "@icuEstado", icuEstado }, { "@icuActivo", icuActivo }, { "@icuObserv", icuObserv }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@icuFechaHoraCreacion", icuFechaHoraCreacion }, { "@icuFechaHoraUltimaModificacion", icuFechaHoraUltimaModificacion }, { "@icuInsConfirmar", icuInsConfirmar } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }


            public DataTable InformeInscripcionCursado(Int32 insId, Int32 carId, Int32 plaId, Int32 curId, Int32 camId, Int32 escId, Int32 anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("InformeInscripcionCursado", new object[,] { { "@insId", insId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "escId", escId }, { "@anio", anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable InformeCalificacionesPorTrimestre(Int32 curso, Int32 anio, Int32 insId, Int32 Periodo)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("InformeCalificacionesPorTrimestre", new object[,] { { "@curso", curso }, { "@anio", anio }, { "@insId", insId }, { "@Periodo", Periodo } });
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