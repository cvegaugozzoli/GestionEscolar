using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  FormasPago
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _fopId; 
			public Int32 fopId { get { return _fopId; } set { _fopId = value; } }

            private String _fopNombre; 
			public String fopNombre { get { return _fopNombre; } set { _fopNombre = value; } }

            private Boolean _fopActivo; 
			public Boolean fopActivo { get { return _fopActivo; } set { _fopActivo = value; } }

            private DateTime _fopFechaHoraCreacion; 
			public DateTime fopFechaHoraCreacion { get { return _fopFechaHoraCreacion; } set { _fopFechaHoraCreacion = value; } }

            private DateTime _fopFechaHoraUltimaModificacion; 
			public DateTime fopFechaHoraUltimaModificacion { get { return _fopFechaHoraUltimaModificacion; } set { _fopFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuidUltimaModificacion; 
			public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public FormasPago() { try { this.fopId = 0; } catch (Exception oError) { throw oError; } }            

            public FormasPago(Int32 fopId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[FormasPago.ObtenerUno]", new object[,] {{"@fopId", fopId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["fopId"].ToString().Trim().Length > 0)
                        {
                            this.fopId = Convert.ToInt32(Fila.Rows[0]["fopId"]);
                        }
                        else
                        {
                            this.fopId = 0;
                        }

					    if(Fila.Rows[0]["fopNombre"].ToString().Trim().Length > 0)
                        {
                            this.fopNombre = Convert.ToString(Fila.Rows[0]["fopNombre"]);
                        }
                        else
                        {
                            this.fopNombre = "";
                        }

					    if(Fila.Rows[0]["fopFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.fopFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["fopFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.fopFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["fopFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.fopFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["fopFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.fopFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["fopActivo"].ToString().Trim().Length > 0)
                        {
                            this.fopActivo = (Convert.ToInt32(Fila.Rows[0]["fopActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.fopActivo = false;
                        }
                        
					    if(Fila.Rows[0]["usuIdCreacion"].ToString().Trim().Length > 0)
                        {
                            this.usuIdCreacion = Convert.ToInt32(Fila.Rows[0]["usuIdCreacion"]);
                        }
                        else
                        {
						    this.usuIdCreacion = 0;
                        }
                        
					    if(Fila.Rows[0]["usuidUltimaModificacion"].ToString().Trim().Length > 0)
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

            public FormasPago(Int32 fopId, String fopNombre, Boolean fopActivo, DateTime fopFechaHoraCreacion, DateTime fopFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
			{
                try
                {
				    this.fopId = fopId;
				    this.fopNombre = fopNombre;
				    this.fopActivo = fopActivo;
				    this.fopFechaHoraCreacion = fopFechaHoraCreacion;
				    this.fopFechaHoraUltimaModificacion = fopFechaHoraUltimaModificacion;
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
                	Tabla = ocdGestor.EjecutarReader("[FormasPago.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[FormasPago.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[FormasPago.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[FormasPago.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 fopId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[FormasPago.ObtenerUno]", new object[,] {{"@fopId", fopId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 fopId, String fopNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[FormasPago.ObtenerValidarRepetido]", new object[,] {{"@fopId", fopId}, {"@fopNombre", fopNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 fopId, String fopNombre, Boolean fopActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime fopFechaHoraCreacion, DateTime fopFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[FormasPago.Actualizar]", new object[,] {{"@fopId", fopId}, {"@fopNombre", fopNombre}, {"@fopActivo", fopActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@fopFechaHoraCreacion", fopFechaHoraCreacion}, {"@fopFechaHoraUltimaModificacion", fopFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String fopNombre, Boolean fopActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime fopFechaHoraCreacion, DateTime fopFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[FormasPago.Copiar]", new object[,] {{"@fopNombre", fopNombre}, {"@fopActivo", fopActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@fopFechaHoraCreacion", fopFechaHoraCreacion}, {"@fopFechaHoraUltimaModificacion", fopFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 fopId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[FormasPago.Eliminar]", new object[,] {{"@fopId", fopId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String fopNombre, Boolean fopActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime fopFechaHoraCreacion, DateTime fopFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[FormasPago.Insertar]", new object[,] {{"@fopNombre", fopNombre}, {"@fopActivo", fopActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@fopFechaHoraCreacion", fopFechaHoraCreacion}, {"@fopFechaHoraUltimaModificacion", fopFechaHoraUltimaModificacion}});
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
                    if(this.fopId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[FormasPago.Actualizar]", new object[,] {{"@fopId", fopId}, {"@fopNombre", fopNombre}, {"@fopActivo", fopActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@fopFechaHoraCreacion", fopFechaHoraCreacion}, {"@fopFechaHoraUltimaModificacion", fopFechaHoraUltimaModificacion}});
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
                    if(this.fopId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[FormasPago.Copiar]", new object[,] {{"@fopNombre", fopNombre}, {"@fopActivo", fopActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@fopFechaHoraCreacion", fopFechaHoraCreacion}, {"@fopFechaHoraUltimaModificacion", fopFechaHoraUltimaModificacion}});
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
                    if(this.fopId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[FormasPago.Eliminar]", new object[,] {{"@fopId", fopId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[FormasPago.Insertar]", new object[,] {{"@fopNombre", fopNombre}, {"@fopActivo", fopActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@fopFechaHoraCreacion", fopFechaHoraCreacion}, {"@fopFechaHoraUltimaModificacion", fopFechaHoraUltimaModificacion}});
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