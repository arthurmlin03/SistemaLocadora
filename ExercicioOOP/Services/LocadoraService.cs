using ExercicioOOP.Automoveis;
using ExercicioOOP.Customers;
using ExercicioOOP.Enums;
using ExercicioOOP.Estabelecimento;
using ExercicioOOP.Interfaces;
using ExercicioOOP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExercicioOOP.Services
{
	public class LocadoraService
	{
		private readonly ILocadora _locadora;

		public LocadoraService(ILocadora locadora)
		{
			_locadora = locadora;
		}


		public void CadastrarCliente(string nome, string cpf)
		{
			var cpfFormatado = Utilitario.FormatarCpf(cpf);
			var cliente = new Cliente(nome, cpfFormatado);
			_locadora.CadastrarCliente(cliente);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Cliente cadastrado com sucesso!");
			Console.ResetColor();
		}

		public void CadastroDeVeiculo(TipoVeiculo tipo, string marca, string modelo, int ano, string placa, int?
		numeroDePortas = null, int? cilindradas = null, double? capacidadeEmToneladas = null)
		{
			var placaFormatada = Utilitario.FormatarPlaca(placa);

			Veiculo veiculo = tipo switch
			{
				TipoVeiculo.Carro => new Carro(marca, modelo, ano, placaFormatada, numeroDePortas ?? 4),
				TipoVeiculo.Moto => new Moto(marca, modelo, ano, placaFormatada, cilindradas ?? 135),
				TipoVeiculo.Caminhao => new Caminhao(marca, modelo, ano, placaFormatada, capacidadeEmToneladas ?? 5),
				_ => null

			};

			if (veiculo == null)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Tipo de veiculo inválido!");
				Console.ResetColor();
				return;
			}

			_locadora.CadastrarVeiculo(veiculo);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Veículo cadastrado com sucesso!");
			Console.ResetColor();


		}

		public void FazerAluguelDeVeiculo(string cpfCliente, string placa)
		{
			var cpfFormatado = Utilitario.FormatarCpf(cpfCliente);
			var placaFormatada = Utilitario.FormatarPlaca(placa);

			_locadora.AlugarVeiculo(cpfFormatado, placaFormatada);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Veículo alugado com sucesso. Obrigado pela preferência!");
			Console.ResetColor();
		}

		public void DevolverVeiculoAlugado(string cpfCliente, string placa)
		{
			var cpfFormatado = Utilitario.FormatarCpf(cpfCliente);
			var placaFormatada = Utilitario.FormatarPlaca(placa);

			_locadora.DevolverVeiculo(cpfFormatado, placaFormatada);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Veículo devolvido.");
			Console.ResetColor();
		}

		public void ListarVeiculosAlugadosPorCliente(string cpfCliente)
		{
			var cpfFormatado = Utilitario.FormatarCpf(cpfCliente);

			_locadora.ListarVeiculosAlugadosPorCliente(cpfFormatado);
		}

		public void ListarVeiculosCadastrados()
		{

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("--- VEICULOS DISPONÍVEIS PARA ALUGAR ----");
			Console.ResetColor();

			Console.WriteLine();
			_locadora.ListarVeiculosDisponiveis();

			Console.Write("------------------------------------------");
			Console.WriteLine();

		}
		public void ListarClientes()
		{
			_locadora.ListarClientesCadastrados();
		}





	}
}
