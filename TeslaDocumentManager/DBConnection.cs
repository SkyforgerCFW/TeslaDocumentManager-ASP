using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TeslaDocumentManager
{
    public class DBConnection
    {
        static SqlConnection GetConn
        {
            get
            {
                return new SqlConnection(string.Format(
                    "Data source = {0};"+ 
                    "Initial catalog = {1};"+
                    "Integrated security = {2}", 
                    ConfigurationManager.AppSettings["DataSource"], 
                    ConfigurationManager.AppSettings["InitialCatalog"], 
                    ConfigurationManager.AppSettings["IntegratedSecurity"]));
            }
        }

        public static SqlCommand GetCommand
        {
            get
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBConnection.GetConn;
                cmd.CommandType = CommandType.Text;
                return cmd;
            }
        }
    }
}