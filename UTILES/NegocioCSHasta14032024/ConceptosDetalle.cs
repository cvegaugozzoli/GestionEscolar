using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  ConceptosDetalle
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _codId; 
			public Int32 codId { get { return _codId; } set { _codId = value; } }

            private String _codNombre; 
			public String codNombre { get { return _codNombre; } set { _codNombre = value; } }

            private Decimal _conImporte; 
			public Decimal conImporte { get { return _conImporte; } set { _conImporte = value; } }

            private Boolean _codActivo; 
			public Boolean codActivo { get { return _codActivo; } set { _codActivo = value; } }

            private DateTime _codFechaHoraCreacion; 
			public DateTime codFechaHoraCreacion { get { return _codFechaHoraCreacion; } set { _codFechaHoraCreacion = value; } }

            private DateTime _codFechaHoraUltimaModificacion; 
			public DateTime codFechaHoraUltimaModificacion { get { return _codFechaHoraUltimaModificacion; } set { _codFechaHoraUltimaModificacion = value; } }

			private Int32 _conId; 
			public Int32 conId { get { return _conId; } set { _conId = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuidUltimaModificacion; 
			public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public ConceptosDetalle() { try { this.codId = 0; } catch (Exception oError) { throw oError; } }            

            public ConceptosDetalle(Int32 codId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[ConceptosDetalle.ObtenerUno]", new object[,] {{"@codId", codId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["codId"].ToString().Trim().Length > 0)
                        {
                            this.codId = Convert.ToInt32(Fila.Rows[0]["codId"]);
                        }
                        else
                        {
                            this.codId = 0;
                        }

					    if(Fila.Rows[0]["codNombre"].ToString().Trim().Length > 0)
                        {
                            this.codNombre = Convert.ToString(Fila.Rows[0]["codNombre"]);
                        }
                        else
                        {
                            this.codNombre = "";
                        }

					    if(Fila.Rows[0]["conImporte"].ToString().Trim().Length > 0)
                        {
                            this.conImporte = Convert.ToDecimal(Fila.Rows[0]["conImporte"]);
                        }
                        else
                        {
                            this.conImporte = 0;
                        }

					    if(Fila.Rows[0]["codFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.codFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["codFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.codFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["codFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.codFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["codFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.codFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["codActivo"].ToString().Trim().Length > 0)
                        {
                            this.codActivo = (Convert.ToInt32(Fila.Rows[0]["codActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.codActivo = false;
                        }
                        
					    if(Fila.Rows[0]["conId"].ToString().Trim().Length > 0)
                        {
                            this.conId = Convert.ToInt32(Fila.Rows[0]["conId"]);
                        }
                        else
                        {
						    this.conId = 0;
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

            public ConceptosDetalle(Int32 codId, String codNombre, Decimal conImporte, Boolean codActivo, DateTime codFechaHoraCreacion, DateTime codFechaHoraUltimaModificacion, Int32 IconId, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
			{
                try
                {
				    this.codId = codId;
				    this.codNombre = codNombre;
				    this.conImporte = conImporte;
				    this.codActivo = codActivo;
				    this.codFechaHoraCreacion = codFechaHoraCreacion;
				    this.codFechaHoraUltimaModificacion = codFechaHoraUltimaModificacion;
				    this.conId = conId;
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
                	Tabla = ocdGestor.EjecutarReader("[ConceptosDetalle.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[ConceptosDetalle.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[ConceptosDetalle.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[ConceptosDetalle.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 codId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[ConceptosDetalle.ObtenerUno]", new object[,] {{"@codId", codId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 codId, String codNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[ConceptosDetalle.ObtenerValidarRepetido]", new object[,] {{"@codId", codId}, {"@codNombre", codNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 codId, String codNombre, Int32 conId, Decimal conImporte, Boolean codActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime codFechaHoraCreacion, DateTime codFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ConceptosDetalle.Actualizar]", new object[,] {{"@codId", codId}, {"@codNombre", codNombre}, {"@conId", conId}, {"@conImporte", conImporte}, {"@codActivo", codActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@codFechaHoraCreacion", codFechaHoraCreacion}, {"@codFechaHoraUltimaModificacion", codFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String codNombre, Int32 conId, Decimal conImporte, Boolean codActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime codFechaHoraCreacion, DateTime codFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ConceptosDetalle.Copiar]", new object[,] {{"@codNombre", codNombre}, {"@conId", conId}, {"@conImporte", conImporte}, {"@codActivo", codActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@codFechaHoraCreacion", codFechaHoraCreacion}, {"@codFechaHoraUltimaModificacion", codFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 codId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ConceptosDetalle.Eliminar]", new object[,] {{"@codId", codId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String codNombre, Int32 conId, Decimal conImporte, Boolean codActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime codFechaHoraCreacion, DateTime codFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ConceptosDetalle.Insertar]", new object[,] {{"@codNombre", codNombre}, {"@conId", conId}, {"@conImporte", conImporte}, {"@codActivo", codActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@codFechaHoraCreacion", codFechaHoraCreacion}, {"@codFechaHoraUltimaModificacion", codFechaHoraUltimaModificacion}});
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
                    if(this.codId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ConceptosDetalle.Actualizar]", new object[,] {{"@codId", codId}, {"@codNombre", codNombre}, {"@conId", conId}, {"@conImporte", conImporte}, {"@codActivo", codActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@codFechaHoraCreacion", codFechaHoraCreacion}, {"@codFechaHoraUltimaModificacion", codFechaHoraUltimaModificacion}});
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
                    if(this.codId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ConceptosDetalle.Copiar]", new object[,] {{"@codNombre", codNombre}, {"@conId", conId}, {"@conImporte", conImporte}, {"@codActivo", codActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@codFechaHoraCreacion", codFechaHoraCreacion}, {"@codFechaHoraUltimaModificacion", codFechaHoraUltimaModificacion}});
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
                    if(this.codId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ConceptosDetalle.Eliminar]", new object[,] {{"@codId", codId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ConceptosDetalle.Insertar]", new object[,] {{"@codNombre", codNombre}, {"@conId", conId}, {"@conImporte", conImporte}, {"@codActivo", codActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@codFechaHoraCreacion", codFechaHoraCreacion}, {"@codFechaHoraUltimaModificacion", codFechaHoraUltimaModificacion}});
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