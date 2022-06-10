using System.Collections;

namespace BankAccounts;

public class Account : IEnumerable
{
    public Account(string? name, string secondName, string thirdName, string? phoneNumber, string passport)
    {
        FirstName = name;
        SecondName = secondName;
        ThirdName = thirdName;
        PhoneNumber = phoneNumber;
        Passport = passport;
    }

    public Account() : this("", "", "", "", "")
    {
    }

    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? ThirdName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Passport { get; set; }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}