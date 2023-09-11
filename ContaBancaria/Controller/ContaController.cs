using ContaBancaria.Model;
using ContaBancaria.Repository;
using NotImplementedException = System.NotImplementedException;

namespace ContaBancaria.Controller;

public class ContaController : IContaRepository
{
    private readonly List<Conta> listaContas = new();
    int numero = 0;
    
    public void ProcurarPorNumero(int numero)
    {
        var conta = BuscarNaCollection(numero);

        if (conta is not null)
            conta.Visualizar();
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nA conta número {numero} não foi encontrada!");
            Console.ResetColor();
        }
    }

    public void ListarContas()
    {
        foreach (var conta in listaContas)
        {
            conta.Visualizar();
        }
    }

    public void Cadastrar(Conta conta)
    {
        listaContas.Add(conta);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nA conta {conta.GetNumero()} foi criada com sucesso!\n");
    }

    public void Atualizar(Conta conta)
    {
        var buscaConta = BuscarNaCollection(conta.GetNumero());
        
        if (buscaConta is not null)
        {
            var index = listaContas.IndexOf(buscaConta);
            listaContas[index] = conta;
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nA conta {conta.GetNumero()} foi atualizada com sucesso!\n");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nA conta número {conta.GetNumero()} não foi encontrada!\n");
            Console.ResetColor();
        }
    }

    public void Deletar(int numero)
    {
        var conta = BuscarNaCollection(numero);

        if (conta is not null)
            if (listaContas.Remove(conta))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"A conta número {numero} foi removida com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta número {numero} não foi removida!");
                Console.ResetColor();
            }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"A conta número {numero} não foi encontrada!");
            Console.ResetColor();
        }
    }

    public void Sacar(int numero, decimal valor)
    {
        var conta = BuscarNaCollection(numero);
        
        if (conta is not null)
        {
            conta.Sacar(valor);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Saque de {valor.ToString("C")} realizado com sucesso!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"A conta número {numero} não foi encontrada!");
            Console.ResetColor();
        }
    }

    public void Depositar(int numero, decimal valor)
    {
        var conta = BuscarNaCollection(numero);
        
        if (conta is not null)
        {
            conta.Depositar(valor);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Depósito de {valor.ToString("C")} realizado com sucesso!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"A conta número {numero} não foi encontrada!");
            Console.ResetColor();
        }
    }

    public void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
    {
        var contaOrigem = BuscarNaCollection(numeroOrigem);
        var contaDestino = BuscarNaCollection(numeroDestino);
        
        if (contaOrigem is not null && contaDestino is not null)
        {
            if (contaOrigem.Sacar(valor))
            {
                contaDestino.Depositar(valor);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Transferência de {valor.ToString("C")} realizado com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Conta de Origem e/ou Conta de destino não foram encontrada!");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"A conta número {numeroOrigem} não foi encontrada!");
            Console.ResetColor();
        }
    }
    
    //Métodos Auxiliares
    public int GerarNumero()
    {
        numero++;
        return numero;
    }
    
    //Método para buscar um objeto Conta na lista de contas pelo número
    public Conta? BuscarNaCollection(int numero)
    {
        foreach (var conta in listaContas)
        {
            if (conta.GetNumero() == numero)
            {
                return conta;
            }
        }

        return null;
    }

    public void ListarContasPorTitular(string titular)
    {
        //var contasPorTitular = listaContas.Where(conta => conta.GetTitular() == titular);
        
        var contasPorTitular = from conta in listaContas
            where conta.GetTitular().ToUpper().Contains(titular.ToUpper())
            select conta;
        
        contasPorTitular.ToList().ForEach(c => c.Visualizar());
    }
}