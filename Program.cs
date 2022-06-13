namespace BankAccounts;

internal class Program
{
    public static void Main(string[] args)
    {
        Bank bank = new();

        bank.GetList();
        bank.AccountInfo();

        Console.ReadKey();
        Console.Clear();
    }
}