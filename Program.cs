using System;
using System.Collections.Generic;

namespace SistemadoDeEstacionamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcao;
            string placa;
            int contador;
            List<string> carros = new List<string>();
            CalculoEstacionamento estacionamento = new CalculoEstacionamento();

            Console.WriteLine("Bem-vindo ao Sistema de Estacionamento");
            Console.Write("Digite o preço inicial: ");
            estacionamento.ValorFixo = int.Parse(Console.ReadLine());

            Console.Write("Digite o preço por hora: ");
            estacionamento.ValorHora = int.Parse(Console.ReadLine());

            Console.Clear();

            do
            {
                Console.WriteLine("Digite qual opção deseja!");
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Encerrar");

                Console.Write("Digite a opção: ");
                opcao = Console.ReadLine();
                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Digite a placa do veículo: ");
                        placa = Console.ReadLine().ToUpper();
                        carros.Add(placa);
                        Console.WriteLine("Veículo cadastrado com sucesso.");
                        Console.WriteLine("Pressione Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "2":
                        if (carros.Count == 0)
                        {
                            Console.WriteLine("Não há veículos cadastrados.");
                        }
                        else
                        {
                            contador = 1;
                            Console.WriteLine("Lista de carros estacionados:\n");
                            foreach (string item in carros)
                            {
                                Console.WriteLine($"{contador} - {item}");
                                contador++;
                            }

                            Console.Write("\nDigite a placa do veículo: ");
                            placa = Console.ReadLine().ToUpper();

                            if (carros.Contains(placa))
                            {
                                carros.Remove(placa);
                                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                                estacionamento.TempoEstacionado = int.Parse(Console.ReadLine());

                                int valorTotal = estacionamento.ValorFixo + (estacionamento.ValorHora * estacionamento.TempoEstacionado);
                                Console.WriteLine($"\nO veículo {placa} foi removido. Valor total: R$ {valorTotal}");
                            }
                            else
                            {
                                Console.WriteLine("\nPlaca não encontrada.");
                            }
                        }
                        Console.WriteLine("Pressione Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "3":
                        if (carros.Count == 0)
                        {
                            Console.WriteLine("Nenhum veículo cadastrado.");
                        }
                        else
                        {
                            contador = 1;
                            Console.WriteLine("Lista de carros estacionados:\n");
                            foreach (string item in carros)
                            {
                                Console.WriteLine($"{contador} - {item}");
                                contador++;
                            }
                        }
                        Console.WriteLine("\nPressione Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "4":
                        Console.WriteLine("Encerrando sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        Console.WriteLine("Pressione Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }

            } while (opcao != "4");
        }
    }
}