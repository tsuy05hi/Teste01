using System;

namespace Teste01
{
    public class Entrada
    {
        //public int ID { get; set; }
        public string NOME { get; set; }
        public string SOBRENOME { get; set; }
        public string CIDADE { get; set; }
        public string DATA { get; set; }
        public Entrada(int _id, string _nome, string _sobrenome, string _cidade, string _data)
        {
          //  ID = _id;
            NOME = _nome;
            SOBRENOME = _sobrenome;
            CIDADE = _cidade;
            DATA = _data;
        }
    }

}