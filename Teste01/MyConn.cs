
using System;
using System.Data.SQLite;

namespace Teste01
{
    public class MyConn
    {
        public  SQLiteConnection sqlConnection;
        public  SQLiteCommand sqlCommand;
        public  SQLiteParameter sqlParameter;
        public string connectionString;

        public MyConn()
        {
            connectionString ="";
            connectionString = "Data Source=TesteDB.db;Version=3;";
            
            sqlConnection = new SQLiteConnection(connectionString);
            sqlConnection.Open();

        }
        public MyConn(string _connectionString)
        {
            connectionString = _connectionString;
        }
        public void Close()
        {
            sqlConnection.Close();
        }        
    }
}