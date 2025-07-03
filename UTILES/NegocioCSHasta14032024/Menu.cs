using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  Menu
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _menId; 
			public Int32 menId { get { return _menId; } set { _menId = value; } }

            private String _menNombre; 
			public String menNombre { get { return _menNombre; } set { _menNombre = value; } }

            private Int32 _menOrden; 
			public Int32 menOrden { get { return _menOrden; } set { _menOrden = value; } }

            private String _menUrl; 
			public String menUrl { get { return _menUrl; } set { _menUrl = value; } }

            private String _menIcono; 
			public String menIcono { get { return _menIcono; } set { _menIcono = value; } }

            private Boolean _menEsMenu; 
			public Boolean menEsMenu { get { return _menEsMenu; } set { _menEsMenu = value; } }

            private Boolean _menActivo; 
			public Boolean menActivo { get { return _menActivo; } set { _menActivo = value; } }

            private DateTime _menFechaHoraCreacion; 
			public DateTime menFechaHoraCreacion { get { return _menFechaHoraCreacion; } set { _menFechaHoraCreacion = value; } }

            private DateTime _menFechaHoraUltimaModificacion; 
			public DateTime menFechaHoraUltimaModificacion { get { return _menFechaHoraUltimaModificacion; } set { _menFechaHoraUltimaModificacion = value; } }

			private Int32 _menIdPadre; 
			public Int32 menIdPadre { get { return _menIdPadre; } set { _menIdPadre = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public Menu() { try { this.menId = 0; } catch (Exception oError) { throw oError; } }            

            public Menu(Int32 menId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Menu.ObtenerUno]", new object[,] {{"@menId", menId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["menId"].ToString().Trim().Length > 0)
                        {
                            this.menId = Convert.ToInt32(Fila.Rows[0]["menId"]);
                        }
                        else
                        {
                            this.menId = 0;
                        }

					    if(Fila.Rows[0]["menNombre"].ToString().Trim().Length > 0)
                        {
                            this.menNombre = Convert.ToString(Fila.Rows[0]["menNombre"]);
                        }
                        else
                        {
                            this.menNombre = "";
                        }

					    if(Fila.Rows[0]["menOrden"].ToString().Trim().Length > 0)
                        {
                            this.menOrden = Convert.ToInt32(Fila.Rows[0]["menOrden"]);
                        }
                        else
                        {
                            this.menOrden = 0;
                        }

					    if(Fila.Rows[0]["menUrl"].ToString().Trim().Length > 0)
                        {
                            this.menUrl = Convert.ToString(Fila.Rows[0]["menUrl"]);
                        }
                        else
                        {
                            this.menUrl = "";
                        }

					    if(Fila.Rows[0]["menIcono"].ToString().Trim().Length > 0)
                        {
                            this.menIcono = Convert.ToString(Fila.Rows[0]["menIcono"]);
                        }
                        else
                        {
                            this.menIcono = "";
                        }

					    if(Fila.Rows[0]["menFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.menFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["menFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.menFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["menFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.menFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["menFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.menFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["menEsMenu"].ToString().Trim().Length > 0)
                        {
                            this.menEsMenu = (Convert.ToInt32(Fila.Rows[0]["menEsMenu"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.menEsMenu = false;
                        }
                        
					    if(Fila.Rows[0]["menActivo"].ToString().Trim().Length > 0)
                        {
                            this.menActivo = (Convert.ToInt32(Fila.Rows[0]["menActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.menActivo = false;
                        }
                        
					    if(Fila.Rows[0]["menIdPadre"].ToString().Trim().Length > 0)
                        {
                            this.menIdPadre = Convert.ToInt32(Fila.Rows[0]["menIdPadre"]);
                        }
                        else
                        {
						    this.menIdPadre = 0;
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

            public Menu(Int32 menId, String menNombre, Int32 menOrden, String menUrl, String menIcono, Boolean menEsMenu, Boolean menActivo, DateTime menFechaHoraCreacion, DateTime menFechaHoraUltimaModificacion, Int32 ImenIdPadre, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.menId = menId;
				    this.menNombre = menNombre;
				    this.menOrden = menOrden;
				    this.menUrl = menUrl;
				    this.menIcono = menIcono;
				    this.menEsMenu = menEsMenu;
				    this.menActivo = menActivo;
				    this.menFechaHoraCreacion = menFechaHoraCreacion;
				    this.menFechaHoraUltimaModificacion = menFechaHoraUltimaModificacion;
				    this.menIdPadre = menIdPadre;
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
                	Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerListaAsociarACustom(Int32 perId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerListaAsociarACustom]", new object[,] {{"@perId", perId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerListaRaiz(String PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerListaRaiz]", new object[,] {{"@PrimerItem", PrimerItem}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerMenuSecundario(Int32 menIdPadre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerMenuSecundario]", new object[,] {{"@menIdPadre", menIdPadre}});
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
                	Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 menId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerUno]", new object[,] {{"@menId", menId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 menId, String menNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerValidarRepetido]", new object[,] {{"@menId", menId}, {"@menNombre", menNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void ActivarInactivar(Int32 menId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Menu.ActivarInactivar]", new object[,] {{"@menId", menId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Actualizar(Int32 menId, String menNombre, Int32 menIdPadre, Int32 menOrden, String menUrl, String menIcono, Boolean menEsMenu, Boolean menActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime menFechaHoraCreacion, DateTime menFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Menu.Actualizar]", new object[,] {{"@menId", menId}, {"@menNombre", menNombre}, {"@menIdPadre", menIdPadre}, {"@menOrden", menOrden}, {"@menUrl", menUrl}, {"@menIcono", menIcono}, {"@menEsMenu", menEsMenu}, {"@menActivo", menActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@menFechaHoraCreacion", menFechaHoraCreacion}, {"@menFechaHoraUltimaModificacion", menFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String menNombre, Int32 menIdPadre, Int32 menOrden, String menUrl, String menIcono, Boolean menEsMenu, Boolean menActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime menFechaHoraCreacion, DateTime menFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Menu.Copiar]", new object[,] {{"@menNombre", menNombre}, {"@menIdPadre", menIdPadre}, {"@menOrden", menOrden}, {"@menUrl", menUrl}, {"@menIcono", menIcono}, {"@menEsMenu", menEsMenu}, {"@menActivo", menActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@menFechaHoraCreacion", menFechaHoraCreacion}, {"@menFechaHoraUltimaModificacion", menFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 menId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Menu.Eliminar]", new object[,] {{"@menId", menId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void EliminarCustom(Int32 menId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Menu.EliminarCustom]", new object[,] {{"@menId", menId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String menNombre, Int32 menIdPadre, Int32 menOrden, String menUrl, String menIcono, Boolean menEsMenu, Boolean menActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime menFechaHoraCreacion, DateTime menFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Menu.Insertar]", new object[,] {{"@menNombre", menNombre}, {"@menIdPadre", menIdPadre}, {"@menOrden", menOrden}, {"@menUrl", menUrl}, {"@menIcono", menIcono}, {"@menEsMenu", menEsMenu}, {"@menActivo", menActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@menFechaHoraCreacion", menFechaHoraCreacion}, {"@menFechaHoraUltimaModificacion", menFechaHoraUltimaModificacion}});
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
                    if(this.menId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Menu.Actualizar]", new object[,] {{"@menId", menId}, {"@menNombre", menNombre}, {"@menIdPadre", menIdPadre}, {"@menOrden", menOrden}, {"@menUrl", menUrl}, {"@menIcono", menIcono}, {"@menEsMenu", menEsMenu}, {"@menActivo", menActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@menFechaHoraCreacion", menFechaHoraCreacion}, {"@menFechaHoraUltimaModificacion", menFechaHoraUltimaModificacion}});
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
                    if(this.menId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Menu.Copiar]", new object[,] {{"@menNombre", menNombre}, {"@menIdPadre", menIdPadre}, {"@menOrden", menOrden}, {"@menUrl", menUrl}, {"@menIcono", menIcono}, {"@menEsMenu", menEsMenu}, {"@menActivo", menActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@menFechaHoraCreacion", menFechaHoraCreacion}, {"@menFechaHoraUltimaModificacion", menFechaHoraUltimaModificacion}});
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
                    if(this.menId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Menu.Eliminar]", new object[,] {{"@menId", menId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Menu.Insertar]", new object[,] {{"@menNombre", menNombre}, {"@menIdPadre", menIdPadre}, {"@menOrden", menOrden}, {"@menUrl", menUrl}, {"@menIcono", menIcono}, {"@menEsMenu", menEsMenu}, {"@menActivo", menActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@menFechaHoraCreacion", menFechaHoraCreacion}, {"@menFechaHoraUltimaModificacion", menFechaHoraUltimaModificacion}});
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