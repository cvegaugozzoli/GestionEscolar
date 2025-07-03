using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class ArchivoBanco
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _arbid;
            public Int32 arbid { get { return _arbid; } set { _arbid = value; } }

            private String _barra;
            public String barra { get { return _barra; } set { _barra = value; } }

            private Int32 _codcole;
            public Int32 codcole { get { return _codcole; } set { _codcole = value; } }

            private Int32 _codalumno;
            public Int32 codalumno { get { return _codalumno; } set { _codalumno = value; } }

            private String _apellidoynombre;
            public String apellidoynombre { get { return _apellidoynombre; } set { _apellidoynombre = value; } }

            private String _telef;
            public String telef { get { return _telef; } set { _telef = value; } }

            private String _dni;
            public String dni { get { return _dni; } set { _dni = value; } }

            private String _numcuota;
            public String numcuota { get { return _numcuota; } set { _numcuota = value; } }

            private String _privto;
            public String privto { get { return _privto; } set { _privto = value; } }

            private Decimal _priimporte;
            public Decimal priimporte { get { return _priimporte; } set { _priimporte = value; } }

            private String _segvto;
            public String segvto { get { return _segvto; } set { _segvto = value; } }

            private Decimal _segimporte;
            public Decimal segimporte { get { return _segimporte; } set { _segimporte = value; } }

            private String _tervto;
            public String tervto { get { return _tervto; } set { _tervto = value; } }

            private Decimal _impabierto;
            public Decimal impabierto { get { return _impabierto; } set { _impabierto = value; } }

            private String _concepto;
            public String concepto { get { return _concepto; } set { _concepto = value; } }

            private String _curso;
            public String curso { get { return _curso; } set { _curso = value; } }

            private Int32 _aniolectivo;
            public Int32 aniolectivo { get { return _aniolectivo; } set { _aniolectivo = value; } }

            private String _beca;
            public String beca { get { return _beca; } set { _beca = value; } }

            private String _Cuerpo;
            public String Cuerpo { get { return _Cuerpo; } set { _Cuerpo = value; } }
            

            #endregion

            #region Constructores

            public ArchivoBanco() { try { this.arbid = 0; } catch (Exception oError) { throw oError; } }

            public ArchivoBanco(Int32 arbid, String barra, Int32 codcole, Int32 codalumno, String apellidoynombre, String telef, String dni, String numcuota, String privto, Decimal priimporte, String segvto, Decimal segimporte, String tervto, Decimal impabierto, String concepto, String curso, Int32 aniolectivo, String beca, String Cuerpo)
            {
                try
                {
                    this.arbid = arbid;
                    this.barra = barra;
                    this.codcole = codcole;
                    this.codalumno = codalumno;
                    this.apellidoynombre = apellidoynombre;
                    this.telef = telef;
                    this.dni = dni;
                    this.numcuota = numcuota;
                    this.privto = privto;
                    this.priimporte = priimporte;
                    this.segvto = segvto;
                    this.segimporte = segimporte;
                    this.tervto = tervto;
                    this.impabierto = impabierto;
                    this.concepto = concepto;
                    this.curso = curso;
                    this.Cuerpo = Cuerpo;
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            #endregion

            #region Metodos

            public Int32 Insertar()
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ArchivoBanco.Insertar]", new object[,] { { "@barra", barra }, { "@codcole", codcole }, { "@codalumno", codalumno }, { "@apellidoynombre", apellidoynombre }, { "@telef", telef }, { "@dni", dni }, { "@numcuota", numcuota }, { "@privto", privto }, { "@priimporte", priimporte }, { "@segvto", segvto }, { "@segimporte", segimporte }, { "@tervto", tervto }, { "@impabierto", impabierto }, { "@concepto", concepto }, { "@curso", curso }, { "@aniolectivo", aniolectivo }, { "@beca", beca }, { "@Cuerpo", Cuerpo } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }


            public Int32 InsertarCuerpo()
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ArchivoBanco.InsertarCuerpo]", new object[,] { { "@Cuerpo", Cuerpo } });
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
                    Tabla = ocdGestor.EjecutarReader("[ArchivoBanco.ObtenerTodos]", new object[,] { });
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
                    Tabla = ocdGestor.EjecutarReader("[ArchivoBanco.ObtenerTotales]", new object[,] { });
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
                    ocdGestor.EjecutarNonQuery("[ArchivoBanco.Eliminar]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar2()
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ArchivoBancoP.Eliminar]", new object[,] { });
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