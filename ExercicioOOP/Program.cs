using ExercicioOOP.Automoveis;
using ExercicioOOP.Customers;
using ExercicioOOP.Estabelecimento;
using System;
using System.Linq;

namespace ExercicioOOP
{
	class Program
	{
		static void Main(string[] args)
		{
			var locadora = new Locadora();
			var numOp = 0;
			do
			{
				EscreverTitulo("=== SISTEMA DE LOCAÇÃO DE VEÍCULOS === ");

				Console.WriteLine("1. Cadastrar novo cliente. ");
				Console.WriteLine("2. Cadastrar novo veículo.");
				Console.WriteLine("3. Alugar veículo.");
				Console.WriteLine("4. Devolver veículo.");
				Console.WriteLine("5. Veículos disponíveis para alugar.");
				Console.WriteLine("6. Veículos já alugados por clientes. ");
				Console.WriteLine("7. Sair.");

				Console.WriteLine("Escolha uma operação: ");


				if (int.TryParse(Console.ReadLine(), out numOp))
				{
					OperacaoSelecionada(numOp, locadora);
				}
				else
				{
					Console.WriteLine("Opção inválida, tente novamente!");
					numOp = 0;
				}



			} while (numOp != 7);


		}

		private static void CadastroDeCliente(Locadora locadora)
		{


			EscreverTitulo("--- CADASTRE UM CLIENTE -----");

			Console.Write("Nome: ");
			var nomeCliente = Console.ReadLine();

			Console.Write("CPF: ");
			var cpfCliente = Console.ReadLine();
			var cpfFormatado = FormatarCpf(cpfCliente);


			locadora.CadastrarCliente(new Cliente(nomeCliente, cpfFormatado));

			Console.WriteLine("Cliente cadastrado! ");

			EscreverTitulo("------------------------------------------");
			Console.WriteLine();
		}

		private static void CadastroDeVeiculo(Locadora locadora)
		{

			EscreverTitulo("--- CADASTRE UM VEÍCULO ---");

			Console.WriteLine("É um carro, moto ou caminhão (c/m/t)");
			var type = char.Parse(Console.ReadLine().ToUpper());

			Console.Write("Marca: ");
			var marcaVeiculo = Console.ReadLine();

			Console.Write("Modelo: ");
			var modeloVeiculo = Console.ReadLine();

			Console.Write("Ano: ");
			if (!int.TryParse(Console.ReadLine(), out int anoVeiculo))
			{
				Console.WriteLine("Ano inválido");
				return;
			}

			Console.Write("Placa do veículo: ");
			var placaVeiculo = Console.ReadLine();
			var placaFormatada = FormatarPlaca(placaVeiculo);


			if (type == 'C')
			{
				Console.WriteLine("Quantas portas o carro possui?");
				var numeroDePortas = int.Parse(Console.ReadLine());

				locadora.CadastrarVeiculo(new Carro(marcaVeiculo, modeloVeiculo, anoVeiculo, placaFormatada, numeroDePortas));
			}
			else if (type == 'M')
			{
				Console.WriteLine("Quantas cilidradas a moto possui? ");
				var cilindradas = int.Parse(Console.ReadLine());

				locadora.CadastrarVeiculo(new Moto(marcaVeiculo, modeloVeiculo, anoVeiculo, placaFormatada, cilindradas));
			}
			else if (type == 'T')
			{
				Console.WriteLine("Qual a capacidade em toneladas do caminhão? ");
				var capacidadeEmToneladas = double.Parse(Console.ReadLine());

				locadora.CadastrarVeiculo(new Caminhao(marcaVeiculo, modeloVeiculo, anoVeiculo, placaFormatada, capacidadeEmToneladas));
			}
			else
			{
				Console.WriteLine("Desculpe, não possuímos esse tipo de veículo.");
			}

			EscreverTitulo("------------------------------------------");
			Console.WriteLine();

		}

