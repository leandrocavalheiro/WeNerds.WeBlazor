using WeNerds.WeBlazor.Enumarators;

namespace WeNerds.WeBlazor.Models;

public class BadgeItem
{
    public string OriginalValue { get; set; }
    public string ShowValue { get; set; }
    public BadgeStyleMenuEnum Style { get; set; } = BadgeStyleMenuEnum.Information;
    public string ClassName { get; set; }
}
