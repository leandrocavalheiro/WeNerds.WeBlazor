namespace WeNerds.WeBlazor.Models;

public class NavItem
{
    public string Id { get; set; }
    public string Level { get; set; }
    public string Description { get; set; }
    public string Href { get; set; }
    public string ParentId { get; set; }
    public string Icon { get; set; }
    public bool Disabled { get; set; }
    public bool Selected { get; set; }
    public bool Active { get; set; }

    public NavItem(string description, string level, string icon, string href, string parentId = null, bool disabled = false, bool selected = false, string id = null)
    {
        Id = string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id;
        Level = level;
        Description = description;
        Href = href;
        ParentId = parentId;
        Icon = icon;
        Disabled = disabled;
        Selected = selected;
    }
    public bool IsParent(string levelCompare)
    {
        if (string.IsNullOrEmpty(levelCompare))
            return false;

        if (!Level.StartsWith(levelCompare))
            return false;

        var level = Level.Replace($"{levelCompare}.", "");
        if (level.Length <= 1)
            return false;

        return level.IndexOf('.', 0) == 0;
    }
    public bool IsRootLevel()
        => string.IsNullOrWhiteSpace(ParentId);
    public bool IsSubLevel()
        => string.IsNullOrWhiteSpace(ParentId) == false;
    public bool HasIcon()
        => string.IsNullOrWhiteSpace(Icon) == false;
    public bool HasHRef()
        => string.IsNullOrWhiteSpace(Href) == false;

    public int GetLevel()
        => Level.Count(p => p == '.');

    

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
    public bool IsParentSelected(Menu menu, string currentLevel)
    {
        if (!currentLevel.Contains('.'))
            return true;

        var hierarchyLevels = GetHierarchyLevels(currentLevel).Where(p => p != currentLevel).ToList();
        currentLevel = RemoveLastLevel(currentLevel);
        return menu.Items.Count(p => p.Selected && hierarchyLevels.Contains(p.Level)) > 0;        
    }
    private string RemoveLastLevel(string value)
    {
        int lastDotIndex = value.LastIndexOf('.');
        if (lastDotIndex != -1)
            return value.Substring(0, lastDotIndex);

        return value;

    }

}