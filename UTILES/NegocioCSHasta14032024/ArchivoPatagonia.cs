using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class ArchivoPatagonia
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _arpId;
            public Int32 arpId { get { return _arpId; } set { _arpId = value; } }

            private String _arpCabecera;
            public String arpCabecera { get { return _arpCabecera; } set { _arpCabecera = value; } }

            private String _arpDetalle;
            public String arpDetalle { get { return _arpDetalle; } set { _arpDetalle = value; } }

            private Int32 _arpCodAlumno;
            public Int32 arpCodAlumno { get { return _arpCodAlumno; } set { _arpCodAlumno = value; } }

            private Int32 _arpCole;
            public Int32 arpCole { get { return _arpCole; } set { _arpCole = value; } }

            private String _arpApeyNom;
            public String arpApeyNom { get { return _arpApeyNom; } set { _arpApeyNom = value; } }

            private String _arpDni;
            public String arpDni { get { return _arpDni; } set { _arpDni = value; } }

            private String _arpNumCuota;
            public String arpNumCuota { get { return _arpNumCuota; } set { _arpNumCuota = value; } }

            private Decimal _arpImporte;
            public Decimal arpImporte { get { return _arpImporte; } set { _arpImporte = value; } }

            private String _arpCurso;
            public String arpCurso { get { return _arpCurso; } set { _arpCurso = value; } }

            private int _arpAnioLectivo;
            public int arpAnioLectivo { get { return _arpAnioLectivo; } set { _arpAnioLectivo = value; } }

            private string _arpFinal;
            public string arpFinal { get { return _arpFinal; } set { _arpFinal = value; } }

           


            #endregion

            #region Constructores

            public ArchivoPatagonia() { try { this.arpId = 0; } catch (Exception oError) { throw oError; } }

            //public ArchivoPatagonia(Int32 arbid, String barra, Int32 codcole, Int32 codalumno, String apellidoynombre, String telef, String dni, String numcuota, String privto, Decimal priimporte, String segvto, Decimal segimporte, String tervto, Decimal impabierto, String concepto, String curso, Int32 aniolectivo, String beca, String Cuerpo)
            //{
            //    try
            //    {
            //        this.arbid = arbid;
            //        this.barra = barra;
            //        this.codcole = codcole;
            //        this.codalumno = codalumno;
            //        this.apellidoynombre = apellidoynombre;
            //        this.telef = telef;
            //        this.dni = dni;
            //        this.numcuota = numcuota;
            //        this.privto = privto;
            //        this.priimporte = priimporte;
            //        this.segvto = segvto;
            //        this.segimporte = segimporte;
            //        this.tervto = tervto;
            //        this.impabierto = impabierto;
            //        this.concepto = concepto;
            //        this.curso = curso;
            //        this.Cuerpo = Cuerpo;
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}
            #endregion

            #region Metodos
            public DataTable ArchivoPatagoniaObtenerporVarios( Int32 conId, Int32 conAnioLectivo,Int32 CuotaDesde)

            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ARCHIVOPATAGONIA.ObtenerporVarios]", new object[,] {  { "@conId", conId }, { "@conAnioLectivo", conAnioLectivo }, { "@CuotaDesde", CuotaDesde } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;

            }

 public DataTable ObtenerporVariosxDisparos( Int32 conId, Int32 conAnioLectivo,Int32 CuotaDesde, Int32 Disparos )

            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ARCHIVOPATAGONIA.ObtenerporVariosxDisparos]", new object[,] {  { "@conId", conId }, { "@conAnioLectivo", conAnioLectivo }, { "@CuotaDesde", CuotaDesde } , { "@Disparos", Disparos } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;

            }
            public Int32 Insertar()
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ArchivoPatagonia.Insertar]", new object[,]
                    { { "@arpCabecera", arpCabecera }, { "@arpDetalle", arpDetalle },{ "@arpCodAlumno", arpCodAlumno }
                        ,{ "@arpCole", arpCole },{ "@arpApeyNom", arpApeyNom }, { "@arpDni", arpDni }, { "@arpNumCuota ", arpNumCuota  },
                    { "@arpImporte", arpImporte }, { "@arpCurso", arpCurso }, { "@arpAnioLectivo", arpAnioLectivo },
                    { "@arpFinal", arpFinal },});
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }


            public Int32 InsertarDetalle()
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ArchivoPatagonia.InsertarDetalle]", new object[,] { { "@arpDetalle", arpDetalle } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }

            public Int32 InsertarCabecera()
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ArchivoPatagonia.InsertarCabecera]", new object[,] { { "@arpCabecera", arpCabecera } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }
            public DataTable ObtenerTodo()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ArchivoPatagonia.ObtenerTodos]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerTotales()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ARCHIVOPATAGONIA.ObtenerTotales]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            //public void Actualizar(Int32 banId, String banCodigo, String banNombre, String banSucursal, Boolean banActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime banFechaHoraCreacion, DateTime banFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Bancos.Actualizar]", new object[,] { { "@banId", banId }, { "@banCodigo", banCodigo }, { "@banNombre", banNombre }, { "@banSucursal", banSucursal }, { "@banActivo", banActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@banFechaHoraCreacion", banFechaHoraCreacion }, { "@banFechaHoraUltimaModificacion", banFechaHoraUltimaModificacion } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}


            public void Eliminar()
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ArchivoPatagonia.Eliminar]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

      

            //public void Insertar(String banCodigo, String banNombre, String banSucursal, Boolean banActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime banFechaHoraCreacion, DateTime banFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Bancos.Insertar]", new object[,] { { "@banCodigo", banCodigo }, { "@banNombre", banNombre }, { "@banSucursal", banSucursal }, { "@banActivo", banActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@banFechaHoraCreacion", banFechaHoraCreacion }, { "@banFechaHoraUltimaModificacion", banFechaHoraUltimaModificacion } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Actualizar()
            //{
            //    try
            //    {
            //        if (this.banId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Bancos.Actualizar]", new object[,] { { "@banId", banId }, { "@banCodigo", banCodigo }, { "@banNombre", banNombre }, { "@banSucursal", banSucursal }, { "@banActivo", banActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@banFechaHoraCreacion", banFechaHoraCreacion }, { "@banFechaHoraUltimaModificacion", banFechaHoraUltimaModificacion } });
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Eliminar()
            //{
            //    try
            //    {
            //        if (this.banId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Bancos.Eliminar]", new object[,] { { "@banId", banId } });
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}




            #endregion
        }
    }
}