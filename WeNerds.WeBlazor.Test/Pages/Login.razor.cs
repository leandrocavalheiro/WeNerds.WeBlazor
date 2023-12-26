using WeNerds.WeBlazor.Models;

namespace WeNerds.WeBlazor.Test.Pages;

public partial class Login
{
    public Login()
    {

    }

    private void Authenticate(WeButtonLoginClickedArgs args)
    {
        Console.WriteLine($"");
        Console.WriteLine($"User: {args.User}");
        Console.WriteLine($"Password: {args.Password}");
        Console.WriteLine($"");
    }
}
