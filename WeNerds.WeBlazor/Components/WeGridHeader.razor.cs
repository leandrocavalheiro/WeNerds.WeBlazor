using Microsoft.AspNetCore.Components;
using WeNerds.WeBlazor.Models;

namespace WeNerds.WeBlazor.Components;

public partial class WeGridHeader : ComponentBase
{
    [Parameter]
    public ICollection<GridItem> Headers { get; set; }
    public WeGridHeader()
    {
    }
}
