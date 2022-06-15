using BankAccounts.Roles;
using BankAccounts.System;

namespace BankAccounts;

public class Account
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? ThirdName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Passport { get; set; }

    public string ToString(bool access)
    {
        return $"{Id,-6}" +
               $"{FirstName,-20}" +
               $"{SecondName,-20}" +
               $"{ThirdName,-20}" +
               $"{PhoneNumber,-20}" +
               $"{(access ? Passport : "**** ******"),-10}";
    }

    public override bool Equals(object? obj)
    {
        return
            obj is Account account
            && FirstName == account.FirstName
            && SecondName == account.SecondName
            && ThirdName == account.ThirdName;
    }

    public override int GetHashCode()
    {
        return Id;
    }

    private bool Equals(Account other)
    {
        return Id.Equals(other.Id);
    }
}