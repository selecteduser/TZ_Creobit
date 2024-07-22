using UnityEngine;

public sealed class BootHandler : MonoBehaviour
{
    [SerializeField] private LauncherHandler launcherHandler;
    [SerializeField] private MiniGamesDisplayHandler _displayHandler;
    
    private void Awake()
    {
        launcherHandler.Initialize(_displayHandler);
    }
}
