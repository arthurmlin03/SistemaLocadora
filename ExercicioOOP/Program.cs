using ExercicioOOP.Automoveis;
using ExercicioOOP.Customers;
using ExercicioOOP.Enums;
using ExercicioOOP.Estabelecimento;
using ExercicioOOP.Interfaces;
using ExercicioOOP.Services;
using System;
using System.Linq;

namespace ExercicioOOP
{
	class Program
	{
		static void Main(string[] args)
		{
			var numOp = 0;
			ILocadora repositorio = new Locadora();
			var locadora = new LocadoraService(repositorio);
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

		private static void CadastroDeCliente(LocadoraService locadoraService)
		{


			EscreverTitulo("--- CADASTRE UM CLIENTE -----");

			Console.Write("Nome: ");
			var nomeCliente = Console.ReadLine();

			Console.Write("CPF: ");
			var cpfCliente = Console.ReadLine();
			
			locadoraService.CadastrarCliente(nomeCliente, cpfCliente);

			EscreverTitulo("------------------------------------------");
			Console.WriteLine();
		}

		private static void CadastroDeVeiculo(LocadoraService locadoraService)
		{

			EscreverTitulo("--- CADASTRE UM VEÍCULO ---");

			Console.WriteLine("Qualti tipo de veículo? (Carro, Moto, ou Caminhão)");
			var tipo = Console.ReadLine();

			if (!Enum.TryParse<TipoVeiculo>(tipo, true, out var tipoVeiculo))
			{
				Console.WriteLine("Tipo inválido");
				return;
			}

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

			int? numeroDePortas = null;
			int? cilindradas = null;
			double? capacidadeEmToneladas = null;

			switch (tipoVeiculo)
			{
				case TipoVeiculo.Carro:
					Console.WriteLine("Quantas portas o carro possui?");
					numeroDePortas = int.Parse(Console.ReadLine());
					break;
				case TipoVeiculo.Moto:
					Console.WriteLine("Quantas cilíndradas a moto possui?");
					cilindradas = int.Parse(Console.ReadLine());
					break;
				case TipoVeiculo.Caminhao:
					Console.WriteLine("Qual a capacidade em toneladas do caminhão?");
					capacidadeEmToneladas = double.Parse(Console.ReadLine());
					break;
			}

			locadoraService.CadastroDeVeiculo(tipoVeiculo, marcaVeiculo, modeloVeiculo, anoVeiculo, placaVeiculo, numeroDePortas, cilindradas, capacidadeEmToneladas);
			
			EscreverTitulo("------------------------------------------");
			Console.WriteLine();

		}

		private static void OperacaoSelecionada(int numOp, LocadoraService locadora)
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
					DevoluçaoVeiculo(locadora);
					break;
				case 5:
					locadora.ListarVeiculosCadastrados();
					break;
				case 6:
					ListaDeVeiculosAlugados(locadora);
					break;
				case 7:
					Console.WriteLine("Saindo do sistema... ");
					break;
			}
		}

		private static void FazerAluguelDeVeiculo(LocadoraService locadoraService)
		{
			EscreverTitulo("--- ALUGAR VEÍCULO ---- ");

			Console.WriteLine();

			locadoraService.ListarVeiculosCadastrados();

			Console.WriteLine("Digite o cpf do cliente:  ");
			var cpfCliente = Console.ReadLine();

			Console.WriteLine("Digite a placa do veículo:  ");
			var placaVeiculo = Console.ReadLine();

			locadoraService.FazerAluguelDeVeiculo(cpfCliente, placaVeiculo);
			
			EscreverTitulo("------------------------------------------");
			Console.WriteLine();
		}

		private static void DevoluçaoVeiculo(LocadoraService locadoraService)
		{
			EscreverTitulo("--- DEVOLUÇÃO VÉICULO ALUGADO ---");
			locadoraService.ListarClientes();

			Console.WriteLine("Digite o cpf do cliente:  ");
			var cpfCliente = Console.ReadLine();
			

			locadoraService.ListarVeiculosAlugadosPorCliente(cpfCliente);

			Console.WriteLine("Digite a placa do veículo:  ");
			var placaVeiculo = Console.ReadLine();

			locadoraService.DevolverVeiculoAlugado(cpfCliente, placaVeiculo);

			EscreverTitulo("------------------------------------------");
			Console.WriteLine();
		}

		private static void ListaDeVeiculosAlugados(LocadoraService locadoraService)
		{
			EscreverTitulo("--- VEICULOS ALUGADOS ----");
			Console.WriteLine();
			locadoraService.ListarClientes();
			Console.WriteLine("Digite o CPF do cliente: ");
			var cpf = Console.ReadLine();

			locadoraService.ListarVeiculosAlugadosPorCliente(cpf);

			EscreverTitulo("------------------------------------------");
			Console.WriteLine();

		}


		public static void EscreverTitulo(string mensagem)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(mensagem);
			Console.ResetColor();
		}


	}
}
