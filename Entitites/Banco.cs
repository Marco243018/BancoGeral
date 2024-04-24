using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
namespace AppBanco.Entitites
{
    public class Banco
    {
        public string Numero {get; set;}
        public string NomeBanco {get;set;}
        public List<Agencia> Agencias {get; set;}
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
            foreach(Agencia ag in Agencias) 
            {
                Retorno = Retorno + "-----------------------------------\n";
                Retorno = Retorno + ag.ToString();
                Retorno = Retorno + "-----------------------------------\n";
                foreach(Conta c in ag.Contas)
                {
                    Retorno = Retorno + c.ToString();
                    Retorno = Retorno + "-----------------------------------\n";
                    foreach(Movimento m in c.Movimentos)
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
    }
}