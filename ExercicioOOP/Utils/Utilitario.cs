using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioOOP.Utils
{
	public static class Utilitario
	{
		public static string FormatarCpf(string cpf)
		{
			var numeros = new string(cpf.Where(char.IsDigit).ToArray());

			if (numeros.Length != 11)
				return "CPF inválido";

			return Convert.ToUInt64(numeros).ToString(@"000\.000\.000\-00");
		}

		public static string FormatarPlaca(string placa)
		{
			if (string.IsNullOrWhiteSpace(placa))
				return "Placa inválida";

			var limpa = new string(placa.ToUpper().Where(char.IsLetterOrDigit).ToArray());

			if (limpa.Length != 7)
				return "Placa inválida";


			return limpa.Substring(0, 3) + "-" + limpa.Substring(3, 4);
		}

	}
}
