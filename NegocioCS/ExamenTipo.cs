using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  ExamenTipo
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _extId; 
			public Int32 extId { get { return _extId; } set { _extId = value; } }

            private String _extNombre; 
			public String extNombre { get { return _extNombre; } set { _extNombre = value; } }

            private Boolean _extActivo; 
			public Boolean extActivo { get { return _extActivo; } set { _extActivo = value; } }

            private DateTime _extFechaHoraCreacion; 
			public DateTime extFechaHoraCreacion { get { return _extFechaHoraCreacion; } set { _extFechaHoraCreacion = value; } }

            private DateTime _extFechaHoraUltimaModificacion; 
			public DateTime extFechaHoraUltimaModificacion { get { return _extFechaHoraUltimaModificacion; } set { _extFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public ExamenTipo() { try { this.extId = 0; } catch (Exception oError) { throw oError; } }            

            public ExamenTipo(Int32 extId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[ExamenTipo.ObtenerUno]", new object[,] {{"@extId", extId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["extId"].ToString().Trim().Length > 0)
                        {
                            this.extId = Convert.ToInt32(Fila.Rows[0]["extId"]);
                        }
                        else
                        {
                            this.extId = 0;
                        }

					    if(Fila.Rows[0]["extNombre"].ToString().Trim().Length > 0)
                        {
                            this.extNombre = Convert.ToString(Fila.Rows[0]["extNombre"]);
                        }
                        else
                        {
                            this.extNombre = "";
                        }

					    if(Fila.Rows[0]["extFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.extFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["extFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.extFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["extFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.extFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["extFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.extFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["extActivo"].ToString().Trim().Length > 0)
                        {
                            this.extActivo = (Convert.ToInt32(Fila.Rows[0]["extActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.extActivo = false;
                        }
                        
					    if(Fila.Rows[0]["usuIdCreacion"].ToString().Trim().Length > 0)
                        {
                            this.usuIdCreacion = Convert.ToInt32(Fila.Rows[0]["usuIdCreacion"]);
                        }
                        else
                        {
						    this.usuIdCreacion = 0;
                        }
                        
					    if(Fila.Rows[0]["usuIdUltimaModificacion"].ToString().Trim().Length > 0)
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

            public ExamenTipo(Int32 extId, String extNombre, Boolean extActivo, DateTime extFechaHoraCreacion, DateTime extFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.extId = extId;
				    this.extNombre = extNombre;
				    this.extActivo = extActivo;
				    this.extFechaHoraCreacion = extFechaHoraCreacion;
				    this.extFechaHoraUltimaModificacion = extFechaHoraUltimaModificacion;
				    this.usuIdCreacion = usuIdCreacion;
				    this.usuIdUltimaModificacion = usuIdUltimaModificacion;
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
                	Tabla = ocdGestor.EjecutarReader("[ExamenTipo.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[ExamenTipo.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[ExamenTipo.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[ExamenTipo.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 extId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[ExamenTipo.ObtenerUno]", new object[,] {{"@extId", extId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 extId, String extNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[ExamenTipo.ObtenerValidarRepetido]", new object[,] {{"@extId", extId}, {"@extNombre", extNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 extId, String extNombre, Boolean extActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime extFechaHoraCreacion, DateTime extFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ExamenTipo.Actualizar]", new object[,] {{"@extId", extId}, {"@extNombre", extNombre}, {"@extActivo", extActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@extFechaHoraCreacion", extFechaHoraCreacion}, {"@extFechaHoraUltimaModificacion", extFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String extNombre, Boolean extActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime extFechaHoraCreacion, DateTime extFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ExamenTipo.Copiar]", new object[,] {{"@extNombre", extNombre}, {"@extActivo", extActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@extFechaHoraCreacion", extFechaHoraCreacion}, {"@extFechaHoraUltimaModificacion", extFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 extId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ExamenTipo.Eliminar]", new object[,] {{"@extId", extId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String extNombre, Boolean extActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime extFechaHoraCreacion, DateTime extFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ExamenTipo.Insertar]", new object[,] {{"@extNombre", extNombre}, {"@extActivo", extActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@extFechaHoraCreacion", extFechaHoraCreacion}, {"@extFechaHoraUltimaModificacion", extFechaHoraUltimaModificacion}});
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
                    if(this.extId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ExamenTipo.Actualizar]", new object[,] {{"@extId", extId}, {"@extNombre", extNombre}, {"@extActivo", extActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@extFechaHoraCreacion", extFechaHoraCreacion}, {"@extFechaHoraUltimaModificacion", extFechaHoraUltimaModificacion}});
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
                    if(this.extId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ExamenTipo.Copiar]", new object[,] {{"@extNombre", extNombre}, {"@extActivo", extActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@extFechaHoraCreacion", extFechaHoraCreacion}, {"@extFechaHoraUltimaModificacion", extFechaHoraUltimaModificacion}});
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
                    if(this.extId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ExamenTipo.Eliminar]", new object[,] {{"@extId", extId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ExamenTipo.Insertar]", new object[,] {{"@extNombre", extNombre}, {"@extActivo", extActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@extFechaHoraCreacion", extFechaHoraCreacion}, {"@extFechaHoraUltimaModificacion", extFechaHoraUltimaModificacion}});
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