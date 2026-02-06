using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SkyboxManager : MonoBehaviour
{
    [SerializeField] private List<AssetReference> SkyboxMaterials;

    private AsyncOperationHandle<Material> operationHandle;


    public void SetSkybox(int index)
    {
        StartCoroutine(SetSkyboxInternal(index));
    }

    private IEnumerator SetSkyboxInternal(int index)
    {
        if (operationHandle.IsValid())
        {
            Addressables.Release(operationHandle);
        }

        AssetReference skyboxMaterialReference = SkyboxMaterials[index];
        operationHandle = skyboxMaterialReference.LoadAssetAsync<Material>();

        yield return operationHandle;
        RenderSettings.skybox = operationHandle.Result;
    }   
}
