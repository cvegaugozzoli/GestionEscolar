using System;
using System.Xml;
using System.Security.Cryptography;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Datos
    {
        public class Gestor
        {
            string _ConexionCadena;
            int _TiempoEjecucionSQL;

            public Gestor()
            {
                this._ConexionCadena = GetParValue();
                this._TiempoEjecucionSQL = 300;
            }

            public Gestor(string ConexionCadena, int TiempoEjecucionSQL)
            {
                this._ConexionCadena = ConexionCadena;
                this._TiempoEjecucionSQL = TiempoEjecucionSQL;
            }

            public object ConexionCadena
            {
                get
                {
                    return this._ConexionCadena;
                }
            }

            private string GetParValue()
            {
                return System.Configuration.ConfigurationSettings.AppSettings["ConexionCadena"].ToString();
            }

            public DataTable DataReaderToDataTable(OleDbDataReader TablaDataReader, string Sql)
            {
                DataTable Tabla = new DataTable();

                try
                {
                    // ESQUEMA DE LA TABLA
                    DataTable EsquemaTabla = new DataTable();
                    EsquemaTabla = TablaDataReader.GetSchemaTable();

                    // CREAR EL MISMO ESQUEMA EN EL DATATABLE
                    for (int i = 0; i <= EsquemaTabla.Rows.Count - 1; i++)
                    {
                        DataRow EsquemaColumna = EsquemaTabla.Rows[i];

                        string NombreColumna = EsquemaColumna["ColumnName"].ToString();

                        // Si la columna no tiene nombre debe mostrar un mensaje de error
                        if ((NombreColumna.Trim().Length == 0))
                        {
                            NombreColumna = ("SinNombre" + i.ToString());
                        }

                        // CREAR COLUMNA PARA EL DATA TABLE
                        DataColumn ColumnaDataTable = new DataColumn();
                        ColumnaDataTable.Caption = NombreColumna;
                        ColumnaDataTable.ColumnName = NombreColumna;
                        ColumnaDataTable.DataType = Type.GetType(EsquemaColumna["DataType"].ToString());

                        // AGREGAR COLUMNA AL DATA TABLE
                        if (!Tabla.Columns.Contains(ColumnaDataTable.ColumnName))
                        {
                            Tabla.Columns.Add(ColumnaDataTable);
                        }
                    }

                    // AGREGAR DATOS AL DATA TABLE
                    while (TablaDataReader.Read())
                    {
                        // CREAR NUEVA FILA
                        DataRow FilaDataTable = Tabla.NewRow();

                        // RECORRER LOS CAMPOS
                        for (int i = 0; i <= TablaDataReader.FieldCount - 1; i++)
                        {
                            // INSERTAR EL ACTUAL VALUE EN LA FILA
                            FilaDataTable[TablaDataReader.GetName(i)] = TablaDataReader.GetValue(i);
                        }

                        // INSERTAR LA FILA EN LA TABLA
                        Tabla.Rows.Add(FilaDataTable);
                    }

                    // CERRAR EL DATA READER
                    TablaDataReader.Close();
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable EjecutarReader(string strNombreSP, object[,] arr)
            {
                DataTable oDT = new DataTable();
                string ConexionCadena = GetParValue();

                using (OleDbConnection oCnx = new OleDbConnection(ConexionCadena))
                {
                    using (OleDbCommand Comando = new OleDbCommand(strNombreSP, oCnx))
                    {
                        oCnx.Open();

                        try
                        {
                            #region "Parametros"
                            Comando.Parameters.Clear();
                            OleDbParameter oPar;
                            for (int i = 0; (i <= arr.Length / 2 - 1); i++)
                            {
                                if (arr[i, 1].ToString().Length >= 10)
                                {
                                    if (arr[i, 1].ToString().Substring(0, 10) == "01/01/0001")
                                    {
                                        arr[i, 1] = DateTime.Now;
                                    }
                                }

                                oPar = new OleDbParameter(arr[i, 0].ToString(), arr[i, 1]);
                                Comando.Parameters.Add(oPar);
                                oPar = null;
                            }
                            #endregion

                            Comando.CommandType = CommandType.StoredProcedure;
                            Comando.CommandTimeout = _TiempoEjecucionSQL;
                            OleDbDataReader oR = Comando.ExecuteReader();
                            oDT = DataReaderToDataTable(oR, strNombreSP);
                            oR = null;
                        }
                        catch (Exception oError)
                        {
                            throw oError;
                        }
                        finally
                        {
                            oCnx.Close();
                        }
                    }
                }

                return oDT;
            }

            public Int32 EjecutarNonQueryRetornaId2(string strNombreSP, object[,] arr)
            {
                int IdRetorno = 0;
                string ConexionCadena = GetParValue();

                using (OleDbConnection oCnx = new OleDbConnection(ConexionCadena))
                {
                    using (OleDbCommand Comando = new OleDbCommand(strNombreSP, oCnx))
                    {
                        oCnx.Open();

                        try
                        {
                            #region "Parametros"
                            Comando.Parameters.Clear();
                            OleDbParameter oPar;
                            for (int i = 0; (i <= arr.Length / 2 - 1); i++)
                            {
                                if (arr[i, 1].ToString().Length >= 10)
                                {
                                    if ((arr[i, 1].ToString().Substring(0, 10) == "01/01/0001") || ((arr[i, 1].ToString().Substring(0, 10) == null)) || ((arr[i, 1].ToString().Substring(0, 8) == "1/1/0001")) || ((arr[i, 1].ToString().Substring(0, 10) == "1/1/0001 00:00:00")))
                                    {
                                        arr[i, 1] = null;
                                    }
                                }

                                oPar = new OleDbParameter(arr[i, 0].ToString(), arr[i, 1]);
                                Comando.Parameters.Add(oPar);
                                oPar = null;
                            }
                            #endregion


                            Comando.CommandType = CommandType.StoredProcedure;
                            Comando.CommandTimeout = _TiempoEjecucionSQL;
                            IdRetorno = Convert.ToInt32(Comando.ExecuteScalar());
                        }
                        catch (Exception oError)
                        {
                            throw oError;
                        }
                        finally
                        {
                            oCnx.Close();
                        }
                    }
                }

                return IdRetorno;
            }





            public void EjecutarNonQuery2(string strNombreSP, object[,] arr)
            {
                string ConexionCadena = GetParValue();

                using (OleDbConnection oCnx = new OleDbConnection(ConexionCadena))
                {
                    using (OleDbCommand Comando = new OleDbCommand(strNombreSP, oCnx))
                    {
                        oCnx.Open();

                        try
                        {
                            #region "Parametros"
                            Comando.Parameters.Clear();
                            OleDbParameter oPar;
                            for (int i = 0; (i <= arr.Length / 2 - 1); i++)
                            {

                                if (arr[i, 1].ToString().Length >= 10)
                                {
                                    if ((arr[i, 1].ToString().Substring(0, 10) == "01/01/0001") || ((arr[i, 1].ToString().Substring(0, 10) == null)) || ((arr[i, 1].ToString().Substring(0, 8) == "1/1/0001")) || ((arr[i, 1].ToString().Substring(0, 10) == "1/1/0001 00:00:00")))
                                    {
                                        arr[i, 1] = null;
                                    }
                                }



                                oPar = new OleDbParameter(arr[i, 0].ToString(), arr[i, 1]);
                                Comando.Parameters.Add(oPar);
                                oPar = null;
                            }
                            #endregion

                            Comando.CommandType = CommandType.StoredProcedure;
                            Comando.CommandTimeout = _TiempoEjecucionSQL;
                            Comando.ExecuteNonQuery();
                        }
                        catch (Exception oError)
                        {
                            throw oError;
                        }
                        finally
                        {
                            oCnx.Close();
                        }
                    }
                }
            }



            public DataTable EjecutarReader(string strNombreSP)
            {
                DataTable oDT = new DataTable();
                string ConexionCadena = GetParValue();

                using (OleDbConnection oCnx = new OleDbConnection(ConexionCadena))
                {
                    using (OleDbCommand Comando = new OleDbCommand(strNombreSP, oCnx))
                    {
                        oCnx.Open();

                        try
                        {
                            Comando.CommandType = CommandType.StoredProcedure;
                            Comando.CommandTimeout = _TiempoEjecucionSQL;
                            OleDbDataReader oR = Comando.ExecuteReader();
                            oDT = DataReaderToDataTable(oR, strNombreSP);
                            oR = null;
                        }
                        catch (Exception oError)
                        {
                            throw oError;
                        }
                        finally
                        {
                            oCnx.Close();
                        }
                    }
                }

                return oDT;
            }

            public DataTable EjecutarReaderSql(string SQL)
            {
                DataTable oDT = new DataTable();
                string ConexionCadena = GetParValue();

                using (OleDbConnection oCnx = new OleDbConnection(ConexionCadena))
                {
                    using (OleDbCommand Comando = new OleDbCommand(SQL, oCnx))
                    {
                        oCnx.Open();

                        try
                        {
                            Comando.CommandType = CommandType.Text;
                            Comando.CommandTimeout = _TiempoEjecucionSQL;
                            OleDbDataReader oR = Comando.ExecuteReader();
                            oDT = DataReaderToDataTable(oR, SQL);
                            oR = null;
                        }
                        catch (Exception oError)
                        {
                            throw oError;
                        }
                        finally
                        {
                            oCnx.Close();
                        }
                    }
                }

                return oDT;
            }

            public Int32 EjecutarNonQueryRetornaId(string strNombreSP, object[,] arr)
            {
                int IdRetorno = 0;
                string ConexionCadena = GetParValue();

                using (OleDbConnection oCnx = new OleDbConnection(ConexionCadena))
                {
                    using (OleDbCommand Comando = new OleDbCommand(strNombreSP, oCnx))
                    {
                        oCnx.Open();

                        try
                        {
                            #region "Parametros"
                            Comando.Parameters.Clear();
                            OleDbParameter oPar;
                            for (int i = 0; (i <= arr.Length / 2 - 1); i++)
                            {
                                if (arr[i, 1].ToString().Length >= 10)
                                {
                                    if (arr[i, 1].ToString().Substring(0, 10) == "01/01/0001")
                                    {
                                        arr[i, 1] = DateTime.Now;
                                    }
                                }

                                oPar = new OleDbParameter(arr[i, 0].ToString(), arr[i, 1]);
                                Comando.Parameters.Add(oPar);
                                oPar = null;
                            }
                            #endregion

                            Comando.CommandType = CommandType.StoredProcedure;
                            Comando.CommandTimeout = _TiempoEjecucionSQL;
                            IdRetorno = Convert.ToInt32(Comando.ExecuteScalar());
                        }
                        catch (Exception oError)
                        {
                            throw oError;
                        }
                        finally
                        {
                            oCnx.Close();
                        }
                    }
                }

                return IdRetorno;
            }

            public void EjecutarNonQuery(string strNombreSP, object[,] arr)
            {
                string ConexionCadena = GetParValue();

                using (OleDbConnection oCnx = new OleDbConnection(ConexionCadena))
                {
                    using (OleDbCommand Comando = new OleDbCommand(strNombreSP, oCnx))
                    {
                        oCnx.Open();

                        try
                        {
                            #region "Parametros"
                            Comando.Parameters.Clear();
                            OleDbParameter oPar;
                            for (int i = 0; (i <= arr.Length / 2 - 1); i++)
                            {
                                oPar = new OleDbParameter(arr[i, 0].ToString(), arr[i, 1]);
                                Comando.Parameters.Add(oPar);
                                oPar = null;
                            }
                            #endregion

                            Comando.CommandType = CommandType.StoredProcedure;
                            Comando.CommandTimeout = _TiempoEjecucionSQL;
                            Comando.ExecuteNonQuery();
                        }
                        catch (Exception oError)
                        {
                            throw oError;
                        }
                        finally
                        {
                            oCnx.Close();
                        }
                    }
                }
            }

            public void EjecutarNonQuerySinParametros(string strNombreSP)
            {
                string ConexionCadena = GetParValue();

                using (OleDbConnection oCnx = new OleDbConnection(ConexionCadena))
                {
                    using (OleDbCommand Comando = new OleDbCommand(strNombreSP, oCnx))
                    {
                        oCnx.Open();

                        try
                        {
                            Comando.CommandType = CommandType.StoredProcedure;
                            Comando.CommandTimeout = _TiempoEjecucionSQL;
                            Comando.ExecuteNonQuery();
                        }
                        catch (Exception oError)
                        {
                            throw oError;
                        }
                        finally
                        {
                            oCnx.Close();
                        }
                    }
                }
            }
        }

        public class Utiles
        {
            private static string Desencriptar(string Cadena)
            {
                string textDecrypt = String.Empty;
                try
                {
                    // RijndaelManaged
                    string key = "Rdy/obTlKObAUKni/+R+EQ7O0H/vMP66Srsnrr7U9gY=";
                    SymmetricAlgorithm algorithm = new RijndaelManaged();
                    algorithm.Key = Convert.FromBase64String(key);
                    algorithm.Mode = CipherMode.ECB;
                    ICryptoTransform decryptor = algorithm.CreateDecryptor();
                    byte[] data = Convert.FromBase64String(Cadena);
                    byte[] dataDecrypted = decryptor.TransformFinalBlock(data, 0, data.Length);
                    textDecrypt = Encoding.Unicode.GetString(dataDecrypted);
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return textDecrypt;
            }

            public static string GetHash(string Texto)
            {
                UnicodeEncoding encoder = null;
                SHA512Managed sSHA512 = null;
                try
                {
                    encoder = new UnicodeEncoding();
                    sSHA512 = new SHA512Managed();
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Convert.ToBase64String(sSHA512.ComputeHash(encoder.GetBytes(Texto)));
            }
        }
    }
}