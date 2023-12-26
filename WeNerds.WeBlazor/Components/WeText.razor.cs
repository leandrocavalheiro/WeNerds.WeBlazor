using Microsoft.AspNetCore.Components;

namespace WeNerds.WeBlazor.Components;

public partial class WeText<TDataType> : ComponentBase
{
    [Parameter]
    public byte Columns { get; set; }
    [Parameter]
    public byte MarginBotton { get; set; }
    [Parameter]
    public string Id { get; set; }
    [Parameter]
    public string Placeholder { get; set; }
    [Parameter]
    public string TypeField { get; set; }
    [Parameter]
    public string CustomClass { get; set; }
    [Parameter]
    public string Label { get; set; }
    [Parameter]
    public bool Required { get; set; }
    [Parameter]
    public string MessageValidation { get; set; }
    [Parameter]
    public bool Disabled { get; set; }
    [Parameter]
    public bool AutoComplete { get; set; }

    [Parameter]
    public TDataType Value { get; set; }

    [Parameter]
    public EventCallback<TDataType> ValueChanged { get; set; }


    private string GetClassColumns()
    {
        var result = "we-input ";
        switch (Columns)
        {
            case <= 0:
                result += "col-3";
                break;
            case >= 12:
                result += "col-12";
                break;
            default:
                result += $"col-{Columns}";
                break;
        }

        return $"{result} {GetClassMarginBottom()}";
    }

    private string GetClassMarginBottom()
    {
        if (MarginBotton <= 0)
            return "mb-3";

        if (MarginBotton >= 5)
            return "mb-5";

        return $"mb-{MarginBotton}";
    }



    private async Task SetValueAsync(TDataType value)
    {
        Value = value;
        await ValueChanged.InvokeAsync(value);
    }

    private string GetLabel()
        => string.IsNullOrEmpty(Label) ? "Label" : Label;
    private string GetId()
        => string.IsNullOrEmpty(Id) ? $"{Guid.NewGuid}" : Id;
    private string GetDisabledAttribute()
        => Disabled ? "disabled" : null;
    private string GetAutoComplete()
        => AutoComplete ? "on" : "new-password";
    private string GetClass()
        => string.IsNullOrEmpty(CustomClass) ? "we-input-text" : CustomClass;
    public WeText()
    {
        TypeField = "text";
        Id = Guid.NewGuid().ToString();
    }
}
