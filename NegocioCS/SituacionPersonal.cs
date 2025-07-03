using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class SituacionPersonal
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _sitId; 
			public Int32 sitId { get { return _sitId; } set { _sitId = value; } }

            private String _sitNombre; 
			public String sitNombre { get { return _sitNombre; } set { _sitNombre = value; } }

            private Boolean _sitActivo; 
			public Boolean sitActivo { get { return _sitActivo; } set { _sitActivo = value; } }

            private DateTime _sitFechaHoraCreacion; 
			public DateTime sitFechaHoraCreacion { get { return _sitFechaHoraCreacion; } set { _sitFechaHoraCreacion = value; } }

            private DateTime _sitFechaHoraUltimaModificacion; 
			public DateTime sitFechaHoraUltimaModificacion { get { return _sitFechaHoraUltimaModificacion; } set { _sitFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public SituacionPersonal() { try { this.sitId = 0; } catch (Exception oError) { throw oError; } }            

            public SituacionPersonal(Int32 camId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[SituacionPersonal.ObtenerUno]", new object[,] {{"@sitId", sitId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["sitId"].ToString().Trim().Length > 0)
                        {
                            this.sitId = Convert.ToInt32(Fila.Rows[0]["sitId"]);
                        }
                        else
                        {
                            this.sitId = 0;
                        }

					    if(Fila.Rows[0]["sitNombre"].ToString().Trim().Length > 0)
                        {
                            this.sitNombre = Convert.ToString(Fila.Rows[0]["sitNombre"]);
                        }
                        else
                        {
                            this.sitNombre = "";
                        }

					    if(Fila.Rows[0]["sitFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.sitFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["sitFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.sitFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["sitFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.sitFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["sitFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.sitFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["sitActivo"].ToString().Trim().Length > 0)
                        {
                            this.sitActivo = (Convert.ToInt32(Fila.Rows[0]["sitActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.sitActivo = false;
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

            public SituacionPersonal(Int32 sitId, String sitNombre, Boolean sitActivo, DateTime sitFechaHoraCreacion, DateTime sitFechaHoraUltimaModificacion, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion)
			{
                try
                {
				    this.sitId = sitId;
				    this.sitNombre = sitNombre;
				    this.sitActivo = sitActivo;
				    this.sitFechaHoraCreacion = sitFechaHoraCreacion;
				    this.sitFechaHoraUltimaModificacion = sitFechaHoraUltimaModificacion;
				
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
                	Tabla = ocdGestor.EjecutarReader("[SituacionPersonal.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[SituacionPersonal.ObtenerTodo]", new object[,] {});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
          	
            public DataTable ObtenerUno(Int32 sitId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[SituacionPersonal.ObtenerUno]", new object[,] {{ "@sitId", sitId } });
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
          
          
     
                			
            public void Eliminar(Int32 sitId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[SituacionPersonal.Eliminar]", new object[,] {{"@sitId", sitId}});
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
                    if(this.sitId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[SituacionPersonal.Actualizar]", new object[,] {{"@sitId", sitId}, { "@sitNombre", sitNombre}, {"@sitActivo", sitActivo }, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, { "@sitFechaHoraCreacion", sitFechaHoraCreacion}, { "@sitFechaHoraUltimaModificacion", sitFechaHoraUltimaModificacion}});
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
                    if(this.sitId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[SituacionPersonal.Eliminar]", new object[,] {{"@sitId", sitId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[SituacionPersonal.Insertar]", new object[,] { { "@sitId", sitId }, { "@sitNombre", sitNombre }, { "@sitActivo", sitActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@sitFechaHoraCreacion", sitFechaHoraCreacion }, { "@sitFechaHoraUltimaModificacion", sitFechaHoraUltimaModificacion } });
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