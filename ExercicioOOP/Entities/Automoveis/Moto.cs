using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioOOP.Automoveis
{
	public class Moto : Veiculo
	{
		public int Cilindradas { get; set; }

		public Moto(string marca, string modelo, int ano, string placa, int cilindradas)
		: base(placa, marca, modelo, ano)
		{
			Cilindradas = cilindradas;
		}

		public override void ExibirInformacoes()
		{
			base.ExibirInformacoes();
			Console.WriteLine($"Esta moto possui: {Cilindradas} cilindradas.");
		}

	}
}
