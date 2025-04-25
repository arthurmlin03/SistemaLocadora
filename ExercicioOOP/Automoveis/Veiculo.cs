using ExercicioOOP.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioOOP.Automoveis
{
	public abstract class Veiculo
	{
		public string Placa { get; set; }

		public string Marca { get; set; }

		public string Modelo { get; set; }

		public int Ano { get; set; }

		public Cliente Locatario { get; set; } = null;

		public Veiculo(string placa, string marca, string modelo, int ano)
		{
			Placa = placa;
			Marca = marca;
			Modelo = modelo;
			Ano = ano;
		}

		public virtual void ExibirInformacoes()
		{
			Console.WriteLine("Informações do Veículo Alugado:");
			Console.WriteLine($"Placa: {Placa}");
			Console.WriteLine($"Marca: {Marca}");
			Console.WriteLine($"Modelo: {Modelo}");
			Console.WriteLine($"Ano: {Ano}");
		}
		
	}
}
