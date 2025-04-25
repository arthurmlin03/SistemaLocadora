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
			var sistema = new Program();
			var numOp = 0;
			do
			{
				Console.WriteLine("=== SISTEMA DE LOCAÇÃO DE VEÍCULOS === ");

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


			Console.WriteLine("--- CADASTRE UM CLIENTE -----");

			Console.Write("Nome: ");
			var nomeCliente = Console.ReadLine();

			Console.Write("CPF: ");
			var cpfCliente = Console.ReadLine();

			locadora.CadastrarCliente(new Cliente(nomeCliente, cpfCliente));

			Console.WriteLine("Cliente cadastrado! ");
		}

		private static void CadastroDeVeiculo(Locadora locadora)
		{

			Console.WriteLine("--- CADASTRE UM VEÍCULO ---");

			Console.WriteLine("É um carro, moto ou caminhão (c/m/t)");
			var type = char.Parse(Console.ReadLine());

			Console.Write("Marca: ");
			var marcaVeiculo = Console.ReadLine();

			Console.Write("Modelo: ");
			var modeloVeiculo = Console.ReadLine();

			Console.Write("Ano: ");
			var anoVeiculo = int.Parse(Console.ReadLine());

			Console.Write("Placa do veículo: ");
			var placaVeiculo = Console.ReadLine();


			if (type == 'c')
			{
				Console.WriteLine("Quantas portas o carro possui?");
				var numeroDePortas = int.Parse(Console.ReadLine());

				locadora.CadastrarVeiculo(new Carro(marcaVeiculo, modeloVeiculo, anoVeiculo, placaVeiculo, numeroDePortas));
			}
			else if (type == 'm')
			{
				Console.WriteLine("Quantas cilidradas a moto possui? ");
				var cilindradas = int.Parse(Console.ReadLine());

				locadora.CadastrarVeiculo(new Moto(marcaVeiculo, modeloVeiculo, anoVeiculo, placaVeiculo, cilindradas));
			}
			else
			{
				Console.WriteLine("Qual a capacidade em toneladas do caminhão? ");
				var capacidadeEmToneladas = double.Parse(Console.ReadLine());

				locadora.CadastrarVeiculo(new Caminhao(marcaVeiculo, modeloVeiculo, anoVeiculo, placaVeiculo, capacidadeEmToneladas));

			}

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
					locadora.ListarVeiculosDisponiveis();
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
			Console.WriteLine("--- ALUGAR VEÍCULO ---- ");
			
			locadora.ListarClientesCadastrados();

			Console.WriteLine("Digite o cpf do cliente:  ");
			var cpfCliente = Console.ReadLine();

			Console.WriteLine("Digite a placa do veículo:  ");
			var placaVeiculo = Console.ReadLine();

			locadora.AlugarVeiculo(cpfCliente, placaVeiculo);
			Console.WriteLine("------------------------------------------");
		}

		private static void DevolverVeiculoAlugado(Locadora locadora)
		{
			Console.WriteLine("--- DEVOLUÇÃO VÉICULO ALUGADO ---");
			Console.WriteLine("Digite o cpf do cliente:  ");
			var cpfCliente = Console.ReadLine();

			Console.WriteLine("Digite a placa do veículo:  ");
			var placaVeiculo = Console.ReadLine();

			locadora.DevolverVeiculo(cpfCliente, placaVeiculo);
			Console.WriteLine("------------------------------------------");
		}

		private static void ListarVeiculosAlugadosPorClientes(Locadora locadora)
		{
			Console.WriteLine("Digite o CPF do cliente: ");
			var cpf = Console.ReadLine();

			locadora.ListarVeiculosAlugadosPorCliente(cpf);
			Console.WriteLine("------------------------------------------");

		}
	}
}
