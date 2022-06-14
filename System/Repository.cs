namespace BankAccounts.System;

public class Repository
{
    private readonly List<Account> _list = new();

    public Repository(string? path)
    {
        Path = path;
    }

    private string? Path { get; set; }

    public List<Account> GetList()
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
                    Id = int.Parse(field[0]),
                    FirstName = field[1],
                    SecondName = field[2],
                    ThirdName = field[3],
                    PhoneNumber = field[4],
                    Passport = field[5]
                };

                _list.Add(account);
            }

            file.Close();
        }
        else
        {
            var text = "This, path, is, not, correct";
            File.WriteAllText(Path!, text);

            Console.WriteLine("File is not correct.");
        }

        return _list;
    }
}