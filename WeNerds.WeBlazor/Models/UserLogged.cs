namespace WeNerds.WeBlazor.Models;

public struct UserLogged
{
    public string Name { get; set; }
    public string Role { get; set; }
    public string Avatar { get; set; }
    public UserLogged(string name, string role, string avatar)
    {
        Name = name;
        Role = role;
        Avatar = avatar;
    }

}
