using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafioAvanade.Validations;


namespace desafioAvanade.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private int vagasDisponiveis = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora, int vagasDisponiveis)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.vagasDisponiveis = vagasDisponiveis;
        }
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (validacaoPlaca.validarPlaca(placa, out string mensagemErro))
            {
                placa = placa.ToUpper();

                if (VagasDisponiveis() <= 0)
                {
                    Console.WriteLine("Estacionamento lotado!");
                }
                else
                {
                    veiculos.Add(placa);
                    Console.WriteLine($"Veículo {placa} adicionado com sucesso.");
                }
            }
            else
            {
                Console.WriteLine($"Placa Inválida.{mensagemErro} ");
            }
        }


        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            if (!validacaoPlaca.validarPlaca(placa, out string mensagemErro))
            {
                Console.WriteLine($"Placa Inválida. {mensagemErro}");
                return;
            }

            Console.WriteLine($"Deseja remover esta placa {placa}? Responda com Sim (s) ou Não (n)");
            string removerPlaca = Console.ReadLine().ToUpper();

            if (removerPlaca == "SIM" || removerPlaca == "S")
            {
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {

                    try
                    {
                        int horasEstacionado = validarHoras.ObterHorasEstacionado();
                        
                        decimal valorTotal = CalcularValorCobrado(horasEstacionado);

                        Console.WriteLine($"O veículo {placa} removido. Valor a ser cobrado: {valorTotal:C}");
                        
                        veiculos.Remove(placa.ToUpper());  

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("A quantidade de horas inválida. Tente novamente.");
                    }
                }
                else
                {
                    Console.WriteLine($"Desculpe, esse veículo {placa} não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
            else if(removerPlaca != "NAO" && removerPlaca != "N")
            {
                Console.WriteLine("Entrada inválida. Responda com Sim (s) ou Não(n).");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                int totalCarrosEstacionado = 0;

                foreach (string carro in veiculos)
                {
                    Console.WriteLine(carro);
                    totalCarrosEstacionado++;
                }

                ExibirQuantidadeVagasDisponiveis();

            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private int VagasDisponiveis()
        {
            return vagasDisponiveis - veiculos.Count;
        }

        private void ExibirQuantidadeVagasDisponiveis()
        {
            Console.WriteLine($"Estamos com o total de {veiculos.Count} carros estacionados.");
            Console.WriteLine($"Vagas disponíveis: {VagasDisponiveis()}.");

        }

        private decimal CalcularValorCobrado(int horasEstacionado)
        {
            return precoInicial + (precoPorHora * horasEstacionado);

        }


    }
}