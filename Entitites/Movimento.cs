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
    }
}
