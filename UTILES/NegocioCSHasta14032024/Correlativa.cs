using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  Correlativa
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _corId; 
			public Int32 corId { get { return _corId; } set { _corId = value; } }

            private Boolean _corActivo; 
			public Boolean corActivo { get { return _corActivo; } set { _corActivo = value; } }

            private DateTime _corFechaHoraCreacion; 
			public DateTime corFechaHoraCreacion { get { return _corFechaHoraCreacion; } set { _corFechaHoraCreacion = value; } }

            private DateTime _corFechaHoraUltimaModificacion; 
			public DateTime corFechaHoraUltimaModificacion { get { return _corFechaHoraUltimaModificacion; } set { _corFechaHoraUltimaModificacion = value; } }

			private Int32 _escIdOriginal; 
			public Int32 escIdOriginal { get { return _escIdOriginal; } set { _escIdOriginal = value; } }

			private Int32 _carId; 
			public Int32 carId { get { return _carId; } set { _carId = value; } }

			private Int32 _plaId; 
			public Int32 plaId { get { return _plaId; } set { _plaId = value; } }

			private Int32 _curId; 
			public Int32 curId { get { return _curId; } set { _curId = value; } }

			private Int32 _camId; 
			public Int32 camId { get { return _camId; } set { _camId = value; } }

			private Int32 _escId; 
			public Int32 escId { get { return _escId; } set { _escId = value; } }

			private Int32 _cotId; 
			public Int32 cotId { get { return _cotId; } set { _cotId = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public Correlativa() { try { this.corId = 0; } catch (Exception oError) { throw oError; } }            

            public Correlativa(Int32 corId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Correlativa.ObtenerUno]", new object[,] {{"@corId", corId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["corId"].ToString().Trim().Length > 0)
                        {
                            this.corId = Convert.ToInt32(Fila.Rows[0]["corId"]);
                        }
                        else
                        {
                            this.corId = 0;
                        }

					    if(Fila.Rows[0]["corFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.corFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["corFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.corFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["corFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.corFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["corFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.corFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["corActivo"].ToString().Trim().Length > 0)
                        {
                            this.corActivo = (Convert.ToInt32(Fila.Rows[0]["corActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.corActivo = false;
                        }
                        
					    if(Fila.Rows[0]["escIdOriginal"].ToString().Trim().Length > 0)
                        {
                            this.escIdOriginal = Convert.ToInt32(Fila.Rows[0]["escIdOriginal"]);
                        }
                        else
                        {
						    this.escIdOriginal = 0;
                        }
                        
					    if(Fila.Rows[0]["carId"].ToString().Trim().Length > 0)
                        {
                            this.carId = Convert.ToInt32(Fila.Rows[0]["carId"]);
                        }
                        else
                        {
						    this.carId = 0;
                        }
                        
					    if(Fila.Rows[0]["plaId"].ToString().Trim().Length > 0)
                        {
                            this.plaId = Convert.ToInt32(Fila.Rows[0]["plaId"]);
                        }
                        else
                        {
						    this.plaId = 0;
                        }
                        
					    if(Fila.Rows[0]["curId"].ToString().Trim().Length > 0)
                        {
                            this.curId = Convert.ToInt32(Fila.Rows[0]["curId"]);
                        }
                        else
                        {
						    this.curId = 0;
                        }
                        
					    if(Fila.Rows[0]["camId"].ToString().Trim().Length > 0)
                        {
                            this.camId = Convert.ToInt32(Fila.Rows[0]["camId"]);
                        }
                        else
                        {
						    this.camId = 0;
                        }
                        
					    if(Fila.Rows[0]["escId"].ToString().Trim().Length > 0)
                        {
                            this.escId = Convert.ToInt32(Fila.Rows[0]["escId"]);
                        }
                        else
                        {
						    this.escId = 0;
                        }
                        
					    if(Fila.Rows[0]["cotId"].ToString().Trim().Length > 0)
                        {
                            this.cotId = Convert.ToInt32(Fila.Rows[0]["cotId"]);
                        }
                        else
                        {
						    this.cotId = 0;
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

            public Correlativa(Int32 corId, Boolean corActivo, DateTime corFechaHoraCreacion, DateTime corFechaHoraUltimaModificacion, Int32 IescIdOriginal, Int32 IcarId, Int32 IplaId, Int32 IcurId, Int32 IcamId, Int32 IescId, Int32 IcotId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.corId = corId;
				    this.corActivo = corActivo;
				    this.corFechaHoraCreacion = corFechaHoraCreacion;
				    this.corFechaHoraUltimaModificacion = corFechaHoraUltimaModificacion;
				    this.escIdOriginal = escIdOriginal;
				    this.carId = carId;
				    this.plaId = plaId;
				    this.curId = curId;
				    this.camId = camId;
				    this.escId = escId;
				    this.cotId = cotId;
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
                	Tabla = ocdGestor.EjecutarReader("[Correlativa.ObtenerTodo]", new object[,] {});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerTodoporEspacioCurricular(Int32 escId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Correlativa.ObtenerTodoporEspacioCurricular]", new object[,] { { "@escId", escId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }




            public DataTable ObtenerUno(Int32 corId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Correlativa.ObtenerUno]", new object[,] {{"@corId", corId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 corId, Int32 escIdOriginal, Int32 carId, Int32 plaId, Int32 curId, Int32 camId, Int32 escId, Int32 cotId, Boolean corActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime corFechaHoraCreacion, DateTime corFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Correlativa.Actualizar]", new object[,] {{"@corId", corId}, {"@escIdOriginal", escIdOriginal}, {"@carId", carId}, {"@plaId", plaId}, {"@curId", curId}, {"@camId", camId}, {"@escId", escId}, {"@cotId", cotId}, {"@corActivo", corActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@corFechaHoraCreacion", corFechaHoraCreacion}, {"@corFechaHoraUltimaModificacion", corFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 corId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Correlativa.Eliminar]", new object[,] {{"@corId", corId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(Int32 escIdOriginal, Int32 carId, Int32 plaId, Int32 curId, Int32 camId, Int32 escId, Int32 cotId, Boolean corActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime corFechaHoraCreacion, DateTime corFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Correlativa.Insertar]", new object[,] {{"@escIdOriginal", escIdOriginal}, {"@carId", carId}, {"@plaId", plaId}, {"@curId", curId}, {"@camId", camId}, {"@escId", escId}, {"@cotId", cotId}, {"@corActivo", corActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@corFechaHoraCreacion", corFechaHoraCreacion}, {"@corFechaHoraUltimaModificacion", corFechaHoraUltimaModificacion}});
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
                    if(this.corId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Correlativa.Actualizar]", new object[,] {{"@corId", corId}, {"@escIdOriginal", escIdOriginal}, {"@carId", carId}, {"@plaId", plaId}, {"@curId", curId}, {"@camId", camId}, {"@escId", escId}, {"@cotId", cotId}, {"@corActivo", corActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@corFechaHoraCreacion", corFechaHoraCreacion}, {"@corFechaHoraUltimaModificacion", corFechaHoraUltimaModificacion}});
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
                    if(this.corId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Correlativa.Eliminar]", new object[,] {{"@corId", corId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Correlativa.Insertar]", new object[,] {{"@escIdOriginal", escIdOriginal}, {"@carId", carId}, {"@plaId", plaId}, {"@curId", curId}, {"@camId", camId}, {"@escId", escId}, {"@cotId", cotId}, {"@corActivo", corActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@corFechaHoraCreacion", corFechaHoraCreacion}, {"@corFechaHoraUltimaModificacion", corFechaHoraUltimaModificacion}});
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