using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioOOP.Automoveis
{
	public class Caminhao : Veiculo
	{
		public double CapacidadeEmToneladas { get; set; }

		public Caminhao(string marca, string modelo, int ano, string placa, double capacidadeEmToneladas)
		: base(placa, marca, modelo, ano)
		{
			CapacidadeEmToneladas = capacidadeEmToneladas;
		}

		public override void ExibirInformacoes()
		{
			base.ExibirInformacoes();
			Console.WriteLine($"A capacidade em toneladas do caminhão é de: {CapacidadeEmToneladas}.");
		}

	}
}
