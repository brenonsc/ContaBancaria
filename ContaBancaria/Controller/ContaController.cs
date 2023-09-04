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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public void Deletar(int numero)
    {
        throw new NotImplementedException();
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
}