using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppBanco.Models;
namespace AppBanco.Entitites;

public class Conta
{
    public Enums.TipoConta Tipo { get; set; }
    public Correntista correntista { get; set; }
    public string Numero { get; set; }
    public double Saldo { get; private set; }
    public List<Movimento> Movimentos { get; set; }
    public Conta()
    {
        Movimentos = new List<Movimento>();
    }
    public void Addmovimento(Movimento m)
    {
        Movimentos.Add(m);
        if (m.Tipo == Enums.TipoMovimento.Credito)
        {
            Saldo = Saldo + m.Valor;
        }
        else
        {
            Saldo = Saldo - m.Valor;
        }
    }
    public void RemoveMovimento(int index)
    {
        Movimentos.RemoveAt(index);
    }
    public override string ToString()
    {
        string retorno = "Numero........:" + Numero.ToString() + "\n" +
                         "Tipo de conta.:" + Tipo + "\n" +
                         "--------------------------------------" + "\n" +
                         "Correntista" + "\n" +
                         "--------------------------------------" + "\n" +
                         correntista.ToString() +
                         "--------------------------------------" + "\n" +
                         "Saldo da conta:" + Saldo.ToString() + "\n" +
                         "--------------------------------------" + "\n";
        return retorno;
    }
    public string CarregarContaXML(string XMLConta)
    {
        string sTipo = RetornaTagXML(XMLConta, "Tipo");
        if (sTipo == "Corrente")
        {
            Tipo = Enums.TipoConta.Corrente;
        }
        else
        {
            Tipo = Enums.TipoConta.Poupanca;
        }

        Numero = RetornaTagXML(XMLConta, "Numero");

        string DadosCorrentista = RetornaTagXML(XMLConta, "Correntista");
        string DadosMovimentos = RetornaTagXML(XMLConta,"Movimentos");

        correntista = new Correntista();

        correntista.Nome = RetornaTagXML(DadosCorrentista, "Nome");
        correntista.CPF = RetornaTagXML(DadosCorrentista, "CPF");
        correntista.Endereco = RetornaTagXML(DadosCorrentista, "Endereco");
        correntista.Numero = int.Parse(RetornaTagXML(DadosCorrentista, "Numero"));
        correntista.Estado = RetornaTagXML(DadosCorrentista, "Estado");
        correntista.Cidade = RetornaTagXML(DadosCorrentista, "Cidade");
        correntista.Telefone = RetornaTagXML(DadosCorrentista, "Telefone");

        int ContaMovimento = 1;
        string XMLMovimento = RetornaTagXML(DadosMovimentos, "Movimento"+ContaMovimento);
        while(XMLMovimento != "")
        {
            Movimento mov = new Movimento();
            mov.CarregarMovimentoXML(XMLMovimento);

            Addmovimento(mov);
            ContaMovimento++;
            XMLMovimento = RetornaTagXML(DadosMovimentos, "Movimento"+ContaMovimento);
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
    public string GerarXML()
        {
            string XML = "                      <Tipo>" + Tipo + "</Tipo>\n" + 
                         "                      <Numero" + Numero + "</Numero>\n" +
                         "                      <Saldo>" + Saldo.ToString(F2) + "</Saldo>\n" +
                         "                      <Correntista>\n"+
                         "                          <Nome>" + correntista.Nome + "</Nome>\n" +
                         "                          <CPF>" + correntista.CPF + "</CPF>\n" +
                         "                          <Endereco>" + correntista.Endereco + "</Endereco>\n" +
                         "                          <Numero>" + correntista.Numero +"</Numero>\n" +
                         "                          <Estado>" + correntista.Estado +"</Estado>\n" +
                         "                          <Cidade>" + correntista.Cidade +"</Cidade>\n" +
                         "                          <Telefone>" + correntista.Telefone +"</Telefone>\n" +
                         "                      </Correntista>\n" +
                         "                      <Movimentos>\n";
            int contador = 1;             
            foreach (Movimento mov in Movimentos)
            {
                XML = XML + "                           <Movimento" + contador + "</Movimento>\n";
                XML = XML + mov.GerarXML();
                XML = XML + "                           </Movimento" + contador + ">\n";
                contador++;
            }
            XML = XML + "                       </Movimentos>\n";
            return XML;
        }
}
