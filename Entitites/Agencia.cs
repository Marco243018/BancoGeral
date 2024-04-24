using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace AppBanco.Entitites
{
    public class Agencia
    {
        public string Numero{get; set;}
        public string NomeAgencia{get; set;}
        public string Endereco{get; set;}
        public int EnderecoNumero{get; set;}
        public string Bairro{get; set;}
        public string Cidade{get; set;}
        public string Estado {get; set;}
        public List<Conta> Contas {get; set;}
        public Agencia()
        {
            Contas = new List<Conta>();
        }
        public override string ToString()
        {
            string Retorno = "Número.........: " + Numero + "\n" +
                             "Número Agência.: " + NomeAgencia + "\n";
            return Retorno;
        }
        public void AddConta(Conta c)
        {
            Contas.Add(c);
        }
        public void RemoveConta(int Index)
        {
            Contas.RemoveAt(Index);
        }
    }
}
