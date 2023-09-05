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
            Console.WriteLine($"A conta número {numero} não foi encontrada!");
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
        Console.WriteLine($"A conta {conta.GetNumero()} foi criada com sucesso!");
    }

    public void Atualizar(Conta conta)
    {
        var buscaConta = BuscarNaCollection(conta.GetNumero());
        
        if (buscaConta is not null)
        {
            var index = listaContas.IndexOf(buscaConta);
            listaContas[index] = conta;
            
            Console.WriteLine($"A conta {conta.GetNumero()} foi atualizada com sucesso!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"A conta número {conta.GetNumero()} não foi encontrada!");
            Console.ResetColor();
        }
    }

    public void Deletar(int numero)
    {
        var conta = BuscarNaCollection(numero);

        if (conta is not null)
            if(listaContas.Remove(conta))
                Console.WriteLine($"A conta número {numero} foi removida com sucesso!");
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
        throw new NotImplementedException();
    }

    public void Depositar(int numero, decimal valor)
    {
        throw new NotImplementedException();
    }

    public void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
    {
        throw new NotImplementedException();
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
}