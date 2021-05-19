using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace iHelp.Classes
{
        public static class Banco
        {
            public static MySqlCommand Abrir()
            {
                MySqlCommand cmd = new MySqlCommand();
                string strconn = @"server=127.0.0.1;database=tycoondb;user id=root;password=";
                MySqlConnection cn = new MySqlConnection(strconn);
                try
                {
                    cn.Open();
                    cmd.Connection = cn;
                }
                catch (Exception)
                {
                    throw;
                }
                return cmd;
            }
        }

}
