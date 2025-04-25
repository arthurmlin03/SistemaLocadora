using ExercicioOOP.Automoveis;
using ExercicioOOP.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioOOP.Estabelecimento
{
	public class Locadora
	{
		public List<Veiculo> ListaDeVeiculosCadastrados { get; set; } = new List<Veiculo>();

		public List<Cliente> ListaDeClientesCadastrados { get; set; } = new List<Cliente>();

		public void CadastrarVeiculo(Veiculo veiculo)
		{
			ListaDeVeiculosCadastrados.Add(veiculo);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Veiculo cadastrado!");
			Console.ResetColor();
		}

		public void CadastrarCliente(Cliente cliente)
		{
			ListaDeClientesCadastrados.Add(cliente);
		}
		public void AlugarVeiculo(string cpfCliente, string placaVeiculo)
		{

			var cliente = ListaDeClientesCadastrados.FirstOrDefault(c => c.CPF == cpfCliente);
			var veiculo = ListaDeVeiculosCadastrados.FirstOrDefault(v => v.Placa == placaVeiculo);

			if (cliente == null)
			{
				Console.WriteLine("Cliente não encontrado! ");
				return;
			}

			cliente.ListaDeVeiculosAlugados.Add(veiculo);
			veiculo.Locatario = cliente;
		}
		public void DevolverVeiculo(string cpfCliente, string placaVeiculo)
		{
			var cliente = ListaDeClientesCadastrados.FirstOrDefault(c => c.CPF == cpfCliente);
			var veiculo = ListaDeVeiculosCadastrados.FirstOrDefault(v => v.Placa == placaVeiculo);

			if (cliente == null)
			{
				Console.WriteLine("Cliente não encontrado! ");
				return;
			}

			cliente.ListaDeVeiculosAlugados.Remove(veiculo);

			Console.WriteLine("Veículo devolvido!");
			veiculo.Locatario = null;
		}
		public void ListarVeiculosDisponiveis()
		{
			var veiculos = ListaDeVeiculosCadastrados.Where(v => v.Locatario == null);

			Console.WriteLine("Veiculos disponíveis: ");
			foreach (var veiculo in veiculos)
			{
				veiculo.ExibirInformacoes();
			}
		}

		public void ListarVeiculosAlugadosPorCliente(string cpf)
		{
			var cliente = ListaDeClientesCadastrados.FirstOrDefault(c => c.CPF == cpf);


			if (cliente == null || cliente.ListaDeVeiculosAlugados.Count == 0)
			{
				Console.WriteLine("Nenhum veículo alugado.");
				return;
			}

			foreach (var veiculo in cliente.ListaDeVeiculosAlugados)
			{
				veiculo.ExibirInformacoes();
			}
		}

		public void ListarClientesCadastrados()
		{
			if (ListaDeClientesCadastrados.Count == 0)
			{
				Console.WriteLine("Nenhum cliente cadastrado.");
				return;
			}

			Console.WriteLine("Clientes cadastrados: ");
			foreach (var cliente in ListaDeClientesCadastrados)
			{
				Console.WriteLine($"Nome: {cliente.Nome} | CPF: {cliente.CPF}");
			}
		}


	}
}
