using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  PerfilMenu
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _pmeId; 
			public Int32 pmeId { get { return _pmeId; } set { _pmeId = value; } }

            private Boolean _pmeActivo; 
			public Boolean pmeActivo { get { return _pmeActivo; } set { _pmeActivo = value; } }

            private DateTime _pmeFechaHoraCreacion; 
			public DateTime pmeFechaHoraCreacion { get { return _pmeFechaHoraCreacion; } set { _pmeFechaHoraCreacion = value; } }

            private DateTime _pmeFechaHoraUltimaModificacion; 
			public DateTime pmeFechaHoraUltimaModificacion { get { return _pmeFechaHoraUltimaModificacion; } set { _pmeFechaHoraUltimaModificacion = value; } }

			private Int32 _perId; 
			public Int32 perId { get { return _perId; } set { _perId = value; } }

			private Int32 _menId; 
			public Int32 menId { get { return _menId; } set { _menId = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public PerfilMenu() { try { this.pmeId = 0; } catch (Exception oError) { throw oError; } }            

            public PerfilMenu(Int32 pmeId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[PerfilMenu.ObtenerUno]", new object[,] {{"@pmeId", pmeId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["pmeId"].ToString().Trim().Length > 0)
                        {
                            this.pmeId = Convert.ToInt32(Fila.Rows[0]["pmeId"]);
                        }
                        else
                        {
                            this.pmeId = 0;
                        }

					    if(Fila.Rows[0]["pmeFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.pmeFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["pmeFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.pmeFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["pmeFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.pmeFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["pmeFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.pmeFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["pmeActivo"].ToString().Trim().Length > 0)
                        {
                            this.pmeActivo = (Convert.ToInt32(Fila.Rows[0]["pmeActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.pmeActivo = false;
                        }
                        
					    if(Fila.Rows[0]["perId"].ToString().Trim().Length > 0)
                        {
                            this.perId = Convert.ToInt32(Fila.Rows[0]["perId"]);
                        }
                        else
                        {
						    this.perId = 0;
                        }
                        
					    if(Fila.Rows[0]["menId"].ToString().Trim().Length > 0)
                        {
                            this.menId = Convert.ToInt32(Fila.Rows[0]["menId"]);
                        }
                        else
                        {
						    this.menId = 0;
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

            public PerfilMenu(Int32 pmeId, Boolean pmeActivo, DateTime pmeFechaHoraCreacion, DateTime pmeFechaHoraUltimaModificacion, Int32 IperId, Int32 ImenId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.pmeId = pmeId;
				    this.pmeActivo = pmeActivo;
				    this.pmeFechaHoraCreacion = pmeFechaHoraCreacion;
				    this.pmeFechaHoraUltimaModificacion = pmeFechaHoraUltimaModificacion;
				    this.perId = perId;
				    this.menId = menId;
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
                	Tabla = ocdGestor.EjecutarReader("[PerfilMenu.ObtenerTodo]", new object[,] {});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 pmeId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[PerfilMenu.ObtenerUno]", new object[,] {{"@pmeId", pmeId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerxperIdCustom(Int32 perId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[PerfilMenu.ObtenerxperIdCustom]", new object[,] {{"@perId", perId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 pmeId, Int32 perId, Int32 menId, Boolean pmeActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime pmeFechaHoraCreacion, DateTime pmeFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PerfilMenu.Actualizar]", new object[,] {{"@pmeId", pmeId}, {"@perId", perId}, {"@menId", menId}, {"@pmeActivo", pmeActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@pmeFechaHoraCreacion", pmeFechaHoraCreacion}, {"@pmeFechaHoraUltimaModificacion", pmeFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 pmeId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PerfilMenu.Eliminar]", new object[,] {{"@pmeId", pmeId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void EliminarPadresSinHijos(Int32 perId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PerfilMenu.EliminarPadresSinHijos]", new object[,] {{"@perId", perId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(Int32 perId, Int32 menId, Boolean pmeActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime pmeFechaHoraCreacion, DateTime pmeFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PerfilMenu.Insertar]", new object[,] {{"@perId", perId}, {"@menId", menId}, {"@pmeActivo", pmeActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@pmeFechaHoraCreacion", pmeFechaHoraCreacion}, {"@pmeFechaHoraUltimaModificacion", pmeFechaHoraUltimaModificacion}});
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
                    if(this.pmeId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[PerfilMenu.Actualizar]", new object[,] {{"@pmeId", pmeId}, {"@perId", perId}, {"@menId", menId}, {"@pmeActivo", pmeActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@pmeFechaHoraCreacion", pmeFechaHoraCreacion}, {"@pmeFechaHoraUltimaModificacion", pmeFechaHoraUltimaModificacion}});
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
                    if(this.pmeId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[PerfilMenu.Eliminar]", new object[,] {{"@pmeId", pmeId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[PerfilMenu.Insertar]", new object[,] {{"@perId", perId}, {"@menId", menId}, {"@pmeActivo", pmeActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@pmeFechaHoraCreacion", pmeFechaHoraCreacion}, {"@pmeFechaHoraUltimaModificacion", pmeFechaHoraUltimaModificacion}});
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