## README

### Descrição

Este projeto em C# simula um sistema de reservas de hospedagem, permitindo cadastrar hóspedes, selecionar tipos de suíte e calcular o valor das diárias. O sistema inclui um menu interativo para exibir a quantidade de hóspedes e o valor da diária.

### Funcionalidades

- Cadastro de hóspedes
- Seleção do tipo de suíte
- Cálculo do valor das diárias
- Exibição da quantidade de hóspedes
- Exibição do valor das diárias
- Menu interativo

### Estrutura do Projeto

O projeto inclui as seguintes classes:

- **Pessoa:** Representa um hóspede.
- **Suite:** Representa uma suíte com tipo, capacidade e valor da diária.
- **Reserva:** Gerencia a reserva, incluindo a quantidade de dias, hóspedes e suíte, além de calcular o valor total da diária.

### Requisitos

- .NET SDK

### Como Executar

1. Clone o repositório ou baixe o código-fonte.
2. Navegue até o diretório do projeto.
3. Compile o projeto usando o comando:

```bash
dotnet build
```

4. Execute o projeto usando o comando:

```bash
dotnet run
```

### Funcionalidades Detalhadas

#### Cadastro de Hóspedes

O programa solicita ao usuário a quantidade de hóspedes e, em seguida, os nomes de cada hóspede.

#### Seleção do Tipo de Suíte

O usuário pode escolher entre três tipos de suítes:
1. Suíte Tabelada (R$ 150,00 por diária)
2. Suíte Standard (R$ 300,00 por diária)
3. Suíte Premium (R$ 500,00 por diária)

#### Cálculo do Valor das Diárias

O valor da diária é calculado com base na suíte selecionada e na quantidade de dias reservados. 

#### Menu Interativo

O menu permite ao usuário:
1. Exibir a quantidade de hóspedes
2. Exibir o valor da diária
3. Sair do programa

### Exemplo de Execução

```plaintext
== Cadastro de Hóspedes ==
Digite a quantidade de hóspedes: 2
Digite o nome do Hóspede 1: Alice
Digite o nome do Hóspede 2: Bob

== Escolha o tipo de Suíte ==
1. Suíte Tabelada (R$150,00)
2. Suíte Standard (R$300,00)
3. Suíte Premium (R$500,00)
Digite a opção desejada: 2

============== Menu ==============
Número de hóspedes: 2
Hóspedes:
Alice
Bob
Valor da diária: 1500
==================================
1. Exibir quantidade de hóspedes
2. Exibir valor da diária
3. Sair
==================================
Digite a opção desejada: 1
Quantidade de hóspedes: 2
```

### Estrutura do Código

1. **Cadastro de Hóspedes:**
    ```csharp
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
    ```

2. **Seleção do Tipo de Suíte:**
    ```csharp
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
    ```

3. **Cadastro e Gerenciamento da Reserva:**
    ```csharp
    Reserva reserva = new Reserva(diasReservados: 5);
    reserva.CadastrarSuite(suite);
    reserva.CadastrarHospedes(hospedes);
    ```

4. **Menu Interativo:**
    ```csharp
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
    ```

### Contribuição

Sinta-se à vontade para contribuir com melhorias no código ou na documentação, abrindo issues ou pull requests no repositório correspondente.
