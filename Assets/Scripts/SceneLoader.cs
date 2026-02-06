using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AddressablesLearn
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private AssetReference SceneRef;

        public void LoadScenePlease() => SceneRef.LoadSceneAsync();
    }
}
