using Microsoft.AspNetCore.Components;
using System.Reflection;
using WeNerds.WeBlazor.Models;


namespace WeNerds.WeBlazor.Components;

public partial class WeGridRow<TDataType> : ComponentBase
{
    [Parameter]
    public int RowNumber { get; set; }
    [Parameter]
    public TDataType Item { get; set; }
    [Parameter]
    public ICollection<GridItem> Headers { get; set; }
    [Parameter]
    public EventCallback<int> OnClick { get; set; }
    [Parameter]
    public bool IsSelected { get; set; }

    public WeGridRow()
    {

    }
    public string GetFieldValue(string field, object obj)
    {
        try
        {
            if (string.IsNullOrEmpty(field))
                return "";

            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.Name.ToLower() == field.ToLower())
                {
                    object value = obj.GetType().GetProperty(property.Name).GetValue(obj, null);
                    if (value != null)
                        return GetValue(field, value);
                }
            }
            return "";
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private string GetValue(string field, object defaultValue)
    {
        //TODO Implementar Badge
        //Ajustar para valoers genéricos
        //if (BadgeList != null && BadgeList.Length > 0)
        //{
        //    var index = Array.IndexOf(BadgeList, field);
        //    string resultList = string.Empty;
        //    if (index >= 0 && BadgeListExibitionValue.Length >= index)
        //        resultList = BadgeListExibitionValue[index];
        //    if (!string.IsNullOrEmpty(resultList))
        //    {
        //        var result = resultList.Split('|');
        //        if (defaultValue.ToString().ToLower() == "true")
        //            return result[0];

        //        return result[1];
        //    }
        //}


        return defaultValue.ToString();
    }
    private string GetClassField(GridItem currentItem, string value)
    {
        if (currentItem.BadgesInfo != null && currentItem.BadgesInfo.Count > 0)
        {
            var currentBadge = currentItem.BadgesInfo.FirstOrDefault(p => p.OriginalValue.ToLower() == value.ToLower()) ?? new BadgeItem();
            switch (currentBadge.Style)
            {
                case Enumarators.BadgeStyleMenuEnum.Sucess:
                    return "badge badge-bg-success text-success";
                case Enumarators.BadgeStyleMenuEnum.Warning:
                    return "badge badge-bg-warning text-warning";
                case Enumarators.BadgeStyleMenuEnum.Error:
                    return "badge badge-bg-error text-danger";
                case Enumarators.BadgeStyleMenuEnum.Custom:
                    return currentBadge.ClassName;
                default:
                    return "badge badge-bg-information text-information";
            }
        }

        return "";
    }
    private string GetValueBadge(GridItem currentItem, string value)
    {
        if (currentItem.BadgesInfo == null || currentItem.BadgesInfo.Count <= 0)
            return value;

        var currentBadge = currentItem.BadgesInfo.FirstOrDefault(p => p.OriginalValue.ToLower() == value.ToLower()) ?? new BadgeItem();
        if (currentBadge == null)
            return value;

        return currentBadge.ShowValue;
    }
    private async Task RowClickedAsync()
    {
        await OnClick.InvokeAsync(RowNumber);
    }
    private string GetClassColumnAccent()
    {
        var result = "we-grid-column-accent";
        if (IsSelected)
            result += "-active";

        return result;
    }


}
