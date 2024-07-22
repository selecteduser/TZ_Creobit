using UnityEngine;

public sealed class MiniGamesDisplayItemLabelsHandler
{
    private readonly GameObject _title;
    private readonly GameObject _loadLabel;
    private readonly GameObject _unloadLabel;
    private readonly GameObject _playLabel;
    private readonly StateMachineHandler _miniGameHandlerStateMachine;

    public MiniGamesDisplayItemLabelsHandler(GameObject title, GameObject loadLabel, GameObject unloadLabel, GameObject playLabel)
    {
        _title = title;
        _loadLabel = loadLabel;
        _unloadLabel = unloadLabel;
        _playLabel = playLabel;
    }
    public void DisplayAvailableActions(bool loadedStatus)
    {
        _title.SetActive(false);
        HideAvailableActions(); // Refresh so previously available action is not displayed;

        if (loadedStatus) DisplayLoadedMiniGameActions();
        else DisplayUnloadedMiniGameActions();
    }
    public void RefreshAvailableActions(bool loadedStatus)
    {
        if (_title.activeInHierarchy) return;
        DisplayAvailableActions(loadedStatus);
    }
    public void DisplayUnloadedMiniGameActions()
    {
        _loadLabel.SetActive(true);
    }
    public void DisplayLoadedMiniGameActions()
    {
        _unloadLabel.SetActive(true);
        _playLabel.SetActive(true);
    }
    public void DisplayDefaultMiniGamePanel()
    {
        HideAvailableActions();
        _title.SetActive(true);
    }
    public void HideAvailableActions()
    {
        _loadLabel.SetActive(false);
        _unloadLabel.SetActive(false);
        _playLabel.SetActive(false);
    }
}
