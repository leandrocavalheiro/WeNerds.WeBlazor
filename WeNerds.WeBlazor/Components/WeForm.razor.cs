using Microsoft.AspNetCore.Components;

namespace WeNerds.WeBlazor.Components;

public partial class WeForm : ComponentBase
{
    [Parameter]
    public string Title { get; set; }
    [Parameter]
    public bool ShowTitle { get; set; } = true;
    [Parameter]
    public RenderFragment ChildContent { get; set; }
    public WeForm()
    {

    }
}
