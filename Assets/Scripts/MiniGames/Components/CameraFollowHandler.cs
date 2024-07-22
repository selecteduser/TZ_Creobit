using UnityEngine;

[RequireComponent(typeof(Camera))] // Must be put on camera
public sealed class CameraFollowHandler : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
    [SerializeField] private float _smoothAmount;
    
    private Vector3 _originalTargetPosition;
    private Vector3 _originalPosition;

    private void Awake()
    {
        _originalTargetPosition = _followTarget.transform.position;
        _originalPosition = transform.position;
    }
    private void LateUpdate() => UpdateCameraPosition();
    private void UpdateCameraPosition()
    {
        var delta = _followTarget.position - _originalTargetPosition;
        transform.position = Vector3.Slerp(transform.position, _originalPosition + delta, _smoothAmount);
    }
}
