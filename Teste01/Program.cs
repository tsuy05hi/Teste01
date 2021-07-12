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
            Entrada ent = new Entrada(6, "Jose", "dos Santos", "Botucatu","" + DateTime.Now.ToString() + "");
            cn0.InsereOBJ(ent);
            
            cn0.Executa("DELETE FROM TESTETB WHERE ID = 5");            
            cn0.Executa("INSERT INTO TESTETB (ID,NOME, SOBRENOME, CIDADE, DATA) " + 
                        " VALUES (5, 'MANUEL', 'DA SILVA', 'CABREÚVA','" + DateTime.Now.ToString() + "')");
            //dtr.Read ();
            while (dtr.Read())
            {
            //Console.WriteLine(dtr.GetValue(dtr.GetOrdinal("NOME")));
                Console.WriteLine(dtr["NOME"] + " " + 
                                  dtr["SOBRENOME"] + " nasceu em " + 
                                  dtr["CIDADE"] + ", Data Incl.:"+
                                  dtr["DATA"]);
            }
            cn0.Close();
        }
    }
}
