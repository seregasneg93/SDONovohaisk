using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Data;

namespace SDONovohaisk
{
    class ConnectSDO
    {
        //SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-41RHDMT\SQLEXPRESS01;Initial Catalog=SDO_Novohaisk;Integrated Security=True");
        SqlConnection Connection = new SqlConnection();

       
        public void OpenConnection()
        {
            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["Connections.SDO"].ConnectionString;

            if (Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection.Open();
            }
        }
        public void CloseConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }
        public SqlConnection getConnectSDO()
        {
            return Connection;
        }
    }
}
