using System;
using System.Data;
using System.Data.SQLite;

namespace Teste01
{
    class Program
    {
        static void Main(string[] args)
        {
            DBCONN cn0 = new DBCONN(); //classe define a connectionstring e abre a conexão

            SQLiteCommand  cmd = new SQLiteCommand("SELECT * FROM TESTETB", cn0.sqlConnection);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            
            cn0.Executa("INSERT INTO TESTETB (ID,NOME, SOBRENOME, CIDADE) VALUES (5, 'MANUEL', 'DA SILVA', 'CABREÚVA')");
            //dtr.Read ();
            while (dtr.Read())
            {
            //Console.WriteLine(dtr.GetValue(dtr.GetOrdinal("NOME")));
                Console.WriteLine(dtr["NOME"] + " " + dtr["SOBRENOME"] + " nasceu em " + dtr["CIDADE"]);
            }
            cn0.Close();
        }
    }
}
