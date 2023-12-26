using System.Timers;
using WeNerds.WeBlazor.Enumarators;
using WeNerds.WeBlazor.Services.Interfaces;
using Timer = System.Timers.Timer;

namespace WeNerds.WeBlazor.Services.Implementations;

public class WeToastService : IWeToastService, IDisposable
{
    public event Action<string, string, ToastTypeEnum> OnShow;
    public event Action OnHide;
    private Timer _countdown;
    private int _miliseconds;

    public void ShowToast(string message, string title = "Information", ToastTypeEnum toastType = ToastTypeEnum.Information, int miliseconds = 5000)
    {
        _miliseconds = miliseconds;
        OnShow?.Invoke(message, title, toastType);
        StartCountdown();
    }

    private void StartCountdown()
    {
        SetCountdown();

        if (_countdown!.Enabled)
        {
            _countdown.Stop();
            _countdown.Start();
        }
        else
        {
            _countdown!.Start();
        }
    }

    private void SetCountdown()
    {
        if (_countdown != null) 
            return;

        _countdown = new Timer(_miliseconds);
        _countdown.Elapsed += HideToast;
        _countdown.AutoReset = false;
    }

    private void HideToast(object? source, ElapsedEventArgs args)
        => OnHide?.Invoke();

    public void Dispose()
        => _countdown?.Dispose();
}
