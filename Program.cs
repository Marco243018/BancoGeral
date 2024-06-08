using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppBanco.Entitites;

namespace AppBanco;
class Program
{

    static void Main(string[] args) 
    {
        Tela.Menu = 0;
        Tela.MenuSair = 1;
        while (Tela.Menu != Tela.MenuSair)
        {
            switch(Tela.Menu)
            {
                case 0:
                    Tela.MenuPrincipal();
                break;

                default:  
                    //Verificando se foi acionado o menu criar banco
                    if (Tela.Menu == Tela.MenuCriarBanco)
                    {
                        Console.Clear();
                        Console.WriteLine("Criar Banco");
                        Console.ReadLine();
                        Tela.MenuPrincipal();
                    }
                    else
                    {
                        Console.Clear();
                        string CaminhoArquivo = (Tela.ArquivosXML[Tela.Menu-1].FullName);

                        Banco Bank = new Banco();
                        string retorno = Bank.CarregarBanco(CaminhoArquivo);
                        if(retorno == "")
                        {
                            //Carregou o arquivo
                            Console.Clear();
                            Console.WriteLine(Bank.GerarXML());
                            Console.ReadKey();
                        } else {
                            Console.Clear();
                            Console.Write("Erro ao carregar arquivo. Descrição do erro: ");
                            Console.WriteLine(retorno);
                            Console.ReadKey();
                            Tela.MenuPrincipal();
                        }
                        Tela.MenuPrincipal();
                    }
                break;
            }
        }
    }
}
