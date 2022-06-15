using BankAccounts.System;

namespace BankAccounts;

internal class Program
{
    public static void Main(string[] args)
    {
        Bank bank = new();

        bank.GetList();
        bank.ShowAllRecords();
        bank.FindRecordByName();

        Console.ReadKey();
        Console.Clear();
    }
}