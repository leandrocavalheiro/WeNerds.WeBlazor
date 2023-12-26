using Microsoft.AspNetCore.Components;
using WeNerds.WeBlazor.Models;


namespace WeNerds.WeBlazor.Components;

public partial class WeLogin : ComponentBase
{
    [Parameter]
    public string Logo { get; set; }
    [Parameter]
    public string Title { get; set; } = "Login";
    [Parameter]
    public string Subtitle { get; set; } = "Enter your credentials to log in";

    [Parameter]
    public string LabelUser { get; set; } = "User";

    [Parameter]
    public string LabePassword { get; set; } = "Password";

    [Parameter]
    public string Image { get; set; }
    [Parameter]
    public EventCallback<WeButtonLoginClickedArgs> ButtonLoginClicked { get; set; }

    private string User { get; set; }
    private string Password { get; set; }

    public WeLogin()
    {

    }

    private bool HasLogo()
        => string.IsNullOrWhiteSpace(Logo) == false;
    private string GetImage()
    {
        var result = "_content/WeNerds.WeBlazor/images/login_default.jpg";
        if (string.IsNullOrWhiteSpace(Image) == false)
            result = Image;

        return result;
    }
    private string GetLogo()
    {
        var result = "_content/WeNerds.WeBlazor/images/logo.png";
        if (string.IsNullOrWhiteSpace(Logo) == false)
            result = Logo;

        return result;
    }

    private async Task LoginClickedAsync()
    {
        await ButtonLoginClicked.InvokeAsync(new WeButtonLoginClickedArgs(User, Password));
    }
}
