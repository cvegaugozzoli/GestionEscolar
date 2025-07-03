using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class Departamento
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            private int _CODDEPTO;
            public int CODDEPTO
            {
                get { return _CODDEPTO; }
                set { _CODDEPTO = value; }
            }


            private String _NOMBREDEPTO;
            public String NOMBREDEPTO
            {
                get { return _NOMBREDEPTO; }
                set { _NOMBREDEPTO = value; }
            }


            public Departamento()
            {
                try
                {
                    this.CODDEPTO = 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }



            public DataTable ObtenerLista(string PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Departamento.ObtenerLista]", new object[,] { {

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


            public DataTable ObtenerLista2(string PrimerItem,int SegundoItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Departamento.ObtenerListaConCodPro]", new object[,] { {

                     "@PrimerItem",
                        PrimerItem
                    },
                    {
                     "@SegundoItem",
                        SegundoItem
                    },
                    });
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
