using DesafioFundamentos.Models;
using System.Globalization;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

//RegionInfo fornece acesso a informações sobre a cultura atual do aplicativo, como sigla da moeda, etc
//Fonte: https://learn.microsoft.com/pt-br/dotnet/api/system.globalization.regioninfo.isocurrencysymbol?view=net-6.0
RegionInfo informacoesRegionais = new RegionInfo("BR");

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "\nDigite o preço inicial:");
Console.WriteLine();
Console.Write($"{informacoesRegionais.CurrencySymbol}: ");

precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("\nAgora digite o preço por hora:");
Console.WriteLine();
Console.Write($"{informacoesRegionais.CurrencySymbol}: ");

precoPorHora = Convert.ToDecimal(Console.ReadLine());

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine();
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");
    Console.WriteLine();
    Console.Write("Opção selecionada: ");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.Clear();
    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();

}

Console.WriteLine("O programa se encerrou");
