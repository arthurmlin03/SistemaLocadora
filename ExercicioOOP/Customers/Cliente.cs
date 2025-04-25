using ExercicioOOP.Automoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExercicioOOP.Customers
{
	public class Cliente
	{
		public string Nome { get; set; }
		public string CPF { get; set; }
		public List<Veiculo> ListaDeVeiculosAlugados { get; set; } = new List<Veiculo>();

		public Cliente(string nome, string cpf)
		{
			Nome = nome;
			CPF = cpf;
			
		}
	}
}
