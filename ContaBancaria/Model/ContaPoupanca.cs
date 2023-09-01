namespace ContaBancaria.Model;

public class ContaPoupanca : Conta
{
    private int aniversario;
    
    //Método Construtor
    public ContaPoupanca(int numero, int agencia, int tipo, string titular, decimal saldo, int aniversario) : base(numero, agencia, tipo, titular, saldo)
    {
        this.aniversario = aniversario;
    }
    
    //Métodos Getters e Setters
    public int GetAniversario()
    {
        return aniversario;
    }
    
    public void SetAniversario(int aniversario)
    {
        this.aniversario = aniversario;
    }
    
    public override void Visualizar()
    {
        base.Visualizar();
        Console.WriteLine($"Aniversário: todo dia {this.aniversario}");
    }
}