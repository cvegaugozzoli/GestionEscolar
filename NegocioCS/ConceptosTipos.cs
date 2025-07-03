using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  ConceptosTipos
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _cntId; 
			public Int32 cntId { get { return _cntId; } set { _cntId = value; } }

            private String _cntNombre; 
			public String cntNombre { get { return _cntNombre; } set { _cntNombre = value; } }

            private Boolean _cntActivo; 
			public Boolean cntActivo { get { return _cntActivo; } set { _cntActivo = value; } }

            private DateTime _cntFechaHoraCreacion; 
			public DateTime cntFechaHoraCreacion { get { return _cntFechaHoraCreacion; } set { _cntFechaHoraCreacion = value; } }

            private DateTime _cntFechaHoraUltimaModificacion; 
			public DateTime cntFechaHoraUltimaModificacion { get { return _cntFechaHoraUltimaModificacion; } set { _cntFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuidUltimaModificacion; 
			public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public ConceptosTipos() { try { this.cntId = 0; } catch (Exception oError) { throw oError; } }            

            public ConceptosTipos(Int32 cntId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[ConceptosTipos.ObtenerUno]", new object[,] {{"@cntId", cntId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["cntId"].ToString().Trim().Length > 0)
                        {
                            this.cntId = Convert.ToInt32(Fila.Rows[0]["cntId"]);
                        }
                        else
                        {
                            this.cntId = 0;
                        }

					    if(Fila.Rows[0]["cntNombre"].ToString().Trim().Length > 0)
                        {
                            this.cntNombre = Convert.ToString(Fila.Rows[0]["cntNombre"]);
                        }
                        else
                        {
                            this.cntNombre = "";
                        }

					    if(Fila.Rows[0]["cntFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.cntFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["cntFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.cntFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["cntFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.cntFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["cntFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.cntFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["cntActivo"].ToString().Trim().Length > 0)
                        {
                            this.cntActivo = (Convert.ToInt32(Fila.Rows[0]["cntActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.cntActivo = false;
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

            public ConceptosTipos(Int32 cntId, String cntNombre, Boolean cntActivo, DateTime cntFechaHoraCreacion, DateTime cntFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
			{
                try
                {
				    this.cntId = cntId;
				    this.cntNombre = cntNombre;
				    this.cntActivo = cntActivo;
				    this.cntFechaHoraCreacion = cntFechaHoraCreacion;
				    this.cntFechaHoraUltimaModificacion = cntFechaHoraUltimaModificacion;
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
                	Tabla = ocdGestor.EjecutarReader("[ConceptosTipos.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[ConceptosTipos.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerListaInscripcion(String PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ConceptosTipos.ObtenerListaInscripcion]", new object[,] { { "@PrimerItem", PrimerItem } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }



            public DataTable ObtenerListaAlgunos(String PrimerItem, int cntid )
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ConceptosTipos.ObtenerListaAlgunos]", new object[,] { {"@PrimerItem", PrimerItem }, {"@cntid", cntid } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerListaSinUno(String PrimerItem, int cntid)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ConceptosTipos.ObtenerListaSinUno]", new object[,] { { "@PrimerItem", PrimerItem }, { "@cntid", cntid } });
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
                	Tabla = ocdGestor.EjecutarReader("[ConceptosTipos.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[ConceptosTipos.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 cntId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[ConceptosTipos.ObtenerUno]", new object[,] {{"@cntId", cntId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 cntId, String cntNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[ConceptosTipos.ObtenerValidarRepetido]", new object[,] {{"@cntId", cntId}, {"@cntNombre", cntNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 cntId, String cntNombre, Boolean cntActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cntFechaHoraCreacion, DateTime cntFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ConceptosTipos.Actualizar]", new object[,] {{"@cntId", cntId}, {"@cntNombre", cntNombre}, {"@cntActivo", cntActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@cntFechaHoraCreacion", cntFechaHoraCreacion}, {"@cntFechaHoraUltimaModificacion", cntFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String cntNombre, Boolean cntActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cntFechaHoraCreacion, DateTime cntFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ConceptosTipos.Copiar]", new object[,] {{"@cntNombre", cntNombre}, {"@cntActivo", cntActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@cntFechaHoraCreacion", cntFechaHoraCreacion}, {"@cntFechaHoraUltimaModificacion", cntFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 cntId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ConceptosTipos.Eliminar]", new object[,] {{"@cntId", cntId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String cntNombre, Boolean cntActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cntFechaHoraCreacion, DateTime cntFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ConceptosTipos.Insertar]", new object[,] {{"@cntNombre", cntNombre}, {"@cntActivo", cntActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@cntFechaHoraCreacion", cntFechaHoraCreacion}, {"@cntFechaHoraUltimaModificacion", cntFechaHoraUltimaModificacion}});
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
                    if(this.cntId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ConceptosTipos.Actualizar]", new object[,] {{"@cntId", cntId}, {"@cntNombre", cntNombre}, {"@cntActivo", cntActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@cntFechaHoraCreacion", cntFechaHoraCreacion}, {"@cntFechaHoraUltimaModificacion", cntFechaHoraUltimaModificacion}});
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
                    if(this.cntId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ConceptosTipos.Copiar]", new object[,] {{"@cntNombre", cntNombre}, {"@cntActivo", cntActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@cntFechaHoraCreacion", cntFechaHoraCreacion}, {"@cntFechaHoraUltimaModificacion", cntFechaHoraUltimaModificacion}});
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
                    if(this.cntId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ConceptosTipos.Eliminar]", new object[,] {{"@cntId", cntId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ConceptosTipos.Insertar]", new object[,] {{"@cntNombre", cntNombre}, {"@cntActivo", cntActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@cntFechaHoraCreacion", cntFechaHoraCreacion}, {"@cntFechaHoraUltimaModificacion", cntFechaHoraUltimaModificacion}});
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