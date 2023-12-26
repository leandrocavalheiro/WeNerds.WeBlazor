using Microsoft.AspNetCore.Components;
using WeNerds.WeBlazor.Models;

namespace WeNerds.WeBlazor.Components;
public partial class WeSidebar : ComponentBase
{
    [Parameter]
    public string Logo { get; set; }
    [Parameter]
    public UserLogged UserLogged { get; set; }
    [Parameter]
    public Menu Menu { get; set; }

    public WeSidebar()
    {
    }
}