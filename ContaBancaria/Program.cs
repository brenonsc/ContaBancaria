﻿using System.Drawing;
using ContaBancaria.Controller;
using ContaBancaria.Model;

namespace ContaBancaria;

class Program
{
    private static ConsoleKeyInfo consoleKeyInfo;
    
    static void Main(string[] args)
    {
        int opcao, agencia, tipo, aniversario, numero;
        string? titular;
        decimal saldo, limite;
        

        ContaController contas = new();
        ContaCorrente cc1 = new ContaCorrente(contas.GerarNumero(), 456, 1, "Breno", 2000, 500);
        contas.Cadastrar(cc1);
        ContaPoupanca cp1 = new ContaPoupanca(contas.GerarNumero(), 789, 3, "Samantha", 1000, 10);
        contas.Cadastrar(cp1);
        
        /*
        cc1.Visualizar();

        cc1.Sacar(3000);
        cc1.Sacar(2500);
        
        cc1.Visualizar();
        */
        
        cp1.Visualizar();
        cp1.Depositar(100);
        cp1.Visualizar();
        cp1.Sacar(50);
        cp1.Visualizar();
        
        while(true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            
            Console.Write("************************************************************\n\n" +
                          "\t\t\tMATRIX BANK\n" +
                          "\t\tEntre na Matrix Financeira\n\n" +
                          "************************************************************\n\n" +
                          "\t\t1 - Criar conta\n" +
                          "\t\t2 - Listar todas as Contas\n" +
                          "\t\t3 - Buscar Conta por número\n" +
                          "\t\t4 - Atualizar dados da Conta\n" +
                          "\t\t5 - Apagar Conta\n" +
                          "\t\t6 - Sacar\n" +
                          "\t\t7 - Depositar\n" +
                          "\t\t8 - Transferência entre Contas\n" +
                          "\t\t9 - Sair\n\n" +
                          "************************************************************");
            
            Console.Write("\nDigite a opção desejada: ");

            //Tratamento de exceção para entrada de dados em formato incorreto
            try
            {
                opcao = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDigite um valor inteiro entre 1 e 9!\n");
                opcao = 0;
                Console.ResetColor();
                KeyPress();
                continue;
            }

            if (opcao == 9)
            {
                Console.WriteLine("\nMATRIX BANK - Descubra o banco da nova realidade!");
                Sobre();
                Console.ResetColor();
                System.Environment.Exit(0);
            }

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Criar Conta\n\n");
                    Console.ResetColor();
                    
                    Console.Write("Digite o número da agência: ");
                    agencia = int.Parse(Console.ReadLine());
                    
                    Console.Write("Digite o nome do titular: ");
                    titular = Console.ReadLine();
                    
                    titular ??= string.Empty;

                    do
                    {
                        Console.Write("Digite o tipo da conta (1 - Corrente | 2 - Poupança): ");
                        tipo = int.Parse(Console.ReadLine());
                    } while (tipo != 1 && tipo != 2);
                    
                    Console.Write("Digite o saldo inicial: ");
                    saldo = decimal.Parse(Console.ReadLine());

                    switch (tipo)
                    {
                        case 1:
                            Console.Write("Digite o limite: ");
                            limite = decimal.Parse(Console.ReadLine());
                        
                            ContaCorrente cc = new ContaCorrente(contas.GerarNumero(), agencia, tipo, titular, saldo, limite);
                            contas.Cadastrar(cc);
                            break;
                        case 2:
                            Console.Write("Digite o dia do aniversário da conta: ");
                            aniversario = int.Parse(Console.ReadLine());
                        
                            ContaPoupanca cp = new ContaPoupanca(contas.GerarNumero(), agencia, tipo, titular, saldo, aniversario);
                            contas.Cadastrar(cp);
                            break;
                    }
                    
                    KeyPress();
                    break;
                case 2:
                    Console.WriteLine("\n\nListar todas as Contas\n");
                    Console.ResetColor();
                    contas.ListarContas();
                    KeyPress();
                    break;
                case 3:
                    Console.WriteLine("\n\nConsultar dados da Conta por número");
                    Console.Write("Digite o número da conta: ");
                    numero = int.Parse(Console.ReadLine());
                    
                    Console.Write("\n");
                    contas.ProcurarPorNumero(numero);
                    Console.ResetColor();

                    KeyPress();
                    break;
                case 4:
                    Console.WriteLine("\n\nAtualizar dados da Conta por número");
                    Console.ResetColor();
                    
                    Console.Write("Digite o número da conta: ");
                    numero = int.Parse(Console.ReadLine());

                    var conta = contas.BuscarNaCollection(numero);
                    if (conta is not null)
                    {
                        Console.Write("Digite o número da agência: ");
                        agencia = int.Parse(Console.ReadLine());
                    
                        Console.Write("Digite o nome do titular: ");
                        titular = Console.ReadLine();
                    
                        titular ??= string.Empty;
                    
                        Console.Write("Digite o saldo: ");
                        saldo = decimal.Parse(Console.ReadLine());

                        switch (conta.GetTipo())
                        {
                            case 1:
                                Console.Write("Digite o limite: ");
                                limite = decimal.Parse(Console.ReadLine());
                        
                                ContaCorrente cc = new ContaCorrente(numero, agencia, conta.GetTipo(), titular, saldo, limite);
                                contas.Atualizar(cc);
                                break;
                            case 2:
                                Console.Write("Digite o dia do aniversário da conta: ");
                                aniversario = int.Parse(Console.ReadLine());
                        
                                ContaPoupanca cp = new ContaPoupanca(numero, agencia, conta.GetTipo(), titular, saldo, aniversario);
                                contas.Atualizar(cp);
                                break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"A conta número {numero} não foi encontrada!");
                        Console.ResetColor();
                    }
                    KeyPress();
                    break;
                case 5:
                    Console.WriteLine("\n\nApagar a Conta por número");
                    Console.Write("Digite o número da conta: ");
                    numero = int.Parse(Console.ReadLine());
                    
                    Console.Write("\n");
                    contas.Deletar(numero);
                    
                    Console.ResetColor();

                    KeyPress();
                    break;
                case 6:
                    Console.WriteLine("Saque\n\n");
                    Console.ResetColor();

                    KeyPress();
                    break;
                case 7:
                    Console.WriteLine("Depósito\n\n");
                    Console.ResetColor();

                    KeyPress();
                    break;
                case 8:
                    Console.WriteLine("Transferência entre Contas\n\n");
                    Console.ResetColor();

                    KeyPress();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOpção Inválida!\n");
                    Console.ResetColor();

                    KeyPress();
                    break;
            }
        } 
        
        static void Sobre()
        {
            Console.Write("####################################################\n" +
                          "\tProjeto desenvolvido por: \n" +
                          "\tBreno Henrique - brenonsc@gmail.com\n" +
                          "\tgithub.com/brenonsc\n" +
                          "####################################################");
        }
        
        static void KeyPress()
        {
            do
            {
                Console.Write("Pressione Enter para continuar...");
                consoleKeyInfo = Console.ReadKey();
            } while (consoleKeyInfo.Key != ConsoleKey.Enter);
        }
    }
}

