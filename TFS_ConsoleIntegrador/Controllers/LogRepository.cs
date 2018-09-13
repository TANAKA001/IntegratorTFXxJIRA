﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TFS_ConsoleIntegrador.DAO;
using TFS_ConsoleIntegrador.QuerryModels;

namespace TFS_ConsoleIntegrador.Controllers
{
    class LogRepository : TfsIntegradora
    {
        TFSIntegradoraConnection conncetion = new TFSIntegradoraConnection();
        SqlCommand cmd;
        public String ConsultaDtRegistro()
        {
            string query = "Select Dt_Registro from " + tabelaLog;

            DateTime _retorno = conncetion._LogData(query);

            //return _retorno.ToString("yyyy/MM/dd HH:mm:ss");
            return _retorno.ToString("yyyy/MM/dd 00:00:00");
        }

        public dynamic InsertDtRegistro(ObjectToQuery _objectToQuery)
        {
            bool _executado = false;
            try
            {
                String query = " INSERT INTO [dbo].[" + tabelaLog + "] ";
                query += " ([Dt_Registro]) VALUES";
                query += " (@Dt_Registro) ";

                _parameters(_objectToQuery, query);
                conncetion.ExecuteQueries(cmd);
                /*-----------*/
                return new
                {
                    _executado
                };
            }
            catch (Exception e)
            {
                return new
                {
                    e
                };
            }
        }

        public dynamic UpdateDtRegistro(ObjectToQuery _objectToQuery)
        {
            bool _executado = false;
            try
            {
                String query = " UPDATE [dbo].[" + tabelaLog + "] ";
                query += " SET [Dt_Registro] = @Dt_Registro ";
                
                _parameters(_objectToQuery, query);
                conncetion.ExecuteQueries(cmd);
                /*-----------*/
                return new
                {
                    _executado
                };
            }
            catch (Exception e)
            {
                return new
                {
                    e
                };
            }
        }

        private void _parameters(ObjectToQuery _objectToQuery, string query)
        {
            cmd = new SqlCommand(query);

            DateTime DtRegistro = Convert.ToDateTime(_objectToQuery.DtRegistro);

            cmd.Parameters.Add("@Dt_Registro", SqlDbType.DateTime);
            cmd.Parameters["@Dt_Registro"].Value = DtRegistro;
        }
    }
}
