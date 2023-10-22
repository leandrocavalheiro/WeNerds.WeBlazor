using Microsoft.JSInterop;
using WeNerds.WeBlazor.Enumarators;
using WeNerds.WeBlazor.Services.Interfaces;

namespace WeNerds.WeBlazor.Services.Implementations;

public class WeStorage : IWeStorage
{
    private readonly IJSRuntime _jsRuntime;
    public WeStorage(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    /// <summary>
    /// Limpa o storage. <br>
    /// *** Prefira utilizar a versão Async desse método
    /// </summary>
    /// <param name="location">Qual storage buscar: Local ou Session</param>
    public void ClearStorage(StorageLocationEnum location = StorageLocationEnum.SessionStorage)
    {
        var functionName = "sessionStorage.clear";
        if (location == StorageLocationEnum.LocalStorage)        
            functionName = "localStorage.clear";

        Task.Run(async () => await _jsRuntime.InvokeVoidAsync(functionName));
    }

    /// <summary>
    /// Limpa o storage.
    /// </summary>
    /// <param name="location">Qual storage buscar: Local ou Session</param>
    public async Task ClearStorageAsync(StorageLocationEnum location = StorageLocationEnum.SessionStorage)
    {
        var functionName = "sessionStorage.clear";
        if (location == StorageLocationEnum.LocalStorage)
            functionName = "localStorage.clear";

        await _jsRuntime.InvokeVoidAsync(functionName);
    }

    /// <summary>
    /// Busca valor no storage e já converte para o tipo desejado. <br>
    /// *** Prefira utilizar a versão Async desse método
    /// </summary>
    /// <typeparam name="TTypeData"></typeparam>
    /// <param name="key">Chave a ser pesquisada no Storage</param>
    /// <param name="location">Qual storage buscar: Local ou Session</param>
    /// <returns></returns>
    public TTypeData GetItem<TTypeData>(string key, StorageLocationEnum location = StorageLocationEnum.SessionStorage)
    {
        var task = Task.Run(async () => await GetItemAsync<TTypeData>(key, location)); 
        task.Wait();
        return task.Result;
    }

    /// <summary>
    /// Busca valor no storage e já converte para o tipo desejado.
    /// </summary>
    /// <typeparam name="TTypeData"></typeparam>
    /// <param name="key">Chave a ser pesquisada no Storage</param>
    /// <param name="location">Qual storage buscar: Local ou Session</param>
    /// <returns></returns>
    public async Task<TTypeData> GetItemAsync<TTypeData>(string key, StorageLocationEnum location = StorageLocationEnum.SessionStorage)
    {
        try
        {
            var functionName = "sessionStorage.getItem";
            if (location == StorageLocationEnum.LocalStorage)
                functionName = "localStorage.getItem";

            var result = await _jsRuntime.InvokeAsync<TTypeData>(functionName, key);
            return result;
        }
        catch (Exception exception)
        {

            throw;
        }        
    }

    /// <summary>
    /// Remove um item da storage. <br>
    /// *** Prefira utilizar a versão Async desse método
    /// </summary>
    /// <param name="key">Chave a ser removida</param>
    /// <param name="location">Qual storage buscar: Local ou Session</param>
    public void RemoveItem(string key, StorageLocationEnum location = StorageLocationEnum.SessionStorage)
    {
        var task = Task.Run(async () => await RemoveItemAsync(key, location));
        task.Wait();
    }
    /// <summary>
    /// Remove um item da storage.
    /// </summary>
    /// <param name="key">Chave a ser removida</param>
    /// <param name="location">Qual storage buscar: Local ou Session</param>
    public async Task RemoveItemAsync(string key, StorageLocationEnum location = StorageLocationEnum.SessionStorage)
    {
        var functionName = "sessionStorage.removeItem";
        if (location == StorageLocationEnum.LocalStorage)
            functionName = "localStorage.removeItem";

        await _jsRuntime.InvokeVoidAsync(functionName, key);
    }

    /// <summary>
    /// Grava um valor no storage <br>
    /// *** Prefira utilizar a versão Async desse método
    /// </summary>
    /// <typeparam name="TSourceType"></typeparam>
    /// <param name="key">Nome da chave a ser gravada</param>
    /// <param name="value">Valor a ser gravado</param>
    /// <param name="location">Qual storage buscar: Local ou Session</param>
    /// <returns></returns>
    public void SetItem<TSourceType>(string key, TSourceType value, StorageLocationEnum location = StorageLocationEnum.SessionStorage)
    {
        var task = Task.Run(async () => await SetItemAsync<TSourceType>(key, value, location));
        task.Wait();        
    }

    /// <summary>
    /// Grava um valor no storage
    /// </summary>
    /// <typeparam name="TSourceType"></typeparam>
    /// <param name="key">Nome da chave a ser gravada</param>
    /// <param name="value">Valor a ser gravado</param>
    /// <param name="location">Qual storage buscar: Local ou Session</param>
    /// <returns></returns>
    public async Task SetItemAsync<TSourceType>(string key, TSourceType value, StorageLocationEnum location = StorageLocationEnum.SessionStorage)
    {
        var functionName = "sessionStorage.setItem";
        if (location == StorageLocationEnum.LocalStorage)
            functionName = "localStorage.setItem";
        
        await _jsRuntime.InvokeVoidAsync(functionName, key, value);
    }
}
