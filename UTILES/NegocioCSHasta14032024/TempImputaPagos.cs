using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class TempImputaPagos
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _temId; 
			public Int32 temId { get { return _temId; } set { _temId = value; } }

            private String _temNombre;
            public String temNombre { get { return _temNombre; } set { _temNombre = value; } }

            private String _temConcepto;
            public String temConcepto { get { return _temConcepto; } set { _temConcepto = value; } }

            private Decimal _temImporte; 
			public Decimal temImporte { get { return _temImporte; } set { _temImporte = value; } }

            private Int32 _temNroCuota; 
			public Int32 temNroCuota { get { return _temNroCuota; } set { _temNroCuota = value; } }

            private DateTime _temFechaPago; 
			public DateTime temFechaPago { get { return _temFechaPago; } set { _temFechaPago = value; } }

            private String _temImputa;
            public String temImputa { get { return _temImputa; } set { _temImputa = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private String _InstNombre;
            public String InstNombre { get { return _InstNombre; } set { _InstNombre = value; } }
            
            private String _temObserv;
            public String temObserv { get { return _temObserv; } set { _temObserv = value; } }
            #endregion

            #region Constructores

            public TempImputaPagos() { try { this.temId = 0; } catch (Exception oError) { throw oError; } }            

   //         public TempImputaPagos(Int32 temId)
			//{
   //             try
   //             {
   //                 Fila = new DataTable();
   //                 Fila = ocdGestor.EjecutarReader("[Becas.ObtenerUno]", new object[,] {{"@becId", becId}});

			//	    if(Fila.Rows.Count > 0)
   //                 {
			//		    if(Fila.Rows[0]["becId"].ToString().Trim().Length > 0)
   //                     {
   //                         this.becId = Convert.ToInt32(Fila.Rows[0]["becId"]);
   //                     }
   //                     else
   //                     {
   //                         this.becId = 0;
   //                     }

			//		    if(Fila.Rows[0]["becInteres"].ToString().Trim().Length > 0)
   //                     {
   //                         this.becInteres = Convert.ToDecimal(Fila.Rows[0]["becInteres"]);
   //                     }
   //                     else
   //                     {
   //                         this.becInteres = 0;
   //                     }

			//		    if(Fila.Rows[0]["becNombre"].ToString().Trim().Length > 0)
   //                     {
   //                         this.becNombre = Convert.ToString(Fila.Rows[0]["becNombre"]);
   //                     }
   //                     else
   //                     {
   //                         this.becNombre = "";
   //                     }

			//		    if(Fila.Rows[0]["becFechaHoraCreacion"].ToString().Trim().Length > 0)
   //                     {
   //                         this.becFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["becFechaHoraCreacion"]);
   //                     }
   //                     else
   //                     {
   //                         this.becFechaHoraCreacion = DateTime.Now;
   //                     }

			//		    if(Fila.Rows[0]["becFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
   //                     {
   //                         this.becFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["becFechaHoraUltimaModificacion"]);
   //                     }
   //                     else
   //                     {
   //                         this.becFechaHoraUltimaModificacion = DateTime.Now;
   //                     }

			//		    if(Fila.Rows[0]["becActivo"].ToString().Trim().Length > 0)
   //                     {
   //                         this.becActivo = (Convert.ToInt32(Fila.Rows[0]["becActivo"]) == 1 ? true : false);
   //                     }
   //                     else
   //                     {
			//			    this.becActivo = false;
   //                     }
                        
			//		    if(Fila.Rows[0]["usuIdCreacion"].ToString().Trim().Length > 0)
   //                     {
   //                         this.usuIdCreacion = Convert.ToInt32(Fila.Rows[0]["usuIdCreacion"]);
   //                     }
   //                     else
   //                     {
			//			    this.usuIdCreacion = 0;
   //                     }
                        
			//		    if(Fila.Rows[0]["usuIdUltimaModificacion"].ToString().Trim().Length > 0)
   //                     {
   //                         this.usuIdUltimaModificacion = Convert.ToInt32(Fila.Rows[0]["usuIdUltimaModificacion"]);
   //                     }
   //                     else
   //                     {
			//			    this.usuIdUltimaModificacion = 0;
   //                     }
                        
			//		}
   //             }
			//	catch (Exception oError)
   //             {
   //                 throw oError;
   //             }
   //         }

   //         public Becas(Int32 becId, Decimal becInteres, String becNombre, Boolean becActivo, DateTime becFechaHoraCreacion, DateTime becFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			//{
   //             try
   //             {
			//	    this.becId = becId;
			//	    this.becInteres = becInteres;
			//	    this.becNombre = becNombre;
			//	    this.becActivo = becActivo;
			//	    this.becFechaHoraCreacion = becFechaHoraCreacion;
			//	    this.becFechaHoraUltimaModificacion = becFechaHoraUltimaModificacion;
			//	    this.usuIdCreacion = usuIdCreacion;
			//	    this.usuIdUltimaModificacion = usuIdUltimaModificacion;
   //             }
			//    catch (Exception oError)
   //             {
   //                 throw oError;
   //             }
   //         }
            #endregion

            #region Metodos

                			             			
            public DataTable ObtenerTodo()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[TempImputaPagos.ObtenerTodo]", new object[,] {});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
                			

                			
            public void EliminarTodo()
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[TempImputaPagos.EliminarTodo]", new object[,] {});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }

            public Int32 Insertar(String temNombre, String temConcepto, Decimal temImporte, Int32 temNroCuota, DateTime temFechaPago, String temImputa, String InstNombre, String Curso,String Observaciones)
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Temp_ImputaPagos.Insertar]", new object[,] { { "@temNombre", temNombre }, { "@temConcepto", temConcepto }, { "@temImporte", temImporte }, { "@temNroCuota", temNroCuota }, { "@temFechaPago", temFechaPago }, { "@temImputa", temImputa }, { "@InstNombre", InstNombre }, { "@temCurso", Curso }, { "@temObserv", Observaciones } });

                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }

            //public void Insertar(Decimal becInteres, String becNombre, Boolean becActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime becFechaHoraCreacion, DateTime becFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Becas.Insertar]", new object[,] {{"@becInteres", becInteres}, {"@becNombre", becNombre}, {"@becActivo", becActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@becFechaHoraCreacion", becFechaHoraCreacion}, {"@becFechaHoraUltimaModificacion", becFechaHoraUltimaModificacion}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}



            //public Int32 Insertar()
            //{
            //    Int32 IdMax;
            //    try
            //    {
            //        IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Becas.Insertar]", new object[,] {{"@becInteres", becInteres}, {"@becNombre", becNombre}, {"@becActivo", becActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@becFechaHoraCreacion", becFechaHoraCreacion}, {"@becFechaHoraUltimaModificacion", becFechaHoraUltimaModificacion}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //    return IdMax;
            //}


            #endregion
        }
    }
}