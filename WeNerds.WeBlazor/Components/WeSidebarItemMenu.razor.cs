using Microsoft.AspNetCore.Components;
using WeNerds.WeBlazor.Models;

namespace WeNerds.WeBlazor.Components;

public partial class WeSidebarItemMenu : ComponentBase
{
    [Parameter]
    public NavItem Item { get; set; }
    [Parameter]
    public Menu Menu { get; set; }

    [Parameter]
    public EventCallback<string> OnClick { get; set; }
    
    protected override void OnInitialized()
    {
        Console.WriteLine($"Item.Description: {Item.Description}");

        ShowItemMenu();
        GetClassMainDiv();
        GetClassRightIcon();
        GetClassVisible();
    }

    public WeSidebarItemMenu()
    {
    }


    private async Task Clicked()
    {              
        await OnClick.InvokeAsync(Item.Level);        
    }

    private bool ShowItemMenu()
    {
        if (!Item.Level.Contains('.'))
            return true;

        return Item.Selected;       
    }

    private string GetClassMainDiv()
    {
        if (ShowItemMenu())
            return "show-div";

        return "hidden-div";
    }
    private string GetClassRightIcon()
    {        
        if (!string.IsNullOrEmpty(Item.Href))
            return "icon";
        
        if (!Item.Selected)
            return "oi oi-chevron-right icon";

        return "oi oi-chevron-bottom icon";
    }

    private bool GetClassVisible()
    {        
        if (!Item.Level.Contains('.'))
            return true;
       
        return Item.IsParentSelected(Menu, Item.Level);                    
    }
    private string GetMenuItemClass()
    {
        if (Item.Active || Item.Selected)
            return "wenavbar-menu-item-active";

        return "wenavbar-menu-item";

    }

    private string GetRowFlexClass()
    {
        if (Item.Active || Item.Selected)
            return "row-flex-active";

        return "row-flex";

    }

}
