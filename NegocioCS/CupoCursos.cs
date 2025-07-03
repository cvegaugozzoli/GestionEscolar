using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  CupoCursos
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _cupId; 
			public Int32 cupId { get { return _cupId; } set { _cupId = value; } }

            private Int32 _cupAnioInsc; 
			public Int32 cupAnioInsc { get { return _cupAnioInsc; } set { _cupAnioInsc = value; } }

            private Int32 _cupCantidad; 
			public Int32 cupCantidad { get { return _cupCantidad; } set { _cupCantidad = value; } }

            private Boolean _cupActivo; 
			public Boolean cupActivo { get { return _cupActivo; } set { _cupActivo = value; } }

            private DateTime _cupFechaHoraCreacion; 
			public DateTime cupFechaHoraCreacion { get { return _cupFechaHoraCreacion; } set { _cupFechaHoraCreacion = value; } }

            private DateTime _cupFechaHoraUltimaModificacion; 
			public DateTime cupFechaHoraUltimaModificacion { get { return _cupFechaHoraUltimaModificacion; } set { _cupFechaHoraUltimaModificacion = value; } }

			private Int32 _insId; 
			public Int32 insId { get { return _insId; } set { _insId = value; } }

			private Int32 _plaId; 
			public Int32 plaId { get { return _plaId; } set { _plaId = value; } }

			private Int32 _curid; 
			public Int32 curid { get { return _curid; } set { _curid = value; } }

			private Int32 _turId; 
			public Int32 turId { get { return _turId; } set { _turId = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public CupoCursos() { try { this.cupId = 0; } catch (Exception oError) { throw oError; } }            

            public CupoCursos(Int32 cupId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[CupoCursos.ObtenerUno]", new object[,] {{"@cupId", cupId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["cupId"].ToString().Trim().Length > 0)
                        {
                            this.cupId = Convert.ToInt32(Fila.Rows[0]["cupId"]);
                        }
                        else
                        {
                            this.cupId = 0;
                        }

					    if(Fila.Rows[0]["cupAnioInsc"].ToString().Trim().Length > 0)
                        {
                            this.cupAnioInsc = Convert.ToInt32(Fila.Rows[0]["cupAnioInsc"]);
                        }
                        else
                        {
                            this.cupAnioInsc = 0;
                        }

					    if(Fila.Rows[0]["cupCantidad"].ToString().Trim().Length > 0)
                        {
                            this.cupCantidad = Convert.ToInt32(Fila.Rows[0]["cupCantidad"]);
                        }
                        else
                        {
                            this.cupCantidad = 0;
                        }

					    if(Fila.Rows[0]["cupFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.cupFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["cupFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.cupFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["cupFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.cupFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["cupFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.cupFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["cupActivo"].ToString().Trim().Length > 0)
                        {
                            this.cupActivo = (Convert.ToInt32(Fila.Rows[0]["cupActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.cupActivo = false;
                        }
                        
					    if(Fila.Rows[0]["insId"].ToString().Trim().Length > 0)
                        {
                            this.insId = Convert.ToInt32(Fila.Rows[0]["insId"]);
                        }
                        else
                        {
						    this.insId = 0;
                        }
                        
					    if(Fila.Rows[0]["plaId"].ToString().Trim().Length > 0)
                        {
                            this.plaId = Convert.ToInt32(Fila.Rows[0]["plaId"]);
                        }
                        else
                        {
						    this.plaId = 0;
                        }
                        
					    if(Fila.Rows[0]["curid"].ToString().Trim().Length > 0)
                        {
                            this.curid = Convert.ToInt32(Fila.Rows[0]["curid"]);
                        }
                        else
                        {
						    this.curid = 0;
                        }
                        
					    if(Fila.Rows[0]["turId"].ToString().Trim().Length > 0)
                        {
                            this.turId = Convert.ToInt32(Fila.Rows[0]["turId"]);
                        }
                        else
                        {
						    this.turId = 0;
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

            public CupoCursos(Int32 cupId, Int32 cupAnioInsc, Int32 cupCantidad, Boolean cupActivo, DateTime cupFechaHoraCreacion, DateTime cupFechaHoraUltimaModificacion, Int32 IinsId, Int32 IplaId, Int32 Icurid, Int32 IturId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.cupId = cupId;
				    this.cupAnioInsc = cupAnioInsc;
				    this.cupCantidad = cupCantidad;
				    this.cupActivo = cupActivo;
				    this.cupFechaHoraCreacion = cupFechaHoraCreacion;
				    this.cupFechaHoraUltimaModificacion = cupFechaHoraUltimaModificacion;
				    this.insId = insId;
				    this.plaId = plaId;
				    this.curid = curid;
				    this.turId = turId;
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

                			
            public DataTable ObtenerTodo()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[CupoCursos.ObtenerTodo]", new object[,] {});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 cupId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[CupoCursos.ObtenerUno]", new object[,] {{"@cupId", cupId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }

                  public DataTable ObtenerUnoxinsxCurIdxTurno(Int32 insId,Int32 curId, Int32 turId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[CupoCursos.ObtenerUnoxinsxCurIdxTurno]", new object[,] {{ "@insId", insId }, { "@curId", curId }, { "@turId", turId } });
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }			
            public void Actualizar(Int32 cupId, Int32 insId, Int32 plaId, Int32 curid, Int32 turId, Int32 cupAnioInsc, Int32 cupCantidad, Boolean cupActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime cupFechaHoraCreacion, DateTime cupFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[CupoCursos.Actualizar]", new object[,] {{"@cupId", cupId}, {"@insId", insId}, {"@plaId", plaId}, {"@curid", curid}, {"@turId", turId}, {"@cupAnioInsc", cupAnioInsc}, {"@cupCantidad", cupCantidad}, {"@cupActivo", cupActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@cupFechaHoraCreacion", cupFechaHoraCreacion}, {"@cupFechaHoraUltimaModificacion", cupFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 cupId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[CupoCursos.Eliminar]", new object[,] {{"@cupId", cupId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(Int32 insId, Int32 plaId, Int32 curid, Int32 turId, Int32 cupAnioInsc, Int32 cupCantidad, Boolean cupActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime cupFechaHoraCreacion, DateTime cupFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[CupoCursos.Insertar]", new object[,] {{"@insId", insId}, {"@plaId", plaId}, {"@curid", curid}, {"@turId", turId}, {"@cupAnioInsc", cupAnioInsc}, {"@cupCantidad", cupCantidad}, {"@cupActivo", cupActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@cupFechaHoraCreacion", cupFechaHoraCreacion}, {"@cupFechaHoraUltimaModificacion", cupFechaHoraUltimaModificacion}});
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
                    if(this.cupId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[CupoCursos.Actualizar]", new object[,] {{"@cupId", cupId}, {"@insId", insId}, {"@plaId", plaId}, {"@curid", curid}, {"@turId", turId}, {"@cupAnioInsc", cupAnioInsc}, {"@cupCantidad", cupCantidad}, {"@cupActivo", cupActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@cupFechaHoraCreacion", cupFechaHoraCreacion}, {"@cupFechaHoraUltimaModificacion", cupFechaHoraUltimaModificacion}});
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
                    if(this.cupId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[CupoCursos.Eliminar]", new object[,] {{"@cupId", cupId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[CupoCursos.Insertar]", new object[,] {{"@insId", insId}, {"@plaId", plaId}, {"@curid", curid}, {"@turId", turId}, {"@cupAnioInsc", cupAnioInsc}, {"@cupCantidad", cupCantidad}, {"@cupActivo", cupActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@cupFechaHoraCreacion", cupFechaHoraCreacion}, {"@cupFechaHoraUltimaModificacion", cupFechaHoraUltimaModificacion}});
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