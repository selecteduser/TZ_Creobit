using UnityEngine;

[CreateAssetMenu(fileName = "Overall Mini Games Data", menuName = "Overall Mini Games Data")]
public sealed class OverallMiniGamesData : ScriptableObject
{
    [SerializeField] private MiniGameData[] _miniGames;
    
    public MiniGameData[] MiniGames => _miniGames;
}
