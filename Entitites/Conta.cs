using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppBanco.Models;
namespace AppBanco.Entitites;

    public class Conta
    {
        public Enums.TipoConta Tipo {get; set;}
        public Correntista correntista {get; set;}
        public string Numero {get; set;}
        public double Saldo {get; private set;}
        public List<Movimento> Movimentos{get;set;}
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
                Saldo = Saldo- m.Valor;
            }
        }
        public void RemoveMovimento(int index)
        {
            Movimentos.RemoveAt(index);
        }
    public override string ToString()
    {
        string retorno = "Numero........:" + Numero + "\n" +
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
}
