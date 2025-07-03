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

            private DateTime _ixaFechaExamen; 
			public DateTime ixaFechaExamen { get { return _ixaFechaExamen; } set { _ixaFechaExamen = value; } }

            private Decimal _ixaCalificacion; 
			public Decimal ixaCalificacion { get { return _ixaCalificacion; } set { _ixaCalificacion = value; } }

            private Int32 _ixaNumeroActa; 
			public Int32 ixaNumeroActa { get { return _ixaNumeroActa; } set { _ixaNumeroActa = value; } }

            private String _ixaNumeroLibro;
            public String ixaNumeroLibro { get { return _ixaNumeroLibro; } set { _ixaNumeroLibro = value; } }

            private Boolean _ixaActivo; 
			public Boolean ixaActivo { get { return _ixaActivo; } set { _ixaActivo = value; } }

            private DateTime _ixaFechaHoraCreacion; 
			public DateTime ixaFechaHoraCreacion { get { return _ixaFechaHoraCreacion; } set { _ixaFechaHoraCreacion = value; } }

            private DateTime _ixaFechaHoraUltimaModificacion; 
			public DateTime ixaFechaHoraUltimaModificacion { get { return _ixaFechaHoraUltimaModificacion; } set { _ixaFechaHoraUltimaModificacion = value; } }

			private Int32 _aluId; 
			public Int32 aluId { get { return _aluId; } set { _aluId = value; } }

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

			private Int32 _extId; 
			public Int32 extId { get { return _extId; } set { _extId = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            private Int32 _itpId;
            public Int32 itpId { get { return _itpId; } set { _itpId = value; } }
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

					    if(Fila.Rows[0]["ixaFechaExamen"].ToString().Trim().Length > 0)
                        {
                            this.ixaFechaExamen = Convert.ToDateTime(Fila.Rows[0]["ixaFechaExamen"]);
                        }
                        else
                        {
                            this.ixaFechaExamen = DateTime.Now;
                        }

					    if(Fila.Rows[0]["ixaCalificacion"].ToString().Trim().Length > 0)
                        {
                            this.ixaCalificacion = Convert.ToDecimal(Fila.Rows[0]["ixaCalificacion"]);
                        }
                        else
                        {
                            this.ixaCalificacion = 0;
                        }

					    if(Fila.Rows[0]["ixaNumeroActa"].ToString().Trim().Length > 0)
                        {
                            this.ixaNumeroActa = Convert.ToInt32(Fila.Rows[0]["ixaNumeroActa"]);
                        }
                        else
                        {
                            this.ixaNumeroActa = 0;
                        }




                        if (Fila.Rows[0]["ixaNumeroLibro"].ToString().Trim().Length > 0)
                        {
                            this.ixaNumeroLibro = Convert.ToString(Fila.Rows[0]["ixaNumeroLibro"]);
                        }
                        else
                        {
                            this.ixaNumeroLibro = "";
                        }




                        if (Fila.Rows[0]["ixaFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.ixaFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["ixaFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.ixaFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["ixaFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.ixaFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["ixaFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.ixaFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["ixaActivo"].ToString().Trim().Length > 0)
                        {
                            this.ixaActivo = (Convert.ToInt32(Fila.Rows[0]["ixaActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.ixaActivo = false;
                        }
                        
					    if(Fila.Rows[0]["aluId"].ToString().Trim().Length > 0)
                        {
                            this.aluId = Convert.ToInt32(Fila.Rows[0]["aluId"]);
                        }
                        else
                        {
						    this.aluId = 0;
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
                        
					    if(Fila.Rows[0]["extId"].ToString().Trim().Length > 0)
                        {
                            this.extId = Convert.ToInt32(Fila.Rows[0]["extId"]);
                        }
                        else
                        {
						    this.extId = 0;
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

                        if (Fila.Rows[0]["itpId"].ToString().Trim().Length > 0)
                        {
                            this.itpId = Convert.ToInt32(Fila.Rows[0]["itpId"]);
                        }
                        else
                        {
                            this.itpId = 0;
                        }


                    }
                }
				catch (Exception oError)
                {
                    throw oError;
                }
            }

            public InscripcionExamen(Int32 ixaId, DateTime ixaFechaExamen, Decimal ixaCalificacion, Int32 ixaNumeroActa, Boolean ixaActivo, DateTime ixaFechaHoraCreacion, DateTime ixaFechaHoraUltimaModificacion, Int32 IaluId, Int32 IcarId, Int32 IplaId, Int32 IcurId, Int32 IcamId, Int32 IescId, Int32 IextId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion, String ixaNumeroLibro, Int32 itpId)
			{
                try
                {
				    this.ixaId = ixaId;
				    this.ixaFechaExamen = ixaFechaExamen;
				    this.ixaCalificacion = ixaCalificacion;
				    this.ixaNumeroActa = ixaNumeroActa;
				    this.ixaActivo = ixaActivo;
				    this.ixaFechaHoraCreacion = ixaFechaHoraCreacion;
				    this.ixaFechaHoraUltimaModificacion = ixaFechaHoraUltimaModificacion;
				    this.aluId = aluId;
				    this.carId = carId;
				    this.plaId = plaId;
				    this.curId = curId;
				    this.camId = camId;
				    this.escId = escId;
				    this.extId = extId;
				    this.usuIdCreacion = usuIdCreacion;
				    this.usuIdUltimaModificacion = usuIdUltimaModificacion;
                    this.ixaNumeroLibro = ixaNumeroLibro;
                    this.itpId = itpId;
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


            public DataTable ObtenerPorAlumnoPorECporPeriodo(String aluNombre, String espaciocurricular, DateTime fechadesde, DateTime fechahasta, Int32 aplicafiltrofecha)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionExamen.ObtenerPorAlumnoPorECporPeriodo]", new object[,] { { "@aluNombre", aluNombre }, { "@espaciocurricular", espaciocurricular }, { "@fechadesde", fechadesde }, { "@fechahasta", fechahasta }, { "@aplicafiltrofecha", aplicafiltrofecha } });
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


            public DataTable ObtenerUnoControlExiste(Int32 aluId, Int32 escId, DateTime ixaFechaExamen)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionExamen.ObtenerUnoControlExiste]", new object[,] { { "@aluId", ixaId }, { "@escId", ixaId }, { "@ixaFechaExamen", ixaFechaExamen } });
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



            public void Actualizar(Int32 ixaId, Int32 aluId, Int32 carId, Int32 plaId, Int32 curId, Int32 camId, Int32 escId, Int32 extId, DateTime ixaFechaExamen, Decimal ixaCalificacion, Int32 ixaNumeroActa, Boolean ixaActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime ixaFechaHoraCreacion, DateTime ixaFechaHoraUltimaModificacion, Int32 itpId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionExamen.Actualizar]", new object[,] {{"@ixaId", ixaId}, {"@aluId", aluId}, {"@carId", carId}, {"@plaId", plaId}, {"@curId", curId}, {"@camId", camId}, {"@escId", escId}, {"@extId", extId}, {"@ixaFechaExamen", ixaFechaExamen}, {"@ixaCalificacion", ixaCalificacion}, {"@ixaNumeroActa", ixaNumeroActa}, {"@ixaActivo", ixaActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@ixaFechaHoraCreacion", ixaFechaHoraCreacion}, {"@ixaFechaHoraUltimaModificacion", ixaFechaHoraUltimaModificacion}, { "@ixaNumeroLibro", ixaNumeroLibro }, { "@itpId", itpId } });
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
                			
            public void Insertar(Int32 aluId, Int32 carId, Int32 plaId, Int32 curId, Int32 camId, Int32 escId, Int32 extId, DateTime ixaFechaExamen, Decimal ixaCalificacion, Int32 ixaNumeroActa, Boolean ixaActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime ixaFechaHoraCreacion, DateTime ixaFechaHoraUltimaModificacion, String ixaNumeroLibro, Int32 itpId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionExamen.Insertar]", new object[,] {{"@aluId", aluId}, {"@carId", carId}, {"@plaId", plaId}, {"@curId", curId}, {"@camId", camId}, {"@escId", escId}, {"@extId", extId}, {"@ixaFechaExamen", ixaFechaExamen}, {"@ixaCalificacion", ixaCalificacion}, {"@ixaNumeroActa", ixaNumeroActa}, {"@ixaActivo", ixaActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@ixaFechaHoraCreacion", ixaFechaHoraCreacion}, {"@ixaFechaHoraUltimaModificacion", ixaFechaHoraUltimaModificacion}, { "@ixaNumeroLibro", ixaNumeroLibro }, { "@itpId", itpId } });
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
                        ocdGestor.EjecutarNonQuery("[InscripcionExamen.Actualizar]", new object[,] {{"@ixaId", ixaId}, {"@aluId", aluId}, {"@carId", carId}, {"@plaId", plaId}, {"@curId", curId}, {"@camId", camId}, {"@escId", escId}, {"@extId", extId}, {"@ixaFechaExamen", ixaFechaExamen}, {"@ixaCalificacion", ixaCalificacion}, {"@ixaNumeroActa", ixaNumeroActa}, {"@ixaActivo", ixaActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@ixaFechaHoraCreacion", ixaFechaHoraCreacion}, {"@ixaFechaHoraUltimaModificacion", ixaFechaHoraUltimaModificacion}, { "@ixaNumeroLibro", ixaNumeroLibro }, { "@itpId", itpId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[InscripcionExamen.Insertar]", new object[,] {{"@aluId", aluId}, {"@carId", carId}, {"@plaId", plaId}, {"@curId", curId}, {"@camId", camId}, {"@escId", escId}, {"@extId", extId}, {"@ixaFechaExamen", ixaFechaExamen}, {"@ixaCalificacion", ixaCalificacion}, {"@ixaNumeroActa", ixaNumeroActa}, {"@ixaActivo", ixaActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@ixaFechaHoraCreacion", ixaFechaHoraCreacion}, {"@ixaFechaHoraUltimaModificacion", ixaFechaHoraUltimaModificacion}, { "@ixaNumeroLibro", ixaNumeroLibro }, { "@itpId", itpId } });
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