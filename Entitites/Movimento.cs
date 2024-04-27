using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppBanco.Models;

namespace AppBanco.Entitites
{
    public class Movimento
    {
        public DateTime Data { get; set; }
        public Enums.TipoMovimento Tipo { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public Movimento()
        {
            Tipo = Enums.TipoMovimento.Credito;
            Data = DateTime.Now;
            Valor = 0;
        }
        public override string ToString()
        {
            string retorno = "Data...............:" + Data.ToString() + "\n" +
                             "Tipo...............:" + Tipo + "\n" +
                             "Descrição..........;" + Descricao + "\n" +
                             "Valor..............:" + Valor.ToString("F2") + "\n";
            return retorno;
        }
        public string CarregarMovimentoXML(string XMLMovimento)
        {
            string DataMovimento = RetornaTagXML(XMLMovimento, "Data");
            string sTipoMovimento = RetornaTagXML(XMLMovimento, "TipoMovimento");

            Data = Convert.ToDateTime(DataMovimento);
            if (sTipoMovimento == "Credito")
            {
                Tipo = Enums.TipoMovimento.Credito;
            }
            else
            {
                Tipo = Enums.TipoMovimento.Debito;
            }
            Descricao = RetornaTagXML(XMLMovimento, "Descricao");

            Valor = double.Parse(RetornaTagXML(XMLMovimento, "Valor"));



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
