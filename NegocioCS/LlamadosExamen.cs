using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class LlamadosExamen
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _llaId; 
			public Int32 llaId { get { return _llaId; } set { _llaId = value; } }
                      
            private String _llaNombre; 
			public String llaNombre { get { return _llaNombre; } set { _llaNombre = value; } }

            private Int32 _extId; 
			public Int32 extId { get { return _extId; } set { _extId = value; } }

            private Boolean _llaActivo; 
			public Boolean llaActivo { get { return _llaActivo; } set { _llaActivo = value; } }

            private DateTime _llaFechaHoraCreacion; 
			public DateTime llaFechaHoraCreacion { get { return _llaFechaHoraCreacion; } set { _llaFechaHoraCreacion = value; } }

            private DateTime _llaFechaHoraUltimaModificacion; 
			public DateTime llaFechaHoraUltimaModificacion { get { return _llaFechaHoraUltimaModificacion; } set { _llaFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public LlamadosExamen() { try { this.llaId = 0; } catch (Exception oError) { throw oError; } }            

            public LlamadosExamen(Int32 llaId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[LlamadosExamen.ObtenerUno]", new object[,] {{"@llaId", llaId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["llaId"].ToString().Trim().Length > 0)
                        {
                            this.llaId = Convert.ToInt32(Fila.Rows[0]["llaId"]);
                        }
                        else
                        {
                            this.llaId = 0;
                        }				 

					    if(Fila.Rows[0]["llaNombre"].ToString().Trim().Length > 0)
                        {
                            this.llaNombre = Convert.ToString(Fila.Rows[0]["llaNombre"]);
                        }
                        else
                        {
                            this.llaNombre = "";
                        }

					    if(Fila.Rows[0]["extId"].ToString().Trim().Length > 0)
                        {
                            this.extId = Convert.ToInt32(Fila.Rows[0]["extId"]);
                        }
                        else
                        {
                            this.extId = 0;
                        }
					    if(Fila.Rows[0]["llaFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.llaFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["llaFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.llaFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["llaFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.llaFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["llaFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.llaFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["llaActivo"].ToString().Trim().Length > 0)
                        {
                            this.llaActivo = (Convert.ToInt32(Fila.Rows[0]["llaActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.llaActivo = false;
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

            public LlamadosExamen(Int32 llaId,String llaNombre,  Boolean llaActivo, Int32 extId,  DateTime llaFechaHoraCreacion, DateTime llaFechaHoraUltimaModificacion, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion)
			{
                try
                {
				    this.llaId = llaId;
				    this.llaNombre = llaNombre;
				    this.llaActivo = llaActivo;
				    this.extId = extId;
				    this.llaFechaHoraCreacion = llaFechaHoraCreacion;
				    this.llaFechaHoraUltimaModificacion = llaFechaHoraUltimaModificacion;
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
                	Tabla = ocdGestor.EjecutarReader("[LlamadosExamen.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[LlamadosExamen.ObtenerTodo]", new object[,] {});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }

            //public DataTable ObtenerTodoBuscarxNombre(String Nombre)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("LlamadosExamen.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            public DataTable ObtenerUno(Int32 llaId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[LlamadosExamen.ObtenerUno]", new object[,] {{ "@llaId", llaId } });
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerTodoBuscarxNombre(string Nombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[LlamadosExamen.ObtenerTodoBuscarxNombre]", new object[,] {{ "@Nombre", Nombre } });
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
           			
            public void Eliminar(Int32 llaId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[LlamadosExamen.Eliminar]", new object[,] {{"@llaId", llaId}});
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
                    ocdGestor.EjecutarNonQuery("[LlamadosExamen.EliminarxActivo]", new object[,] { { "@Id", Id }, { "@usuIdUltimaModificacion", Usuario }, { "@FechaHoraUltimaModificacion", FechaHoraUltimaModificacion } });
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
                    if(this.llaId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[LlamadosExamen.Actualizar]", new object[,] {{"@llaId", llaId},  {"@llaNombre", llaNombre},
                            {"@llaActivo", llaActivo},  {"@extId", extId},{"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@llaFechaHoraCreacion", llaFechaHoraCreacion}, {"@llaFechaHoraUltimaModificacion", llaFechaHoraUltimaModificacion}});
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
                    if(this.llaId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[LlamadosExamen.Eliminar]", new object[,] {{"@llaId", llaId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[LlamadosExamen.Insertar]", new object[,]  { {"@llaNombre", llaNombre},
                            {"@llaActivo", llaActivo},  {"@extId", extId},{"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@llaFechaHoraCreacion", llaFechaHoraCreacion}, {"@llaFechaHoraUltimaModificacion", llaFechaHoraUltimaModificacion}});
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