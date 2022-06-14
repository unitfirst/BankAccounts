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
        return $"ID: {Id,12}\n" +
               $"Name: {FirstName,14}\n" +
               $"Second name: {SecondName,7}\n" +
               $"Third name: {ThirdName,9}\n" +
               $"Mobile: {PhoneNumber,20}\n" +
               $"Passport: {(access ? Passport : "**** ******"),16}";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        var objAsPart = obj as Account;
        if (objAsPart == null) return false;
        else return Equals(objAsPart);
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