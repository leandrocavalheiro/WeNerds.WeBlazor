
using WeNerds.WeBlazor.Enumarators;

namespace WeNerds.WeBlazor.Models;

public class GridItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ushort Order { get; set; }
    public int? Width { get; set; }
    public bool IsSortable { get; set; }
    public ICollection<BadgeItem> BadgesInfo { get; set; }
    public GridItem(string name, string description, ushort order, int width, bool isSortable)
    {
        Name = name;
        Description = description;
        Order = order;
        Width = width;
        IsSortable = isSortable;
    }
    public GridItem(string name, string description, ushort order, int? width = null, bool isSortable = false)
    {
        Name = name;
        Description = description;
        Order = order;
        Width = width;
        IsSortable = isSortable;
    }
    public void AddBadgeInfo(string originalValue, string showValue, BadgeStyleMenuEnum style, string className = "" )
    {
        BadgesInfo ??= new List<BadgeItem>();
        BadgesInfo.Add(new BadgeItem()
        {
            OriginalValue = originalValue,
            ShowValue = showValue,
            Style = style,
            ClassName = className
        });

    }
}
