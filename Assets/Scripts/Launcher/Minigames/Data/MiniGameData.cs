using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
public sealed class MiniGameData
{
    [SerializeField] private string _title;
    [SerializeField] private AssetReferenceT<GameObject> _container;
    
    public string Title => _title;
    public AssetReferenceT<GameObject> Container => _container;

    private bool _loaded;
    public bool Loaded
    {
        get => _loaded;
        set
        {
            _loaded = value;
            OnLoadStatusChanged?.Invoke(_loaded);
        }
    }

    public event Action<bool> OnLoadStatusChanged;
    
    public override int GetHashCode()
    {
        return _title.GetHashCode() + _container.GetHashCode();
    }
    public void Initialize()
    {
        _loaded = false;
    }
}
