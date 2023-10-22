using Microsoft.AspNetCore.Components;
using WeNerds.WeBlazor.Models;

namespace WeNerds.WeBlazor.Components;

public partial class WeSidebarUserLogged : ComponentBase
{

    [Parameter]
    public UserLogged UserLogged { get; set; }


    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }
    public WeSidebarUserLogged()
    {

    }
}
