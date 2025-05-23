﻿using ExercicioOOP.Automoveis;
using ExercicioOOP.Customers;
using ExercicioOOP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioOOP.Estabelecimento
{
	public class Locadora : ILocadora
	{
		public List<Veiculo> ListaDeVeiculosCadastrados { get; set; } = new List<Veiculo>();

		public List<Cliente> ListaDeClientesCadastrados { get; set; } = new List<Cliente>();

		public void CadastrarVeiculo(Veiculo veiculo)
		{
			ListaDeVeiculosCadastrados.Add(veiculo);
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

			if (!veiculos.Any())
			{
				Console.WriteLine("Não há veículos disponíveis.");
				return;
			}

			Console.WriteLine("Veículos disponíveis: ");
			foreach (var veiculo in veiculos)
			{
				veiculo.ExibirInformacoes();
			}
		}

		public void ListarVeiculosAlugadosPorCliente(string cpfCliente)
		{
			var cliente = ListaDeClientesCadastrados.FirstOrDefault(c => c.CPF == cpfCliente);


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
