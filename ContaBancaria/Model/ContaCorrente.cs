namespace ContaBancaria.Model;

public class ContaCorrente : Conta
{
    private decimal limite;
    
    //Método Construtor
    public ContaCorrente(int numero, int agencia, int tipo, string titular, decimal saldo, decimal limite) : base(numero, agencia, tipo, titular, saldo)
    {
        this.limite = limite;
    }
    
    //Métodos Getters e Setters
    public decimal GetLimite()
    {
        return limite;
    }
    
    public void SetLimite(decimal limite)
    {
        this.limite = limite;
    }
    
    public override bool Sacar(decimal valor)
    {
        if (valor > (this.GetSaldo() + limite))
        {
            Console.WriteLine("Saldo insuficiente!");
            return false;
        }
            
        this.SetSaldo(this.GetSaldo() - valor);
        //Console.WriteLine("Saque realizado com sucesso!");
        return true;
    }

    public override void Visualizar()
    {
        base.Visualizar();
        Console.WriteLine($"Limite: {this.limite.ToString("C")}");
    }
}