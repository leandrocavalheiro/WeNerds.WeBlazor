using Microsoft.AspNetCore.Components;


namespace WeNerds.WeBlazor.Components;

public partial class WeButton : ComponentBase
{
    [Parameter]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [Parameter]
    public string Icon { get; set; }
    [Parameter]
    public string Title { get; set; }
    [Parameter]
    public string CssClass { get; set; }


    [Parameter]
    public EventCallback<int> OnClicked { get; set; }



    public WeButton()
    {

    }
    private string GetClassButton()
    {
        var result = "we-button-icon";
        if (string.IsNullOrWhiteSpace(Icon))
            result = "we-button";
            
        if (string.IsNullOrWhiteSpace(CssClass) == false)
            result = CssClass;

        return result;
    }
    private string GetClassIcon()
    {
        return "we-icon";
    }

    private async Task ButtonClickedAsync()
    {
        Console.WriteLine($"{nameof(ButtonClickedAsync)}: ButtonClickedAsync");
        await OnClicked.InvokeAsync();
    }
}
