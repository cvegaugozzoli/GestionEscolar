using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  InscripcionExamen
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _ixaId; 
			public Int32 ixaId { get { return _ixaId; } set { _ixaId = value; } }
                     
            private Int32 _ictId;
            public Int32 ictId { get { return _ictId; } set { _ictId = value; } }

            private Int32 _meeId;
            public Int32 meeId { get { return _meeId; } set { _meeId = value; } }            
     
            private String _ixaCalificacion; 
			public String ixaCalificacion { get { return _ixaCalificacion; } set { _ixaCalificacion = value; } }

            private Int32 _ixaNumeroActa; 
			public Int32 ixaNumeroActa { get { return _ixaNumeroActa; } set { _ixaNumeroActa = value; } }

             private Boolean _ixaActivo; 
			public Boolean ixaActivo { get { return _ixaActivo; } set { _ixaActivo = value; } }

            private Int32 _itpId;
            public Int32 itpId { get { return _itpId; } set { _itpId = value; } }

            private String _ixaNumeroLibro;
            public String ixaNumeroLibro { get { return _ixaNumeroLibro; } set { _ixaNumeroLibro = value; } }        

            private String _ixaObservacion;
            public String ixaObservacion { get { return _ixaObservacion; } set { _ixaObservacion = value; } }  
			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            private DateTime _ixaFechaHoraCreacion; 
			public DateTime ixaFechaHoraCreacion { get { return _ixaFechaHoraCreacion; } set { _ixaFechaHoraCreacion = value; } }

            private DateTime _ixaFechaHoraUltimaModificacion; 
			public DateTime ixaFechaHoraUltimaModificacion { get { return _ixaFechaHoraUltimaModificacion; } set { _ixaFechaHoraUltimaModificacion = value; } }
            	
            #endregion

            #region Constructores

            public InscripcionExamen() { try { this.ixaId = 0; } catch (Exception oError) { throw oError; } }            

            public InscripcionExamen(Int32 ixaId)
			{
                


                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[InscripcionExamen.ObtenerUno]", new object[,] {{"@ixaId", ixaId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["ixaId"].ToString().Trim().Length > 0)
                        {
                            this.ixaId = Convert.ToInt32(Fila.Rows[0]["ixaId"]);
                        }
                        else
                        {
                            this.ixaId = 0;
                        }

                        if (Fila.Rows[0]["ictId"].ToString().Trim().Length > 0)
                        {
                            this.ictId = Convert.ToInt32(Fila.Rows[0]["ictId"]);
                        }
                        else
                        {
                            this.ictId = 0;
                        }


                        if (Fila.Rows[0]["meeId"].ToString().Trim().Length > 0)
                        {
                            this.meeId = Convert.ToInt32(Fila.Rows[0]["meeId"]);
                        }
                        else
                        {
                            this.meeId = 0;
                        }


					    if(Fila.Rows[0]["ixaCalificacion"].ToString().Trim().Length > 0)
                        {
                            this.ixaCalificacion = Convert.ToString(Fila.Rows[0]["ixaCalificacion"]);
                        }
                        else
                        {
                            this.ixaCalificacion = "";
                        }

					    if(Fila.Rows[0]["ixaNumeroActa"].ToString().Trim().Length > 0)
                        {
                            this.ixaNumeroActa = Convert.ToInt32(Fila.Rows[0]["ixaNumeroActa"]);
                        }
                        else
                        {
                            this.ixaNumeroActa = 0;
                        }

                        if (Fila.Rows[0]["ixaActivo"].ToString().Trim().Length > 0)
                        {
                            this.ixaActivo = (Convert.ToInt32(Fila.Rows[0]["ixaActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.ixaActivo = false;
                        }

                        if (Fila.Rows[0]["itpId"].ToString().Trim().Length > 0)
                        {
                            this.itpId = Convert.ToInt32(Fila.Rows[0]["itpId"]);
                        }
                        else
                        {
                            this.itpId = 0;
                        }

                        if (Fila.Rows[0]["ixaNumeroLibro"].ToString().Trim().Length > 0)
                        {
                            this.ixaNumeroLibro = Convert.ToString(Fila.Rows[0]["ixaNumeroLibro"]);
                        }
                        else
                        {
                            this.ixaNumeroLibro = "";
                        }

                        if (Fila.Rows[0]["ixaObservacion"].ToString().Trim().Length > 0)
                        {
                            this.ixaObservacion = Convert.ToString(Fila.Rows[0]["ixaObservacion"]);
                        }
                        else
                        {
                            this.ixaObservacion = "";
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
                        if (Fila.Rows[0]["ixaFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.ixaFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["ixaFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.ixaFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["ixaFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.ixaFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["ixaFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.ixaFechaHoraUltimaModificacion = DateTime.Now;
                        }


                    }
                }
				catch (Exception oError)
                {
                    throw oError;
                }
            }

            public InscripcionExamen(Int32 ixaId, Int32 ictId,Int32 meeId, String ixaCalificacion, Int32 ixaNumeroActa, Boolean ixaActivo, Int32 itpId, String ixaNumeroLibro, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion ,DateTime ixaFechaHoraCreacion, DateTime ixaFechaHoraUltimaModificacion)
			{
                try
                {
				    this.ixaId = ixaId;
                    this.ictId = ictId;
	                this.meeId = meeId;  
				    this.ixaCalificacion = ixaCalificacion;
				    this.ixaNumeroActa = ixaNumeroActa;
				    this.ixaActivo = ixaActivo;
                    this.itpId = itpId;
                    this.ixaNumeroLibro = ixaNumeroLibro;
                    this.ixaObservacion = ixaObservacion;             
				    this.ixaFechaHoraCreacion = ixaFechaHoraCreacion;
				    this.ixaFechaHoraUltimaModificacion = ixaFechaHoraUltimaModificacion;				   
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
                	Tabla = ocdGestor.EjecutarReader("[InscripcionExamen.ObtenerTodo]", new object[,] {});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerxConsultaME(int turId, int carId, int plaId, int curId, int Anio, int espaciocurricular, DateTime fechadesde, DateTime fechahasta, Int32 aplicafiltrofecha, Int32 itpId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionExamen.ObtenerxConsultaME]", new object[,] { { "@turId", turId },  { "@carId", carId }, { "@plaId", plaId },
                      { "@curId", curId },    { "@Anio", Anio },    { "@espaciocurricular", espaciocurricular }, { "@fechadesde", fechadesde }, { "@fechahasta", fechahasta }, { "@aplicafiltrofecha", aplicafiltrofecha }, { "@itpId", itpId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerUno(Int32 ixaId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[InscripcionExamen.ObtenerUno]", new object[,] {{"@ixaId", ixaId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
   public DataTable ObtenerUnoxictIdxmeeId(Int32 ictId, Int32 meeId )
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[InscripcionExamen.ObtenerUnoxictIdxmeeId]", new object[,] {{ "@ictId", ictId } ,{ "@meeId", meeId } });
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }

  public DataTable ContarxictIdxEvaFinal(Int32 ictId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[InscripcionExamen.ContarxictIdxEvaFinal]", new object[,] {{ "@ictId", ictId } });
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUnoControlExiste(Int32 aluId, Int32 escId, int tueId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionExamen.ObtenerUnoControlExiste]", new object[,] { { "@aluId", ixaId }, { "@escId", ixaId }, { "@tueId", tueId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoporAprobado(Int32 aluId, Int32 escId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionExamen.ObtenerUnoporAprobado]", new object[,] { { "@aluId", ixaId }, { "@escId", ixaId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }



            public DataTable ObtenerUnoPorAlumno(Int32 ixaId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionExamen.ObtenerUnoPorAlumno]", new object[,] { { "@ixaId", ixaId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }



            public void Actualizar(Int32 ixaId, Int32 ictId, Int32 meeId, Decimal ixaCalificacion, Int32 ixaNumeroActa, Boolean ixaActivo, Int32 itpId,
                String ixaNumeroLibro, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion, DateTime ixaFechaHoraCreacion, DateTime ixaFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionExamen.Actualizar]", new object[,] {{"@ixaId", ixaId},
                          {"@ictId", ictId}, {"@meeId", meeId},{"@ixaCalificacion", ixaCalificacion}, {"@ixaNumeroActa", ixaNumeroActa}, {"@ixaActivo", ixaActivo},
                          { "@itpId", itpId }, { "@ixaNumeroLibro", ixaNumeroLibro },  {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@ixaFechaHoraCreacion", ixaFechaHoraCreacion}, {"@ixaFechaHoraUltimaModificacion", ixaFechaHoraUltimaModificacion} });
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void EliminarActivo(Int32 ixaId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionExamen.EliminarActivo]", new object[,] {{"@ixaId", ixaId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                public void Eliminar(Int32 ixaId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionExamen.Eliminar]", new object[,] {{"@ixaId", ixaId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            } 			
            public void Insertar( Int32 ictId,Int32 meeId,  Decimal ixaCalificacion, Int32 ixaNumeroActa, Boolean ixaActivo, Int32 itpId, String ixaNumeroLibro, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion, DateTime ixaFechaHoraCreacion, DateTime ixaFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionExamen.Insertar]", new object[,] {{"@ictId", ictId}, {"@meeId", meeId},{"@ixaCalificacion", ixaCalificacion}, {"@ixaNumeroActa", ixaNumeroActa}, {"@ixaActivo", ixaActivo},
                          { "@itpId", itpId }, { "@ixaNumeroLibro", ixaNumeroLibro },  {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@ixaFechaHoraCreacion", ixaFechaHoraCreacion}, {"@ixaFechaHoraUltimaModificacion", ixaFechaHoraUltimaModificacion} });
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
                    if(this.ixaId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[InscripcionExamen.Actualizar]", new object[,] {{"@ixaId", ixaId},{"@ictId", ictId}, {"@meeId", meeId},{"@ixaCalificacion", ixaCalificacion}, {"@ixaNumeroActa", ixaNumeroActa}, {"@ixaActivo", ixaActivo},
                          { "@itpId", itpId }, { "@ixaNumeroLibro", ixaNumeroLibro },  { "@ixaObservacion", ixaObservacion }, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@ixaFechaHoraCreacion", ixaFechaHoraCreacion}, {"@ixaFechaHoraUltimaModificacion", ixaFechaHoraUltimaModificacion} });
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
                    if(this.ixaId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[InscripcionExamen.Eliminar]", new object[,] {{"@ixaId", ixaId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[InscripcionExamen.Insertar]", new object[,] {
                          {"@ictId", ictId}, {"@meeId", meeId},{"@ixaCalificacion", ixaCalificacion}, {"@ixaNumeroActa", ixaNumeroActa},{ "@ixaNumeroLibro", ixaNumeroLibro }, {"@ixaActivo", ixaActivo},
                          { "@itpId", itpId },   { "@ixaObservacion", ixaObservacion }, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@ixaFechaHoraCreacion", ixaFechaHoraCreacion}, {"@ixaFechaHoraUltimaModificacion", ixaFechaHoraUltimaModificacion} });
                }
                catch (Exception oError)
                {
                	throw oError;
                }
                return IdMax;
            }


            public DataTable InformeInscripcionesExamen(Int32 carid, Int32 plaid, Int32 curid, Int32 camid, Int32 escid, Int32 ixanumeroacta, DateTime ixafechaexamen, Int32 aplicafiltrofecha )
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InformeInscripcionesExamen]", new object[,] { { "@carId", carid }, { "@plaId", plaid }, { "@curId", curid }, { "@camId", camid }, { "@escId", escid }, { "@ixaNumeroActa", ixanumeroacta }, { "@ixaFechaExamen", ixafechaexamen }, { "@aplicaFiltroFecha", aplicafiltrofecha } });
                }

                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            #endregion
        }
    }
}