using System;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

public static class AddressablesUtility
{
    public static void LoadAsset<T>(AssetReferenceT<T> assetReference, Action<AsyncOperationHandle<T>> completedCallback) where T : Object
    {
        var loadingHandler = assetReference.LoadAssetAsync();
        loadingHandler.Completed += HandleCompletion;
        
        void HandleCompletion(AsyncOperationHandle<T> handler)
        {
            loadingHandler.Completed -= HandleCompletion;
            completedCallback?.Invoke(loadingHandler);
        }
    }
}
