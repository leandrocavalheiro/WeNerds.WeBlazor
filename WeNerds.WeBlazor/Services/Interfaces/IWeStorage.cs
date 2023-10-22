using WeNerds.WeBlazor.Enumarators;

namespace WeNerds.WeBlazor.Services.Interfaces;

public interface IWeStorage
{
    TTypeData GetItem<TTypeData>(string key, StorageLocationEnum location = StorageLocationEnum.SessionStorage);
    Task<TTypeData> GetItemAsync<TTypeData>(string key, StorageLocationEnum location = StorageLocationEnum.SessionStorage);
    void SetItem<TTypeData>(string key, TTypeData value, StorageLocationEnum location = StorageLocationEnum.SessionStorage);
    Task SetItemAsync<TTypeData>(string key, TTypeData value, StorageLocationEnum location = StorageLocationEnum.SessionStorage);
    void RemoveItem(string key, StorageLocationEnum location = StorageLocationEnum.SessionStorage);
    Task RemoveItemAsync(string key, StorageLocationEnum location = StorageLocationEnum.SessionStorage);
    void ClearStorage(StorageLocationEnum location = StorageLocationEnum.SessionStorage);
    Task ClearStorageAsync(StorageLocationEnum location = StorageLocationEnum.SessionStorage);
}
