using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Database
{
    public class Context : DbContext
    {

        public Context() : base(@"Entities")
        {

        }

    }

    public static class Ado
    {
        private static readonly string dataProvider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings[dataProvider].ConnectionString + "password=pass;";


        //The process of obtaining a DbProviderFactory involves passing information about a data provider to the DbProviderFactories class.
        //Based on this information, the GetFactory method creates a strongly typed provider factory.

        //ExecuteScalar - Executes the query, and returns the first column of the first row in the result
        //ExecuteNonQuery -For UPDATE, INSERT, and DELETE statements, the return value is the number of rows affected by the command. For all other types of statements, the return value  is -1.
        //ExecuteReader: Returns data to the client as rows.This would typically be an SQL select statement or a Stored Procedure that contains one or more select statements.This method returns a DataReader object that can be used to fill a DataTable object or used directly for printing reports and so forth.

        //This is used to get data for ODBC database , for  SQL SERVER  database - we can use SqlConnection 
        //We can use DbConnection which will work for both ODBC AND SQL SERVER AS it is  base class for both OdbcConnection , SqlConnection
        public static DataSet GetDataSet(string spName)
        {
            DataSet ds = new DataSet();
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                OdbcDataAdapter adapter =
                    new OdbcDataAdapter(spName, connection);

                // Open the connection and fill the DataSet.
                try
                {
                    connection.Open();
                    adapter.Fill(ds);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }
            return ds;

        }

        public static DataSet GetDataSet1(string spName)
        {
            DataSet ds = new DataSet();
            using (OdbcConnection connection = new OdbcConnection())
            {
                connection.ConnectionString = connectionString;

                using (OdbcCommand command = new OdbcCommand())
                {
                    command.CommandText = spName;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;

                    using (OdbcDataAdapter adapter = new OdbcDataAdapter())
                    {
                        adapter.SelectCommand = command;
                        // Open the connection and fill the DataSet.
                        connection.Open();
                        adapter.Fill(ds);
                    }
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }
            return ds;

        }

        public static DataSet GetDataSetByFactory(string spName)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = spName;

                    using (DbDataAdapter adapter = factory.CreateDataAdapter())
                    {

                        adapter.SelectCommand = command;
                        DataSet ds = new DataSet();

                        connection.Open();

                        adapter.Fill(ds);

                        return ds;
                    }
                }

            }
        }


        public static DataTable GetDataTable(string spName)
        {
            return GetDataSet(spName).Tables[0];
        }
    }

    public static class DapperClass
    {
        private static readonly string dataProvider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings[dataProvider].ConnectionString + "password=pass;";

        public static IDbConnection Connection()
        {
            return new OdbcConnection(connectionString);
        }
    }
}
