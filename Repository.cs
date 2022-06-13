namespace BankAccounts;

public class Repository
{
    private readonly List<Account> _list = new();

    public Repository(string? path)
    {
        Path = path;
    }

    private string? Path { get; }

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
                    FirstName = field[0],
                    SecondName = field[1],
                    ThirdName = field[2],
                    PhoneNumber = field[3],
                    Passport = field[4]
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