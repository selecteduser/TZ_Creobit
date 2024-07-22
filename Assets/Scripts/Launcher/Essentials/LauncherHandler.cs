using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

[Serializable]
public sealed class LauncherHandler
{
    [SerializeField] private AssetReferenceT<ScriptableObject> _overallMiniGamesData;

    [SerializeField] private SceneContainersHandler _containersHandler;
    [SerializeField] private Button _backToLauncherButton;
    
    private Dictionary<MiniGameData, AsyncOperationHandle<GameObject>?> _miniGamesContainers;

    public void Initialize(MiniGamesDisplayHandler displayHandler)
    {
        _containersHandler.Initialize();
        
        _backToLauncherButton.onClick.AddListener(_containersHandler.DestroyActiveMiniGameInstance);

        AddressablesUtility.LoadAsset(_overallMiniGamesData, (handler) =>
        {
            if (handler.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError("Failed to load overallMiniGamesData!");
                return;
            }

            var miniGamesData = handler.Result as OverallMiniGamesData;
            
            InitializeMiniGamesContainersDictionary(miniGamesData);
            displayHandler.DisplayMiniGames(miniGamesData);

            displayHandler.OnLoadPressed += LoadMiniGame;
            displayHandler.OnUnloadPressed += UnloadMiniGame;
            displayHandler.OnPlayPressed += PlayMiniGame;
        });
    }
    private void InitializeMiniGamesContainersDictionary(OverallMiniGamesData miniGamesData)
    {
        _miniGamesContainers = new Dictionary<MiniGameData, AsyncOperationHandle<GameObject>?>();
        foreach (var miniGame in miniGamesData.MiniGames)
        {
            miniGame.Initialize();
            _miniGamesContainers.Add(miniGame, null);
        }
    }
    private void LoadMiniGame(MiniGameData miniGameData)
    {
        AddressablesUtility.LoadAsset(miniGameData.Container, (handler) =>
        {
            if (handler.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError($"Failed to load {miniGameData.Title} container!");
                return;
            }
            _miniGamesContainers[miniGameData] = handler;
            miniGameData.Loaded = true;
        });
    }
    private void UnloadMiniGame(MiniGameData miniGameData)
    {
        if (!_miniGamesContainers[miniGameData].HasValue)
        {
            Debug.LogError($"Unexpected behaviour when unloading {miniGameData.Title} container, handler was null.");
            return;
        }
        Addressables.Release(_miniGamesContainers[miniGameData].Value);
        _miniGamesContainers[miniGameData] = null;
        miniGameData.Loaded = false;
    }
    private void PlayMiniGame(MiniGameData miniGameData)
    {
        if (!_miniGamesContainers[miniGameData].HasValue)
        {
            Debug.LogError($"Unexpected behaviour when instantiating {miniGameData.Title} container, handler was null.");
            return;
        }
        _containersHandler.InstantiateMiniGameContainer(_miniGamesContainers[miniGameData].Value.Result);
    }
}
