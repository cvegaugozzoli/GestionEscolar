using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class MesaExamen
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _meeId;
            public Int32 meeId { get { return _meeId; } set { _meeId = value; } }
            private Int32 _meeAnio;
            public Int32 meeAnio { get { return _meeAnio; } set { _meeAnio = value; } }
            private DateTime _meeFecha;
            public DateTime meeFecha { get { return _meeFecha; } set { _meeFecha = value; } }

            private DateTime _meehora;
            public DateTime meehora { get { return _meehora; } set { _meehora = value; } }

            private Int32 _tueId;
            public Int32 tueId { get { return _tueId; } set { _tueId = value; } }

            private Int32 _carId;
            public Int32 carId { get { return _carId; } set { _carId = value; } }

            private Int32 _plaId;
            public Int32 plaId { get { return _plaId; } set { _plaId = value; } }
            private Int32 _escId;
            public Int32 escId { get { return _escId; } set { _escId = value; } }

            private Int32 _curId;
            public Int32 curId { get { return _curId; } set { _curId = value; } }

            private Int32 _meeCantInsc;
            public Int32 meeCantInsc { get { return _meeCantInsc; } set { _meeCantInsc = value; } }

            private Boolean _meeActivo;
            public Boolean meeActivo { get { return _meeActivo; } set { _meeActivo = value; } }

            private DateTime _meeFechaHoraCreacion;
            public DateTime meeFechaHoraCreacion { get { return _meeFechaHoraCreacion; } set { _meeFechaHoraCreacion = value; } }

            private DateTime _meeFechaHoraUltimaModificacion;
            public DateTime meeFechaHoraUltimaModificacion { get { return _meeFechaHoraUltimaModificacion; } set { _meeFechaHoraUltimaModificacion = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public MesaExamen() { try { this.meeId = 0; } catch (Exception oError) { throw oError; } }

            public MesaExamen(Int32 meeId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[MesaExamen.ObtenerUno]", new object[,] { { "@meeId", meeId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["meeId"].ToString().Trim().Length > 0)
                        {
                            this.meeId = Convert.ToInt32(Fila.Rows[0]["meeId"]);
                        }
                        else
                        {
                            this.meeId = 0;
                        }
                        if (Fila.Rows[0]["meeAnio"].ToString().Trim().Length > 0)
                        {
                            this.meeAnio = Convert.ToInt32(Fila.Rows[0]["meeAnio"]);
                        }
                        else
                        {
                            this.meeAnio = 0;
                        }
                        if (Fila.Rows[0]["meeFecha"].ToString().Trim().Length > 0)
                        {
                            this.meeFecha = Convert.ToDateTime(Fila.Rows[0]["meeFecha"]);
                        }
                        else
                        {
                            this.meeFecha = DateTime.Now;
                        }

                        if (Fila.Rows[0]["meehora"].ToString().Trim().Length > 0)
                        {
                            this.meehora = Convert.ToDateTime(Fila.Rows[0]["meehora"]);
                        }
                        else
                        {
                            this.meehora = DateTime.Now;
                        }
                        if (Fila.Rows[0]["tueId"].ToString().Trim().Length > 0)
                        {
                            this.tueId = Convert.ToInt32(Fila.Rows[0]["tueId"]);
                        }
                        else
                        {
                            this.tueId = 0;
                        }

                        if (Fila.Rows[0]["carId"].ToString().Trim().Length > 0)
                        {
                            this.carId = Convert.ToInt32(Fila.Rows[0]["carId"]);
                        }
                        else
                        {
                            this.carId = 0;
                        }
                        if (Fila.Rows[0]["plaId"].ToString().Trim().Length > 0)
                        {
                            this.plaId = Convert.ToInt32(Fila.Rows[0]["plaId"]);
                        }
                        else
                        {
                            this.plaId = 0;
                        }
                        if (Fila.Rows[0]["escId"].ToString().Trim().Length > 0)
                        {
                            this.escId = Convert.ToInt32(Fila.Rows[0]["escId"]);
                        }
                        else
                        {
                            this.escId = 0;
                        }
                        if (Fila.Rows[0]["curId"].ToString().Trim().Length > 0)
                        {
                            this.curId = Convert.ToInt32(Fila.Rows[0]["curId"]);
                        }
                        else
                        {
                            this.curId = 0;
                        }
                        if (Fila.Rows[0]["meeCantInsc"].ToString().Trim().Length > 0)
                        {
                            this.meeCantInsc = Convert.ToInt32(Fila.Rows[0]["meeCantInsc"]);
                        }
                        else
                        {
                            this.meeCantInsc = 0;
                        }
                        if (Fila.Rows[0]["meeFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.meeFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["meeFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.meeFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["meeFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.meeFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["meeFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.meeFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["meeActivo"].ToString().Trim().Length > 0)
                        {
                            this.meeActivo = (Convert.ToInt32(Fila.Rows[0]["meeActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.meeActivo = false;
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

                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            //public MesaExamen(Int32 banId, String banCodigo, String banNombre, String banSucursal, Boolean banActivo, DateTime banFechaHoraCreacion, DateTime banFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            //{
            //    try
            //    {
            //        this.banId = banId;
            //        this.banCodigo = banCodigo;
            //        this.banNombre = banNombre;
            //        this.banSucursal = banSucursal;
            //        this.banActivo = banActivo;
            //        this.banFechaHoraCreacion = banFechaHoraCreacion;
            //        this.banFechaHoraUltimaModificacion = banFechaHoraUltimaModificacion;
            //        this.usuIdCreacion = usuIdCreacion;
            //        this.usuIdUltimaModificacion = usuIdUltimaModificacion;
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}
            #endregion

            #region Metodos




            public DataTable ObtenerTodo()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[MesaExamen.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoxTurnoxescId(int Turno, int escId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[MesaExamen.ObtenerUnoxTurnoxescId]", new object[,] { { "@Turno", Turno }, { "@escId", escId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
    public DataTable ObtenerUnoxTurno(int Turno)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[MesaExamen.ObtenerUnoxTurno]", new object[,] { { "@Turno", Turno } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUno(Int32 meeId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[MesaExamen.ObtenerUno]", new object[,] { { "@meeId", meeId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }



            public void Eliminar(Int32 meeId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[MesaExamen.Eliminar]", new object[,] { { "@meeId", meeId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void EliminarxActivo(Int32 Id, int Usuario, DateTime FechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[MesaExamen.EliminarxActivo]", new object[,] { { "@Id", Id }, { "@usuIdUltimaModificacion", Usuario }, { "@FechaHoraUltimaModificacion", FechaHoraUltimaModificacion }});
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public DataTable ObtenerNivxCarxPlanxrCurxEC(Int32 tue, Int32 carId, Int32 plaId, Int32 curId, Int32 escId, Boolean chekFch, DateTime fecha)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[MesaExamen.ObtenerNivxCarxPlanxrCurxEC]", new object[,] { { "@tue", tue }, { "@carId", carId },
                        { "@plaId", plaId }, { "@curId", curId }, { "@escId", escId } ,{ "@chekFch", chekFch }, { "@fecha", fecha }});
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public void ActualizarFch(int meeId, DateTime FechaMod, int Usuario, DateTime meeFechaHoraUltimaModificacion)
            {
                try
                {
                    if (meeId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[MesaExamen.ActualizarFch]", new object[,] { { "@meeId", meeId }, { "@FechaMod", FechaMod },
                       { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@meeFechaHoraUltimaModificacion", meeFechaHoraUltimaModificacion } });
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void Actualizar()
            {
                try
                {
                    if (this.meeId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[MesaExamen.Actualizar]", new object[,] { { "@meeId", meeId },  { "@meeAnio", meeAnio },{ "@meeFecha", meeFecha },
                            { "@meehora", meehora }, { "@tueId", tueId },  { "@carId", carId },  { "@plaId", plaId },  { "@escId", escId }, { "@curId", curId },
   { "@meeCantInsc", meeCantInsc }, { "@mee Activo", meeActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion },
   { "@meeFechaHoraCreacion", meeFechaHoraCreacion }, { "@meeFechaHoraUltimaModificacion", meeFechaHoraUltimaModificacion } });
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
                    if (this.meeId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[MesaExamen.Eliminar]", new object[,] { { "@banId", meeId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[MesaExamen.Insertar]", new object[,] { { "@meeAnio", meeAnio },  { "@meeFecha", meeFecha },
                        { "@meehora", meehora }, { "@tueId", tueId }, { "@carId", carId }, { "@plaId", plaId }, { "@escId", escId }, { "@curId", curId },
                        { "@meeCantInsc", meeCantInsc },{ "@meeActivo", meeActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion },
                        { "@meeFechaHoraCreacion", meeFechaHoraCreacion }, { "@meeFechaHoraUltimaModificacion", meeFechaHoraUltimaModificacion } });
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