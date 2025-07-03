using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  Turnos
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _turId; 
			public Int32 turId { get { return _turId; } set { _turId = value; } }

            private String _turNombre; 
			public String turNombre { get { return _turNombre; } set { _turNombre = value; } }

            private Boolean _turActivo; 
			public Boolean turActivo { get { return _turActivo; } set { _turActivo = value; } }

            private DateTime _turFechaHoraCreacion; 
			public DateTime turFechaHoraCreacion { get { return _turFechaHoraCreacion; } set { _turFechaHoraCreacion = value; } }

            private DateTime _turFechaHoraUltimaModificacion; 
			public DateTime turFechaHoraUltimaModificacion { get { return _turFechaHoraUltimaModificacion; } set { _turFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public Turnos() { try { this.turId = 0; } catch (Exception oError) { throw oError; } }            

            public Turnos(Int32 turId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Turnos.ObtenerUno]", new object[,] {{"@turId", turId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["turId"].ToString().Trim().Length > 0)
                        {
                            this.turId = Convert.ToInt32(Fila.Rows[0]["turId"]);
                        }
                        else
                        {
                            this.turId = 0;
                        }

					    if(Fila.Rows[0]["turNombre"].ToString().Trim().Length > 0)
                        {
                            this.turNombre = Convert.ToString(Fila.Rows[0]["turNombre"]);
                        }
                        else
                        {
                            this.turNombre = "";
                        }

					    if(Fila.Rows[0]["turFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.turFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["turFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.turFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["turFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.turFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["turFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.turFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["turActivo"].ToString().Trim().Length > 0)
                        {
                            this.turActivo = (Convert.ToInt32(Fila.Rows[0]["turActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.turActivo = false;
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

            public Turnos(Int32 turId, String turNombre, Boolean turActivo, DateTime turFechaHoraCreacion, DateTime turFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.turId = turId;
				    this.turNombre = turNombre;
				    this.turActivo = turActivo;
				    this.turFechaHoraCreacion = turFechaHoraCreacion;
				    this.turFechaHoraUltimaModificacion = turFechaHoraUltimaModificacion;
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
                	Tabla = ocdGestor.EjecutarReader("[Turnos.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[Turnos.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[Turnos.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[Turnos.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 turId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Turnos.ObtenerUno]", new object[,] {{"@turId", turId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 turId, String turNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Turnos.ObtenerValidarRepetido]", new object[,] {{"@turId", turId}, {"@turNombre", turNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 turId, String turNombre, Boolean turActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime turFechaHoraCreacion, DateTime turFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Turnos.Actualizar]", new object[,] {{"@turId", turId}, {"@turNombre", turNombre}, {"@turActivo", turActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@turFechaHoraCreacion", turFechaHoraCreacion}, {"@turFechaHoraUltimaModificacion", turFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String turNombre, Boolean turActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime turFechaHoraCreacion, DateTime turFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Turnos.Copiar]", new object[,] {{"@turNombre", turNombre}, {"@turActivo", turActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@turFechaHoraCreacion", turFechaHoraCreacion}, {"@turFechaHoraUltimaModificacion", turFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 turId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Turnos.Eliminar]", new object[,] {{"@turId", turId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String turNombre, Boolean turActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime turFechaHoraCreacion, DateTime turFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Turnos.Insertar]", new object[,] {{"@turNombre", turNombre}, {"@turActivo", turActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@turFechaHoraCreacion", turFechaHoraCreacion}, {"@turFechaHoraUltimaModificacion", turFechaHoraUltimaModificacion}});
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
                    if(this.turId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Turnos.Actualizar]", new object[,] {{"@turId", turId}, {"@turNombre", turNombre}, {"@turActivo", turActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@turFechaHoraCreacion", turFechaHoraCreacion}, {"@turFechaHoraUltimaModificacion", turFechaHoraUltimaModificacion}});
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
                    if(this.turId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Turnos.Copiar]", new object[,] {{"@turNombre", turNombre}, {"@turActivo", turActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@turFechaHoraCreacion", turFechaHoraCreacion}, {"@turFechaHoraUltimaModificacion", turFechaHoraUltimaModificacion}});
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
                    if(this.turId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Turnos.Eliminar]", new object[,] {{"@turId", turId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Turnos.Insertar]", new object[,] {{"@turNombre", turNombre}, {"@turActivo", turActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@turFechaHoraCreacion", turFechaHoraCreacion}, {"@turFechaHoraUltimaModificacion", turFechaHoraUltimaModificacion}});
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