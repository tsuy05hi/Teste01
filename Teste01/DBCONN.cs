using System;
using System.Reflection;
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
        public void InsereOBJ( Entrada _ent)
        {
            Object o = _ent;
            Type type = o.GetType();
            string FieldName ;
            string FieldValueStr;
            FieldValueStr = "";
            //int FieldValueInt;
             foreach(PropertyInfo pi in type.GetProperties())
             {
                FieldName = pi.Name;
                // if ( pi.GetValue(FieldName).GetType() == typeof(int) )
                //if ( FieldName != "ID")
                //{
                    //FieldValueInt = (int)pi.GetValue(FieldName).ToString();
                    //Console.WriteLine(FieldName + "/" + FieldValueInt.ToString());
                //}
                //else
                //{
                    FieldValueStr = pi.GetValue(FieldName).ToString();
                    Console.WriteLine(FieldName + "/" + FieldValueStr);
                //}  
                
             }

        }
    }
}