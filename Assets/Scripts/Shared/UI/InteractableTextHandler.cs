using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public sealed class InteractableTextHandler : InteractableUIElementHandler
{
    [field: SerializeField] public Text Text { get; private set; }

    public void Initialize()
    {
        Text = GetComponent<Text>();
    }
}
