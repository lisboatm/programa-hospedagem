using System;
using System.Collections.Generic;
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Pessoa> hospedes = new List<Pessoa>();

Console.WriteLine("== Cadastro de Hóspedes ==");

Console.Write("Digite a quantidade de hóspedes: ");
int quantidadeHospedes = Convert.ToInt32(Console.ReadLine());

for (int i = 1; i <= quantidadeHospedes; i++)
{
    Console.Write($"Digite o nome do Hóspede {i}: ");
    string nomeHospede = Console.ReadLine();
    Pessoa hospede = new Pessoa(nome: nomeHospede);
    hospedes.Add(hospede);
}

Console.WriteLine("\n== Escolha o tipo de Suíte ==");

Console.WriteLine("1. Suíte Tabelada (R$150,00)");
Console.WriteLine("2. Suíte Standard (R$300,00)");
Console.WriteLine("3. Suíte Premium (R$500,00)");
Console.Write("Digite a opção desejada: ");
string opcaoSuite = Console.ReadLine();

Suite suite;

switch (opcaoSuite)
{
    case "1":
        suite = new Suite(tipoSuite: "Tabelada", capacidade: quantidadeHospedes, valorDiaria: 150);
        break;
    case "2":
        suite = new Suite(tipoSuite: "Standard", capacidade: quantidadeHospedes, valorDiaria: 300);
        break;
    case "3":
        suite = new Suite(tipoSuite: "Premium", capacidade: quantidadeHospedes, valorDiaria: 500);
        break;
    default:
        Console.WriteLine("Opção inválida. Suíte Tabelada será selecionada por padrão.");
        suite = new Suite(tipoSuite: "Tabelada", capacidade: quantidadeHospedes, valorDiaria: 150);
        break;
}

Reserva reserva = new Reserva(diasReservados: 5);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

bool executando = true;

while (executando)
{
    Console.WriteLine("\n============== Menu ==============");
    Console.WriteLine($"Número de hóspedes: {reserva.ObterQuantidadeHospedes()}");
    Console.WriteLine("Hóspedes:");
    foreach (Pessoa hospede in reserva.Hospedes)
    {
        Console.WriteLine(hospede.Nome);
    }
    Console.WriteLine($"Valor da diária: {reserva.CalcularValorDiaria()}");
    Console.WriteLine("==================================");
    Console.WriteLine("1. Exibir quantidade de hóspedes");
    Console.WriteLine("2. Exibir valor da diária");
    Console.WriteLine("3. Sair");
    Console.WriteLine("==================================");
    Console.Write("Digite a opção desejada: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
            break;
        case "2":
            Console.WriteLine($"Valor da diária: {reserva.CalcularValorDiaria()}");
            break;
        case "3":
            executando = false;
            break;
        default:
            Console.WriteLine("Opção inválida. Digite novamente.");
            break;
    }
}

Console.WriteLine("\nEncerrando o programa...");
