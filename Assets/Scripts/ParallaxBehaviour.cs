using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _followingTarget;
    [SerializeField, Range(0, 1)] private float _parallaxStrenght;
    [SerializeField] private bool _disableVerticalParallax;

    private Vector3 _lastTargetPosition;

    private void Start()
    {
        if(_followingTarget == null)
            _followingTarget = Camera.main.transform;

        _lastTargetPosition = _followingTarget.position;
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var delta = _followingTarget.position - _lastTargetPosition;

        if (_disableVerticalParallax)
            delta.y = 0;

        _lastTargetPosition = _followingTarget.position;
        transform.position += delta * _parallaxStrenght;
    }
}
