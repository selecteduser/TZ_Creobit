using UnityEngine;

public sealed class InputHandler : MonoBehaviour
{
    public Vector2 InputDirection { get; private set; }

    private void Update() => UpdateInputDirection();
    private void UpdateInputDirection()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        
        InputDirection = new Vector2(x, y);
    }
}
