using System.Text.RegularExpressions;

namespace WeNerds.WeBlazor.Models;

public class Menu
{
    public ICollection<NavItem> Items { get; set; }
    public NavItem AddMenuItem(string description, string icon, string href, bool disabled = false, bool selected = false, string id = null)
    {
        Items ??= new List<NavItem>();
        var rootMenu = new NavItem(description, GetNextLevelRoot(), icon, href, null, disabled, selected, id);
        Items.Add(rootMenu);
        return rootMenu;
    }
    public NavItem AddChildrenItem(NavItem parent, string description, string icon, string href, bool disabled = false, bool selected = false, string id = null)
    {
        if (Items == null || Items.Count == 0)
            return null;

        var newItem = new NavItem(description, GetNextLevelParent(parent.Level), icon, href, parent.Id, disabled, selected, id);
        Items.Add(newItem);
        return newItem;
    }

    private string GetNextLevelRoot()
    {
        string currentRoot = Items.Where(p => !p.Level.Contains('.')).Select(p => p.Level).OrderBy(p => p).ToList().LastOrDefault();
                
        if (string.IsNullOrEmpty(currentRoot))
            return $"1";

        int.TryParse(currentRoot, out int currentLevel);
        currentLevel++;
        return $"{currentLevel}";
    }
    private string GetNextLevelParent(string currentParent)
    {
        var lengthCurrentParent = currentParent.Length - 2;
        if (lengthCurrentParent < 0)
            lengthCurrentParent = 1;
        
        ICollection<string> itemCollection = Items.Where(p => p.Level.StartsWith($"{currentParent}.")).Select(p => p.Level.Substring(lengthCurrentParent, (p.Level.Length - lengthCurrentParent))).OrderBy(p => p).ToList();
        if (itemCollection == null || itemCollection.Count <= 0)
            return $"{currentParent}.1";

        var regex = new Regex(@"^\.\d+$");

        var matches = itemCollection.Where(v => regex.IsMatch(v)).LastOrDefault();
        if (string.IsNullOrEmpty(matches))
            return $"{currentParent}.1";
        
        var maxLevel = matches.Split('.');
        if (maxLevel.Length == 0)
            return $"{currentParent}.1";

        int.TryParse(maxLevel[maxLevel.Length - 1], out int currentLevel);
        currentLevel++;
        return $"{currentParent}.{currentLevel++}";
    }
    public void ResetSelected()
    {
        foreach (var item in Items)
            item.Selected = false;
    }
    public void ChangeActiveItem(string currentLevel)
    {
        SetSelected(currentLevel);
        SetActive(currentLevel);        
    }

    /// <summary>
    /// ItemMenu que acabou de ser selecionado
    /// </summary>
    /// <param name="currentLevel">Level do ItemMenu</param>
    private void SetSelected(string currentLevel)
    {
        if (Items == null || Items.Count == 0)
            return;

        ResetSelected();
        var hierarchyLevels = GetHierarchyLevels(currentLevel);
        var currentSelecteds = Items.Where(p => hierarchyLevels.Contains(p.Level)).ToList();
        foreach (var item in currentSelecteds)        
            item.Selected = true;
    }
    /// <summary>
    /// ItemMenu ques efetivamente ativo
    /// </summary>
    /// <param name="currentLevel">Level do ItemMenu</param>
    private void SetActive(string currentLevel)
    {
        if (Items == null || Items.Count == 0 || string.IsNullOrEmpty(currentLevel) || !IsActivable(currentLevel))
            return;
        
        var hierarchyLevels = GetHierarchyLevels(currentLevel);
        foreach (var item in Items)
            item.Active = false;

        var currentSelecteds = Items.Where(p => hierarchyLevels.Contains(p.Level)).ToList();
        foreach (var item in currentSelecteds)
            item.Active = true;
    }
    private static ICollection<string> GetHierarchyLevels(string targetLevel)
    {
        ICollection<string> hierarchyLevels = new List<string>();

        string[] levels = targetLevel.Split('.');
        string currentLevel = "";

        foreach (string level in levels)
        {
            if (!string.IsNullOrWhiteSpace(currentLevel))            
                currentLevel += ".";
            
            currentLevel += level;
            hierarchyLevels.Add(currentLevel);
        }

        return hierarchyLevels;
    }
    public bool IsParentSelected(string currentLevel)
    {
        if (!currentLevel.Contains('.'))
            return true;
       
        var hierarchyLevels = GetHierarchyLevels(currentLevel).Where(p => p != currentLevel).ToList();
        currentLevel = RemoveLastLevel(currentLevel);
        return hierarchyLevels.Contains(currentLevel);        
    }
    private string RemoveLastLevel(string value)
    {
        int lastDotIndex = value.LastIndexOf('.');
        if (lastDotIndex != -1)        
            return value.Substring(0, lastDotIndex);
        
        return value;
    }
    public bool IsActivable(string currentLevel)
        => Items.Count(p => p.Level.StartsWith(currentLevel)) <= 1;
             
}