		private static void OperacaoSelecionada(int numOp, Locadora locadora)
		{
			switch (numOp)
			{
				case 1:
					CadastroDeCliente(locadora);
					break;
				case 2:
					CadastroDeVeiculo(locadora);
					break;
				case 3:
					FazerAluguelDeVeiculo(locadora);
					break;
				case 4:
					DevolverVeiculoAlugado(locadora);
					break;
				case 5:
					ListarVeiculosCadastrados(locadora);
					break;
				case 6:
					ListarVeiculosAlugadosPorClientes(locadora);
					break;
				case 7:
					Console.WriteLine("Saindo do sistema... ");
					break;
			}
		}

		private static void FazerAluguelDeVeiculo(Locadora locadora)
		{
			EscreverTitulo("--- ALUGAR VEÍCULO ---- ");

			Console.WriteLine();

			locadora.ListarClientesCadastrados();

			Console.WriteLine("Digite o cpf do cliente:  ");
			var cpfCliente = Console.ReadLine();
			var cpfFormatado = FormatarCpf(cpfCliente);


			locadora.ListarVeiculosDisponiveis();

			Console.WriteLine("Digite a placa do veículo:  ");
			var placaVeiculo = Console.ReadLine();
			var placaFormatada = FormatarPlaca(placaVeiculo);

			locadora.AlugarVeiculo(cpfFormatado, placaFormatada);
			EscreverTitulo("------------------------------------------");
			Console.WriteLine();
		}

		private static void DevolverVeiculoAlugado(Locadora locadora)
		{
			EscreverTitulo("--- DEVOLUÇÃO VÉICULO ALUGADO ---");
			locadora.ListarClientesCadastrados();

			Console.WriteLine("Digite o cpf do cliente:  ");
			var cpfCliente = Console.ReadLine();
			var cpfFormatado = FormatarCpf(cpfCliente);

			locadora.ListarVeiculosAlugadosPorCliente(cpfFormatado);

			Console.WriteLine("Digite a placa do veículo:  ");
			var placaVeiculo = Console.ReadLine();
			var placaFormatada = FormatarPlaca(placaVeiculo);

			locadora.DevolverVeiculo(cpfFormatado, placaFormatada);

			EscreverTitulo("------------------------------------------");
			Console.WriteLine();
		}

		private static void ListarVeiculosAlugadosPorClientes(Locadora locadora)
		{
			EscreverTitulo("--- VEICULOS ALUGADOS ----");
			Console.WriteLine();
			locadora.ListarClientesCadastrados();
			Console.WriteLine("Digite o CPF do cliente: ");
			var cpf = Console.ReadLine();
			var cpfFormatado = FormatarCpf(cpf);

			locadora.ListarVeiculosAlugadosPorCliente(cpfFormatado);

			EscreverTitulo("------------------------------------------");
			Console.WriteLine();

		}

		private static void EscreverTitulo(string mensagem)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(mensagem);
			Console.ResetColor();
		}

		private static void ListarVeiculosCadastrados(Locadora locadora)
		{
			EscreverTitulo("--- VEICULOS DISPONÍVEIS PARA ALUGAR ----");
			Console.WriteLine();
			locadora.ListarVeiculosDisponiveis();

			EscreverTitulo("------------------------------------------");
			Console.WriteLine();

		}

		public static string FormatarCpf(string cpf)
		{
			var numeros = new string(cpf.Where(char.IsDigit).ToArray());

			if (numeros.Length != 11)
				return "CPF inválido";

			return Convert.ToUInt64(numeros).ToString(@"000\.000\.000\-00");
		}

		public static string FormatarPlaca(string placa)
		{
			if (string.IsNullOrWhiteSpace(placa))
				return "Placa inválida";

			var limpa = new string(placa.ToUpper().Where(char.IsLetterOrDigit).ToArray());

			if (limpa.Length != 7)
				return "Placa inválida";

			
			return limpa.Substring(0, 3) + "-" + limpa.Substring(3, 4);
		}


	}
}
