using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  RegistracionCalificaciones
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _recId; 
			public Int32 recId { get { return _recId; } set { _recId = value; } }

            private Decimal _recTrabajoPractico; 
			public Decimal recTrabajoPractico { get { return _recTrabajoPractico; } set { _recTrabajoPractico = value; } }

            private Decimal _recTrabajoPracticoRecuperatorio; 
			public Decimal recTrabajoPracticoRecuperatorio { get { return _recTrabajoPracticoRecuperatorio; } set { _recTrabajoPracticoRecuperatorio = value; } }

            private Decimal _recAsistencia; 
			public Decimal recAsistencia { get { return _recAsistencia; } set { _recAsistencia = value; } }

            private Decimal _recCalificacionParcial1; 
			public Decimal recCalificacionParcial1 { get { return _recCalificacionParcial1; } set { _recCalificacionParcial1 = value; } }

            private Decimal _recCalificacionParcial2; 
			public Decimal recCalificacionParcial2 { get { return _recCalificacionParcial2; } set { _recCalificacionParcial2 = value; } }

            private Decimal _recCalificacionParcial3; 
			public Decimal recCalificacionParcial3 { get { return _recCalificacionParcial3; } set { _recCalificacionParcial3 = value; } }

            private Decimal _recCalificacionParcial4; 
			public Decimal recCalificacionParcial4 { get { return _recCalificacionParcial4; } set { _recCalificacionParcial4 = value; } }

            private Decimal _recCalificacionParcialRecuperatorio1; 
			public Decimal recCalificacionParcialRecuperatorio1 { get { return _recCalificacionParcialRecuperatorio1; } set { _recCalificacionParcialRecuperatorio1 = value; } }

            private Decimal _recCalificacionParcialRecuperatorio2; 
			public Decimal recCalificacionParcialRecuperatorio2 { get { return _recCalificacionParcialRecuperatorio2; } set { _recCalificacionParcialRecuperatorio2 = value; } }

            private Decimal _recCalificacionParcialRecuperatorio3; 
			public Decimal recCalificacionParcialRecuperatorio3 { get { return _recCalificacionParcialRecuperatorio3; } set { _recCalificacionParcialRecuperatorio3 = value; } }

            private Decimal _recCalificacionParcialRecuperatorio4; 
			public Decimal recCalificacionParcialRecuperatorio4 { get { return _recCalificacionParcialRecuperatorio4; } set { _recCalificacionParcialRecuperatorio4 = value; } }

            private String _recObservaciones; 
			public String recObservaciones { get { return _recObservaciones; } set { _recObservaciones = value; } }

            private Boolean _recActivo; 
			public Boolean recActivo { get { return _recActivo; } set { _recActivo = value; } }

            private DateTime _recFechaHoraCreacion; 
			public DateTime recFechaHoraCreacion { get { return _recFechaHoraCreacion; } set { _recFechaHoraCreacion = value; } }

            private DateTime _recFechaHoraUltimaModificacion; 
			public DateTime recFechaHoraUltimaModificacion { get { return _recFechaHoraUltimaModificacion; } set { _recFechaHoraUltimaModificacion = value; } }

			private Int32 _icuId; 
			public Int32 icuId { get { return _icuId; } set { _icuId = value; } }

			private Int32 _conId; 
			public Int32 conId { get { return _conId; } set { _conId = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            private Decimal _recEvaluacionFinal;
            public Decimal recEvaluacionFinal { get { return _recEvaluacionFinal; } set { _recEvaluacionFinal = value; } }

            private DateTime _recFechaRegularizaPromociona;
            public DateTime recFechaRegularizaPromociona { get { return _recFechaRegularizaPromociona; } set { _recFechaRegularizaPromociona = value; } }
            #endregion

            #region Constructores

            public RegistracionCalificaciones() { try { this.recId = 0; } catch (Exception oError) { throw oError; } }            

            public RegistracionCalificaciones(Int32 recId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[RegistracionCalificaciones.ObtenerUno]", new object[,] {{"@recId", recId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["recId"].ToString().Trim().Length > 0)
                        {
                            this.recId = Convert.ToInt32(Fila.Rows[0]["recId"]);
                        }
                        else
                        {
                            this.recId = 0;
                        }

					    if(Fila.Rows[0]["recTrabajoPractico"].ToString().Trim().Length > 0)
                        {
                            this.recTrabajoPractico = Convert.ToDecimal(Fila.Rows[0]["recTrabajoPractico"]);
                        }
                        else
                        {
                            this.recTrabajoPractico = 0;
                        }

					    if(Fila.Rows[0]["recTrabajoPracticoRecuperatorio"].ToString().Trim().Length > 0)
                        {
                            this.recTrabajoPracticoRecuperatorio = Convert.ToDecimal(Fila.Rows[0]["recTrabajoPracticoRecuperatorio"]);
                        }
                        else
                        {
                            this.recTrabajoPracticoRecuperatorio = 0;
                        }

					    if(Fila.Rows[0]["recAsistencia"].ToString().Trim().Length > 0)
                        {
                            this.recAsistencia = Convert.ToDecimal(Fila.Rows[0]["recAsistencia"]);
                        }
                        else
                        {
                            this.recAsistencia = 0;
                        }

					    if(Fila.Rows[0]["recCalificacionParcial1"].ToString().Trim().Length > 0)
                        {
                            this.recCalificacionParcial1 = Convert.ToDecimal(Fila.Rows[0]["recCalificacionParcial1"]);
                        }
                        else
                        {
                            this.recCalificacionParcial1 = 0;
                        }

					    if(Fila.Rows[0]["recCalificacionParcial2"].ToString().Trim().Length > 0)
                        {
                            this.recCalificacionParcial2 = Convert.ToDecimal(Fila.Rows[0]["recCalificacionParcial2"]);
                        }
                        else
                        {
                            this.recCalificacionParcial2 = 0;
                        }

					    if(Fila.Rows[0]["recCalificacionParcial3"].ToString().Trim().Length > 0)
                        {
                            this.recCalificacionParcial3 = Convert.ToDecimal(Fila.Rows[0]["recCalificacionParcial3"]);
                        }
                        else
                        {
                            this.recCalificacionParcial3 = 0;
                        }

					    if(Fila.Rows[0]["recCalificacionParcial4"].ToString().Trim().Length > 0)
                        {
                            this.recCalificacionParcial4 = Convert.ToDecimal(Fila.Rows[0]["recCalificacionParcial4"]);
                        }
                        else
                        {
                            this.recCalificacionParcial4 = 0;
                        }

					    if(Fila.Rows[0]["recCalificacionParcialRecuperatorio1"].ToString().Trim().Length > 0)
                        {
                            this.recCalificacionParcialRecuperatorio1 = Convert.ToDecimal(Fila.Rows[0]["recCalificacionParcialRecuperatorio1"]);
                        }
                        else
                        {
                            this.recCalificacionParcialRecuperatorio1 = 0;
                        }

					    if(Fila.Rows[0]["recCalificacionParcialRecuperatorio2"].ToString().Trim().Length > 0)
                        {
                            this.recCalificacionParcialRecuperatorio2 = Convert.ToDecimal(Fila.Rows[0]["recCalificacionParcialRecuperatorio2"]);
                        }
                        else
                        {
                            this.recCalificacionParcialRecuperatorio2 = 0;
                        }

					    if(Fila.Rows[0]["recCalificacionParcialRecuperatorio3"].ToString().Trim().Length > 0)
                        {
                            this.recCalificacionParcialRecuperatorio3 = Convert.ToDecimal(Fila.Rows[0]["recCalificacionParcialRecuperatorio3"]);
                        }
                        else
                        {
                            this.recCalificacionParcialRecuperatorio3 = 0;
                        }

					    if(Fila.Rows[0]["recCalificacionParcialRecuperatorio4"].ToString().Trim().Length > 0)
                        {
                            this.recCalificacionParcialRecuperatorio4 = Convert.ToDecimal(Fila.Rows[0]["recCalificacionParcialRecuperatorio4"]);
                        }
                        else
                        {
                            this.recCalificacionParcialRecuperatorio4 = 0;
                        }

					    if(Fila.Rows[0]["recObservaciones"].ToString().Trim().Length > 0)
                        {
                            this.recObservaciones = Convert.ToString(Fila.Rows[0]["recObservaciones"]);
                        }
                        else
                        {
                            this.recObservaciones = "";
                        }

					    if(Fila.Rows[0]["recFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.recFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["recFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.recFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["recFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.recFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["recFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.recFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["recActivo"].ToString().Trim().Length > 0)
                        {
                            this.recActivo = (Convert.ToInt32(Fila.Rows[0]["recActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.recActivo = false;
                        }
                        
					    if(Fila.Rows[0]["icuId"].ToString().Trim().Length > 0)
                        {
                            this.icuId = Convert.ToInt32(Fila.Rows[0]["icuId"]);
                        }
                        else
                        {
						    this.icuId = 0;
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
                        
					    if(Fila.Rows[0]["usuIdUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.usuIdUltimaModificacion = Convert.ToInt32(Fila.Rows[0]["usuIdUltimaModificacion"]);
                        }
                        else
                        {
						    this.usuIdUltimaModificacion = 0;
                        }


                        if (Fila.Rows[0]["recEvaluacionFinal"].ToString().Trim().Length > 0)
                        {
                            this.recEvaluacionFinal = Convert.ToDecimal(Fila.Rows[0]["recEvaluacionFinal"]);
                        }
                        else
                        {
                            this.recEvaluacionFinal = 0;
                        }


                        if (Fila.Rows[0]["recFechaRegularizaPromociona"].ToString().Trim().Length > 0)
                        {
                            this.recFechaRegularizaPromociona = Convert.ToDateTime(Fila.Rows[0]["recFechaRegularizaPromociona"]);
                        }
                        else
                        {
                            this.recFechaRegularizaPromociona = DateTime.Now;
                        }

                    }
                }
				catch (Exception oError)
                {
                    throw oError;
                }
            }

            public RegistracionCalificaciones(Int32 recId, Decimal recTrabajoPractico, Decimal recTrabajoPracticoRecuperatorio, Decimal recAsistencia, Decimal recCalificacionParcial1, Decimal recCalificacionParcial2, Decimal recCalificacionParcial3, Decimal recCalificacionParcial4, Decimal recCalificacionParcialRecuperatorio1, Decimal recCalificacionParcialRecuperatorio2, Decimal recCalificacionParcialRecuperatorio3, Decimal recCalificacionParcialRecuperatorio4, String recObservaciones, Boolean recActivo, DateTime recFechaHoraCreacion, DateTime recFechaHoraUltimaModificacion, Int32 IicuId, Int32 IconId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.recId = recId;
				    this.recTrabajoPractico = recTrabajoPractico;
				    this.recTrabajoPracticoRecuperatorio = recTrabajoPracticoRecuperatorio;
				    this.recAsistencia = recAsistencia;
				    this.recCalificacionParcial1 = recCalificacionParcial1;
				    this.recCalificacionParcial2 = recCalificacionParcial2;
				    this.recCalificacionParcial3 = recCalificacionParcial3;
				    this.recCalificacionParcial4 = recCalificacionParcial4;
				    this.recCalificacionParcialRecuperatorio1 = recCalificacionParcialRecuperatorio1;
				    this.recCalificacionParcialRecuperatorio2 = recCalificacionParcialRecuperatorio2;
				    this.recCalificacionParcialRecuperatorio3 = recCalificacionParcialRecuperatorio3;
				    this.recCalificacionParcialRecuperatorio4 = recCalificacionParcialRecuperatorio4;
				    this.recObservaciones = recObservaciones;
				    this.recActivo = recActivo;
				    this.recFechaHoraCreacion = recFechaHoraCreacion;
				    this.recFechaHoraUltimaModificacion = recFechaHoraUltimaModificacion;
				    this.icuId = icuId;
				    this.conId = conId;
				    this.usuIdCreacion = usuIdCreacion;
				    this.usuIdUltimaModificacion = usuIdUltimaModificacion;
                    this.recEvaluacionFinal = recEvaluacionFinal;
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
                	Tabla = ocdGestor.EjecutarReader("[RegistracionCalificaciones.ObtenerTodo]", new object[,] {});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerTodoporInscripcionCursado(Int32 icuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionCalificaciones.ObtenerTodoporInscripcionCursado]", new object[,] { { "@icuId", icuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerUno(Int32 recId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[RegistracionCalificaciones.ObtenerUno]", new object[,] {{"@recId", recId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }






            public void Actualizar(Int32 recId, Int32 icuId, Decimal recTrabajoPractico, Decimal recTrabajoPracticoRecuperatorio, Decimal recAsistencia, Decimal recCalificacionParcial1, Decimal recCalificacionParcial2, Decimal recCalificacionParcial3, Decimal recCalificacionParcial4, Decimal recCalificacionParcialRecuperatorio1, Decimal recCalificacionParcialRecuperatorio2, Decimal recCalificacionParcialRecuperatorio3, Decimal recCalificacionParcialRecuperatorio4, Int32 conId, String recObservaciones, Boolean recActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime recFechaHoraCreacion, DateTime recFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionCalificaciones.Actualizar]", new object[,] {{"@recId", recId}, {"@icuId", icuId}, {"@recTrabajoPractico", recTrabajoPractico}, {"@recTrabajoPracticoRecuperatorio", recTrabajoPracticoRecuperatorio}, {"@recAsistencia", recAsistencia}, {"@recCalificacionParcial1", recCalificacionParcial1}, {"@recCalificacionParcial2", recCalificacionParcial2}, {"@recCalificacionParcial3", recCalificacionParcial3}, {"@recCalificacionParcial4", recCalificacionParcial4}, {"@recCalificacionParcialRecuperatorio1", recCalificacionParcialRecuperatorio1}, {"@recCalificacionParcialRecuperatorio2", recCalificacionParcialRecuperatorio2}, {"@recCalificacionParcialRecuperatorio3", recCalificacionParcialRecuperatorio3}, {"@recCalificacionParcialRecuperatorio4", recCalificacionParcialRecuperatorio4}, {"@conId", conId}, {"@recObservaciones", recObservaciones}, {"@recActivo", recActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@recFechaHoraCreacion", recFechaHoraCreacion}, {"@recFechaHoraUltimaModificacion", recFechaHoraUltimaModificacion}, { "@recEvaluacionFinal", recEvaluacionFinal }, { "@recFechaRegularizaPromociona", recFechaRegularizaPromociona } });
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			


            public void Eliminar(Int32 recId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionCalificaciones.Eliminar]", new object[,] {{"@recId", recId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }


                			
            public void Insertar(Int32 icuId, Decimal recTrabajoPractico, Decimal recTrabajoPracticoRecuperatorio, Decimal recAsistencia, Decimal recCalificacionParcial1, Decimal recCalificacionParcial2, Decimal recCalificacionParcial3, Decimal recCalificacionParcial4, Decimal recCalificacionParcialRecuperatorio1, Decimal recCalificacionParcialRecuperatorio2, Decimal recCalificacionParcialRecuperatorio3, Decimal recCalificacionParcialRecuperatorio4, Int32 conId, String recObservaciones, Boolean recActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime recFechaHoraCreacion, DateTime recFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionCalificaciones.Insertar]", new object[,] {{"@icuId", icuId}, {"@recTrabajoPractico", recTrabajoPractico}, {"@recTrabajoPracticoRecuperatorio", recTrabajoPracticoRecuperatorio}, {"@recAsistencia", recAsistencia}, {"@recCalificacionParcial1", recCalificacionParcial1}, {"@recCalificacionParcial2", recCalificacionParcial2}, {"@recCalificacionParcial3", recCalificacionParcial3}, {"@recCalificacionParcial4", recCalificacionParcial4}, {"@recCalificacionParcialRecuperatorio1", recCalificacionParcialRecuperatorio1}, {"@recCalificacionParcialRecuperatorio2", recCalificacionParcialRecuperatorio2}, {"@recCalificacionParcialRecuperatorio3", recCalificacionParcialRecuperatorio3}, {"@recCalificacionParcialRecuperatorio4", recCalificacionParcialRecuperatorio4}, {"@conId", conId}, {"@recObservaciones", recObservaciones}, {"@recActivo", recActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@recFechaHoraCreacion", recFechaHoraCreacion}, {"@recFechaHoraUltimaModificacion", recFechaHoraUltimaModificacion}, { "@recEvaluacionFinal", recEvaluacionFinal }, { "@recFechaRegularizaPromociona", recFechaRegularizaPromociona } });
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
                    if(this.recId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[RegistracionCalificaciones.Actualizar]", new object[,] {{"@recId", recId}, {"@icuId", icuId}, {"@recTrabajoPractico", recTrabajoPractico}, {"@recTrabajoPracticoRecuperatorio", recTrabajoPracticoRecuperatorio}, {"@recAsistencia", recAsistencia}, {"@recCalificacionParcial1", recCalificacionParcial1}, {"@recCalificacionParcial2", recCalificacionParcial2}, {"@recCalificacionParcial3", recCalificacionParcial3}, {"@recCalificacionParcial4", recCalificacionParcial4}, {"@recCalificacionParcialRecuperatorio1", recCalificacionParcialRecuperatorio1}, {"@recCalificacionParcialRecuperatorio2", recCalificacionParcialRecuperatorio2}, {"@recCalificacionParcialRecuperatorio3", recCalificacionParcialRecuperatorio3}, {"@recCalificacionParcialRecuperatorio4", recCalificacionParcialRecuperatorio4}, {"@conId", conId}, {"@recObservaciones", recObservaciones}, {"@recActivo", recActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@recFechaHoraCreacion", recFechaHoraCreacion}, {"@recFechaHoraUltimaModificacion", recFechaHoraUltimaModificacion}, { "@recEvaluacionFinal", recEvaluacionFinal }, { "@recFechaRegularizaPromociona", recFechaRegularizaPromociona } });
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
                    if(this.recId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[RegistracionCalificaciones.Eliminar]", new object[,] {{"@recId", recId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[RegistracionCalificaciones.Insertar]", new object[,] {{"@icuId", icuId}, {"@recTrabajoPractico", recTrabajoPractico}, {"@recTrabajoPracticoRecuperatorio", recTrabajoPracticoRecuperatorio}, {"@recAsistencia", recAsistencia}, {"@recCalificacionParcial1", recCalificacionParcial1}, {"@recCalificacionParcial2", recCalificacionParcial2}, {"@recCalificacionParcial3", recCalificacionParcial3}, {"@recCalificacionParcial4", recCalificacionParcial4}, {"@recCalificacionParcialRecuperatorio1", recCalificacionParcialRecuperatorio1}, {"@recCalificacionParcialRecuperatorio2", recCalificacionParcialRecuperatorio2}, {"@recCalificacionParcialRecuperatorio3", recCalificacionParcialRecuperatorio3}, {"@recCalificacionParcialRecuperatorio4", recCalificacionParcialRecuperatorio4}, {"@conId", conId}, {"@recObservaciones", recObservaciones}, {"@recActivo", recActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@recFechaHoraCreacion", recFechaHoraCreacion}, {"@recFechaHoraUltimaModificacion", recFechaHoraUltimaModificacion}, { "@recEvaluacionFinal", recEvaluacionFinal }, { "@recFechaRegularizaPromociona", recFechaRegularizaPromociona } });
                }
                catch (Exception oError)
                {
                	throw oError;
                }
                return IdMax;
            }


            //public void ActualizarCalificacionExamen(Int32 recId, Int32 icuId, Decimal recCalificacionExamen)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[RegistracionCalificaciones.ActualizarCalificacionExamen]", new object[,] { { "@recId", recId }, { "@icuId", icuId }, { "@recCalificacionExamen", recCalificacionExamen } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            public void ActualizarCalificacionExamen(Int32 icuId, Decimal recCalificacionExamen)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionCalificaciones.ActualizarCalificacionExamen]", new object[,] { { "@icuId", icuId }, { "@recCalificacionExamen", recCalificacionExamen } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }


            #endregion
        }
    }
}