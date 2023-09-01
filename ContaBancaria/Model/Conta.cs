namespace ContaBancaria.Model;

public class Conta
{
    private int numero;
    private int agencia;
    private int tipo;
    private string titular = string.Empty;
    private decimal saldo;

    //Método Construtor
    public Conta(int numero, int agencia, int tipo, string titular, decimal saldo)
    {
        this.numero = numero;
        this.agencia = agencia;
        this.tipo = tipo;
        this.titular = titular;
        this.saldo = saldo;
    }
    
    //Polimorfismo de Sobrecarga
    public Conta()
    {
        
    }

    //Métodos Getters e Setters
    public int GetNumero()
    {
        return numero;
    }

    public void SetNumero(int numero)
    {
        this.numero = numero;
    }

    public int GetAgencia()
    {
        return agencia;
    }

    public void SetAgencia(int agencia)
    {
        this.agencia = agencia;
    }

    public int GetTipo()
    {
        return tipo;
    }

    public void SetTipo(int tipo)
    {
        this.tipo = tipo;
    }

    public string GetTitular()
    {
        return titular;
    }

    public void SetTitular(string titular)
    {
        this.titular = titular;
    }

    public decimal GetSaldo()
    {
        return saldo;
    }

    public void SetSaldo(decimal saldo)
    {
        this.saldo = saldo;
    }

    //Métodos
    public virtual bool Sacar(decimal valor)
    {
        if (valor > this.saldo)
        {
            Console.WriteLine("Saldo insuficiente!");
            return false;
        }
            
        this.SetSaldo(this.saldo - valor);
        return true;
    }
    
    public void Depositar(decimal valor)
    {
        this.SetSaldo(this.saldo + valor);
    }
    
    public virtual void Visualizar()
    {
        string tipo = "";

        switch (this.tipo)
        {
            case 1:
                tipo = "Conta Corrente";
                break;
            case 2:
                tipo = "Conta Poupança";
                break;
        }

        Console.WriteLine("Dados da Conta\n" +
                          "**************************\n" +
                          "Número da Conta: " + this.numero +
                          "\nAgência: " + this.agencia +
                          "\nTipo: " + tipo +
                          "\nTitular: " + this.titular +
                          "\nSaldo: " + (this.saldo).ToString("C"));
                          //"\n**************************")
    }
}