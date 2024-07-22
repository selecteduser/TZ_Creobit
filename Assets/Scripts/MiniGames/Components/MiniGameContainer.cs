using UnityEngine;

public sealed class MiniGameContainer : MonoBehaviour
{
    [SerializeField] private GameObject _uiContainer;
    [SerializeField] private GameObject _worldContainer;

    public GameObject UIContainer => _uiContainer;
    public GameObject WorldContainer => _worldContainer;
}
