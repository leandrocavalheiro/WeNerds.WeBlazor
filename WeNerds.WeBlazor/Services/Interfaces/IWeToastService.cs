using WeNerds.WeBlazor.Enumarators;

namespace WeNerds.WeBlazor.Services.Interfaces;

public interface IWeToastService
{
    public event Action<string, string, ToastTypeEnum> OnShow;
    public event Action OnHide;
    void ShowToast(string message, string title = "Information", ToastTypeEnum toastType = ToastTypeEnum.Information, int miliseconds = 5000);
}
