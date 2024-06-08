using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
namespace AppBanco.Entitites
{
    public class Banco
    {
        public string Numero { get; set; }
        public string NomeBanco { get; set; }
        public List<Agencia> Agencias { get; set; }
        public Banco()
        {
            Agencias = new List<Agencia>();
        }
        public override string ToString()
        {
            string Retorno = "";
            Retorno = Retorno + "-----------------------------------\n";
            Retorno = Retorno + "Número......:" + Numero + "\n";
            Retorno = Retorno + "Banco.......:" + NomeBanco + "\n";
            Retorno = Retorno + "-----------------------------------\n";
            Retorno = Retorno + "Agencias\n";
            Retorno = Retorno + "-----------------------------------\n";
            foreach (Agencia ag in Agencias)
            {
                Retorno = Retorno + "-----------------------------------\n";
                Retorno = Retorno + ag.ToString();
                Retorno = Retorno + "-----------------------------------\n";
                foreach (Conta c in ag.Contas)
                {
                    Retorno = Retorno + c.ToString();
                    Retorno = Retorno + "-----------------------------------\n";
                    foreach (Movimento m in c.Movimentos)
                    {
                        Retorno = Retorno + m.ToString();
                        Retorno = Retorno + "-----------------------------------\n";
                    }
                }
            }
            return Retorno;
        }
        public void AddAgencia(Agencia ag)
        {
            Agencias.Add(ag);
        }
        public void RemoveAgencia(int Index)
        {
            Agencias.RemoveAt(Index);
        }
        public string CarregarBanco(string CaminhoArquivo)
        {
            string Retorno = "";
            string MeuXML = File.ReadAllText(CaminhoArquivo);

            if (MeuXML == "")
            {
                Retorno = "Arquivo Vázio.";
            }
            else
            {
                string Banco = RetornaTagXML(MeuXML, "Banco");
                string CadastroBanco = RetornaTagXML(Banco, "BancoCadastro");
                Numero = RetornaTagXML(CadastroBanco, "Numero");
                NomeBanco = RetornaTagXML(CadastroBanco, "NomeBanco");

                string Agencias = RetornaTagXML(Banco, "Agencias");
                int ContaAgencia = 1;
                string DadosAgencia = RetornaTagXML(Agencias, "Agencia" + ContaAgencia);
                string CadastroAgencia = "";
                while (DadosAgencia != "")
                {
                    Agencia ag = new Agencia();
                    ag.CarregarAgenciaXML(DadosAgencia);
                    AddAgencia(ag);
                    ContaAgencia++;
                    DadosAgencia = RetornaTagXML(Agencias, "Agencia" + ContaAgencia);

                }

                Retorno = "";
            }
            return Retorno;
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
        public string GerarXML()
        {
            string XML = "";
            foreach (Agencia ag in Agencias)
            {
                string rXML = ag.GerarXML();
                if (rXML != "")
                {
                    XML = rXML;
                }
            }
            return XML;
        }
    }
}