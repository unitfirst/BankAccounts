using System.Text;
using BankAccounts.Interfaces;
using BankAccounts.Roles;

namespace BankAccounts.System;

public class Bank : IEditPhoneNumber, IEditFullName
{
    private readonly Account _account = new();
    private readonly Employee _employee;
    private readonly Repository _repo = new(@"clients.txt");
    private List<Account> _accountList;

    private Bank(List<Account> accountList)
    {
        _accountList = accountList;

        Console.WriteLine("Please select role:" +
                          "\n1.Consultant" +
                          "\n2.Manager");

        _employee = Console.ReadLine() == "1" ? new Consultant() : new Manager();
    }

    public Bank() : this(new List<Account>())
    {
    }

    public void EditName()
    {
        if (_employee is Consultant)
        {
            PrintAccessDenied();
        }
        else
        {
            Console.WriteLine("Type new name:");
            var name = Console.ReadLine();

            if (name != string.Empty)
            {
                Console.WriteLine("Name was changed.");
                _account.FirstName = name;
            }
            else
            {
                Console.WriteLine("Name cant be empty.");
            }
        }
    }

    public void EditPhoneNumber()
    {
        Console.WriteLine("Type new number:");
        var number = Console.ReadLine();

        if (number != string.Empty)
        {
            Console.WriteLine("Phone number was changed.");
            _account.PhoneNumber = number;
        }
        else
        {
            Console.WriteLine("Phone number cant be empty.");
        }
    }

    public void GetList()
    {
        _accountList = _repo.GetList();
    }

    public void ShowRecord()
    {
        Console.WriteLine("\nType name for search...");

        var nameRequest = Console.ReadLine();
        var access = _employee is not Consultant;

        Console.WriteLine($"\nFind: Account where name contains \"{nameRequest}\":");
        Console.WriteLine(_accountList.Find(
            account => account.FirstName!.Contains($"{ToCamel(nameRequest)}"))?.ToString(access));
    }

    public void ShowAllRecords()
    {
        PrintHeader();
        foreach (var item in _accountList)
            Console.WriteLine(
                $"{item.Id,-6}" +
                $"{item.FirstName,-20}" +
                $"{item.SecondName,-20}" +
                $"{item.ThirdName,-20}" +
                $"{item.PhoneNumber,-20}" +
                $"{(_employee is Consultant ? "**** ******" : item.Passport),-10}");
    }

    private void PrintAccessDenied()
    {
        Console.WriteLine("Sorry, you dont have permission to edit name.");
    }

    private void PrintHeader()
    {
        Console.WriteLine(
            $"{"ID",-6}" +
            $"{"Account name",-20}" +
            $"{"Second Name",-20}" +
            $"{"Third name",-20}" +
            $"{"Phone number",-20}" +
            $"{"Passport",-10}");
    }

    private string ToCamel(string? nameRequest)
    {
        var array = nameRequest?.Split(' ');
        var result = new StringBuilder();

        if (array != null)
            foreach (var item in array)
                result.Append(char.ToUpper(item[0]) + item.Substring(1, item.Length - 1));

        return result.ToString();
    }
}