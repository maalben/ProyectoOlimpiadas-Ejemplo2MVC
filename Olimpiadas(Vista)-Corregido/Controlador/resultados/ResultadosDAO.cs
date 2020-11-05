using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Controlador.resultados
{
    public class ResultadosDAO
    {

        Clasedatos clasedatos = null;
        ResultadosDTO resultadosDTO = null;
        DataTable listaDatos = null; 

        public ResultadosDAO(ResultadosDTO resultadosDTO)
        {
            this.resultadosDTO = resultadosDTO;
        }

        public DataTable ListarResultados() {
            listaDatos = new DataTable();
            try {
                clasedatos = new Clasedatos();
                SqlParameter[] parametros = null;

                if (this.resultadosDTO == null) {

                    parametros = new SqlParameter[4];

                    parametros[0] = new SqlParameter();
                    parametros[0].ParameterName = "@numerodocumento";
                    parametros[0].SqlDbType = SqlDbType.BigInt;
                    parametros[0].SqlValue = resultadosDTO.getNumerodocumento();

                    parametros[1] = new SqlParameter();
                    parametros[1].ParameterName = "@nombreparticipante";
                    parametros[1].SqlDbType = SqlDbType.VarChar;
                    parametros[1].Size = 50;
                    parametros[1].SqlValue = resultadosDTO.getNombreparticipante();

                    parametros[2] = new SqlParameter();
                    parametros[2].ParameterName = "@idposicion";
                    parametros[2].SqlDbType = SqlDbType.TinyInt;
                    parametros[2].SqlValue = resultadosDTO.getIdposicion();

                    parametros[3] = new SqlParameter();
                    parametros[3].ParameterName = "@idpais";
                    parametros[3].SqlDbType = SqlDbType.TinyInt;
                    parametros[3].SqlValue = resultadosDTO.getIdpais();
                } else {
                    parametros = null;
                }

                listaDatos = clasedatos.retornaTabla(parametros, "spresultados_listar");
            }
            catch (Exception exception) {
                throw new Exception(exception.Message);
            }

            return listaDatos;
        }

        
        public void guardarNuevoResultado() {

            SqlParameter[] parametrosM = null;
            //ParametrosGenerico parametrosGenerico = new ParametrosGenerico();

            try {

                clasedatos = new Clasedatos();
                parametrosM = new SqlParameter[3];
                /*
                parametrosM[0] = new SqlParameter();
                parametrosM[0] = parametrosGenerico.numerico("@numerodocumento", SqlDbType.BigInt, resultadosDTO.getNumerodocumento(), 0);
                parametrosM[1] = new SqlParameter();
                parametrosM[1] = parametrosGenerico.texto("@nombreparticipante", SqlDbType.VarChar, resultadosDTO.getNombreparticipante(), 50, 1);
                */
                parametrosM[0] = new SqlParameter();
                parametrosM[0].ParameterName = "@numerodocumento";
                parametrosM[0].SqlDbType = SqlDbType.BigInt;
                parametrosM[0].SqlValue = resultadosDTO.getNumerodocumento();
                
                parametrosM[1] = new SqlParameter();
                parametrosM[1].ParameterName = "@nombreparticipante";
                parametrosM[1].SqlDbType = SqlDbType.VarChar;
                parametrosM[1].Size = 50;
                parametrosM[1].SqlValue = resultadosDTO.getNombreparticipante();
                
                parametrosM[2] = new SqlParameter();
                parametrosM[2].ParameterName = "@idposicion";
                parametrosM[2].SqlDbType = SqlDbType.TinyInt;
                parametrosM[2].SqlValue = resultadosDTO.getIdposicion();

                clasedatos.ejecutarSP(parametrosM, "spresultados_guardar");
            }
            catch (Exception exception) {
                throw new Exception(exception.Message);
            }
        }

        public void guardarCambiosResultados() {

            SqlParameter[] parametros = null;

            try
            {
                clasedatos = new Clasedatos();

                parametros = new SqlParameter[2];

                parametros[0] = new SqlParameter();
                parametros[0].ParameterName = "@numerodocumento";
                parametros[0].SqlDbType = SqlDbType.BigInt;
                parametros[0].SqlValue = resultadosDTO.getNumerodocumento();

                parametros[1] = new SqlParameter();
                parametros[1].ParameterName = "@idposicion";
                parametros[1].SqlDbType = SqlDbType.TinyInt;
                parametros[1].SqlValue = resultadosDTO.getIdposicion();

                clasedatos.ejecutarSP(parametros, "spresultados_guardarcambios");
            }
            catch (Exception exception) {
                throw new Exception(exception.Message);
            }

        }

        public void eliminarResultado()
        {
            SqlParameter[] parametros = null;
            ParametrosGenerico parametrosGenerico = new ParametrosGenerico();

            try
            {

                clasedatos = new Clasedatos();
                parametros = new SqlParameter[1];

                //parametros[0] = parametrosGenerico.numerico("@numerodocumento", SqlDbType.BigInt, resultadosDTO.getNumerodocumento(), 0);

                parametros[0] = new SqlParameter();
                parametros[0].ParameterName = "@numerodocumento";
                parametros[0].SqlDbType = SqlDbType.BigInt;
                parametros[0].SqlValue = resultadosDTO.getNumerodocumento();

                clasedatos.ejecutarSP(parametros, "spresultados_eliminar");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}
