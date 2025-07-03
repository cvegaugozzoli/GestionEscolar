using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  InscripcionExamenTipo
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _itpId; 
			public Int32 itpId { get { return _itpId; } set { _itpId = value; } }

            private String _itpNombre; 
			public String itpNombre { get { return _itpNombre; } set { _itpNombre = value; } }

            private Boolean _itpActivo; 
			public Boolean itpActivo { get { return _itpActivo; } set { _itpActivo = value; } }

            private DateTime _itpFechaHoraCreacion; 
			public DateTime itpFechaHoraCreacion { get { return _itpFechaHoraCreacion; } set { _itpFechaHoraCreacion = value; } }

            private DateTime _itpFechaHoraUltimaModificacion; 
			public DateTime itpFechaHoraUltimaModificacion { get { return _itpFechaHoraUltimaModificacion; } set { _itpFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public InscripcionExamenTipo() { try { this.itpId = 0; } catch (Exception oError) { throw oError; } }            

            public InscripcionExamenTipo(Int32 itpId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[InscripcionExamenTipo.ObtenerUno]", new object[,] {{"@itpId", itpId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["itpId"].ToString().Trim().Length > 0)
                        {
                            this.itpId = Convert.ToInt32(Fila.Rows[0]["itpId"]);
                        }
                        else
                        {
                            this.itpId = 0;
                        }

					    if(Fila.Rows[0]["itpNombre"].ToString().Trim().Length > 0)
                        {
                            this.itpNombre = Convert.ToString(Fila.Rows[0]["itpNombre"]);
                        }
                        else
                        {
                            this.itpNombre = "";
                        }

					    if(Fila.Rows[0]["itpFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.itpFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["itpFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.itpFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["itpFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.itpFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["itpFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.itpFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["itpActivo"].ToString().Trim().Length > 0)
                        {
                            this.itpActivo = (Convert.ToInt32(Fila.Rows[0]["itpActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.itpActivo = false;
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

            public InscripcionExamenTipo(Int32 itpId, String itpNombre, Boolean itpActivo, DateTime itpFechaHoraCreacion, DateTime itpFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.itpId = itpId;
				    this.itpNombre = itpNombre;
				    this.itpActivo = itpActivo;
				    this.itpFechaHoraCreacion = itpFechaHoraCreacion;
				    this.itpFechaHoraUltimaModificacion = itpFechaHoraUltimaModificacion;
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

                			
            public DataTable ObtenerLista(String PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[InscripcionExamenTipo.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[InscripcionExamenTipo.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[InscripcionExamenTipo.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 itpId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[InscripcionExamenTipo.ObtenerUno]", new object[,] {{"@itpId", itpId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 itpId, String itpNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[InscripcionExamenTipo.ObtenerValidarRepetido]", new object[,] {{"@itpId", itpId}, {"@itpNombre", itpNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 itpId, String itpNombre, Boolean itpActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime itpFechaHoraCreacion, DateTime itpFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionExamenTipo.Actualizar]", new object[,] {{"@itpId", itpId}, {"@itpNombre", itpNombre}, {"@itpActivo", itpActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@itpFechaHoraCreacion", itpFechaHoraCreacion}, {"@itpFechaHoraUltimaModificacion", itpFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String itpNombre, Boolean itpActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime itpFechaHoraCreacion, DateTime itpFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionExamenTipo.Copiar]", new object[,] {{"@itpNombre", itpNombre}, {"@itpActivo", itpActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@itpFechaHoraCreacion", itpFechaHoraCreacion}, {"@itpFechaHoraUltimaModificacion", itpFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 itpId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionExamenTipo.Eliminar]", new object[,] {{"@itpId", itpId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String itpNombre, Boolean itpActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime itpFechaHoraCreacion, DateTime itpFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionExamenTipo.Insertar]", new object[,] {{"@itpNombre", itpNombre}, {"@itpActivo", itpActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@itpFechaHoraCreacion", itpFechaHoraCreacion}, {"@itpFechaHoraUltimaModificacion", itpFechaHoraUltimaModificacion}});
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
                    if(this.itpId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[InscripcionExamenTipo.Actualizar]", new object[,] {{"@itpId", itpId}, {"@itpNombre", itpNombre}, {"@itpActivo", itpActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@itpFechaHoraCreacion", itpFechaHoraCreacion}, {"@itpFechaHoraUltimaModificacion", itpFechaHoraUltimaModificacion}});
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
                    if(this.itpId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[InscripcionExamenTipo.Copiar]", new object[,] {{"@itpNombre", itpNombre}, {"@itpActivo", itpActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@itpFechaHoraCreacion", itpFechaHoraCreacion}, {"@itpFechaHoraUltimaModificacion", itpFechaHoraUltimaModificacion}});
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
                    if(this.itpId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[InscripcionExamenTipo.Eliminar]", new object[,] {{"@itpId", itpId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[InscripcionExamenTipo.Insertar]", new object[,] {{"@itpNombre", itpNombre}, {"@itpActivo", itpActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@itpFechaHoraCreacion", itpFechaHoraCreacion}, {"@itpFechaHoraUltimaModificacion", itpFechaHoraUltimaModificacion}});
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