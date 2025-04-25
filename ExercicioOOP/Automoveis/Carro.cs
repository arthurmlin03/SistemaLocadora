using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioOOP.Automoveis
{
	public class Carro : Veiculo
	{
		public int NumeroDePortas { get; set; }

		public Carro(string marca, string modelo, int ano, string placa, int numeroDePortas) 
		: base ( placa,  marca,  modelo,  ano)
		{
			NumeroDePortas = numeroDePortas;
		}


		public override void ExibirInformacoes()
		{
			base.ExibirInformacoes();
			Console.WriteLine($"Numero de Portas: {NumeroDePortas}");
		}
	}
}
