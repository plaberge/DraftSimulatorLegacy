using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DraftSimulator.DAL
{
    class DataConnection
    {
        // The following properties are to store a hardcoded connection string if no 
        // environment variable has the connection string.
        public static string userName;
        public static string password;
        public static string dataSource;
        public static string databaseName;

        SqlConnectionStringBuilder connectionStringBuilder;
        
        public DataConnection()
        {

        }

        public DataConnection(string SQLconnection)
        {
            if (SQLconnection == "")
            {
                // If you can't get the DB Connection string from an environment variable, build it now.
                //userName = "<PUT DB USERNAME HERE/>";
                //password = "<PUT DB PASSWORD HERE/>";
                //dataSource = "<PUT DB SOURCE OR URL HERE/>";
                //databaseName = "<PUT DB NAME HERE/>";
                
                connectionStringBuilder = new SqlConnectionStringBuilder();
                connectionStringBuilder.DataSource = DataConnection.dataSource;
                connectionStringBuilder.InitialCatalog = DataConnection.databaseName;
                connectionStringBuilder.Encrypt = true;
                connectionStringBuilder.TrustServerCertificate = false;
                connectionStringBuilder.UserID = DataConnection.userName;
                connectionStringBuilder.Password = DataConnection.password;

            }
            else
            {
                connectionStringBuilder = new SqlConnectionStringBuilder(SQLconnection);
            }
        }

        public DataTable ExecuteQuery(string queryString)
        {
            SqlDataReader queryResult;

            DataTable dtSQLData = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString);
                command.Connection = connection;
                connection.Open();

                queryResult = command.ExecuteReader();
                dtSQLData.Load(queryResult);
                connection.Close();
            }

            return dtSQLData;
        }


    }
}
