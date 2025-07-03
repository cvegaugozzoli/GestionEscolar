using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  Tarjetas
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _tarId; 
			public Int32 tarId { get { return _tarId; } set { _tarId = value; } }

            private String _tarNombre; 
			public String tarNombre { get { return _tarNombre; } set { _tarNombre = value; } }

            private Boolean _tarActivo; 
			public Boolean tarActivo { get { return _tarActivo; } set { _tarActivo = value; } }

            private DateTime _tarFechaHoraCreacion; 
			public DateTime tarFechaHoraCreacion { get { return _tarFechaHoraCreacion; } set { _tarFechaHoraCreacion = value; } }

            private DateTime _tarFechaHoraUltimaModificacion; 
			public DateTime tarFechaHoraUltimaModificacion { get { return _tarFechaHoraUltimaModificacion; } set { _tarFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuidUltimaModificacion; 
			public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public Tarjetas() { try { this.tarId = 0; } catch (Exception oError) { throw oError; } }            

            public Tarjetas(Int32 tarId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Tarjetas.ObtenerUno]", new object[,] {{"@tarId", tarId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["tarId"].ToString().Trim().Length > 0)
                        {
                            this.tarId = Convert.ToInt32(Fila.Rows[0]["tarId"]);
                        }
                        else
                        {
                            this.tarId = 0;
                        }

					    if(Fila.Rows[0]["tarNombre"].ToString().Trim().Length > 0)
                        {
                            this.tarNombre = Convert.ToString(Fila.Rows[0]["tarNombre"]);
                        }
                        else
                        {
                            this.tarNombre = "";
                        }

					    if(Fila.Rows[0]["tarFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.tarFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["tarFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.tarFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["tarFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.tarFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["tarFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.tarFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["tarActivo"].ToString().Trim().Length > 0)
                        {
                            this.tarActivo = (Convert.ToInt32(Fila.Rows[0]["tarActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.tarActivo = false;
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

            public Tarjetas(Int32 tarId, String tarNombre, Boolean tarActivo, DateTime tarFechaHoraCreacion, DateTime tarFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
			{
                try
                {
				    this.tarId = tarId;
				    this.tarNombre = tarNombre;
				    this.tarActivo = tarActivo;
				    this.tarFechaHoraCreacion = tarFechaHoraCreacion;
				    this.tarFechaHoraUltimaModificacion = tarFechaHoraUltimaModificacion;
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
                	Tabla = ocdGestor.EjecutarReader("[Tarjetas.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[Tarjetas.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[Tarjetas.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[Tarjetas.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 tarId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Tarjetas.ObtenerUno]", new object[,] {{"@tarId", tarId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 tarId, String tarNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Tarjetas.ObtenerValidarRepetido]", new object[,] {{"@tarId", tarId}, {"@tarNombre", tarNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 tarId, String tarNombre, Boolean tarActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime tarFechaHoraCreacion, DateTime tarFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Tarjetas.Actualizar]", new object[,] {{"@tarId", tarId}, {"@tarNombre", tarNombre}, {"@tarActivo", tarActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@tarFechaHoraCreacion", tarFechaHoraCreacion}, {"@tarFechaHoraUltimaModificacion", tarFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String tarNombre, Boolean tarActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime tarFechaHoraCreacion, DateTime tarFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Tarjetas.Copiar]", new object[,] {{"@tarNombre", tarNombre}, {"@tarActivo", tarActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@tarFechaHoraCreacion", tarFechaHoraCreacion}, {"@tarFechaHoraUltimaModificacion", tarFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 tarId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Tarjetas.Eliminar]", new object[,] {{"@tarId", tarId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String tarNombre, Boolean tarActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime tarFechaHoraCreacion, DateTime tarFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Tarjetas.Insertar]", new object[,] {{"@tarNombre", tarNombre}, {"@tarActivo", tarActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@tarFechaHoraCreacion", tarFechaHoraCreacion}, {"@tarFechaHoraUltimaModificacion", tarFechaHoraUltimaModificacion}});
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
                    if(this.tarId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Tarjetas.Actualizar]", new object[,] {{"@tarId", tarId}, {"@tarNombre", tarNombre}, {"@tarActivo", tarActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@tarFechaHoraCreacion", tarFechaHoraCreacion}, {"@tarFechaHoraUltimaModificacion", tarFechaHoraUltimaModificacion}});
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
                    if(this.tarId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Tarjetas.Copiar]", new object[,] {{"@tarNombre", tarNombre}, {"@tarActivo", tarActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@tarFechaHoraCreacion", tarFechaHoraCreacion}, {"@tarFechaHoraUltimaModificacion", tarFechaHoraUltimaModificacion}});
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
                    if(this.tarId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Tarjetas.Eliminar]", new object[,] {{"@tarId", tarId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Tarjetas.Insertar]", new object[,] {{"@tarNombre", tarNombre}, {"@tarActivo", tarActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@tarFechaHoraCreacion", tarFechaHoraCreacion}, {"@tarFechaHoraUltimaModificacion", tarFechaHoraUltimaModificacion}});
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