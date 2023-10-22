using Microsoft.AspNetCore.Components;
using WeNerds.WeBlazor.Enumarators;

namespace WeNerds.WeBlazor.Components;

public partial class WePagination : ComponentBase
{
    [Parameter]
    public int TotalPages { get; set; }
    [Parameter]
    public int CurrentPage { get; set; }
    [Parameter]
    public EventCallback<int> OnClick { get; set; }
    public WePagination()
    {

    }
    private string GetPages()
    {
        if (TotalPages == 0)
            return "Página 1 de 1";

        return $"Página {CurrentPage} de {TotalPages}";                       
    }
    private async Task Clicked(SelectedPageEnum selectedPage)
    {

        switch (selectedPage)
        {
            case SelectedPageEnum.First:
                CurrentPage = 1;
                break;
            case SelectedPageEnum.Previous:
                CurrentPage--;
                break;
            case SelectedPageEnum.Next:
                CurrentPage++;
                break;
            case SelectedPageEnum.Last:
                CurrentPage = TotalPages;
                break;
            default:
                break;
        }

        if (CurrentPage <= 0)
            CurrentPage = 1;

        if (CurrentPage > TotalPages)
            CurrentPage = TotalPages;

        GetPages();
        StateHasChanged();
        await OnClick.InvokeAsync(CurrentPage);
    }
}
