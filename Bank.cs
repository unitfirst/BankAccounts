using BankAccounts.Interfaces;
using BankAccounts.Roles;

namespace BankAccounts;

public class Bank : IEditPhoneNumber, IEditFullName
{
    private string? Path { get; }
    private Account account = new();
    private Employee employee;
    private readonly List<Account> _accounts = new();
    private readonly bool _flag;

    public Bank(string? path)
    {
        Path = path;
        Console.WriteLine("Please select role:" +
                          "\n1.Consultant" +
                          "\n2.Manager");
        employee = Console.ReadLine() == "1" ? new Consultant() : new Manager();
        _flag = employee.GetType() != typeof(Consultant);
    }

    public List<Account> GetAccountList()
    {
        if (Path != null)
        {
            using var file = new StreamReader(Path);

            string? line;
            while ((line = file.ReadLine()) != null)
            {
                var field = line.Split(", ");
                var account = new Account
                {
                    FirstName = field[0],
                    SecondName = field[1],
                    ThirdName = field[2],
                    PhoneNumber = field[3],
                    Passport = field[4]
                };

                _accounts.Add(account);
            }

            file.Close();
        }

        return _accounts;
    }
    
    public void AccountInfo()
    {
        Console.WriteLine(
            $"{"Account name",-20}{"Second Name",-20}{"Third name",-20}{"Phone number",-20}{"Passport",-10}");

        foreach (var item in _accounts)
            Console.WriteLine(
                $"{item.FirstName,-20}" +
                $"{item.SecondName,-20}" +
                $"{item.ThirdName,-20}" +
                $"{item.PhoneNumber,-20}" +
                $"{(_flag == false ? "**** ******" : item.Passport),-10}");
    }

    public void EditName()
    {
        if (employee is Consultant)
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
                account.FirstName = name;
            }
            else
            {
                Console.WriteLine("Name cant be empty.");
            }
        }
    }
    
    public void EditPhoneNumber(Account account)
    {
        Console.WriteLine("Type new number:");
        var number = Console.ReadLine();

        if (number != string.Empty)
        {
            Console.WriteLine("Phone number was changed.");
            account.PhoneNumber = number;
        }
        else
        {
            Console.WriteLine("Phone number cant be empty.");
        }
    }
    
    private void PrintAccessDenied()
    {
        Console.WriteLine("Sorry, you dont have permission to edit name.");
    }

    public void EditName(Account account)
    {
        throw new NotImplementedException();
    }
}