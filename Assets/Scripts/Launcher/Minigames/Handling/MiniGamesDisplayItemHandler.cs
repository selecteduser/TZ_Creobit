using System;
using UnityEngine;

public sealed class MiniGamesDisplayItemHandler : MonoBehaviour
{
    private InteractableUIElementHandler _background;
    
    [SerializeField] private InteractableTextHandler _title;
    [SerializeField] private InteractableTextHandler _loadLabel;
    [SerializeField] private InteractableTextHandler _unloadLabel;
    [SerializeField] private InteractableTextHandler _playLabel;
    
    private MiniGamesDisplayItemLabelsHandler _labelsHandler;
    private MiniGameData _miniGameData;

    public event Action OnLoadPressed;
    public event Action OnUnloadPressed;
    public event Action OnPlayPressed;
    
    public void SetTitle(string title) => _title.Text.text = title;
    public void Initialize(InteractableUIElementHandler background, MiniGameData miniGameData)
    {
        _background = background;
        _miniGameData = miniGameData;
        
        InitializeDisplayHandler();
        InitializeLabels();
        InitializeLabelsInteractions();
    }
    private void InitializeDisplayHandler()
    {
        _labelsHandler = new MiniGamesDisplayItemLabelsHandler(_title.gameObject, _loadLabel.gameObject, _unloadLabel.gameObject, _playLabel.gameObject);
    }
    private void InitializeLabels()
    {
        _title.Initialize();
        _loadLabel.Initialize();
        _unloadLabel.Initialize();
        _playLabel.Initialize();
        
        _labelsHandler.HideAvailableActions();
    }
    private void InitializeLabelsInteractions()
    {
        _miniGameData.OnLoadStatusChanged += _labelsHandler.RefreshAvailableActions;
        
        _title.OnMouseOver += () => _labelsHandler.DisplayAvailableActions(_miniGameData.Loaded);

        _loadLabel.OnMouseClick += () => OnLoadPressed?.Invoke();
        _unloadLabel.OnMouseClick += () => OnUnloadPressed?.Invoke();
        _playLabel.OnMouseClick += () => OnPlayPressed?.Invoke();
        
        _background.OnMouseOver += _labelsHandler.DisplayDefaultMiniGamePanel;
    }
}
