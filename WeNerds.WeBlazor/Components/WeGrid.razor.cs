using Microsoft.AspNetCore.Components;
using System.Reflection;
using WeNerds.WeBlazor.Models;

namespace WeNerds.WeBlazor.Components;

public partial class WeGrid<TDataType> : ComponentBase
{
    [Parameter]
    public string Title { get; set; }
    [Parameter]
    public bool ShowTitle { get; set; } = true;
    [Parameter]
    public bool ShowHeaders { get; set; } = true;
    [Parameter]
    public bool EnableAdd { get; set; } = true;
    [Parameter]
    public bool EnableEdit { get; set; } = true;
    public bool EnableDelete { get; set; } = true;

    [Parameter]
    public ICollection<GridItem> Headers { get; set; }
    [Parameter]
    public ICollection<TDataType> Items { get; set; }

    [Parameter]
    public int MinimalRows { get; set; } = 5;

    private int _moreRows;
    private int _currentPage = 1;
    private int _totalPages = 4;
    private ICollection<TDataType> _showItems = new List<TDataType>();

    public WeGrid()
    {
       //  _moreRows = CompleteRows();
       // GetPage(_currentRow);
    }
    protected override void OnInitialized()
    {

    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            _moreRows = CompleteRows();
            GetPage(_currentPage);
        }
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
    private int CompleteRows()
    {
        if (MinimalRows <= 0 )
            return 0;

        if (Items == null)
            return MinimalRows;

        if (Items.Count > MinimalRows)
            return 0;

        return (MinimalRows - Items.Count);        
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
    private void GetPage(int page)
    {
        var skipRecords = page < 1 ? 0 : (page - 1);
        skipRecords *= MinimalRows;
        if (Items == null)
            _showItems = new List<TDataType>();
        else        
            _showItems = Items.Skip(skipRecords).Take(MinimalRows).ToList();

        _currentPage = page;

        StateHasChanged();
    }


}
