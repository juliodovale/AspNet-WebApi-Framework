using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AGENDARestful.Models.Repository
{
    public class Repository : IRepository, IDisposable
    {
        private String strConnection;

        public Repository()
        {
            strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["AGENDA"].ConnectionString;
        }

        private SqlConnection connection;
        public System.Data.SqlClient.SqlConnection GetConnection()
        {
            if (connection == null)
                connection = new SqlConnection(strConnection);

            return connection;
        }

        public void Dispose()
        {
            if (connection != null)
                connection.Dispose();

            connection = null;
        }
    }
}