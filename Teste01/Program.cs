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

            //Programado na classe DBCONN
            //SQLiteCommand  cmd = new SQLiteCommand("SELECT * FROM TESTETB", cn0.sqlConnection);
            //SQLiteDataReader dtr = cmd.ExecuteReader();

            var dtr = cn0.Consulta("SELECT ID FROM TESTETB WHERE ID = (SELECT MAX(ID) FROM TESTETB) ");
            dtr.Read();
            //Precisa converter para int32, porque retorna int64
            var MAXID = Convert.ToInt32(dtr["ID"]) + 1;
            //Console.WriteLine(MAXID);
            //Console.WriteLine(MAXID.GetType());
            Entrada ent = new Entrada(MAXID, "Jose", "dos Santos", "Botucatu","" + DateTime.Now.ToString() + "");
            
            cn0.Executa("DELETE FROM TESTETB WHERE ID > 5 ");            
            cn0.InsereOBJ(ent, "TESTETB");
            
            dtr = cn0.Consulta("SELECT * FROM TESTETB");
            while (dtr.Read())
            {
                //Console.WriteLine(dtr.GetValue(dtr.GetOrdinal("NOME")));
                Console.WriteLine(dtr["ID"] + " " + dtr["NOME"] + " " + 
                                  dtr["SOBRENOME"] + " nasceu em " + 
                                  dtr["CIDADE"] + ", Data Incl.:"+
                                  dtr["DATA"]);
            }
            cn0.Close();
        }
    }
}
