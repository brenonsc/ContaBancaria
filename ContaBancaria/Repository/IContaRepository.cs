using System.Runtime.InteropServices;
using ContaBancaria.Model;
namespace ContaBancaria.Repository;

public interface IContaRepository
{
    //Métodos CRUD
    public void ProcurarPorNumero(int numero);
    public void ListarContas();
    public void Cadastrar(Conta conta);
    public void Atualizar(Conta conta);
    public void Deletar(int numero);
    
    //Métodos de Operação Bancária
    public void Sacar(int numero, decimal valor);
    public void Depositar(int numero, decimal valor);
    public void Transferir(int numeroOrigem, int numeroDestino, decimal valor);
}