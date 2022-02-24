using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _offset;

    private Vector3 _velocity;

    private void Start()
    {
        transform.position = _target.position + _offset;
    }
    private void FixedUpdate()
    { 
        Move();
    }

    private void Move()
    {
        var cameraPosition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, cameraPosition, ref _velocity, _speed);
    }
}
