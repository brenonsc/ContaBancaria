using System.Drawing;
using ContaBancaria.Model;

namespace ContaBancaria;

class Program
{
    private static ConsoleKeyInfo consoleKeyInfo;
    
    static void Main(string[] args)
    {
        int opcao = 0;
        ContaCorrente cc1 = new ContaCorrente(2, 456, 1, "Breno", 2000, 500);
        ContaPoupanca cp1 = new ContaPoupanca(3, 789, 3, "Samantha", 1000, 10);
        
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
            opcao = int.Parse(Console.ReadLine());

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

                    KeyPress();
                    break;
                case 2:
                    Console.WriteLine("Listar todas as Contas\n\n");
                    Console.ResetColor();

                    KeyPress();
                    break;
                case 3:
                    Console.WriteLine("Consultar dados da Conta - por número\n\n");
                    Console.ResetColor();

                    KeyPress();
                    break;
                case 4:
                    Console.WriteLine("Atualizar dados da Conta\n\n");
                    Console.ResetColor();

                    KeyPress();
                    break;
                case 5:
                    Console.WriteLine("Apagar a Conta\n\n");
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

