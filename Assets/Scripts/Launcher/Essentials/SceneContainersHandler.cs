using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

[Serializable]
public sealed class SceneContainersHandler
{
    [SerializeField] private Transform _canvas;
    [SerializeField] private Transform _world;

    [SerializeField] private GameObject _launcherMenuContainer;
    [SerializeField] private GameObject _overlay;

    private MiniGameContainer _activeContainerInstance;
    
    public void Initialize()
    {
        _overlay.SetActive(false);
    }
    public void InstantiateMiniGameContainer(GameObject container)
    {
        ToggleLauncherMenu(false);

        _activeContainerInstance = Object.Instantiate(container).GetComponent<MiniGameContainer>();
        
        var uiContainer = _activeContainerInstance.UIContainer;
        if (uiContainer != null) uiContainer.transform.SetParent(_canvas.transform, true);
        
        var worldContainer = _activeContainerInstance.WorldContainer;
        if (worldContainer != null) worldContainer.transform.SetParent(_world.transform, false);
    }
    public void ToggleLauncherMenu(bool status)
    {
        _launcherMenuContainer.SetActive(status);
        _overlay.SetActive(!status);
    }
    public void DestroyActiveMiniGameInstance()
    {
        Addressables.ReleaseInstance(_activeContainerInstance.gameObject);
        if (_activeContainerInstance.UIContainer != null) Object.Destroy(_activeContainerInstance.UIContainer);
        if (_activeContainerInstance.WorldContainer != null) Object.Destroy(_activeContainerInstance.WorldContainer);
        Object.Destroy(_activeContainerInstance.gameObject);

        ToggleLauncherMenu(true);
    }
}
