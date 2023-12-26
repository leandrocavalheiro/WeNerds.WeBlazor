using Microsoft.AspNetCore.Components;

namespace WeNerds.WeBlazor.Components;

public partial class WeHeader : ComponentBase
{
    [Parameter]
    public string Title { get; set; }
    [Parameter]
    public string Subtitle { get; set; }
    public WeHeader()
    {
    }
}
