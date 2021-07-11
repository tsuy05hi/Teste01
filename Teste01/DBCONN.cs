using System;
using System.Data.SQLite;

namespace Teste01
{
    public class DBCONN
    {
        public SQLiteConnection sqlConnection  { get;  }
        public  SQLiteCommand sqlCommand;
        public SQLiteCommandBuilder commandBuilder;
//        public  SQLiteParameter sqlParameter;
        public string connectionString;

        public DBCONN()
        {
            connectionString ="";
            connectionString = "Data Source=TesteDB.db;Version=3;";
            
            sqlConnection = new SQLiteConnection(connectionString);
            sqlConnection.Open();

        }
        public DBCONN(string _connectionString)
        {
            connectionString = _connectionString;
        }
        public void Close()
        {
            sqlConnection.Close();
        }        
        public void Open()
        {
            sqlConnection.Open();
        }        
        public void Executa(string sqlExpression)
        {
            long i;
            sqlCommand = new SQLiteCommand(sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = sqlExpression;
            i = sqlCommand.ExecuteNonQuery();
        }
    }
}