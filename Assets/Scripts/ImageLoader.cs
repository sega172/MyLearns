using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{

    [SerializeField] private Image image;
    [SerializeField] private AssetReference spriteRef;

    public void PleaseLoadImage()
    {
        LoadImage();
    }


    async void LoadImage()
    {
        AsyncOperationHandle<Sprite> handle = spriteRef.LoadAssetAsync<Sprite>();
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            image.sprite = handle.Result;
            Addressables.Release(handle);
        }
    }
}
