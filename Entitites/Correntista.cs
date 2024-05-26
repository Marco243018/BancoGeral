using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace AppBanco.Entitites
{
    public class Correntista
    {
        public string Nome {get; set;}
        public string CPF {get; set;}
        public string Endereco { get; set;}
        public int Numero {get; set;}
        public string Estado { get; set;}
        public string Cidade { get; set;}
        public string  Telefone { get; set;} 
         public override string ToString()
         {
            string retorno = "Nome.......: " + Nome + "\n" +
                             "CPF..... ..: " + CPF + "\n" +
                             "Endereco...: " + Endereco + "\n" +
                             "Estado.....: " + Estado + "\n" +
                             "Cidade.....: " + Cidade + "\n" +
                             "Telefone...: " + Telefone + "\n";
         return retorno;
         } 
    }
}