using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed class CharacterMovementHandler : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;

    [SerializeField] private float _moveSpeed;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        var movementDirection = _inputHandler.InputDirection.normalized;
        _rigidbody.velocity = new Vector3(movementDirection.x, 0f, movementDirection.y) * _moveSpeed;
    }
}
