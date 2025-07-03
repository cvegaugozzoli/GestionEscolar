using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class Movimiento
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _movId;
            public Int32 movId { get { return _movId; } set { _movId = value; } }

            private String _movDescripcion;
            public String movDescripcion { get { return _movDescripcion; } set { _movDescripcion = value; } }



            private DateTime _movFechaHoraCreacion;
            public DateTime movFechaHoraCreacion { get { return _movFechaHoraCreacion; } set { _movFechaHoraCreacion = value; } }

            private DateTime _movFechaHoraUltimaModificacion;
            public DateTime movFechaHoraUltimaModificacion { get { return _movFechaHoraUltimaModificacion; } set { _movFechaHoraUltimaModificacion = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public Movimiento() { try { this.movId = 0; } catch (Exception oError) { throw oError; } }

            public Movimiento(Int32 movId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Movimiento.ObtenerUno]", new object[,] { { "@movId", movId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["movId"].ToString().Trim().Length > 0)
                        {
                            this.movId = Convert.ToInt32(Fila.Rows[0]["movId"]);
                        }
                        else
                        {
                            this.movId = 0;
                        }

                        if (Fila.Rows[0]["movDescripcion"].ToString().Trim().Length > 0)
                        {
                            this.movDescripcion = Convert.ToString(Fila.Rows[0]["movDescripcion"]);
                        }
                        else
                        {
                            this.movDescripcion = "";
                        }

                        if (Fila.Rows[0]["movFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.movFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["movFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.movFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["movFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.movFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["movFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.movFechaHoraUltimaModificacion = DateTime.Now;
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

            //         public Sexo(Int32 sexId, String sexNombre, Boolean sexActivo, DateTime sexFechaHoraCreacion, DateTime sexFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            //{
            //             try
            //             {
            //	    this.sexId = sexId;
            //	    this.sexNombre = sexNombre;
            //	    this.sexActivo = sexActivo;
            //	    this.sexFechaHoraCreacion = sexFechaHoraCreacion;
            //	    this.sexFechaHoraUltimaModificacion = sexFechaHoraUltimaModificacion;
            //	    this.usuIdCreacion = usuIdCreacion;
            //	    this.usuIdUltimaModificacion = usuIdUltimaModificacion;
            //             }
            //    catch (Exception oError)
            //             {
            //                 throw oError;
            //             }
            //         }

            #endregion
            #region Metodos


            //public DataTable ObtenerBuscador(String ValorABuscar)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[Sexo.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}

            public DataTable ObtenerLista(String PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Movimiento.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            //    public DataTable ObtenerTodo()
            //    {
            //        ocdGestor = new Datos.Gestor();
            //        Tabla = new DataTable();

            //        try
            //        {
            //        	Tabla = ocdGestor.EjecutarReader("[Sexo.ObtenerTodo]", new object[,] {});
            //        }
            //        catch (Exception oError)
            //        {
            //        	throw oError;
            //        }

            //        return Tabla;
            //    }

            //    public DataTable ObtenerTodoBuscarxNombre(String Nombre)
            //    {
            //        ocdGestor = new Datos.Gestor();
            //        Tabla = new DataTable();

            //        try
            //        {
            //        	Tabla = ocdGestor.EjecutarReader("[Sexo.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
            //        }
            //        catch (Exception oError)
            //        {
            //        	throw oError;
            //        }

            //        return Tabla;
            //    }

            //    public DataTable ObtenerUno(Int32 sexId)
            //    {
            //        ocdGestor = new Datos.Gestor();
            //        Tabla = new DataTable();

            //        try
            //        {
            //        	Tabla = ocdGestor.EjecutarReader("[Sexo.ObtenerUno]", new object[,] {{"@sexId", sexId}});
            //        }
            //        catch (Exception oError)
            //        {
            //        	throw oError;
            //        }

            //        return Tabla;
            //    }

            //    public DataTable ObtenerValidarRepetido(Int32 sexId, String sexNombre)
            //    {
            //        ocdGestor = new Datos.Gestor();
            //        Tabla = new DataTable();

            //        try
            //        {
            //        	Tabla = ocdGestor.EjecutarReader("[Sexo.ObtenerValidarRepetido]", new object[,] {{"@sexId", sexId}, {"@sexNombre", sexNombre}});
            //        }
            //        catch (Exception oError)
            //        {
            //        	throw oError;
            //        }

            //        return Tabla;
            //    }

            //    public void Actualizar(Int32 sexId, String sexNombre, Boolean sexActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime sexFechaHoraCreacion, DateTime sexFechaHoraUltimaModificacion)
            //    {
            //        try
            //        {
            //            ocdGestor.EjecutarNonQuery("[Sexo.Actualizar]", new object[,] {{"@sexId", sexId}, {"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //        }
            //        catch (Exception oError)
            //        {
            //        	throw oError;
            //        }
            //    }

            //    public void Copiar(String sexNombre, Boolean sexActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime sexFechaHoraCreacion, DateTime sexFechaHoraUltimaModificacion)
            //    {
            //        try
            //        {
            //            ocdGestor.EjecutarNonQuery("[Sexo.Copiar]", new object[,] {{"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //        }
            //        catch (Exception oError)
            //        {
            //        	throw oError;
            //        }
            //    }

            //    public void Eliminar(Int32 sexId)
            //    {
            //        try
            //        {
            //            ocdGestor.EjecutarNonQuery("[Sexo.Eliminar]", new object[,] {{"@sexId", sexId}});
            //        }
            //        catch (Exception oError)
            //        {
            //        	throw oError;
            //        }
            //    }

            //    public void Insertar(String sexNombre, Boolean sexActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime sexFechaHoraCreacion, DateTime sexFechaHoraUltimaModificacion)
            //    {
            //        try
            //        {
            //            ocdGestor.EjecutarNonQuery("[Sexo.Insertar]", new object[,] {{"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //        }
            //        catch (Exception oError)
            //        {
            //        	throw oError;
            //        }
            //    }

            //    public void Actualizar()
            //    {
            //        try
            //        {
            //            if(this.sexId != 0)
            //            {
            //                ocdGestor.EjecutarNonQuery("[Sexo.Actualizar]", new object[,] {{"@sexId", sexId}, {"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //            }
            //        }
            //        catch (Exception oError)
            //        {
            //        	throw oError;
            //        }
            //    }

            //    public void Copiar()
            //    {
            //        try
            //        {
            //            if(this.sexId != 0)
            //            {
            //                ocdGestor.EjecutarNonQuery("[Sexo.Copiar]", new object[,] {{"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //            }
            //        }
            //        catch (Exception oError)
            //        {
            //        	throw oError;
            //        }
            //    }

            //    public void Eliminar()
            //    {
            //        try
            //        {
            //            if(this.sexId != 0)
            //            {
            //                ocdGestor.EjecutarNonQuery("[Sexo.Eliminar]", new object[,] {{"@sexId", sexId}});
            //            }
            //        }
            //        catch (Exception oError)
            //        {
            //        	throw oError;
            //        }
            //    }

            //    public Int32 Insertar()
            //    {
            //        Int32 IdMax;
            //        try
            //        {
            //            IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Sexo.Insertar]", new object[,] {{"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //        }
            //        catch (Exception oError)
            //        {
            //        	throw oError;
            //        }
            //        return IdMax;
            //    }


            //    #endregion
            //}

        }
    }
    #endregion
}