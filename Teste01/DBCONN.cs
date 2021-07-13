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
        public void InsereOBJ( Entrada _ent, string _tabName)
        {
            Object o = _ent;
            Type inteiro = typeof(System.Int32);
            Type type = o.GetType();
            string FieldName ;
            string FieldValueStr;
            string strSQL;
            string strValues;
            FieldValueStr = "";
            strSQL = "INSERT INTO " + _tabName + " (";
            strValues = " Values (";
            //int FieldValueInt;
             foreach(PropertyInfo pi in type.GetProperties())
             {
                FieldName = pi.Name;
                // if ( pi.GetValue(FieldName).GetType() == typeof(int) )
                //if ( FieldName != "ID")
                //{
                //    FieldValueInt = (int)pi.GetValue(FieldName).ToString();
                    //Console.WriteLine(FieldName + "/" + FieldValueInt.ToString());
                //}
                //else
                //{
                    FieldValueStr = pi.GetValue(o).ToString();
                    //Console.WriteLine(FieldName + "/" + FieldValueStr);
                    //Console.WriteLine(pi.GetValue(o).GetType());
                //}  
                strSQL = strSQL + (strSQL.Substring(strSQL.Length - 1, 1) == "("?"":",") + FieldName;
                if (pi.GetValue(o).GetType().Equals(inteiro))
                {
                    strValues  = strValues + (strValues.Substring(strValues.Length - 1, 1) == "("?"":",") + FieldValueStr;
                }
                else
                {
                    strValues  = strValues + (strValues.Substring(strValues.Length - 1, 1) == "("?"":",") + "'" + FieldValueStr + "'";
                }
                
             }
             strSQL = strSQL + " )";
             strValues = strValues + " )";
             
             //Console.WriteLine(strSQL + strValues);
             Executa(strSQL + strValues);
        }
        public SQLiteDataReader Consulta(string _sqlQuery)
        {
            SQLiteCommand  _cmd = new SQLiteCommand(_sqlQuery, sqlConnection);
            SQLiteDataReader _sqlDataReader = _cmd.ExecuteReader();
            return _sqlDataReader;
        }
    }
}