using System.Runtime.CompilerServices;
using AppBanco.Entitites;

namespace AppBanco;
class Program
{

    static void Main(string[] args) 
    {
        string Linha = Tela.RetornaCadeiaCaracter("-",20);
        Linha ="|" + Linha + "|";
        Console.WriteLine(Linha);

        Linha = "|" + Tela.ImprimirCampo("Nome",10)+ "|    Valor|";
        Console.WriteLine(Linha);
        Linha = "|" + Tela.RetornaCadeiaCaracter("-", 20) + "|";
        Console.WriteLine(Linha);

        Linha = "|" + Tela.ImprimirCampo("Capivara Agiota",10) + "|" + Tela.ImprimirValor(20000,9) + "|";
        Console.WriteLine(Linha);

        Linha = "|" + Tela.ImprimirCampo("Kero Kero",10) + "|" + Tela.ImprimirValor(18.1,9) + "|";
        Console.WriteLine(Linha);

        Linha = "|" + Tela.ImprimirCampo("Marcola",10) + "|" + Tela.ImprimirValor(100,9) + "|";
        Console.WriteLine(Linha);

        Linha = "|" + Tela.RetornaCadeiaCaracter("-", 20) + "|";
        Console.WriteLine(Linha);

        Console.ReadKey();
    }
}
