using Microsoft.AspNetCore.Components;

namespace WeNerds.WeBlazor.Components;

public partial class WeCard : ComponentBase
{
    [Parameter]
    public string Title { get; set; }
    [Parameter]
    public bool ShowTitle { get; set; } = true;
    [Parameter]
    public bool ShowNewButton { get; set; }
    public WeCard()
    {

    }
}
