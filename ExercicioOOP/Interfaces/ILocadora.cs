using ExercicioOOP.Automoveis;
using ExercicioOOP.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioOOP.Interfaces
{
	public interface ILocadora
	{
		void CadastrarVeiculo(Veiculo veiculo);
		void CadastrarCliente(Cliente cliente);
		void AlugarVeiculo(string cpfCliente, string placaVeiculo);
		void DevolverVeiculo(string cpfCliente, string placaVeiculo);
		void ListarVeiculosDisponiveis();
		void ListarVeiculosAlugadosPorCliente(string cpfCliente);
		void ListarClientesCadastrados();

	}
}
