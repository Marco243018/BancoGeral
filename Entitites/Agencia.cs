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
        public string Numero { get; set; }
        public string NomeAgencia { get; set; }
        public string Endereco { get; set; }
        public int EnderecoNumero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public List<Conta> Contas { get; set; }
        public Agencia()
        {
            Contas = new List<Conta>();
        }
        public override string ToString()
        {
            string Retorno = "Número.........: " + Numero + "\n" +
                             "Número Agência.: " + NomeAgencia + "\n" +
                             "Endereço.......: " + Endereco + "\n" +
                             "Numero.........: " + EnderecoNumero.ToString() + "\n" +
                             "Bairro.........: " + Bairro + "\n" +
                             "Cidade.........: " + Cidade + "\n" +
                             "Estado.........: " + Estado + "\n";
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
        public string CarregarAgenciaXML(string XMLAgencia)
        {
            string CadastroAgencia = RetornaTagXML(XMLAgencia, "AgenciaCadastro");
            Numero = RetornaTagXML(CadastroAgencia, "Numero");
            NomeAgencia = RetornaTagXML(CadastroAgencia, "NomeAgencia");
            Endereco = RetornaTagXML(CadastroAgencia, "EnderecoAgencia");
            EnderecoNumero = int.Parse(RetornaTagXML(CadastroAgencia, "EnderecoNumero"));
            Bairro = RetornaTagXML(CadastroAgencia, "Bairro");
            Cidade = RetornaTagXML(CadastroAgencia, "Cidade");
            Estado = RetornaTagXML(CadastroAgencia, "Estado");

            string Contas = RetornaTagXML(XMLAgencia, "Contas");

            string XMLContas = RetornaTagXML(XMLAgencia, "Contas");

            int ContaConta = 1;
            string DadosConta = RetornaTagXML(XMLContas, "Conta" + ContaConta);
            while (DadosConta != "")
            {
                Conta Cont = new Conta();

                Cont.CarregarContaXML(DadosConta);
                
                AddConta(Cont);

                ContaConta++;
                DadosConta = RetornaTagXML(XMLAgencia, "Conta" + ContaConta);
            }
            return "";
        }
        private string RetornaTagXML(string XML, string Tag)
        {
            string Retorno = "";
            if (XML != "")
            {
                int PI = XML.IndexOf("<" + Tag + ">");
                if (PI > 0)
                {
                    PI += Tag.Length + 2;
                    int PF = XML.IndexOf("</" + Tag + ">");
                    int Comprimento = PF - PI;
                    Retorno = XML.Substring(PI, Comprimento);
                }
                else
                {
                    Retorno = "";
                }
            }
            else
            {
                Retorno = "";
            }
            return Retorno;
        }
    }
}
