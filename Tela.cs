using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace AppBanco
{
    static class Tela
    {
        public static string ImprimirCampo(string Texto, int Comprimento)
        {
            string Retorno = "";
            if(Texto.Length > Comprimento)
            {
                Retorno = Texto.Substring(0, Comprimento);
            }
            else
            {
                if(Texto.Length == Comprimento)
                {
                    Retorno = Texto;
                }
                else
                {
                    int NumeroEspaco = Comprimento - Texto.Length;
                    Retorno = Texto;
                    for(int I=0;I<NumeroEspaco;I++)
                    {
                        Retorno = Retorno + " ";
                    }
                }
            }
            return Retorno;
        }
        public static string ImprimirValor(double Valor, int Comprimento)
        {
            string Retorno = "";
            string sValor = Valor.ToString("F2");
            if(sValor.Length>Comprimento)
            {
                Retorno = sValor.Substring(sValor.Length-Comprimento,Comprimento);
            }
            else
            {
                int NumeroEspaco = Comprimento - sValor.Length;
                for (int I = 0; I<NumeroEspaco;I++)
                {
                    Retorno = Retorno + " ";
                }
                Retorno = Retorno + sValor;
            }
            return Retorno;            
        }
        public static string RetornaCadeiaCaracter(string C, int Comprimento)
        {
            string Retorno="";
            for (int I = 0; I<Comprimento;I++)
            {
                Retorno = Retorno + C;
            }
            return Retorno;
        }
    }
}