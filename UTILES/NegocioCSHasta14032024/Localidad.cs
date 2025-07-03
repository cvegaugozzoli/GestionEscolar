using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class Localidad
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            private int _LOC_ID;
            public int LOC_ID
            {
                get { return _LOC_ID; }
                set { _LOC_ID = value; }
            }
            private int _LOC_COD;
            public int LOC_COD
            {
                get { return _LOC_COD; }
                set { _LOC_COD = value; }
            }
            private int _LOC_DEP_COD;
            public int LOC_DEP_COD
            {
                get { return _LOC_DEP_COD; }
                set { _LOC_DEP_COD = value; }
            }
            private int _LOC_PROVI_ID;
            public int LOC_PROVI_ID
            {
                get { return _LOC_PROVI_ID; }
                set { _LOC_PROVI_ID = value; }
            }
            private int _LOC_CP;
            public int LOC_CP
            {
                get { return _LOC_CP; }
                set { _LOC_CP = value; }
            }

            private String _LOC_DESCRIPCION;
            public String LOC_DESCRIPCION
            {
                get { return _LOC_DESCRIPCION; }
                set { _LOC_DESCRIPCION = value; }
            }


            public Localidad()
            {
                try
                {
                    this.LOC_ID = 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public DataTable LOCALIDADES_TraeporDeptoId_PciaId(int PrimerItem, int SegundoItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[LOCALIDADES_TraeporDeptoId_PciaId]", new object[,] { {

                     "@PrimerItem",
                        PrimerItem
                    },
{

                     "@SegundoItem",
                        SegundoItem
                    }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable LOCALIDADES_TraeporDeptoId_PciaId(string PrimerItem, int SegundoItem, int TercerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[LOCALIDADES_TraeporDeptoId_PciaId]", new object[,] { {

                     "@PrimerItem",
                        PrimerItem
                    },
                    {
                     "@SegundoItem",
                        SegundoItem
                    },
                    {
                     "@TerceroItem",
                       TercerItem

                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerLista(String PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Localidad.ObtenerLista]", new object[,] { {

                     "@PrimerItem",
                        PrimerItem
                    },

                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable LOCALIDADES_TraeporCod(int PrimerItem, int SegundoItem, int TercerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[LOCALIDADES_TraeporCod]", new object[,] { {

                     "@PrimerItem",
                        PrimerItem
                    },
                    {
                     "@SegundoItem",
                        SegundoItem

                    },
                     {
                     "@TercerItem",
                       TercerItem

                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }
        }
    }
}
