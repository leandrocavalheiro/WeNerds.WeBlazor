using Microsoft.AspNetCore.Components;

namespace WeNerds.WeBlazor.Components;

public partial class WeSidebarHeader : ComponentBase
{

    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public string Logo { get; set; }

    [Parameter]
    public string Href { get; set; } = "/";

    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }
    public WeSidebarHeader()
    {

    }

    private bool ShowLogo()
        => !string.IsNullOrEmpty(Logo);

    
}
