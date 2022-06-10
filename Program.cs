namespace BankAccounts;

internal class Program
{
    public static void Main(string[] args)
    {
        Bank bank = new(@"clients.txt");

        bank.GetAccountList();
        bank.AccountInfo();

        Console.ReadKey();
        Console.Clear();
    }
}