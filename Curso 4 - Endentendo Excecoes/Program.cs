using Curso_4___Endentendo_Excecoes;

class Program
{
    static void Main(string[] args)
    {

        try
        { 
            ContaCorrente conta = new ContaCorrente(987, 5460);
            conta.Depositar(500);
            Console.WriteLine("Saldo: "+conta.Saldo);
            conta.Sacar(2500);
            Console.WriteLine("Saldo: " + conta.Saldo);
           
        }
        catch (ArgumentException ex)
        {   
            Console.WriteLine("Erro no parãmetro: "+ex.ParamName);  
            Console.WriteLine("Ocorreu um erro do tipo ArgumentException");
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine($"{ex.Message}");

        }
        catch (SaldoinsuficienteException ex)
        {
            Console.WriteLine("Exceção: "+ ex.Message);
            Console.WriteLine("Exceção do tipo SaldoInsuficienteException");
            //Console.WriteLine(ex.StackTrace);
        }

           

        Console.ReadLine();
    }
}