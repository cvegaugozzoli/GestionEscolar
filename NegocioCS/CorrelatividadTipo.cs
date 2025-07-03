using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  CorrelatividadTipo
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _cotId; 
			public Int32 cotId { get { return _cotId; } set { _cotId = value; } }

            private String _cotNombre; 
			public String cotNombre { get { return _cotNombre; } set { _cotNombre = value; } }

            private Boolean _cotActivo; 
			public Boolean cotActivo { get { return _cotActivo; } set { _cotActivo = value; } }

            private DateTime _cotFechaHoraCreacion; 
			public DateTime cotFechaHoraCreacion { get { return _cotFechaHoraCreacion; } set { _cotFechaHoraCreacion = value; } }

            private DateTime _cotFechaHoraUltimaModificacion; 
			public DateTime cotFechaHoraUltimaModificacion { get { return _cotFechaHoraUltimaModificacion; } set { _cotFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public CorrelatividadTipo() { try { this.cotId = 0; } catch (Exception oError) { throw oError; } }            

            public CorrelatividadTipo(Int32 cotId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[CorrelatividadTipo.ObtenerUno]", new object[,] {{"@cotId", cotId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["cotId"].ToString().Trim().Length > 0)
                        {
                            this.cotId = Convert.ToInt32(Fila.Rows[0]["cotId"]);
                        }
                        else
                        {
                            this.cotId = 0;
                        }

					    if(Fila.Rows[0]["cotNombre"].ToString().Trim().Length > 0)
                        {
                            this.cotNombre = Convert.ToString(Fila.Rows[0]["cotNombre"]);
                        }
                        else
                        {
                            this.cotNombre = "";
                        }

					    if(Fila.Rows[0]["cotFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.cotFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["cotFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.cotFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["cotFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.cotFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["cotFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.cotFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["cotActivo"].ToString().Trim().Length > 0)
                        {
                            this.cotActivo = (Convert.ToInt32(Fila.Rows[0]["cotActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.cotActivo = false;
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

            public CorrelatividadTipo(Int32 cotId, String cotNombre, Boolean cotActivo, DateTime cotFechaHoraCreacion, DateTime cotFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.cotId = cotId;
				    this.cotNombre = cotNombre;
				    this.cotActivo = cotActivo;
				    this.cotFechaHoraCreacion = cotFechaHoraCreacion;
				    this.cotFechaHoraUltimaModificacion = cotFechaHoraUltimaModificacion;
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
                	Tabla = ocdGestor.EjecutarReader("[CorrelatividadTipo.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[CorrelatividadTipo.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[CorrelatividadTipo.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[CorrelatividadTipo.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 cotId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[CorrelatividadTipo.ObtenerUno]", new object[,] {{"@cotId", cotId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 cotId, String cotNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[CorrelatividadTipo.ObtenerValidarRepetido]", new object[,] {{"@cotId", cotId}, {"@cotNombre", cotNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 cotId, String cotNombre, Boolean cotActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime cotFechaHoraCreacion, DateTime cotFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[CorrelatividadTipo.Actualizar]", new object[,] {{"@cotId", cotId}, {"@cotNombre", cotNombre}, {"@cotActivo", cotActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@cotFechaHoraCreacion", cotFechaHoraCreacion}, {"@cotFechaHoraUltimaModificacion", cotFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String cotNombre, Boolean cotActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime cotFechaHoraCreacion, DateTime cotFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[CorrelatividadTipo.Copiar]", new object[,] {{"@cotNombre", cotNombre}, {"@cotActivo", cotActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@cotFechaHoraCreacion", cotFechaHoraCreacion}, {"@cotFechaHoraUltimaModificacion", cotFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 cotId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[CorrelatividadTipo.Eliminar]", new object[,] {{"@cotId", cotId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String cotNombre, Boolean cotActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime cotFechaHoraCreacion, DateTime cotFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[CorrelatividadTipo.Insertar]", new object[,] {{"@cotNombre", cotNombre}, {"@cotActivo", cotActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@cotFechaHoraCreacion", cotFechaHoraCreacion}, {"@cotFechaHoraUltimaModificacion", cotFechaHoraUltimaModificacion}});
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
                    if(this.cotId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[CorrelatividadTipo.Actualizar]", new object[,] {{"@cotId", cotId}, {"@cotNombre", cotNombre}, {"@cotActivo", cotActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@cotFechaHoraCreacion", cotFechaHoraCreacion}, {"@cotFechaHoraUltimaModificacion", cotFechaHoraUltimaModificacion}});
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
                    if(this.cotId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[CorrelatividadTipo.Copiar]", new object[,] {{"@cotNombre", cotNombre}, {"@cotActivo", cotActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@cotFechaHoraCreacion", cotFechaHoraCreacion}, {"@cotFechaHoraUltimaModificacion", cotFechaHoraUltimaModificacion}});
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
                    if(this.cotId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[CorrelatividadTipo.Eliminar]", new object[,] {{"@cotId", cotId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[CorrelatividadTipo.Insertar]", new object[,] {{"@cotNombre", cotNombre}, {"@cotActivo", cotActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@cotFechaHoraCreacion", cotFechaHoraCreacion}, {"@cotFechaHoraUltimaModificacion", cotFechaHoraUltimaModificacion}});
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