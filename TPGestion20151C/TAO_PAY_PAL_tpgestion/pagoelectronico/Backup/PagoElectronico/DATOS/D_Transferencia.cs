using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using PagoElectronico.NEGOCIO;
using System.Windows.Forms;
using System.Globalization;

namespace PagoElectronico.DATOS
{
    class D_Transferencia
    {

        private D_ConexionBD conexionBD;

        public D_ConexionBD Con
        {
            get { return conexionBD; }
            set { conexionBD = value; }
        }

        public D_Transferencia()
        {
        }

        public SqlCommand ejecutarStoreProcedure(string nomStoreProcedure)
        {
            D_ConexionBD con = new D_ConexionBD();
            this.conexionBD = con;
            con.AbrirConexion();
            SqlCommand storeProcedure = new SqlCommand();
            storeProcedure.Connection = con.Conexion;
            storeProcedure.CommandText = nomStoreProcedure;
            storeProcedure.CommandType = CommandType.StoredProcedure;
            return storeProcedure;
        }

        public SqlTransaction ejecutarTransaction()
        {
            D_ConexionBD conexion = new D_ConexionBD();
            this.conexionBD = conexion;
            conexion.AbrirConexion();

            return conexion.Conexion.BeginTransaction();

        }

        public DataTable ListarCuentas(int idCliente)
        {
            String respuesta;
            DataTable dtResultado = new DataTable("cuenta");
            SqlCommand storeProcedure = this.ejecutarStoreProcedure("TAO_PAY_PAL.sp_ListarCuentas");
            try
            {
                /*@cliente numeric(18,0),
                @numCta numeric(18,0) output, @nom_ap varchar(50)output, @categoria varchar(50) output,
                @moneda varchar(50) output, @pais varchar(50) output, @estado varchar(50) output,
                @fechaLimite datetime output
                 * 
                 */

                SqlParameter p_idCliente = new SqlParameter();
                p_idCliente.ParameterName = "@cliente";
                p_idCliente.SqlDbType = SqlDbType.Int;
                p_idCliente.Value = idCliente;
                storeProcedure.Parameters.Add(p_idCliente);

                SqlDataAdapter sqlDat = new SqlDataAdapter(storeProcedure);
                respuesta = storeProcedure.ExecuteNonQuery() == 1 ? "ok" : "NO ejecuto";
                sqlDat.Fill(dtResultado);



            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
                dtResultado = null;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
            return dtResultado;
        }

        public string validarExistenciaCuenta(String idCuenta)
        {
            string respuesta = "ok";
            DataTable dtResultado = new DataTable("BuscarCuenta");

            try
            {
                SqlCommand storeProcedure = this.ejecutarStoreProcedure("TAO_PAY_PAL.sp_BuscarCtaTransf");

                SqlParameter p_idCuenta = new SqlParameter();
                p_idCuenta.ParameterName = "@numCta";
                p_idCuenta.SqlDbType = SqlDbType.BigInt;
                p_idCuenta.Value = Convert.ToInt64(long.Parse(idCuenta));
                storeProcedure.Parameters.Add(p_idCuenta);

                SqlDataAdapter sqlDat = new SqlDataAdapter(storeProcedure);
                storeProcedure.ExecuteNonQuery();
                sqlDat.Fill(dtResultado);

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            conexionBD.CerrarConexion();
            return respuesta;
        }



        public DataTable buscarCuenta(String idCuenta)
        {

            DataTable dtResultado = new DataTable("BuscarCuenta");

            try
            {
                SqlCommand storeProcedure = this.ejecutarStoreProcedure("TAO_PAY_PAL.sp_BuscarCtaTransf");

                SqlParameter p_idCuenta = new SqlParameter();
                p_idCuenta.ParameterName = "@numCta";
                p_idCuenta.SqlDbType = SqlDbType.BigInt;
                p_idCuenta.Value = Convert.ToInt64(long.Parse(idCuenta));
                storeProcedure.Parameters.Add(p_idCuenta);

                SqlDataAdapter sqlDat = new SqlDataAdapter(storeProcedure);
                storeProcedure.ExecuteNonQuery();// == 1 ? "ok" : "Cuenta no Encontrada";
                sqlDat.Fill(dtResultado);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conexionBD.CerrarConexion();
            return dtResultado;
        }

        public String RealizarTransferencia(String numCtaOrigem, String numCtaDestino,
                                                 String importe, DateTime fechaApp)
        {
            String estadoDeRespuesta = "ok";
            SqlTransaction transaction = ejecutarTransaction();
            DataTable tbCtaDestino = buscarCuenta(numCtaDestino);
            DataTable tbCtaOrigen = buscarCuenta(numCtaOrigem);
            SqlCommand storeProcedure = this.ejecutarStoreProcedure("TAO_PAY_PAL.sp_Transferencia");
            try
            {
                N_Transferencia.validarCuentaDestino(tbCtaDestino, Convert.ToInt64(long.Parse(numCtaDestino)));
                N_Transferencia.validarImporteDeTranf(tbCtaOrigen, numCtaOrigem, importe);

                SqlParameter p_idCtaOrigen = new SqlParameter();
                p_idCtaOrigen.ParameterName = "@numCtaOrigen";
                p_idCtaOrigen.SqlDbType = SqlDbType.BigInt;
                p_idCtaOrigen.Value = Convert.ToInt64(long.Parse(numCtaOrigem));
                storeProcedure.Parameters.Add(p_idCtaOrigen);

                SqlParameter p_idCtaDestino = new SqlParameter();
                p_idCtaDestino.ParameterName = "@numCtaDestino";
                p_idCtaDestino.SqlDbType = SqlDbType.BigInt;
                p_idCtaDestino.Value = Convert.ToInt64(long.Parse(numCtaDestino));
                storeProcedure.Parameters.Add(p_idCtaDestino);

                SqlParameter p_importe = new SqlParameter();
                p_importe.ParameterName = "@importe";
                p_importe.SqlDbType = SqlDbType.Decimal;
                //---------Solucion del "11.55" que daba 1155.0 ahora da 11.55
                p_importe.Value = Double.Parse(importe, CultureInfo.GetCultureInfo("en-us"));
                storeProcedure.Parameters.Add(p_importe);

                SqlParameter p_fechaApp = new SqlParameter();
                p_fechaApp.ParameterName = "@fecha";
                p_fechaApp.SqlDbType = SqlDbType.DateTime;
                p_fechaApp.Value = fechaApp;
                storeProcedure.Parameters.Add(p_fechaApp);


                SqlDataAdapter sqlDat = new SqlDataAdapter(storeProcedure);
                storeProcedure.ExecuteNonQuery();



                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                estadoDeRespuesta = ex.Message;
            }
            conexionBD.CerrarConexion();
            return estadoDeRespuesta;
        }
    }
}
