namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {

            Console.Clear();
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            Console.WriteLine();

            string placaDoVeiculo = "";
            bool inputValido = false;
            do
            {
                placaDoVeiculo = Console.ReadLine();
                Console.Clear();

                if (!ValidadorDePlaca.ValidarPlaca(placaDoVeiculo) && placaDoVeiculo.ToUpper() == "MENU")
                {

                    Console.WriteLine("Você selecionou a opção Menu!");
                    Thread.Sleep(1200);
                    inputValido = true;
                    return;
                }
                else if (!ValidadorDePlaca.ValidarPlaca(placaDoVeiculo))
                {
                    Console.WriteLine("Dados inválidos!");
                    Console.WriteLine();
                    Console.WriteLine("Nosso sistema aceita apenas dois padrões de placa:");
                    Console.WriteLine();
                    Console.WriteLine("1 - Brasileiro   3 letras, 4 números");
                    Console.WriteLine("2 - Mercosul     3 letras, 1 número, 1 número ou letra e 2 números");
                    Console.WriteLine();
                    Console.WriteLine("Digite uma placa válida, ou MENU para voltar!");
                }
                else
                {
                    veiculos.Add(placaDoVeiculo.ToUpper());
                    inputValido = true;
                    Console.WriteLine("Veículo cadastrado com sucesso!");
                    Console.WriteLine();
                    Thread.Sleep(1200);
                }

            }
            while (!inputValido);


        }

        public void RemoverVeiculo()
        {
            Console.Clear();
            Console.WriteLine("Digite a placa do veículo para remover:");
            Console.WriteLine();
            Console.Write("Código da placa: ");

            string placa = "";

            placa = Console.ReadLine();

            Console.WriteLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horas = 0;
                decimal valorTotal = 0;
                bool inteiroConvertido = false;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    Console.Write("Quantidade de horas: ");
                    inteiroConvertido = int.TryParse(Console.ReadLine(), out int result);
                    horas = result;
                }
                while (!inteiroConvertido);

                valorTotal = precoInicial + precoPorHora * horas;


                veiculos.Remove(placa);
                Console.WriteLine();
                Console.WriteLine($"O veículo de placa: {placa.ToUpper()} foi removido e o preço total foi de: {valorTotal:C2}");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.Clear();
                Console.WriteLine("As placas dos veículos estacionados são:");
                Console.WriteLine();
                foreach (string placa in veiculos)
                {
                    Console.Write($"{placa}  ");
                }

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Não há veículos estacionados.");
                Console.ReadKey();

            }
        }
    }
}
