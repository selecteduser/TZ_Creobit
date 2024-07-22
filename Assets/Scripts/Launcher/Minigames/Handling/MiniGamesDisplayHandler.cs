using System;
using UnityEngine;

public class MiniGamesDisplayHandler : MonoBehaviour
{
    [SerializeField] private InteractableUIElementHandler _background;
    [SerializeField] private GameObject _miniGameDisplayedItem;

    public event Action<MiniGameData> OnLoadPressed;
    public event Action<MiniGameData> OnUnloadPressed;
    public event Action<MiniGameData> OnPlayPressed;
    
    public void DisplayMiniGames(OverallMiniGamesData data)
    {
        foreach (var miniGameData in data.MiniGames)
        {
            CreateDisplayedMiniGameItem(miniGameData);
        }
    }
    private void CreateDisplayedMiniGameItem(MiniGameData miniGameData)
    {
        var itemInstance = Instantiate(_miniGameDisplayedItem, transform, false);

        var itemHandler = itemInstance.GetComponent<MiniGamesDisplayItemHandler>();
        itemHandler.Initialize(_background, miniGameData);
        itemHandler.SetTitle(miniGameData.Title);

        itemHandler.OnLoadPressed += () => OnLoadPressed?.Invoke(miniGameData);
        itemHandler.OnUnloadPressed += () => OnUnloadPressed?.Invoke(miniGameData);
        itemHandler.OnPlayPressed += () => OnPlayPressed?.Invoke(miniGameData);
    }
}
