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
        ShowItemMenu();
        GetClassMainDiv();
        GetClassRightIcon();
        GetClassVisible();
    }

    public WeSidebarItemMenu()
    {
    }


    private async Task ClickedAsync()
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

    private string  GetIcon()
    {
        var icon = string.IsNullOrWhiteSpace(Item.ParentId) ? "label" : "minimize";
        if (string.IsNullOrWhiteSpace(Item.Icon) == false)
            icon = Item.Icon;

        Console.WriteLine(icon);

        return icon;
    }

    private string GetRightIcon()
    {
        if (!string.IsNullOrEmpty(Item.Href))
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
}
