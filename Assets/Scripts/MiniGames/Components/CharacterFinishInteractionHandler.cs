using UnityEngine;
using UnityEngine.Events;

public sealed class CharacterFinishInteractionHandler : MonoBehaviour
{
    [SerializeField] private Collider _finishTrigger;
    [SerializeField] private UnityEvent _onReachedFinish;

    private void OnTriggerEnter(Collider other)
    {
        if (other != _finishTrigger) return;
        
        _onReachedFinish.Invoke();
    }
}
