using Microsoft.AspNetCore.Components;
using WeNerds.WeBlazor.Models;

namespace WeNerds.WeBlazor.Components;

public partial class WeMenuItem : ComponentBase
{
    [Parameter]
    public NavItem Item { get; set; }
    [Parameter]
    public Menu Menu { get; set; }

    [Inject]
    protected NavigationManager Navigation { get; set; }

    [Parameter]
    public EventCallback<string> OnClick { get; set; }
    public WeMenuItem()
    {

    }

    private string GetWeMenuItemStyle()
    {             
        return $"padding-left: {Item.GetLevel() * 20}px !important";
    }

    private string GetWeMenuItemClass()
    {
        var active = "";
        
        if (Item.Active || Item.Selected)
           active = "-active";

        return $"we-menu-item{active}";
    }
    private string GetRightIcon()
    {
        if (string.IsNullOrWhiteSpace(Item.Href) == false)
            return "";

        if (!Item.Selected)
            return "chevron_right";

        return "expand_more";
    }
    private string GetClassIcon()
    {
        var currentClass = "we-icon-menu-child";
        if (string.IsNullOrEmpty(Item.ParentId))
            currentClass = "we-icon-menu";

        if (Item.Active || Item.Selected)
            currentClass += "-active";

        return currentClass;
    }
    private string GetClassMenuDescription()
    {
        var currentClass = "we-menu-description";

        if (Item.Active || Item.Selected)
            currentClass += "-active";

        return currentClass;
    }
    private async Task ClickedAsync()
    {
        if (Item.HasHRef())
            Navigation.NavigateTo(Item.Href);

        await OnClick.InvokeAsync(Item.Level);
    }

    private string GetIcon()
    {
        var icon = "drag_indicator";
        if (Item.IsSubLevel())
        {
            icon = "radio_button_unchecked";

            if (Item.Selected)            
                icon = "radio_button_checked";
            
        }

        if (Item.HasIcon())
            icon = Item.Icon;

        Console.WriteLine(icon);

        return icon;
    }

    private bool GetClassVisible()
    {
        if (!Item.Level.Contains('.'))
            return true;

        return Item.IsParentSelected(Menu, Item.Level);
    }
}
