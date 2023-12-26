using Microsoft.AspNetCore.Components;


namespace WeNerds.WeBlazor.Components;

public partial class WeTitle : ComponentBase
{
    [Parameter]
    public string Title { get; set; }
    [Parameter]
    public string Subtitle { get; set; }
    [Parameter]
    public string CustomClass { get; set; }    
    public WeTitle()
    {
    }

    private string GetClass()
    {
        if (string.IsNullOrWhiteSpace(CustomClass))
            return "we-title";
        return CustomClass;
    }
}