using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.Design;
namespace AppBanco
{
    static class Tela
    {
        public static int MenuCriarBanco{ get; set; }
        public static int MenuSair{ get; set; }
        public static int Menu{ get; set; }
        public static FileInfo[] ArquivosXML { get; set; }
        public static string ImprimirCampo(string Texto, int Comprimento)
        {
            string Retorno = "";
            if (Texto.Length > Comprimento)
            {
                Retorno = Texto.Substring(0, Comprimento);
            }
            else
            {
                if (Texto.Length == Comprimento)
                {
                    Retorno = Texto;
                }
                else
                {
                    int NumeroEspaco = Comprimento - Texto.Length;
                    Retorno = Texto;
                    for (int I = 0; I < NumeroEspaco; I++)
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
            if (sValor.Length > Comprimento)
            {
                Retorno = sValor.Substring(sValor.Length - Comprimento, Comprimento);
            }
            else
            {
                int NumeroEspaco = Comprimento - sValor.Length;
                for (int I = 0; I < NumeroEspaco; I++)
                {
                    Retorno = Retorno + " ";
                }
                Retorno = Retorno + sValor;
            }
            return Retorno;
        }
        public static string RetornaCadeiaCaracter(string C, int Comprimento)
        {
            string Retorno = "";
            for (int I = 0; I < Comprimento; I++)
            {
                Retorno = Retorno + C;
            }
            return Retorno;
        }
        public static void MenuPrincipal()
        {
            int OpcaoMenu = 0;
            Console.Clear();
            Console.WriteLine("|" + RetornaCadeiaCaracter("-", 78) + "|");
            Console.WriteLine("|" + ImprimirCampo("App Banco Versão 1.0", 78) + "|");
            Console.WriteLine("|" + RetornaCadeiaCaracter("-", 78) + "|");
            Console.WriteLine("|" + ImprimirCampo("Menu Principal: Indique o número de um banco ou uma opção", 78) + "|");
            Console.WriteLine("|" + RetornaCadeiaCaracter("-", 78) + "|");
            Console.WriteLine("|" + ImprimirCampo("Lista de bancos existentes:", 78) + "|");
            Console.WriteLine("|" + RetornaCadeiaCaracter("-", 78) + "|");

            string caminho = Directory.GetCurrentDirectory();
            caminho += @"/Dados/"; //Alterar dependendo da plataforma

            DirectoryInfo dirInfo = new DirectoryInfo(caminho);

            ArquivosXML = dirInfo.GetFiles("*.xml");

            foreach (FileInfo Arquivo in ArquivosXML)
            {
                OpcaoMenu++;
                Console.WriteLine("|" + ImprimirCampo(OpcaoMenu.ToString(), 3) + " - " + ImprimirCampo(Arquivo.Name, 72) + "|");
            }

            Console.WriteLine("|" + RetornaCadeiaCaracter("-", 78) + "|");
            Console.WriteLine("|" + ImprimirCampo("Outras Opções:", 78) + "|");
            Console.WriteLine("|" + RetornaCadeiaCaracter("-", 78) + "|");

            //Opção de criar novo banco:
            OpcaoMenu++;
            MenuCriarBanco = OpcaoMenu;
            Console.WriteLine("|" + ImprimirCampo(OpcaoMenu.ToString(), 3) + " - " + ImprimirCampo("Criar um novo banco", 72) + "|");
            OpcaoMenu++;
            MenuSair = OpcaoMenu;
            Console.WriteLine("|" + ImprimirCampo(OpcaoMenu.ToString(), 3) + " - " + ImprimirCampo("Fechar o sistema", 72) + "|");
            Console.WriteLine("|" + RetornaCadeiaCaracter("-", 78) + "|");
            Menu = int.Parse(Console.ReadLine());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.Design;
namespace AppBanco
{
    static class Tela
    {
        public static int MenuCriarBanco{ get; set; }
        public static int MenuSair{ get; set; }
        public static int Menu{ get; set; }
        public static FileInfo[] ArquivosXML { get; set; }
        public static string ImprimirCampo(string Texto, int Comprimento)
        {
            string Retorno = "";
            if (Texto.Length > Comprimento)
            {
                Retorno = Texto.Substring(0, Comprimento);
            }
            else
            {
                if (Texto.Length == Comprimento)
                {
                    Retorno = Texto;
                }
                else
                {
                    int NumeroEspaco = Comprimento - Texto.Length;
                    Retorno = Texto;
                    for (int I = 0; I < NumeroEspaco; I++)
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
            if (sValor.Length > Comprimento)
            {
                Retorno = sValor.Substring(sValor.Length - Comprimento, Comprimento);
            }
            else
            {
                int NumeroEspaco = Comprimento - sValor.Length;
                for (int I = 0; I < NumeroEspaco; I++)
                {
                    Retorno = Retorno + " ";
                }
                Retorno = Retorno + sValor;
            }
            return Retorno;
        }
        public static string RetornaCadeiaCaracter(string C, int Comprimento)
        {
            string Retorno = "";
            for (int I = 0; I < Comprimento; I++)
            {
                Retorno = Retorno + C;
            }
            return Retorno;
        }
        public static void MenuPrincipal()
        {
            int OpcaoMenu = 0;
            Console.Clear();
            Console.WriteLine("|" + RetornaCadeiaCaracter("-", 78) + "|");
            Console.WriteLine("|" + ImprimirCampo("App Banco Versão 1.0", 78) + "|");
            Console.WriteLine("|" + RetornaCadeiaCaracter("-", 78) + "|");
            Console.WriteLine("|" + ImprimirCampo("Menu Principal: Indique o número de um banco ou uma opção", 78) + "|");
            Console.WriteLine("|" + RetornaCadeiaCaracter("-", 78) + "|");
            Console.WriteLine("|" + ImprimirCampo("Lista de bancos existentes:", 78) + "|");
            Console.WriteLine("|" + RetornaCadeiaCaracter("-", 78) + "|");

            string caminho = Directory.GetCurrentDirectory();
            caminho += @"/Dados/"; //Alterar dependendo da plataforma

            DirectoryInfo dirInfo = new DirectoryInfo(caminho);

            ArquivosXML = dirInfo.GetFiles("*.xml");

            foreach (FileInfo Arquivo in ArquivosXML)
            {
                OpcaoMenu++;
                Console.WriteLine("|" + ImprimirCampo(OpcaoMenu.ToString(), 3) + " - " + ImprimirCampo(Arquivo.Name, 72) + "|");
            }

            Console.WriteLine("|" + RetornaCadeiaCaracter("-", 78) + "|");
            Console.WriteLine("|" + ImprimirCampo("Outras Opções:", 78) + "|");
            Console.WriteLine("|" + RetornaCadeiaCaracter("-", 78) + "|");

            //Opção de criar novo banco:
            OpcaoMenu++;
            MenuCriarBanco = OpcaoMenu;
            Console.WriteLine("|" + ImprimirCampo(OpcaoMenu.ToString(), 3) + " - " + ImprimirCampo("Criar um novo banco", 72) + "|");
            OpcaoMenu++;
            MenuSair = OpcaoMenu;
            Console.WriteLine("|" + ImprimirCampo(OpcaoMenu.ToString(), 3) + " - " + ImprimirCampo("Fechar o sistema", 72) + "|");
            Console.WriteLine("|" + RetornaCadeiaCaracter("-", 78) + "|");
            Menu = int.Parse(Console.ReadLine());
        }
    }
}