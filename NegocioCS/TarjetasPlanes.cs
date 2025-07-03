using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class TarjetasPlanes
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _tapId;
            public Int32 tapId { get { return _tapId; } set { _tapId = value; } }

            private String _tapNombre;
            public String tapNombre { get { return _tapNombre; } set { _tapNombre = value; } }

            private Decimal _tapInteres;
            public Decimal tapInteres { get { return _tapInteres; } set { _tapInteres = value; } }

            private Int32 _tapCantCuotaPlan;
            public Int32 tapCantCuotaPlan { get { return _tapCantCuotaPlan; } set { _tapCantCuotaPlan = value; } }

            private Boolean _tapActivo;
            public Boolean tapActivo { get { return _tapActivo; } set { _tapActivo = value; } }

            private DateTime _tapFechaHoraCreacion;
            public DateTime tapFechaHoraCreacion { get { return _tapFechaHoraCreacion; } set { _tapFechaHoraCreacion = value; } }

            private DateTime _tapFechaHoraUltimaModificacion;
            public DateTime tapFechaHoraUltimaModificacion { get { return _tapFechaHoraUltimaModificacion; } set { _tapFechaHoraUltimaModificacion = value; } }

            private Int32 _tarId;
            public Int32 tarId { get { return _tarId; } set { _tarId = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuidUltimaModificacion;
            public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public TarjetasPlanes() { try { this.tapId = 0; } catch (Exception oError) { throw oError; } }

            public TarjetasPlanes(Int32 tapId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[TarjetasPlanes.ObtenerUno]", new object[,] { { "@tapId", tapId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["tapId"].ToString().Trim().Length > 0)
                        {
                            this.tapId = Convert.ToInt32(Fila.Rows[0]["tapId"]);
                        }
                        else
                        {
                            this.tapId = 0;
                        }

                        if (Fila.Rows[0]["tapNombre"].ToString().Trim().Length > 0)
                        {
                            this.tapNombre = Convert.ToString(Fila.Rows[0]["tapNombre"]);
                        }
                        else
                        {
                            this.tapNombre = "";
                        }

                        if (Fila.Rows[0]["tapInteres"].ToString().Trim().Length > 0)
                        {
                            this.tapInteres = Convert.ToDecimal(Fila.Rows[0]["tapInteres"]);
                        }
                        else
                        {
                            this.tapInteres = 0;
                        }

                        if (Fila.Rows[0]["tapCantCuotaPlan"].ToString().Trim().Length > 0)
                        {
                            this.tapCantCuotaPlan = Convert.ToInt32(Fila.Rows[0]["tapCantCuotaPlan"]);
                        }
                        else
                        {
                            this.tapCantCuotaPlan = 0;
                        }

                        if (Fila.Rows[0]["tapFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.tapFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["tapFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.tapFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["tapFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.tapFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["tapFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.tapFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["tapActivo"].ToString().Trim().Length > 0)
                        {
                            this.tapActivo = (Convert.ToInt32(Fila.Rows[0]["tapActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.tapActivo = false;
                        }

                        if (Fila.Rows[0]["tarId"].ToString().Trim().Length > 0)
                        {
                            this.tarId = Convert.ToInt32(Fila.Rows[0]["tarId"]);
                        }
                        else
                        {
                            this.tarId = 0;
                        }

                        if (Fila.Rows[0]["usuIdCreacion"].ToString().Trim().Length > 0)
                        {
                            this.usuIdCreacion = Convert.ToInt32(Fila.Rows[0]["usuIdCreacion"]);
                        }
                        else
                        {
                            this.usuIdCreacion = 0;
                        }

                        if (Fila.Rows[0]["usuidUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.usuidUltimaModificacion = Convert.ToInt32(Fila.Rows[0]["usuidUltimaModificacion"]);
                        }
                        else
                        {
                            this.usuidUltimaModificacion = 0;
                        }

                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public TarjetasPlanes(Int32 tapId, String tapNombre, Decimal tapInteres, Int32 tapCantCuotaPlan, Boolean tapActivo, DateTime tapFechaHoraCreacion, DateTime tapFechaHoraUltimaModificacion, Int32 ItarId, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
            {
                try
                {
                    this.tapId = tapId;
                    this.tapNombre = tapNombre;
                    this.tapInteres = tapInteres;
                    this.tapCantCuotaPlan = tapCantCuotaPlan;
                    this.tapActivo = tapActivo;
                    this.tapFechaHoraCreacion = tapFechaHoraCreacion;
                    this.tapFechaHoraUltimaModificacion = tapFechaHoraUltimaModificacion;
                    this.tarId = tarId;
                    this.usuIdCreacion = usuIdCreacion;
                    this.usuidUltimaModificacion = usuidUltimaModificacion;
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            #endregion

            #region Metodos


            public DataTable ObtenerBuscador(String ValorABuscar)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TarjetasPlanes.ObtenerBuscador]", new object[,] { { "@ValorABuscar", ValorABuscar } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerLista(String PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TarjetasPlanes.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerListaxTarjId(String PrimerItem, int tarjId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TarjetasPlanes.ObtenerListaxTarjId]", new object[,] { { "@PrimerItem", PrimerItem }, { "@tarjId", tarjId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodo()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TarjetasPlanes.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoBuscarxNombre(String Nombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TarjetasPlanes.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(Int32 tapId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TarjetasPlanes.ObtenerUno]", new object[,] { { "@tapId", tapId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUnoxTarjeta(Int32 tarId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TarjetasPlanes.ObtenerUnoxTarjeta]", new object[,] { { "@tarId", tarId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoxtarIdxtapId(Int32 tarId, Int32 tapId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TarjetasPlanes.ObtenerUnoxtarIdxtapId]", new object[,] { { "@tarId", tarId } ,{ "@tapId", tapId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerValidarRepetido(Int32 tapId, String tapNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TarjetasPlanes.ObtenerValidarRepetido]", new object[,] { { "@tapId", tapId }, { "@tapNombre", tapNombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void Actualizar(Int32 tapId, String tapNombre, Int32 tarId, Decimal tapInteres, Int32 tapCantCuotaPlan, Boolean tapActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime tapFechaHoraCreacion, DateTime tapFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[TarjetasPlanes.Actualizar]", new object[,] { { "@tapId", tapId }, { "@tapNombre", tapNombre }, { "@tarId", tarId }, { "@tapInteres", tapInteres }, { "@tapCantCuotaPlan", tapCantCuotaPlan }, { "@tapActivo", tapActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@tapFechaHoraCreacion", tapFechaHoraCreacion }, { "@tapFechaHoraUltimaModificacion", tapFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Copiar(String tapNombre, Int32 tarId, Decimal tapInteres, Int32 tapCantCuotaPlan, Boolean tapActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime tapFechaHoraCreacion, DateTime tapFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[TarjetasPlanes.Copiar]", new object[,] { { "@tapNombre", tapNombre }, { "@tarId", tarId }, { "@tapInteres", tapInteres }, { "@tapCantCuotaPlan", tapCantCuotaPlan }, { "@tapActivo", tapActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@tapFechaHoraCreacion", tapFechaHoraCreacion }, { "@tapFechaHoraUltimaModificacion", tapFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 tapId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[TarjetasPlanes.Eliminar]", new object[,] { { "@tapId", tapId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(String tapNombre, Int32 tarId, Decimal tapInteres, Int32 tapCantCuotaPlan, Boolean tapActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime tapFechaHoraCreacion, DateTime tapFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[TarjetasPlanes.Insertar]", new object[,] { { "@tapNombre", tapNombre }, { "@tarId", tarId }, { "@tapInteres", tapInteres }, { "@tapCantCuotaPlan", tapCantCuotaPlan }, { "@tapActivo", tapActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@tapFechaHoraCreacion", tapFechaHoraCreacion }, { "@tapFechaHoraUltimaModificacion", tapFechaHoraUltimaModificacion } });
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
                    if (this.tapId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[TarjetasPlanes.Actualizar]", new object[,] { { "@tapId", tapId }, { "@tapNombre", tapNombre }, { "@tarId", tarId }, { "@tapInteres", tapInteres }, { "@tapCantCuotaPlan", tapCantCuotaPlan } , { "@tapActivo", tapActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@tapFechaHoraCreacion", tapFechaHoraCreacion }, { "@tapFechaHoraUltimaModificacion", tapFechaHoraUltimaModificacion } });
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Copiar()
            {
                try
                {
                    if (this.tapId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[TarjetasPlanes.Copiar]", new object[,] { { "@tapNombre", tapNombre }, { "@tarId", tarId }, { "@tapInteres", tapInteres }, { "@tapCantCuotaPlan", tapCantCuotaPlan } , { "@tapActivo", tapActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@tapFechaHoraCreacion", tapFechaHoraCreacion }, { "@tapFechaHoraUltimaModificacion", tapFechaHoraUltimaModificacion } });
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
                    if (this.tapId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[TarjetasPlanes.Eliminar]", new object[,] { { "@tapId", tapId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[TarjetasPlanes.Insertar]", new object[,] { { "@tapNombre", tapNombre }, { "@tarId", tarId }, { "@tapInteres", tapInteres }, { "@tapCantCuotaPlan", tapCantCuotaPlan }, { "@tapActivo", tapActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@tapFechaHoraCreacion", tapFechaHoraCreacion }, { "@tapFechaHoraUltimaModificacion", tapFechaHoraUltimaModificacion } });
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