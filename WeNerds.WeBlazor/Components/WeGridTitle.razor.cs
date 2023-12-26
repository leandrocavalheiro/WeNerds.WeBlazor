using Microsoft.AspNetCore.Components;


namespace WeNerds.WeBlazor.Components;

public partial class WeGridTitle : ComponentBase
{
    [Parameter]
    public string Title { get; set; }
    [Parameter]
    public string Subtitle { get; set; }
    [Parameter]
    public bool ShowNewButton { get; set; }
    public WeGridTitle()
    {
    }
}
