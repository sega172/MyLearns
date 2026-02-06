using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PrefabLoader : MonoBehaviour
{
    [SerializeField] AssetReference prefabRef;


    public void LoadPrefabPlease()
    {
        //Вариант 1.
        //LoadPrefab();

        //Вариант 2. Одной командой
        prefabRef.InstantiateAsync();
    }

    private async void LoadPrefab()
    {
        AsyncOperationHandle<GameObject> handle = prefabRef.LoadAssetAsync<GameObject>();
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject prefab = handle.Result;
            Instantiate(prefab);
            Addressables.Release(handle);
        }
    }
}
