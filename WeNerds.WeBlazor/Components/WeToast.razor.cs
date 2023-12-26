using Microsoft.AspNetCore.Components;
using WeNerds.WeBlazor.Enumarators;


namespace WeNerds.WeBlazor.Components;

public partial class WeToast : ComponentBase
{
    [Parameter]
    public ToastTypeEnum ToastType { get; set; } = ToastTypeEnum.Information;

    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public string Text { get; set; }

    [Parameter]
    public string Icon { get; set; }

    [Parameter]
    public int TimerInMiliseconds { get; set; } = 5000;



    private string _heading;
    private string _message;
    private bool _isVisible;
    private string _backgroundCssClass;
    private string _iconCssClass;

    public WeToast()
    {

    }


    protected override void OnInitialized()
    {
        _weToastService.OnShow += ShowToast;
        _weToastService.OnHide += HideToast;
    }




    private string GetClass()
    {
        var isVisible = _isVisible ? "we-toast-visible" : "we-toast-hide";

        switch (ToastType.ToString())
        {
            case $"{nameof(ToastTypeEnum.Success)}":
                return $"we-toast-success {isVisible}";
            case $"{nameof(ToastTypeEnum.Warning)}":
                return $"we-toast-warning {isVisible}";
            case $"{nameof(ToastTypeEnum.Error)}":
                return $"we-toast-error {isVisible}";
            default:
                return $"we-toast {isVisible}";

        }
    }

    private string GetIcon()
    {
        if (!string.IsNullOrWhiteSpace(Icon))
            return Icon;
        
        switch (ToastType.ToString())
        {
            case $"{nameof(ToastTypeEnum.Success)}":
                return "check_circle";
            case $"{nameof(ToastTypeEnum.Warning)}":
                return "warning";
            case $"{nameof(ToastTypeEnum.Error)}":
                return "error";
            default:
                return "info";

        }
    }


    private void ShowToast(string message, string title = "Information",  ToastTypeEnum toastType = ToastTypeEnum.Information)
    {
        Title = title;
        Text = message;
        ToastType = toastType;
        _isVisible = true;
        StateHasChanged();
    }

    private void HideToast()
    {
        _isVisible = false;
        StateHasChanged();
    }

    

    void IDisposable.Dispose()
    {
        _weToastService.OnShow -= ShowToast;
        _weToastService.OnHide -= HideToast;
    }
    private void BuildToastSettings(ToastTypeEnum toastType, string message)
    {
        switch (toastType)
        {
            case ToastTypeEnum.Information:
                _backgroundCssClass = $"bg-info";
                _iconCssClass = "info";
                _heading = "Info";
                break;
            case ToastTypeEnum.Success:
                _backgroundCssClass = $"bg-success";
                _iconCssClass = "check";
                _heading = "Success";
                break;
            case ToastTypeEnum.Warning:
                _backgroundCssClass = $"bg-warning";
                _iconCssClass = "exclamation";
                _heading = "Warning";
                break;
            case ToastTypeEnum.Error:
                _backgroundCssClass = "bg-danger";
                _iconCssClass = "times";
                _heading = "Error";
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(toastType), toastType, null);
        }
        Console.WriteLine($"BuildToastSettings: {nameof(toastType)} - {message}");
        Text = message;
        ToastType = toastType;
    }
}
